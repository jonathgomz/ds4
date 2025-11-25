<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_203._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <style>
            body { font-family: Arial, sans-serif; margin: 20px; }
            .Contenedor { max-width: 600px; margin: 0 auto; }
            .Herramientas { margin: 20px 0; padding: 10px; background: #f5f5f5; }
            .Herramientas button { margin-right: 10px; padding: 8px 15px; }
            .GrupoDiv { margin: 10px 0; }
            .GrupoDiv label { display: inline-block; width: 100px; font-weight: bold; }
            .GrupoDiv input { width: 200px; padding: 5px; }
            .disabled { background-color: #e9ecef; opacity: 0.6; }
        </style>
    
            <div class="Contenedor">
                <h1>Pagina de gestion de laptops</h1>

                <div class="Herramientas">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" CssClass="btn-primary" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Enabled="false"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Enabled="false"/>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="false"/>
                    <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" CssClass="btn-secondary" />
                </div>

                <div class="Buscar">
                    <label>Buscar por ID</label>
                    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>

                <div class="Formulario">
                    <div class="GrupoDiv">
                        <label>ID:</label>
                        <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="disabled"></asp:TextBox>
                    </div>

                    <div class="GrupoDiv">
                        <label>Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="disabled"></asp:TextBox>
                    </div>

                    <div class="GrupoDiv">
                        <label>Precio</label>
                        <asp:TextBox ID="txtPrecio" runat="server" Enabled="false" CssClass="disabled"></asp:TextBox>
                    </div>

                    <div class="GrupoDiv">
                        <label>Stock</label>
                        <asp:TextBox ID="txtStock" runat="server" Enabled="false" CssClass="disabled"></asp:TextBox>
                    </div>
                </div>

                <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
</asp:Content>