<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucdrogasadmision.ascx.cs" Inherits="CARA_Draftv0._1.App.Perfiles.wucdrogasadmision" %>

<div class="card mb-4">
    <div class="card-header">
        <h5 class="card-title">Información de drogas de uso y diagnósticos</h5>
        <h6>Seleccione todas las sustancias de uso por el paciente. Favor marcar con X el recuerdo correspondiente si la sustancia fue confirmada por una prueba de toxicología, al igual que la vía y frecuencia de uso. Finalmente anoté la edad de primer uso.</h6>
    </div>

    <div class="table-panel-body">
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Droga de Uso</span></th>
                <th><span class="SEPSLabel">Toxicología</span></th>
                <th><span class="SEPSLabel">Vía de uso</span></th>
                <th><span class="SEPSLabel">Frecuncia de uso</span></th>
                <th><span class="SEPSLabel">Edad de primer uso</span></th>
            </tr>
            <tr>
                <th><span class="SEPSLabel">Primaria</span></th>
                <td>
                    <asp:RequiredFieldValidator ID="rfvDrogaPrimaria" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Droga Primaria" ControlToValidate="ddlDrogaPrimaria" InitialValue="0" Text="*"/>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDrogaPrimaria"></asp:DropDownList>
                        <asp:Label ID="lblDrogaPrimaria" runat="server" />
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvToxicologiaPrimaria" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ForeColor="Red" ErrorMessage="Toxicologia Primaria" ControlToValidate="ddlToxicologiaPrimaria" InitialValue="0" Text="*"/>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" ID="ddlToxicologiaPrimaria" CssClass="form-control">
                            <asp:ListItem Value="0" Text="" />
                            <asp:ListItem Value="1" Text="Si" />
                            <asp:ListItem Value="2" Text="No" />
                        </asp:DropDownList>
                        <asp:Label ID="lblToxicologiaPrimaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlViaPrimaria"></asp:DropDownList>
                        <asp:Label ID="lblViaPrimaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFrecuenciaPrimaria"></asp:DropDownList>
                        <asp:Label ID="lblFrecuenciaPrimaria" runat="server" />
                    </div>
                </td>
                <td>
                    <asp:RangeValidator ID="rvEdadPrimaria" CssClass="rightFloatAsterisk" runat="server" ControlToValidate="txtEdadPrimaria" ErrorMessage="Edad de inicio - Droga Primaria" ToolTip="Escriba un número entero menor o igual a la edad del paciente" Type="Integer" MinimumValue="0" Display="Dynamic" Text="*"/>
                    <div class="expandibleDiv">
                        <asp:textbox runat="server" CssClass="form-control" ID="txtEdadPrimaria" MaxLength="2"/>
                        <asp:Label ID="lblEdadPrimaria" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th><span class="SEPSLabel">Secundaria</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDrogaSecundaria" onChange="ddlDrogaSecF();"></asp:DropDownList>
                        <asp:Label ID="lblDrogaSecundaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlToxicologiaSecundaria">
                            <asp:ListItem Value="0" Text="" />
                            <asp:ListItem Value="1" Text="Si" />
                            <asp:ListItem Value="2" Text="No" />
                        </asp:DropDownList>
                        <asp:Label ID="lblToxicologiaSecundaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlViaSecundaria"></asp:DropDownList>
                        <asp:Label ID="lblViaSecundaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFrecuenciaSecundaria"></asp:DropDownList>
                        <asp:Label ID="lblFrecuenciaSecundaria" runat="server" />
                    </div>
                </td>
                <td>
                    <asp:RangeValidator ID="rvEdadSecundaria" CssClass="rightFloatAsterisk" runat="server" ControlToValidate="txtEdadSecundaria" ErrorMessage="Edad de inicio - Droga Secundaria" ToolTip="Escriba un número entero menor o igual a la edad del paciente" Type="Integer" MinimumValue="0" Display="Dynamic" Text="*"/>
                    <div class="expandibleDiv">
                        <asp:textbox runat="server" CssClass="form-control" ID="txtEdadSecundaria"/>
                        <asp:Label ID="lblEdadSecundaria" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th><span class="SEPSLabel">Terciaria</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDrogaTerciaria" onChange="ddlDrogaTerF();"></asp:DropDownList>
                        <asp:Label ID="lblDrogaTerciaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlToxicologiaTerciaria">
                            <asp:ListItem Value="0" Text="" />
                            <asp:ListItem Value="1" Text="Si" />
                            <asp:ListItem Value="2" Text="No" />
                        </asp:DropDownList>
                        <asp:Label ID="lblToxicologiaTerciaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlViaTerciaria"></asp:DropDownList>
                        <asp:Label ID="lblViaTerciaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFrecuenciaTerciaria"></asp:DropDownList>
                        <asp:Label ID="lblFrecuenciaTerciaria" runat="server" />
                    </div>
                </td>
                <td>
                    <asp:RangeValidator ID="rvEdadTerciaria" CssClass="rightFloatAsterisk" runat="server" ControlToValidate="txtEdadTerciaria" ErrorMessage="Edad de inicio - Droga Terciaria" ToolTip="Escriba un número entero menor o igual a la edad del paciente" Type="Integer" MinimumValue="0" Display="Dynamic" Text="*"/>
                    <div class="expandibleDiv">
                        <asp:textbox runat="server" CssClass="form-control" ID="txtEdadTerciaria"/>
                        <asp:Label ID="lblEdadTerciaria" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th><span class="SEPSLabel">Cuarta</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtDrogaCuarta" onBlur="txtDrogaCuaF();"/>
                        <asp:Label ID="lblDrogaCuarta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlToxicologiaCuarta">
                            <asp:ListItem Value="0" Text="" />
                            <asp:ListItem Value="1" Text="Si" />
                            <asp:ListItem Value="2" Text="No" />
                        </asp:DropDownList>
                        <asp:Label ID="lblToxicologiaCuarta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlViaCuarta"></asp:DropDownList>
                        <asp:Label ID="lblViaCuarta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFrecuenciaCuarta"></asp:DropDownList>
                        <asp:Label ID="lblFrecuenciaCuarta" runat="server" />
                    </div>
                </td>
                <td>
                    <asp:RangeValidator ID="rvEdadCuarta" CssClass="rightFloatAsterisk" runat="server" ControlToValidate="txtEdadCuarta" ErrorMessage="Edad de inicio - Droga Cuarta" ToolTip="Escriba un número entero menor o igual a la edad del paciente" Type="Integer" MinimumValue="0" Display="Dynamic" Text="*"/>
                    <div class="expandibleDiv">
                        <asp:textbox runat="server" CssClass="form-control" ID="txtEdadCuarta"/>
                         <asp:Label ID="lblEdadCuarta" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th><span class="SEPSLabel">Quinta</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtDrogaQuinta" onBlur="txtDrogaQuiF();"/>
                        <asp:Label ID="lblDrogaQuinta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlToxicologiaQuinta">
                            <asp:ListItem Value="0" Text="" />
                            <asp:ListItem Value="1" Text="Si" />
                            <asp:ListItem Value="2" Text="No" />
                        </asp:DropDownList>
                        <asp:Label ID="lblToxicologiaQuinta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlViaQuinta"></asp:DropDownList>
                        <asp:Label ID="lblViaQuinta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFrecuenciaQuinta"></asp:DropDownList>
                        <asp:Label ID="lblFrecuenciaQuinta" runat="server" />
                    </div>
                </td>
                <td>
                    <asp:RangeValidator ID="rvEdadQuinta" CssClass="rightFloatAsterisk" runat="server" ControlToValidate="txtEdadQuinta" ErrorMessage="Edad de inicio - Droga Quinta" ToolTip="Escriba un número entero menor o igual a la edad del paciente" Type="Integer" MinimumValue="0" Display="Dynamic" Text="*"/>
                    <div class="expandibleDiv">
                        <asp:textbox runat="server" CssClass="form-control" ID="txtEdadQuinta"/>
                        <asp:Label ID="lblEdadQuinta" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="card mb-4">
    <div class="card-header">
        <h5 class="card-title">Evento de sobredosis en los pasados 12 meses y sustancias consumidas</h5>
    </div>

    <div class="table-panel-body">
        <table class="table table-striped table-hover">
            <tr>
                <th><span class="SEPSLabel">Evento de Sobredosis</span></th>
                <th><span class="SEPSLabel">Primera Droga</span></th>
                <th><span class="SEPSLabel">Segunda Droga</span></th>
                <th><span class="SEPSLabel">Tercera Droga</span></th>
                <th><span class="SEPSLabel">Cuarta Droga</span></th>
            </tr>
            <tr>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSobredosis"  onChange="ddlSobredosisF();">
                            <asp:ListItem Value="0" Text="" />
                            <asp:ListItem Value="1" Text="Si" />
                            <asp:ListItem Value="2" Text="No" />
                        </asp:DropDownList>
                        <asp:Label ID="lblSobredosis" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSobredosisPrimaria" onChange="ddlSobrePrimF();"></asp:DropDownList>
                        <asp:Label ID="lblSobredosisPrimaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSobredosisSecundaria"></asp:DropDownList>
                        <asp:Label ID="lblSobredosisSecundaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:textbox runat="server" CssClass="form-control" ID="txtSobredosisTerciaria"></asp:textbox>
                        <asp:Label ID="lblSobredosisTerciaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:textbox runat="server" CssClass="form-control" ID="txtSobredosisCuarta"/>
                        <asp:Label ID="lblSobredosisCuarta" runat="server" />
                    </div>
                </td>
            </tr>

       </table>
    </div>
