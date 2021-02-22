<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="CARA_Draftv0._1.App.Entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">

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

    </main>

    

</asp:Content>
