<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Title" DataField="innerText" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        Add Album<br />
        Title&nbsp;
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
        Artist&nbsp;
        <asp:TextBox ID="txtArtist" runat="server"></asp:TextBox><br />
        Price&nbsp;
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
    </div>

</asp:Content>