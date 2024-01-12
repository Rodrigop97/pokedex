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
        Pokemon poke = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["n"] != null)
                {
                    PokemonNegocio negocioPokemon = new PokemonNegocio();
                    poke = negocioPokemon.listarSP().Find(x => x.Id == int.Parse(Request.QueryString["n"]));
                }

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
                //    PokemonNegocio negocioPokemon = new PokemonNegocio();
                //    poke = negocioPokemon.listarSP().Find(x => x.Id == int.Parse(Request.QueryString["n"]));
                    //Pokemon selected = negocioPokemon.listarSP().Find(x => x.Id == int.Parse(Request.QueryString["n"]));
                    txtNumero.Text = poke.Numero.ToString();
                    txtNombre.Text = poke.Nombre;
                    txtDescripcion.Text = poke.Descripcion;
                    txtUrlImagen.Text = poke.UrlImagen;
                    imgPokemon.ImageUrl = poke.UrlImagen;
                    ddlTipo.SelectedValue = poke.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = poke.Debilidad.Id.ToString();
                    btnCambiarActivacion.Text = poke.Activo ? "Desactivar" : "Activar";
                    btnCambiarActivacion.Visible = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            if (poke == null)
                poke = new Pokemon();
            //Pokemon poke = new Pokemon();
            //poke.Id = int.Parse(Request.QueryString["n"]);
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

        protected void cambiarActivacion_Click(object sender, EventArgs e)
        {
            poke.Activo = !poke.Activo;
            PokemonNegocio pNegocio = new PokemonNegocio();
            pNegocio.modificarSP(poke);
            Response.Redirect("Default.aspx");
        }
    }
}