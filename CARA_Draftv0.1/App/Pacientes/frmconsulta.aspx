<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmconsulta.aspx.cs" Inherits="CARA_Draftv0._1.App.Pacientes.frmconsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <header class="page-header page-header-compact page-header-light border-bottom mb-4">
            <div class="container-fluid px-4">
                <div class="page-header-content">
                     <div class="row justify-content-center">
                        <div class="col-xl-6 align-self-center">
                            <h5 style="text-align:center"><b>Centro: </b><i><asp:Label Text="" runat="server" Id="lblCentro"/></i> <b>Licencia: </b><i><asp:Label Text="" runat="server" Id="lblLicencia"/></i></h5>
                        </div>
                    </div>
                    <div class="row align-items-center justify-content-between pt-3">
                        <div class="col-auto mb-3">
                            <h3 class="page-header-title">
                                <div class="page-header-icon">
                                    <i class="fas fa-fw fa-user-md"></i><span>Búsqueda de Paciente</span>
                                </div>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </header>

    <div id="PacienteBox" runat="server" class="container-xl px-4">
       
        <div>

            <div class="card mb-4">
                <div class="card-header">
                    <h5 class="card-title">Filtros de Búsqueda</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-2 SEPSDivs">
                            <span class="SEPSLabelConsulta">IUP:</span>
                            <div class="expandibleDiv">
                                <asp:TextBox ID="txtIUP" runat="server"  CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-sm-3 SEPSDivs">
                            <span class="SEPSLabelConsulta">Expediente:</span>
                            <div class="expandibleDiv">
                                <asp:TextBox ID="txtExpediente" runat="server"  CssClass="form-control" />
                            </div>
                        </div>
                        <div class="col-sm-4 SEPSDivs">
                            <span class="SEPSLabelConsulta">Fecha de Nacimiento:</span>
                            <div class="expandibleDiv">
                                <asp:TextBox ID="txtNacimiento" runat="server"  CssClass="form-control" TextMode="Date"/>
                            </div>
                        </div>
                        <div class="col-sm-3 SEPSDivs">
                            <span class="SEPSLabelConsulta">Género:</span>
                            <div class="expandibleDiv">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlGenero"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-6 SEPSDivs pt-3">
                            <span class="SEPSLabelConsulta">Grupo Étnico:</span>
                            <div class="expandibleDiv">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlGrupoEtnico"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-6 SEPSDivs pt-3">
                            <span class="SEPSLabelConsulta">Raza:</span>
                            <div>
                                <asp:ListBox runat="server" ID="lbxRaza" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 SEPSDivs">
                            <div class="btn-group px-md-3 pt-3" role="group">
                                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-outline-secondary" Text="Registrar paciente" OnClick="btnRegistrar_Click"/>
                                <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-outline-secondary" Text="Borrar campos" OnClick="btnBorrar_Click"/>
                                <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-outline-secondary" Text="Buscar Paciente" OnClick="btnConsultar_Click"/>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="card" runat="server">
                <div class="card-header">
                    <h5 class="card-title">Resultados de Búsqueda</h5>
                </div>
                <div class="card-body">
                    <div class="table-responsive table-striped table-hover table-sm" id="divPacienteList">
                        <asp:GridView ID="gvPcientes" runat="server"  CssClass="table table-bordered pacientesListTable" AutoGenerateColumns="False" Width="100%" DataKeyNames="PK_Paciente">
                        
                            <Columns>

                                <asp:BoundField DataField="PK_Paciente" HeaderText="IUP" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="NB_Centro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Expediente">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkExpediente" runat="server" Text='<%# Bind("NR_Expediente") %>'  OnClick="lnkExpediente_Click" CommandArgument='<%# Eval("Pk_Paciente")%>' CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="FE_Nacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:MM/dd/yyyy}" SortExpression="FE_Nacimiento" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="DE_GrupoEtnico" HeaderText="Grupo Etnico" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>

                            </Columns>
                            <EmptyDataTemplate>
                            <div class="card-block">
                                <p class="text-center pt-4 pb-4">Ningún paciente coincide con su búsqueda. <a href="<%=ResolveClientUrl("~/App/Pacientes/frmEditar.aspx?accion=crear")%>">Crear Nuevo Paciente</a></p>
                            </div>
                         </EmptyDataTemplate>

                        </asp:GridView>
                    </div>

                </div>

<%--                Página #:        
            <asp:DropDownList ID="ddlJumpTo" runat="server" OnSelectedIndexChanged="PageNumberChanged" AutoPostBack="true"></asp:DropDownList>--%>

            </div>

        </div>  
    </div>

</main>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/css/bootstrap-multiselect.css" type="text/css" />

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/js/bootstrap-multiselect.js"></script>

<script type="text/javascript">
    
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }

    function sweetAlertRef(titulo, texto, icono, ref) {

            swal({
                title: titulo,
                text: texto,
                icon: icono
            }).then((value) => { window.location.href = ref; });
    }

    function sweetAlert(titulo, texto, icono) {
            swal({
                title: titulo,
                text: texto,
                icon: icono
            })
        }

    $(function () {
        $(<%=lbxRaza.ClientID%>).multiselect({
            enableCaseInsensitiveFiltering: true,
            buttonClass: 'form-control',
            buttonWidth: '93%'
        });
    });


</script>

</asp:Content>
