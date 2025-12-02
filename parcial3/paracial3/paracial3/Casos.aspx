<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Casos.aspx.cs" Inherits="SistemaBuffeteAbogados.Casos" %>

<!DOCTYPE html>
<html>
<head>
    <title>Casos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Casos Legales</h1>
        <a href="Default.aspx">Inicio</a>
        <hr />
        
        <h3>Datos del Caso</h3>
        
        Número Caso: <asp:TextBox ID="txtNumeroCaso" runat="server"></asp:TextBox><br /><br />
        
        Cliente: 
        <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList><br /><br />
        
        Abogado: 
        <asp:DropDownList ID="ddlAbogado" runat="server"></asp:DropDownList><br /><br />
        
        Título: <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox><br /><br />
        
        Descripción:<br />
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" Columns="50"></asp:TextBox><br /><br />
        
        Estado: 
        <asp:DropDownList ID="ddlEstado" runat="server">
            <asp:ListItem>Nuevo</asp:ListItem>
            <asp:ListItem>En Proceso</asp:ListItem>
            <asp:ListItem>Cerrado</asp:ListItem>
        </asp:DropDownList><br /><br />
        
        Fecha Inicio: <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date"></asp:TextBox><br /><br />
        
        Fecha Vencimiento: <asp:TextBox ID="txtFechaVencimiento" runat="server" TextMode="Date"></asp:TextBox><br /><br />
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnNuevo" runat="server" Text="Limpiar" OnClick="btnNuevo_Click" />
        <br /><br />
        
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        <asp:HiddenField ID="hdnCasoID" runat="server" Value="0" />
        
        <hr />
        <h3>Lista de Casos</h3>
        
        <asp:GridView ID="gvCasos" runat="server" AutoGenerateColumns="False" 
                      OnRowCommand="gvCasos_RowCommand">
            <Columns>
                <asp:BoundField DataField="NumeroCaso" HeaderText="Número" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="Abogado" HeaderText="Abogado" />
                <asp:BoundField DataField="Titulo" HeaderText="Título" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" 
                                    CommandName="Editar" CommandArgument='<%# Eval("CasoID") %>' />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                                    CommandName="Eliminar" CommandArgument='<%# Eval("CasoID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>