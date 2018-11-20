<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NorthwindApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1> EDIT SHIPPERS</h1>
    <asp:GridView ID="gvShipper" AutoGenerateEditButton="true" AutoGenerateColumns="false"  runat="server">
        <Columns>

            <asp:TemplateField HeaderText="Id" ControlStyle-Width="10px">
               <ItemTemplate>
                   <asp:Label ID="lblId" runat="server" Text ='<%# Eval ("Id") %>'>  </asp:Label>
               </ItemTemplate>
            
           </asp:TemplateField>

           <asp:TemplateField HeaderText="Company Name" ControlStyle-Width="100px">
               <ItemTemplate>
                   <asp:Label ID="lblCompanyName" runat="server" Text ='<%# Eval ("CompanyName") %>'>  </asp:Label>
               </ItemTemplate>
               <EditItemTemplate>
                   <asp:Textbox ID="txtCompanyName" runat="server" Text ='<%# Eval ("CompanyName") %>'>  </asp:Textbox>
               </EditItemTemplate>
           </asp:TemplateField>

            <asp:TemplateField HeaderText="Phone" ControlStyle-Width="100px">
               <ItemTemplate>
                   <asp:Label ID="lblPhone" runat="server" Text ='<%# Eval ("Phone") %>'>  </asp:Label>
               </ItemTemplate>
               <EditItemTemplate>
                   <asp:Textbox ID="txtPhone" runat="server" Text ='<%# Eval ("Phone") %>'>  </asp:Textbox>
               </EditItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
             <asp:Button ID="btnAddRow" runat="server" Text="Add New Row" />
            </FooterTemplate>
           </asp:TemplateField>
            
        </Columns>
    </asp:GridView>


</asp:Content>
