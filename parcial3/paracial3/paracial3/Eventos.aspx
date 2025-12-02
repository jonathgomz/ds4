<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="SistemaBuffeteAbogados.Eventos" %>

<!DOCTYPE html>
<html>
<head>
    <title>Eventos</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Eventos y Audiencias</h1>
        <a href="Default.aspx">Inicio</a>
        <hr />
        
        <h3>Datos del Evento</h3>
        
        Caso: 
        <asp:DropDownList ID="ddlCaso" runat="server"></asp:DropDownList><br /><br />
        
        Fecha y Hora: <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTimeLocal"></asp:TextBox><br /><br />
        
        Descripción:<br />
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" Columns="50"></asp:TextBox><br /><br />
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        <br /><br />
        
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
        <asp:HiddenField ID="hdnEventoID" runat="server" Value="0" />
        
        <hr />
        <h3>Lista de Eventos</h3>
        
        <asp:GridView ID="gvEventos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvEventos_RowCommand">
            <Columns>
                <asp:BoundField DataField="EventoID" HeaderText="ID" />
                <asp:BoundField DataField="NumeroCaso" HeaderText="Caso" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" 
                                    CommandName="Editar" CommandArgument='<%# Eval("EventoID") %>' />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                                    CommandName="Eliminar" CommandArgument='<%# Eval("EventoID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>