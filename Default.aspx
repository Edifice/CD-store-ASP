<%@ Page 
    Title="Home Page" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeFile="Default.aspx.cs" 
    Inherits="_Default" 
    EnableEventValidation="false"
%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div>
        <asp:GridView ID="GridView1" runat="server" onrowcommand="GridView1_RowCommand" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Artist" HeaderText="Artist"/>
                <asp:BoundField DataField="Title" HeaderText="Title"/>
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="AddToCart" CommandArgument='<%#Bind("ID") %>' Text="Add to cart" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
        
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