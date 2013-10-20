<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CheckoutSummary.aspx.cs" Inherits="CheckoutSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>You entered the following data</h1>
    <h4>Please double-check them and wait, until you get bored. Actually no, you should not wait, because this is not a real shop, so you wont get these albums even if your really want them. That's it...</h4>
    <br />
    <br />
    <label>First Name</label>
    <asp:Label ID="lblFirstName" runat="server" Text="Label"></asp:Label>
    <br />
    <label>Last Name</label>
    <asp:Label ID="lblLastName" runat="server" Text="Label"></asp:Label>
    <br />
    <label>Street Name</label>
    <asp:Label ID="lblStreetName" runat="server" Text="Label"></asp:Label>
    <br />
    <label>City</label>
    <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
    <br />
    <label>Country</label>
    <asp:Label ID="lblCountry" runat="server" Text="Label"></asp:Label>
    <br />
    <label>E-mail</label>
    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
    <br />
</asp:Content>

