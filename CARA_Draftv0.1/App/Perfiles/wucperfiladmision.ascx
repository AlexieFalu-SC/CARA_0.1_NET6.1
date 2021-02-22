<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucperfiladmision.ascx.cs" Inherits="CARA_Draftv0._1.App.Perfiles.wucperfiladmision" %>

<div class="card mb-4">
    <div class="card-header">
        <h5 class="card-title">Perfil de Paciente</h5>
    </div>

    <div class="card-body">
        <div class="row">
            <div class="col-print-4 col-sm-4 SEPSDivsInfo">
                <span class="SEPSLabel">Género:</span>
                <asp:RequiredFieldValidator ID="rfvGenero" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Género" ControlToValidate="ddlGenero" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList ID="ddlGenero" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Label ID="lblGenero" runat="server" />
                </div>
            </div>
            <div class="col-print-4 col-sm-4 SEPSDivsInfo">
                <span class="SEPSLabel">Fecha de Nacimiento:</span>
                <div class="expandibleDiv">
                <asp:Label ID="lblNacimiento" DataFormatString="{0:MM/dd/yyyy}" Text="" runat="server" />
                 </div>
            </div>
            <div class="col-print-3 col-sm-4 SEPSDivs">
                <span class="SEPSLabel">Edad:</span>
                <div class="expandibleDiv">
                <asp:Label ID="lblEdad" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-4 col-sm-4 SEPSDivsInfo">
                <span class="SEPSLabel">Grupo étnico:</span>
                <div class="expandibleDiv">
                <asp:Label ID="lblGrupoEtnico" runat="server" />
                </div>
            </div>
            <div class="col-print-4 col-sm-4 SEPSDivsInfo">
                <span class="SEPSLabel">Raza:</span>
                <div class="expandibleDiv">
                <asp:Label ID="lblRaza" Text="Blanco" runat="server" />
                </div>
            </div>
            <div class="col-print-4 col-sm-4 SEPSDivs">
                <span class="SEPSLabel">Estado marital:</span>
                <asp:RequiredFieldValidator ID="rfvEstadoMarital" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Estado Marital" ControlToValidate="ddlEstadoMarital" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstadoMarital"></asp:DropDownList>
                    <asp:Label ID="lblEstadoMarital" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-4 col-sm SEPSDivsInfo">
                <span class="SEPSLabel">Municipio de Residencia:</span>
                <asp:RequiredFieldValidator ID="rfvMunicipio" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Residencia" ControlToValidate="ddlMunicipio" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMunicipio"></asp:DropDownList>
                    <asp:Label ID="lblMunicipio" runat="server" />
                </div>
            </div>
            <div class="col-print-4 col-sm SEPSDivsInfo">
                <span class="SEPSLabel">Residencia:</span>
                <asp:RequiredFieldValidator ID="rfvResidencia" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Residencia" ControlToValidate="ddlResidencia" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlResidencia"></asp:DropDownList>
                    <asp:Label ID="lblResidencia" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-4 col-sm-4 SEPSDivsInfo">
                <span class="SEPSLabel">Total de hijos menores bajo su cuido:</span>
                <asp:RequiredFieldValidator ID="rfvMenoresCuidado" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Menores Cuidado" ControlToValidate="ddlMenoresCuidado" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMenoresCuidado"></asp:DropDownList>
                    <asp:Label ID="lblMenoresCuidado" runat="server" />
                </div>
            </div>
            <div class="col-print-4 col-sm-4 SEPSDivsInfo">
                <span class="SEPSLabel">Embarazada:</span>
                <asp:RequiredFieldValidator ID="rfvEmbarazada" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Embarazada" ControlToValidate="ddlEmbarazada" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEmbarazada"></asp:DropDownList>
                    <asp:Label ID="lblEmbarazada" runat="server" />
                </div>
            </div>
            <div class="col-print-4 col-sm-4 SEPSDivs">
                <span class="SEPSLabel">Veterano:</span>
                <asp:RequiredFieldValidator ID="rfvVeterano" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Veterano" ControlToValidate="ddlVeterano" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlVeterano"></asp:DropDownList>
                    <asp:Label ID="lblVeterano" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-4 col-sm SEPSDivsInfo">
                <span class="SEPSLabel">Escolaridad - Último año completado:</span>
                <asp:RequiredFieldValidator ID="rfvEscolaridad" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Escolaridad" ControlToValidate="ddlEscolaridad" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEscolaridad"></asp:DropDownList>
                    <asp:Label ID="lblEscolaridad" runat="server" />
                </div>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-print-3 col-sm-3 SEPSDivsInfo">
                <span class="SEPSLabel">Condición laboral:</span>
                <asp:RequiredFieldValidator ID="rfvCondicionLaboral" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Condición Laboral" ControlToValidate="ddlCondicionLaboral" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCondicionLaboral" onChange="ddlCondLaboral();"></asp:DropDownList>
                    <asp:Label ID="lblCondicionLaboral" runat="server" />
                </div>
            </div>
            <div class="col-print-3 col-sm-3 SEPSDivsInfo">
                <span class="SEPSLabel">No Fuerza Laboral:</span>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlNoFuerzaLaboral" onChange="ddlFuerzaLaboral();"></asp:DropDownList>
                    <asp:Label ID="lblNoFuerzaLaboral" runat="server" />
                </div>
            </div>
            <div class="col-print-3 col-sm-3 SEPSDivsInfo">
                <span class="SEPSLabel">Estudios:</span>
                <asp:RequiredFieldValidator ID="rfvEstudio" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Estudio" ControlToValidate="ddlEstudio" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstudio"></asp:DropDownList>
                    <asp:Label ID="lblEstudio" runat="server" />
                </div>
            </div>
            <div class="col-print-3 col-sm-3 SEPSDivs">
                <span class="SEPSLabel">Fuente de Ingreso:</span>
                <asp:RequiredFieldValidator ID="rfvFuenteIngreso" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Fuente Ingreso" ControlToValidate="ddlFuenteIngreso" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFuenteIngreso"></asp:DropDownList>
                    <asp:Label ID="lblFuenteIngreso" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>