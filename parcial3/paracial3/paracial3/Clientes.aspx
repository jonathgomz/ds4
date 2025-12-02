<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="SistemaBuffeteAbogados.Clientes" %>

<!DOCTYPE html>
<html>
<head>
    <title>Clientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Clientes</h1>
        <a href="Default.aspx">Inicio</a>
        <hr />
        
        <h3>Datos del Cliente</h3>
        
        Nombre: <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br /><br />
        Teléfono: <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br /><br />
        Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        <br /><br />
        
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        <asp:HiddenField ID="hdnClienteID" runat="server" Value="0" />
        
        <hr />
        <h3>Lista de Clientes</h3>
        
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvClientes_RowCommand">
            <Columns>
                <asp:BoundField DataField="ClienteID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" 
                                    CommandName="Editar" CommandArgument='<%# Eval("ClienteID") %>' />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                                    CommandName="Eliminar" CommandArgument='<%# Eval("ClienteID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
