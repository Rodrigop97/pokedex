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
                if (Request.QueryString["n"] != null)
                {
                    PokemonNegocio negocioPokemon = new PokemonNegocio();
                    Pokemon selected = negocioPokemon.listarSP().Find(x => x.Numero == int.Parse(Request.QueryString["n"]));
                    txtNumero.Text = selected.Numero.ToString();
                    txtNombre.Text = selected.Nombre;
                    txtDescripcion.Text = selected.Descripcion;
                    txtUrlImagen.Text = selected.UrlImagen;
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
            Pokemon nuevo = new Pokemon();
            nuevo.Numero = int.Parse(txtNumero.Text);
            nuevo.Nombre = txtNombre.Text.ToString();
            nuevo.Descripcion = txtDescripcion.Text.ToString();
            nuevo.UrlImagen = txtUrlImagen.Text.ToString();

            ElementoNegocio datos = new ElementoNegocio();
            List<Elemento> elementos = datos.listar();
            Elemento tipo = new Elemento();
            tipo = elementos.Find(x => x.Id == int.Parse(ddlTipo.SelectedValue));
            nuevo.Tipo = tipo;
            Elemento debilidad = new Elemento();
            debilidad = elementos.Find(x => x.Id == int.Parse(ddlDebilidad.SelectedValue));
            nuevo.Debilidad = debilidad;

            PokemonNegocio pNegocio = new PokemonNegocio();
            pNegocio.agregarSP(nuevo);
            Response.Redirect("Default.aspx");
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {

            imgPokemon.ImageUrl = txtUrlImagen.Text.ToString();
        }
    }
}