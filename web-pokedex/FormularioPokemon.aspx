<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="web_pokedex.Agregar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agregar pokemon</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scriptManager" />
        <div class="container">
            <div class="col-6">
                <div class="row mt-4">
                    <h2 class="col align-self-start">Nuevo Pokemon</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="col-md-12">
                        <label for="txtNumero" class="form-label">Numero</label>
                        <asp:TextBox runat="server" TextMode="Number" ID="txtNumero" CssClass="form-control" />
                    </div>
                    <div class="col-md-12">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>
                    <div class="col-12">
                        <label for="txtDescripcion" class="form-label">Descripcion</label>
                        <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                    <div class="col-6">
                        <label for="ddlTipo" class="form-label">Tipo</label>
                        <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <label for="ddlDebilidad" class="form-label">Debilidad</label>
                        <asp:DropDownList runat="server" ID="ddlDebilidad" CssClass="form-select"></asp:DropDownList>
                    </div>

                </div>
                <div class="col-6">
                    <div class="col-md-12">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <label for="txtUrlImagen" class="form-label">Url de imagen</label>
                                <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control col-6" AutoPostBack="true"
                                    OnTextChanged="txtUrlImagen_TextChanged" />
                                <div class="col-md-12">
                                    <asp:Image ImageUrl="https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg"
                                        runat="server" ID="imgPokemon" CssClass="mt-4 img-thumbnail col-mt-auto col-lg-6" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 mt-3">
                    <% if (Request.QueryString["index"] != null)
                        {
                    %>
                    <asp:Button Text="Guardar" runat="server" CssClass="btn btn-primary" />
                    <%}
                        else
                        {
                    %>
                    <asp:Button Text="Aceptar" OnClick="Aceptar_Click" runat="server" CssClass="btn btn-primary" />
                    <asp:Button OnClick="cambiarActivacion_Click" ID="btnCambiarActivacion" runat="server" CssClass="btn btn-warning" Visible="false" />
                    <%} %>
                    <a href="Default.aspx">Cancelar</a>
                    
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