</div>

<div class="card mb-4">
    <div class="card-header">
        <h5 class="card-title">Diagnósticos y Condiciones de salud física</h5>
        <h6>Seleccione los códigos de diagnóstico de adicción (ICD10) y salud mental (DSM 5) del cliente al igual que otras condiciones físicas que pueda tener.</h6>
    </div>

    <div class="table-panel-body">
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Diagnósticos de adicción</span></th>
                <th><span class="SEPSLabel">Diagnósticos de salud mental</span></th>
                <th><span class="SEPSLabel">Condiciones de salud física</span></th>
            </tr>
            <tr>
                <th><span class="SEPSLabel">1.</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlICDXPrimaria"></asp:DropDownList>
                        <asp:Label ID="lblICDXPrimaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDSMVPrimaria"></asp:DropDownList>
                        <asp:Label ID="lblDSMVPrimaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCondicionPrimaria"></asp:DropDownList>
                        <asp:Label ID="lblCondicionPrimaria" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th><span class="SEPSLabel">2.</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlICDXSecundaria"></asp:DropDownList>
                        <asp:Label ID="lblICDXSecundaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDSMVSecundaria"></asp:DropDownList>
                        <asp:Label ID="lblDSMVSecundaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCondicionSecundaria"></asp:DropDownList>
                        <asp:Label ID="lblCondicionSecundaria" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th><span class="SEPSLabel">3.</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlICDXTerciaria"></asp:DropDownList>
                        <asp:Label ID="lblICDXTerciaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDSMVTerciaria"></asp:DropDownList>
                        <asp:Label ID="lblDSMVTerciaria" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCondicionTerciaria"></asp:DropDownList>
                        <asp:Label ID="lblCondicionTerciaria" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <th><span class="SEPSLabel">4.</span></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlICDXCuarta"></asp:DropDownList>
                        <asp:Label ID="lblICDXCuarta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDSMVCuarta"></asp:DropDownList>
                        <asp:Label ID="lblDSMVCuarta" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCondicionCuarta"></asp:DropDownList>
                        <asp:Label ID="lblCondicionCuarta" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>

<div class="card">
    <div class="table-panel-body">
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Nivel de Cuidado de Uso de Sustancias</span></th>
                <th><span class="SEPSLabel">Seguro de Salud</span></th>
            </tr>
            <tr>
                <th></th>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlNivelSustancia"></asp:DropDownList>
                        <asp:Label ID="lblNivelSustancia" runat="server" />
                    </div>
                </td>
                <td>
                    <div class="expandibleDiv">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSeguroSalud"></asp:DropDownList>
                        <asp:Label ID="lblSeguroSalud" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>