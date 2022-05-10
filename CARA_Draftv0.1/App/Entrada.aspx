<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="CARA_Draftv0._1.App.Entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">

        <div style="max-width:600px;margin:auto">
            <br />
            <h1 class="hidden-print">Sistema Estadístico de Admisiones a Tratamientos de Sustancias (SEATS)</h1>
            <br />
            <p>Sistema para recopilar información y generar informes estadísticos de pacientes con experiencias de sobredosis que ingresen a los programas de instituciones que brinden servicios de tratamiento de abuso de sustancias.  Estas instituciones son licenciadas e inspeccionadas por la Oficina de Organismos Reguladores (OOR) de ASSMCA y son conocidas dentro de la Agencia como Registrados.</p>
            <br />
            <div class="text-center">
                <img class="img-fluid" src="<%=ResolveClientUrl("~/Content/images/graphic_home.png")%>" />
            </div>
        </div>

    </main>--%>

<main>

    <div class="container-xl px-4 mt-5">
        <!-- Custom page header alternative example-->
        <div class="d-flex justify-content-between align-items-sm-center flex-column flex-sm-row mb-4">
            <div class="me-4 mb-3 mb-sm-0">
                <h1 class="mb-0">Tablero Principal</h1>
                <div class="small">
                    <span class="fw-500 text-primary"><asp:Label ID="lblDia" Text="" runat="server" /></span>
                    <asp:Label ID="lblFecha" Text="" runat="server" />
                </div>
            </div>
        </div>
        <!-- Illustration dashboard card example-->
        <div class="card card-waves mb-4 mt-5">
            <div class="card-body p-5">
                <div class="row align-items-center justify-content-between">
                    <div class="col">
                        <h2 class="text-primary">¡Bienvenido al Sistema Estadístico de Admisiones a Tratamientos de Sustancias y Salud Mental (SEATSS)!</h2>
                        <p class="text-gray-700">Sistema para recopilar información y generar informes estadísticos de pacientes con experiencias de sobredosis que ingresen a los programas de instituciones que brinden servicios de tratamiento de abuso de sustancias.  Estas instituciones son licenciadas e inspeccionadas por la Oficina de Organismos Reguladores (OOR) de ASSMCA y son conocidas dentro de la Agencia como Registrados.</p>
                                        
                    </div>
                    <div class="col d-none d-lg-block mt-xxl-n4"><img class="img-fluid px-xl-4 mt-xxl-n5" src="<%=ResolveClientUrl("~/Content/images/undraw_visionary_technology_re_jfp7.svg")%>"></div>
                </div>
            </div>
        </div>
    </div>

</main>

    

</asp:Content>
