<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="registradoListaCentros.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.registradoListaCentros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .collapsed-row {
            display:none;
            padding:0px;
            margin:0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<main>
    <header class="page-header page-header-compact page-header-light border-bottom mb-4">
            <div class="container-fluid px-4">
                <div class="page-header-content">
                    <div class="row align-items-center justify-content-between pt-3">
                        <div class="col-auto mb-3">
                            <h3 class="page-header-title">
                                <div class="page-header-icon">
                                    <i class="fas fa-fw fa-hospital"></i><span> Lista de Mis Facilidades</span>
                                </div>
                            </h3>
                        </div>
                      <%--  <div class="col-auto">
                            <div class="btn-group mr-2">
                                <a class="btn btn-sm btn-light text-primary" href="<%=ResolveClientUrl("~/App/Administracion/registradoListaUsuarios")%>">
                                    <i class="fas fa-fw fa-user-plus"></i>Volver a lista de Usuarios
                                </a>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </header>

        <div class="container-fluid px-4">
            <div class="card">
                    <div class="card-header">
                        <div class="btn-toolbar justify-content-between" role="toolbar">
                            <div>
                                <h4>Facilidades</h4>
                            </div>
                            <%--<div>
                            <a class="btn btn-sm btn-light text-primary"  runat="server" href="~/App/Administracion/adminRegistroFacilidad">
                                <i class="fas fa-fw fa-hospital"></i>
                                Registrar Nueva Facilidad
                            </a>
                            </div>--%>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">

                            <asp:GridView runat="server" ID="gvCentrosList" CssClass="table table-bordered usuariosASSMCAListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="PK_Centro"  onrowdatabound="gvLicenciasList_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                                <div style="width:15px; align-content:center;">
                                                    <%--<button class="btn btn-sm" style="margin-left:0px; margin-right:0px; float: left;" onclick="return ToggleGridPanel(this, 'tr<%# Eval("Cuenta_Princiapal") %>')"><i class="fas fa-fw fa-plus-circle"></i></button>--%>
                                                    <button class="btn btn-sm" style="margin-left:0px; margin-right:0px; float: left;" onclick="return ToggleGridPanel(this, 'tr<%# Eval("PK_Centro") %>')"><i class="fas fa-fw fa-plus-circle"></i></button>
                                                </div>
                                
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NB_Centro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Estatus">
                                        <ItemTemplate>
                                            <div class="row">&nbsp <%# Eval("CentroEstatus") %></div>
                                             <%# MyNewRow(Eval("PK_Centro")) %>
                                            <asp:GridView runat="server" ID="gvLicenciasList" CssClass="table table-bordered" Width="100%" AutoGenerateColumns="false" DataKeyNames="NB_Licencia">
                                                <Columns>
                                                    <asp:BoundField DataField="NB_Licencia" HeaderText="Nombre de Licencia" />
                                                    <asp:BoundField DataField="NR_Licencia" HeaderText="Número de Licencia" />
                                                    <asp:BoundField DataField="FE_Expiracion" HeaderText="Expiración de Licencia" DataFormatString = "{0:MM/dd/yyyy}"/>
                                                    <asp:BoundField DataField="NB_Categoria" HeaderText="Categoria de Licencia" />
                                                    <asp:BoundField DataField="CentroLicenciaEstatus" HeaderText="Estatus de Licencia" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    Esta facilidad no contiene licencias atadas
                                                </EmptyDataTemplate>
                                                <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            
                                </Columns>
                                <EmptyDataTemplate>
                                    No existen usuarios adicionales al de usted
                                </EmptyDataTemplate>
                                <%--<i class='fas fa-fw fa-trash-alt'></i>--%>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
        </div>
</main>

<script type="text/javascript">
    $(document).ready(function () {
        $('.usuariosExternosListTable').DataTable();
    });
    function ToggleGridPanel(btn, row) {
        var current = $('#' + row).css('display');
        if (current == 'none') {
            $('#' + row).show();
            $(btn).html('<i class="fas fa-fw fa-minus-circle"></i>');
        } else {
            $('#' + row).hide();
            $(btn).html('<i class="fas fa-fw fa-plus-circle"></i>');
        }
        return false;
    }
</script>

</asp:Content>
