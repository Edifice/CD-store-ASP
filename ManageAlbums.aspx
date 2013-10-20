<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageAlbums.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Artist" HeaderText="Artist" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>
    </asp:GridView>

    <h2>Add Album</h2>

    <label>Title</label>
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />

    <label>Artist</label>
    <asp:TextBox ID="txtArtist" runat="server"></asp:TextBox><br />

    <label>Price</label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
</asp:Content>

