<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Multipllicar.aspx.cs" Inherits="Lab_20.Multipllicar" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tabla de multiplicar 25</title>
</head>
<body>
   <form id="form1" runat="server">

    <h2>Tabla de Multiplicar hasta 25</h2>

    <asp:Label ID="Label1" runat="server" Text="Ingrese un número: "></asp:Label>
    <asp:TextBox ID="txtA" runat="server"></asp:TextBox>

    <asp:Button ID="btnMultiplicar" runat="server" Text="Generar" OnClick="btnMultiplicar_Click" />

    <br /><br />

    <asp:Label ID="lblResultado" runat="server"></asp:Label>

</form>

</body>
</html>

