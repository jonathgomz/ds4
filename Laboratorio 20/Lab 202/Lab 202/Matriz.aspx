<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Matriz.aspx.cs" Inherits="Lab_202.Matriz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2> Matriz N X N con diagonal inversa</h2>
        <asp:Label ID="Label1" runat="server" Text="Ingrese N: "></asp:Label>
        <asp:TextBox ID="txtN" runat="server"></asp:TextBox>

        <asp:Button ID="btnIniciar" runat="server" Text="Generar Matriz" OnClick="btnIniciar_Click" />
        <br />

        <asp:Table ID="GMatriz" runat="server" BorderWidth="1" CellPadding="6" CellSpacing="0" BorderStyle="Solid"></asp:Table>
    </form>
</body>
</html>
