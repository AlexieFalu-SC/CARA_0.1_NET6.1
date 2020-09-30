<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmconsulta.aspx.cs" Inherits="CARA_Draftv0._1.App.Pacientes.frmconsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    <div id="PacienteBox" runat="server">
        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <h1 class="h2">Búsqueda de Paciente</h1>
            <div class="btn-toolbar mb-2 mb-md-0">
              <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-outline-secondary">Share</button>
                <button type="button" class="btn btn-sm btn-outline-secondary">Export</button>
              </div>
            </div>
          </div>
        
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
                <div class="card-body" style="padding:0px">

                    <asp:GridView ID="gvPcientes" runat="server"  CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Paciente">
                        
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
                            <p class="text-center pt-4 pb-4">Ningún paciente coincide con su búsqueda. <a href="frmEditar.aspx">Crear Nuevo Paciente</a></p>
                        </div>
                     </EmptyDataTemplate>

                        <PagerSettings Visible="False"></PagerSettings>

                    </asp:GridView>

                </div>

                Página #:        
            <asp:DropDownList ID="ddlJumpTo" runat="server" OnSelectedIndexChanged="PageNumberChanged" AutoPostBack="true"></asp:DropDownList>

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
