<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="rolesRegistrado.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.rolesRegistrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
        <div id="RolesRegistradoBox" runat="server">

             <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-5 border-bottom">
                <h1 class="h2">Usuarios con Rol: <asp:Label ID="lblRol" Text="" runat="server" /></h1>
                <div class="btn-toolbar mb-2 mb-md-0">
                  <div class="btn-group mr-2">
                    <button type="button" class="btn btn-sm btn-outline-secondary">Compartir</button>
            <button type="button" class="btn btn-sm btn-outline-secondary" onclick="javascript:window.print();">Imprimir</button>
                  </div>
                </div>
             </div>

            <div class="mb-4">

                <div class="btn-toolbar justify-content-between mb-4" role="toolbar" aria-label="Toolbar with button groups">
                    <div class="btn-group" role="group" aria-label="First group">
                        <asp:LinkButton ID="lnkVolver" Text="Volver" runat="server" OnClick="lnkVolver_Click" />
                    </div>
                    <div id="divBotones" class="btn-group" role="group" style="padding-top: 10px;">
                        <asp:Button ID="btnRolUsuario" runat="server" CssClass="btn btn-outline-secondary" OnClick="btnRolUsuario_Click" Text="Agregar Usuario a Rol" />
                        <asp:Button ID="btnEliminarRol" CssClass="btn btn-outline-secondary" OnClick="btnEliminarRol_Click" Text="Eliminar Usuario de Rol" runat="server" />
                    </div>
                </div>

                <div class="card mb-4">
                    <div class="card-header">
                            <div class="row">
                                <div class="col-md-4 text-left">
                                    <span>
                                        <asp:Literal ID="LitCantidadUsuarios" runat="server"></asp:Literal>
                                        Usuarios Encontrados</span>
                                </div>
                            </div>
                      </div>

                    <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="gvUsuarios_PageIndexChanging" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Usuario">
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>  
                                    <asp:CheckBox ID="CheckBox1" runat="server" />  
                                </EditItemTemplate>  
                                <ItemTemplate>  
                                    <asp:CheckBox ID="CheckBox1" runat="server" />  
                                </ItemTemplate>  
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>                        
                        </Columns>
                        <EmptyDataTemplate>
                            <div class="card-block">
                                <p class="text-center pt-4 pb-4">Ningún usuario.</p>
                            </div>
                            </EmptyDataTemplate>

                        <PagerSettings Visible="False"></PagerSettings>

                    </asp:GridView>

                </div>
                Página #:        
                    <asp:DropDownList ID="ddlJumpTo" runat="server" OnSelectedIndexChanged="PageNumberChanged" AutoPostBack="true"></asp:DropDownList>

            </div>

        </div>
    </main>

    <script type="text/javascript">
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }

    function sweetAlertRef(titulo, texto, icono, ref) {
        var baseUrl = "<%=ResolveClientUrl("~/")%>" + ref;

        swal({
            title: titulo,
            text: texto,
            icon: icono
        }).then((value) => { window.location.href = baseUrl; });
    }

    function sweetAlert(titulo, texto, icono) {
        swal({
            title: titulo,
            text: texto,
            icon: icono
        })
    }
    </script>
</asp:Content>
