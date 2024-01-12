<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listaPokemons.aspx.cs" Inherits="web_pokedex.listaPokemons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="gvPokemons" AutoGenerateColumns="false" CssClass="table table-bordered table-striped border-dark-subtle mt-3" 
        OnSelectedIndexChanged="gvPokemons_SelectedIndexChanged" AllowPaging="true" PageSize="8"
        OnPageIndexChanging="gvPokemons_PageIndexChanging" >
        <Columns>
            <asp:BoundField DataField="Id" HeaderStyle-CssClass="d-none" ItemStyle-CssClass="d-none" />
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField ShowSelectButton="true" SelectText="Editar" />
        </Columns>
    </asp:GridView>
    <a href="FormularioPokemon.aspx" class="btn btn-primary" >Agregarr</a>
</asp:Content>
