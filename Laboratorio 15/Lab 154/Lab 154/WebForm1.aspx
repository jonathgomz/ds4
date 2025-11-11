<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab_154.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Suma de dos números</title>
</head>
<body>
    <form id="form1" runat="server">

        <h3>Suma de dos números</h3>

        Número 1:
        <asp:TextBox ID="txtA" runat="server" Width="60px"></asp:TextBox>

        <br /><br />

        Número 2:
        <asp:TextBox ID="txtB" runat="server" Width="60px"></asp:TextBox>

        <br /><br />

        <asp:Button ID="btnSumar" runat="server" Text="Sumar" OnClick="btnSumar_Click" />

        <br /><br />

        Resultado:
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>

