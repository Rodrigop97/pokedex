using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_pokedex
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.ToString().Contains("Default"))
                aHome.Attributes["class"] = "nav-link active";
            if (Request.Url.ToString().Contains("listaPokemons"))
                aListaPokemon.Attributes["class"] = "nav-link active";
        }
    }
}