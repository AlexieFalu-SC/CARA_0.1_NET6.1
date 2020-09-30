<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmVisualizar.aspx.cs" Inherits="CARA_Draftv0._1.App.Pacientes.frmVisualizar" %>
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

            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Datos del Paciente</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-2 SEPSDivs">
                            <span class="SEPSLabelConsulta">IUP:</span>
                            <div class="expandibleDiv">
                                <asp:Label ID="lblIUP" runat="server" />
                            </div>
                        </div>
                        <div class="col-sm-3 SEPSDivs">
                            <span class="SEPSLabelConsulta">Expediente:</span>
                            <div class="expandibleDiv">
                                <asp:Label ID="lblExpediente" runat="server"  />
                            </div>
                        </div>
                        <div class="col-sm-4 SEPSDivs">
                            <span class="SEPSLabelConsulta">Fecha de Nacimiento:</span>
                            <div class="expandibleDiv">
                                <asp:Label ID="lblNacimiento" runat="server" />
                            </div>
                        </div>
                        <div class="col-sm-3 SEPSDivs">
                            <span class="SEPSLabelConsulta">Grupo Étnico:</span>
                            <div class="expandibleDiv">
                                <asp:Label runat="server" ID="lblGrupoEtnico" />
                            </div>
                        </div>
                        <div class="col-sm-6 SEPSDivs pt-3">
                            <span class="SEPSLabelConsulta">Raza:</span>
                            <div>
                                <asp:Label runat="server" ID="lblRaza" SelectionMode="Multiple" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 SEPSDivs">
                            <div class="btn-group px-md-3 pt-3" role="group">
                                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-outline-secondary" Text="Registrar Admisión" OnClick="btnRegistrar_Click"/>
                                <%--<asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-outline-secondary" Text="Borrar campos" OnClick="btnBorrar_Click"/>
                                <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-outline-secondary" Text="Consultar" OnClick="btnConsultar_Click"/>--%>
                                <asp:Button ID="btnActualizarPaciente" CssClass="btn btn-outline-secondary" Text="Modificar Paciente" OnClick="btnModificarPaciente_Click" runat="server" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="card" runat="server">
                <div class="card-header">
                    <h5 class="card-title">Listado de Episodios</h5>
                </div>
                <div class="card-body" style="padding:0px">

                    <asp:GridView ID="gvEpisodios" runat="server"  CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Episodio">
                        
                        <Columns>
                            <asp:TemplateField HeaderText="Episodio">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEpisodio" runat="server" Text='<%# Bind("PK_Episodio") %>'  OnClick="lnkEpisodio_Click" CommandArgument='<%# Eval("PK_Episodio")%>' CausesValidation="false"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="NB_Centro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="FE_Episodio" HeaderText="Fecha de Nacimiento" DataFormatString="{0:MM/dd/yyyy}" SortExpression="FE_Episodio" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="NR_Perfiles" HeaderText="Perfiles" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>

                        </Columns>
                        <EmptyDataTemplate>
                        <div class="card-block">
                            <p class="text-center pt-4 pb-4">El paciente no contiene ningún episodio.</p>
                        </div>
                     </EmptyDataTemplate>

                        <PagerSettings Visible="False"></PagerSettings>

                    </asp:GridView>

                </div>

<%--                Página #:        
            <asp:DropDownList ID="ddlJumpTo" runat="server" OnSelectedIndexChanged="PageNumberChanged" AutoPostBack="true"></asp:DropDownList>--%>

            </div>

        </div>  
    </div>

</main>

</asp:Content>
