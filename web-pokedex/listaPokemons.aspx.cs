﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_pokedex
{
    public partial class listaPokemons : System.Web.UI.Page
    {
        List<Pokemon> listaPokemon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PokemonNegocio datos = new PokemonNegocio();
                listaPokemon = datos.listarSP();
                gvPokemons.DataSource = listaPokemon;
                gvPokemons.DataBind();
            }
        }

        protected void gvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = int.Parse(gvPokemons.Rows[gvPokemons.SelectedIndex].Cells[0].Text.ToString());
            Response.Redirect("FormularioPokemon.aspx?n="+num);
        }
    }
}