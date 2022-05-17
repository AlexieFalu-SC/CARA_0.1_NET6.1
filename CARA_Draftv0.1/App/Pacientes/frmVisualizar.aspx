<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmVisualizar.aspx.cs" Inherits="CARA_Draftv0._1.App.Pacientes.frmVisualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main id="divPacienteEpisodiosMain">
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
                                    <i class="fas fa-fw fa-id-card"></i><span> Expediente del Paciente - Episodios</span>
                                </div>
                            </h3>
                        </div>
                        <div class="col-auto">
                            <div class="btn-group mr-2">
                                <asp:Button runat="server" Text="PDF" OnClientClick="PrintDiv()" CssClass="btn btn-sm btn-outline-secondary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>

    <div id="PacienteBox" runat="server" class="container-xl px-4">
        <div class="row justify-content-center">
            <div class="col-xl-6 align-self-center">
                <div class="card">
                    <%--<div class="card-header">
                        <h5 class="card-title">Datos del Paciente</h5>
                    </div>--%>
                    
                    <div class="card-body">
                        <div class="row">
                            <div class="col-xl-3">
                                <div class="text-center">
                                <asp:Image ID="profileImg" ImageUrl="~/Content/images/Avatar.png" runat="server" CssClass="img-account-profile rounded-circle mb-2" />
                                <div style="text-align:center" class="small font-italic text-muted mb-4"><span>Paciente</span></div>
                                </div>
                            </div>
                            <div class="col-xl-9">
                                <div class="row">
                                    <div class="form-group col-6">
                                        <span class="SEPSLabelConsulta"><b>IUP:</b></span>
                                        <asp:Label ID="lblIUP" CssClass="font-italic" runat="server" />
                                    </div>
                                    <div class="form-group col-6">
                                        <span class="SEPSLabelConsulta"><b>Expediente:</b></span>
                                        <asp:Label ID="lblExpediente" CssClass="font-italic" runat="server"  />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-6">
                                        <span class="SEPSLabelConsulta"><b>Fecha de Nacimiento:</b></span>
                                        <asp:Label ID="lblNacimiento" CssClass="font-italic" runat="server" />
                                    </div>
                                    <div class="form-group col-6">
                                        <span class="SEPSLabelConsulta"><b>Grupo Étnico:</b></span>
                                        <asp:Label runat="server" CssClass="font-italic" ID="lblGrupoEtnico" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-6">
                                        <span class="SEPSLabelConsulta"><b>Raza:</b></span>
                                        <asp:Label runat="server" ID="lblRaza" SelectionMode="Multiple" />
                                    </div>
                                    <div class="form-group col-6">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="btn-group px-md-3 pt-3" role="group">
                                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-outline-secondary" Text="Registrar Admisión" OnClick="btnRegistrar_Click"/>
                                <asp:Button ID="btnActualizarPaciente" CssClass="btn btn-outline-secondary" Text="Modificar Paciente" OnClick="btnModificarPaciente_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div class="container-xl px-4 mt-4">
            <div class="card" runat="server">
                <div class="card-header">
                    <h5 class="card-title">Listado de Episodios</h5>
                </div>
                <div class="card-body" style="padding:0px">
                    <div class="table-responsive table-striped table-hover table-sm" id="divPacienteEpisodiosList">
                        <asp:GridView ID="gvEpisodios" runat="server"  CssClass="table table-bordered pacienteEpisodiosListTable" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Episodio">
                        
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
                </div>
            </div>
        </div>
</main>

<script>

    function PrintDiv() {
        var d = new Date();
        var divContents = document.getElementById("divPacienteEpisodiosList").innerHTML;

        var printWindow = window.open();
        printWindow.document.write('<html><head>');
        printWindow.document.write('</head><body style="font-family:courier;"><style>h2 {text-align: center;} a {text-decoration:none; color:black;}  table { font-size: 12px; width:100%; border-collapse:collapse; } table, td, th { border: 1px solid black;}</style>');
        printWindow.document.write('<h2>Expediente del Paciente</h2>');
        printWindow.document.write('<p>Fecha: ' + '' + '</p>');
        printWindow.document.write('<p>Centro: ' + '' + '</p>');
        printWindow.document.write('<p>Licencia: ' + '' + '</p>');
        printWindow.document.write('<p>IUP: ' + '' + '</p>');
        printWindow.document.write('<p>Expediente: ' + '' + '</p>');
        printWindow.document.write('<p>Grupo Étnico: ' + '' + '</p>');
        printWindow.document.write('<p>Raza: ' + '' + '</p>');
        printWindow.document.write('</br>');
        printWindow.document.write(divContents);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.print();
    }  
</script>

</asp:Content>
