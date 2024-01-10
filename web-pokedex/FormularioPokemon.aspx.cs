using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_pokedex
{
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio datos = new ElementoNegocio();
                    ddlTipo.DataSource = datos.listar();
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();
                    ddlDebilidad.DataSource = datos.listar();
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }
                if (Request.QueryString["n"] != null && !IsPostBack)
                {
                    PokemonNegocio negocioPokemon = new PokemonNegocio();
                    Pokemon selected = negocioPokemon.listarSP().Find(x => x.Id == int.Parse(Request.QueryString["n"]));
                    txtNumero.Text = selected.Numero.ToString();
                    txtNombre.Text = selected.Nombre;
                    txtDescripcion.Text = selected.Descripcion;
                    txtUrlImagen.Text = selected.UrlImagen;
                    imgPokemon.ImageUrl = selected.UrlImagen;
                    ddlTipo.SelectedValue = selected.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = selected.Debilidad.Id.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Pokemon poke = new Pokemon();
            poke.Id = int.Parse(Request.QueryString["n"]);
            poke.Numero = int.Parse(txtNumero.Text);
            poke.Nombre = txtNombre.Text.ToString();
            poke.Descripcion = txtDescripcion.Text.ToString();
            poke.UrlImagen = txtUrlImagen.Text.ToString();

            ElementoNegocio datos = new ElementoNegocio();
            List<Elemento> elementos = datos.listar();
            Elemento tipo = new Elemento();
            tipo = elementos.Find(x => x.Id == int.Parse(ddlTipo.SelectedValue));
            poke.Tipo = tipo;
            Elemento debilidad = new Elemento();
            debilidad = elementos.Find(x => x.Id == int.Parse(ddlDebilidad.SelectedValue));
            poke.Debilidad = debilidad;

            PokemonNegocio pNegocio = new PokemonNegocio();
            if (Request.QueryString["n"] != null)
                pNegocio.modificarSP(poke);
            else
                pNegocio.agregarSP(poke);
            Response.Redirect("Default.aspx");
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {

            imgPokemon.ImageUrl = txtUrlImagen.Text.ToString();
        }
    }
}