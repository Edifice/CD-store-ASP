<%@ Page 
    Title="Home Page" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeFile="Default.aspx.cs" 
    Inherits="Default" 
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
      
    </div>
     <div>
        <asp:Button ID="btnCheckOut_" runat="server" OnClick="btnCheckOut" Text="CheckOut" />
    </div>
     <div>
        <asp:Button ID="btnCleanCart_" runat="server" OnClick="btnCleanCart" Text="Clean Cart" />
    </div>

</asp:Content>