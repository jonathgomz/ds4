<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio_171._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
        <div class="row">
         <asp:GridView ID="MyGridView" DataSourceID="MyDataSource1"
             AllowSorting="true" AllowPaging="true"
             DataKeyNames="ProductID"
             AutoGeneradeEditButton="true"
             Runat="server" />

            <asp:SqlDataSource ID="MyDataSource1" runat="server"
                ConnectionString="data source=localhost; initial catalog=northwind;persist security info=True;Integrated Security=SSPI"
                ProviderName="System.Data.SqlClient"
                SelectCommand="SELECT ProductID, ProductName, UnitPrice from Products"
                UpdateCommand="Update ProductID set [ProductName]=@ProductName, [UnitPrice]=@UnitPrice where [ProductID]=@ProductID">

            </asp:SqlDataSource>
        </div>

</asp:Content>
