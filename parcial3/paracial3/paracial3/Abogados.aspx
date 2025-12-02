<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Abogados.aspx.cs" Inherits="SistemaBuffeteAbogados.Abogados" %>

<!DOCTYPE html>
<html>
<head>
    <title>Abogados</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Abogados</h1>
        <a href="Default.aspx">Inicio</a>
        <hr />
        
        <h3>Datos del Abogado</h3>
        
        Nombre: <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br /><br />
        Teléfono: <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox><br /><br />
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        <br /><br />
        
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        <asp:HiddenField ID="hdnAbogadoID" runat="server" Value="0" />
        
        <hr />
        <h3>Lista de Abogados</h3>
        
        <asp:GridView ID="gvAbogados" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAbogados_RowCommand">
            <Columns>
                <asp:BoundField DataField="AbogadoID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" 
                                    CommandName="Editar" CommandArgument='<%# Eval("AbogadoID") %>' />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                                    CommandName="Eliminar" CommandArgument='<%# Eval("AbogadoID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
