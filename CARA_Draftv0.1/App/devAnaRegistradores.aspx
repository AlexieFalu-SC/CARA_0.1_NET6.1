<%@ Page Title=" | Mi Tablero Gráfico" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="devAnaRegistradores.aspx.cs" Inherits="CARA_Draftv0._1.App.devAnaRegistradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

     <header class="page-header page-header-compact page-header-light border-bottom bg-white mb-4">
            <div class="container-fluid px-4">
                <div class="page-header-content">
                    <div class="row align-items-center justify-content-between pt-3">
                        <div class="col-auto mb-3">
                            <h3 class="page-header-title">
                                <div class="page-header-icon">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-user">
                                        <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path><circle cx="12" cy="7" r="4"></circle></svg>
                                    Mi Tablero Gráfico
                                </div>

                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <div class="container-xl px-4 mt-4">

            <!-- Content Row -->
            <div class="row">

                <!-- Comienza Columna de Filtros -->
                <div class="col-md-3 col-lg-2 px-md-0">
                    <ul class="list-group">
                        <li class="list-group-item">
                            <div class="row">
                                <h6 class="list-item">Fecha de Admisión</h6>
                            </div>
                            <div class="row">
                                <span class="list-item">Desde</span>
                                <asp:textbox runat="server" ID="txtFechaDesde" CssClass="form-control" TextMode="Date" onChange="changeFecha();"/>
                                <span class="list-item">Hasta</span>
                                <asp:textbox runat="server" ID="txtFechaHasta" CssClass="form-control" TextMode="Date" onChange="changeFecha();"/>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <span class="list-item">Centro de Servicio</span>
                                <asp:ListBox runat="server" ID="lbxCentro" SelectionMode="Multiple" onChange="changeFecha();" CssClass="form-control"></asp:ListBox>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <h6 class="list-item">Género</h6>
                            </div>
                            <div class="row">
                                <asp:ListBox runat="server" ID="lbxGenero" SelectionMode="Multiple" CssClass="form-control" onChange="changeFecha();"></asp:ListBox>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <h6 class="list-item">Nivel de Cuidado</h6>
                            </div>
                            <div class="row">
                                <asp:ListBox ID="lbxNivelSustancia" runat="server" SelectionMode="Multiple" onChange="changeFecha();" CssClass="form-control"></asp:ListBox>
                            </div>
                        </li>
                    </ul>
                </div>
                <!-- Termina Columna de Filtros -->

                <div class="col-md-9 ml-sm-auto col-lg-10 px-md-3">

                    <!-- Comienza Cuadros Superiores -->
                    <div class="row">
                        <div class="col-xl-3 col-md-6 mb-4">
                            <div class="card border-left-secondary shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Perfiles</div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalPerfiles"></div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                </div>
                                </div>
                            </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-md-6 mb-4">
                            <div class="card border-left-secondary shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Referidos CARA</div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalReferidosCara"></div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-md-6 mb-4">
                            <div class="card border-left-secondary shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                <div class="col">
                                    <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Género</div>
                                    <div class="row no-gutters align-items-center">
                                    <div class="col-auto">
                                        <div class="h6 mb-0 mr-3 font-weight-bold text-gray-800">Masculino</div>
                                    </div>
                                    <div class="col">
                                        <div class="progress progress-sm mr-2">
                                        <div class="progress-bar bg-info" role="progressbar" id="perMasculino" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                    </div>
                                        <div class="col">
                                            <div class="font-weight-bold" id="totalMasculino"></div>
                                        </div>
                                    </div>
                                    <div class="row no-gutters align-items-center">
                                    <div class="col-auto">
                                        <div class="h6 mb-0 mr-3 font-weight-bold text-gray-800">Femenino</div>
                                    </div>
                                    <div class="col">
                                        <div class="progress progress-sm mr-2">
                                        <div class="progress-bar bg-info" role="progressbar" id="perFemenino" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                    </div>
                                        <div class="col">
                                            <div class="font-weight-bold" id="totalFemenino"></div>
                                        </div>
                                    </div>
                                </div>
                                </div>
                            </div>
                            </div>
                        </div>

                        <div class="col-xl-3 col-md-6 mb-4">
                            <div class="card border-left-secondary shadow h-100 py-2">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Edad Promedio</div>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="edadPromedioCara"></div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Termina Cuadros Superiores -->

                    <!-- Comienza Primera Linea de Graficas -->
                    <div class="row">

                        <!-- Chart: Fuente de Referidos Principales -->
                        <div class="col-lg-6 mb-2">
                            <div class="card shadow mb-4">
                            <!-- Card Header - Dropdown -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <h6 class="m-0 font-weight-bold text-info">Fuente de Referidos Principales</h6>
                            </div>
                            <!-- Card Body -->
                            <div class="card-body">
                                <div class="chart-area">
                                    <div id="referido_chart" style="height: 250px"></div>
                                </div>
                            </div>
                            </div>
                        </div>

                        <!-- Chart: Fuente de Referidos Principales -->
                        <div class="col-lg-6 mb-2">
                            <div class="card shadow mb-4">
                            <!-- Card Header - Dropdown -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <h6 class="m-0 font-weight-bold text-info">Drogas de Uso</h6>
                            </div>
                            <!-- Card Body -->
                            <div class="card-body">
                                <div class="chart-area">
                                    <div id="drogas_chart" style="height: 250px"></div>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                    <!-- Termina Primera Linea de Graficas -->

                    <!-- Comienza Segunda Linea de Graficas -->
                     <div class="row">

                        <!-- Chart: Perfiles por Centro -->
                        <div class="col-lg-6 mb-2">
                            <div class="card shadow mb-4">
                            <!-- Card Header - Dropdown -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <h6 class="m-0 font-weight-bold text-info">Eventos de Sobredosis</h6>
                            </div>
                            <!-- Card Body -->
                            <div class="card-body">
                                <div class="chart-area" id="dashboard_div">
                                    <div style="height: 250px">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div id="sobredosis_chart"></div>
                                            </div>
                                            <div class="col-md-6">
                                                <div id="drogaSobredosis_chart"></div>
                                            </div>
                                        </div>
                         
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>

                        <!-- Chart: Perfiles por Centro -->
                        <div class="col-lg-6 mb-2">
                            <div class="card shadow mb-4">
                            <!-- Card Header - Dropdown -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <h6 class="m-0 font-weight-bold text-info">Niveles de Cuidado</h6>
                            </div>
                            <!-- Card Body -->
                            <div class="card-body">
                                <div class="chart-area">
                                    <div id="nivelCuidado_div" style="height: 250px"></div>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                    <!-- Termina Segunda Linea de Graficas -->

                </div>


            </div>
        </div>

    </main>
</asp:Content>
