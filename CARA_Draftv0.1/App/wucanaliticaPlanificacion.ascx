<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucanaliticaPlanificacion.ascx.cs" Inherits="CARA_Draftv0._1.App.wucanaliticaPlanificacion" %>

<div class="row">
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
                    <h6 class="list-item">Centro de Servicio</h6>
                </div>
                <div class="row">
                    <asp:ListBox runat="server" ID="lbxCentro" SelectionMode="Multiple" onChange="changeFecha();" CssClass="form-control">
                </asp:ListBox>
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

    <div class="col-md-9 ml-sm-auto col-lg-10 px-md-3">
        <div class="row">
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                        <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Vía de Uso (más utilizada)</div>
                        <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="viaUsada"></div>
                    </div>
                    <div class="col-auto">
                        <i class="fas fa-calendar fa-2x text-gray-300"></i>
                    </div>
                    </div>
                </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Toxicología</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalToxicologia"></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Centros</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalCentros"></div>
                        </div>
                    </div>
                </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-info text-uppercase mb-1" style="text-align:center">Total de Admisiones</div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800" style="text-align:center" id="totalAdmisiones"></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
        <%-- <div class="my-4 w-50" id="curve_chart" style="width: 500px; height: 380px; float:left"></div>--%>
        <%-- <div class="my-4 w-50" id="curve_chart2" style="width: 500px; height: 380px; float:right"></div>--%>
        <%-- <div class="my-4 w-50" id="curve_chart3" style="width: 500px; height: 380px; float:left"></div>--%>
    
        <div class="row">

            <!-- Chart: Fuente de Referidos Principales -->
            <div class="col-lg-6 mb-2">
                <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">DIAGNOSTICOS ICD 10 (Top 10)</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="icdx_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            <!-- Chart: Fuente de Referidos Principales -->
            <div class="col-lg-6 mb-2">
                <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">DIAGNOSTICOS DSMV (Top 10)</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="dsmv_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            </div>

        <div class="row">

            <!-- Chart: Perfiles por Centro -->
            <div class="col-lg-6 mb-2">
                <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">CONDICIONES SALUD FÍSICAS</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <div id="saludfisicas_chart" style="height: 250px"></div>
                    </div>
                </div>
                </div>
            </div>

            <!-- Chart: Perfiles por Centro -->
            <div class="col-lg-6 mb-2">
                <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-primary">DROGAS DE USO (Confirmadas Toxicología)</h6>
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

        </div>

</div>
