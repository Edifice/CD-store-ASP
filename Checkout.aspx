<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <label>First Name</label>
        <asp:TextBox ID="FirstName" runat="server" />
    </div>
    <div>
        <label>Last Name</label>
        <asp:TextBox ID="LastName" runat="server" />
    </div>
    <div>
        <label>Street Name</label>
        <asp:TextBox ID="StreetName" runat="server" />
    </div>
    <div>
        <label>City</label>
        <asp:TextBox ID="City" runat="server" />
    </div>
    <div>
        <label>Country</label>
        <asp:TextBox ID="Country" runat="server" />
    </div>
    <div>
        <label>E-mail</label>
        <asp:TextBox ID="Email" runat="server" />
    </div>
    <div>
        <asp:Button ID="id" Text="Submit Order" OnClick="sub" runat="server" />
    </div>

</asp:Content>

