<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucdatospersonales.ascx.cs" Inherits="CARA_Draftv0._1.App.Perfiles.wucdatospersonales" %>

<div class="card mb-4">
    <div class="card-header">
        <h5 class="card-title">Información de admisión</h5>
    </div>
    <div class="card-body">
        <div class="row">
            <div class="col">
                <div class="row d-flex justify-content-center SEPSDivsInfo px-md-3">
                    <span class="SEPSLabel">Nombre del Centro/Unidad de Servicio:</span>
                </div>
                <div class="row d-flex justify-content-center px-md-3">
                    <asp:Label ID="lblCentro" Text="" runat="server" />
                </div>
            </div>
            <div class="col">
                <div class="row d-flex justify-content-center SEPSDivsInfo px-md-3">
                    <span class="SEPSLabel">ID de proveedor:</span>
                </div>
                <div class="row d-flex justify-content-center px-md-3">
                    <asp:Label Text="3125367" runat="server" />
                </div>
            </div>
            <div class="col">
                <div class="row d-flex justify-content-center SEPSDivsInfo px-md-3">
                    <span class="SEPSLabel">Fecha Admisión:</span>
                </div>
                <asp:RequiredFieldValidator ID="rfvFechaAdmision" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Este campo requerido." ErrorMessage="Fecha de Admisión" ControlToValidate="txtFechaAdmision" Text="*"/>
                <div class="row d-flex justify-content-center px-md-3">
                    <asp:TextBox ID="txtFechaAdmision" runat="server"  CssClass="form-control" TextMode="Date"/>
                    <asp:Label ID="lblFechaAdmision" runat="server" />
                </div>
            </div>
            <div class="col">
                <div class="row d-flex justify-content-center SEPSDivsInfo px-md-3">
                    <span class="SEPSLabel">Hora:</span>
                </div>
                <asp:RequiredFieldValidator ID="rfvHoraAdmision" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Este campo requerido." ErrorMessage="Hora de Admisión" ControlToValidate="txtHoraAdmision" Text="*"/>
                <div class="row d-flex justify-content-center px-md-3">
                    <asp:TextBox ID="txtHoraAdmision" runat="server"  CssClass="form-control" TextMode="Time"/>
                    <asp:Label ID="lblHoraAdmision" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-6 col-md-3 SEPSDivs">
                <span class="SEPSLabel">ID de paciente:</span>
                <div class="expandibleDiv">
                <asp:Label ID="lblIUP" Text="" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-3 SEPSDivs">
                <span class="SEPSLabel">Tipo de Admisión:</span>
                <asp:RequiredFieldValidator ID="rfvTipoAdmision" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Tipo de Admisión" ControlToValidate="ddlEstadoServicio" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstadoServicio"></asp:DropDownList>
                    <asp:Label ID="lblEstadoServicio" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-3 SEPSDivs">
                <span class="SEPSLabel">Días en espera para admisión:</span>
                <asp:RequiredFieldValidator ID="rfvDiasEspera" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Este campo requerido." ErrorMessage="Días en espera para admisión" ControlToValidate="txtDiasEspera" Text="*"/>
                <asp:RegularExpressionValidator ID="revDiasEspera" runat="server"   ForeColor="red"  ControlToValidate="txtDiasEspera" Display="Dynamic" ErrorMessage="Días en espera tiene que ser un número. No puede contener letras." ValidationExpression="(\d{1})?(\d{1})?(\d{1})?" Text="Días en espera tiene que ser número. No puede contener letras."    />
                <div class="expandibleDiv">
                <asp:textbox runat="server" ID="txtDiasEspera" CssClass="form-control" MaxLength="3"/>
                    <asp:Label ID="lblDiasEspera" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-3 SEPSDivs">
                <span class="SEPSLabel">Arrestos en los pasados 30 días:</span>
                <asp:RequiredFieldValidator ID="rfvArrestos" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Este campo requerido." ErrorMessage="Arrestos pasados 30 días" ControlToValidate="txtArrestos" Text="*"/>
                <asp:RegularExpressionValidator ID="revArrestos" runat="server"   ForeColor="red"  ControlToValidate="txtArrestos" Display="Dynamic" ErrorMessage="Los arrestos tiene que ser un número. No puede contener letras." ValidationExpression="(\d{1})?(\d{1})?(\d{1})?" Text="Los arrestos tiene que ser número. No puede contener letras."    />
                <div class="expandibleDiv">
                <asp:textbox runat="server" ID="txtArrestos" CssClass="form-control" MaxLength="3"/>
                    <asp:Label ID="lblArrestos" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-6 col-md SEPSDivs">
                <span class="SEPSLabel">Fuente de Referido:</span>
                <asp:RequiredFieldValidator ID="rfvFuenteRef" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Fuente Referido" ControlToValidate="ddlFuenteReferido" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFuenteReferido"></asp:DropDownList>
                    <asp:Label ID="lblFuenteReferido" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-sm SEPSDivsInfo">
                <span class="SEPSLabel">Cantidad de episodios previos:</span>
                <asp:RequiredFieldValidator ID="rfvEpisodiosPre" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Episodios Previos" ControlToValidate="ddlEpisodiosPrevios" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEpisodiosPrevios"></asp:DropDownList>
                    <asp:Label ID="lblEpisodiosPrevios" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-12 col-md SEPSDivs">
                <span class="SEPSLabel">Asistencia a grupos de apoyo en los pasados 30 días previo a admisión:</span>
                <asp:RequiredFieldValidator ID="rfvFrecuenciaApo" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Militar" ControlToValidate="ddlFrecuenciaApoyo" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFrecuenciaApoyo"></asp:DropDownList>
                    <asp:Label ID="lblFrecuenciaApoyo" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>