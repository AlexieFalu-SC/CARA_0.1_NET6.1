<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="frmcentro.aspx.cs" Inherits="CARA_Draftv0._1.App.Perfiles.frmCentro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<main>
    <div class="container-fluid">
        <div class="row justify-content-center">
            
              
                    <div class="card mb-4 mb-xl-0">
                        <div class="card-header"><h3 class="card-title">Selección de Centro Para Acceder a Registro</h3></div>
                            <div class="card-body">
                                    <div class="row">
                                        <div class="col-xl-6">
                                            <div class="card mb-4 mb-xl-0">
                                                <div class="card-header"><h4 class="card-title">Selección de Centro</h4></div>
                                                <div class="card-body">
                                                    <div class="form-group">
                                                        <label class="control-label">Centro:</label>
                                                        <asp:DropDownList runat="server" ID="ddlCentro" OnSelectedIndexChanged="CambioDePrograma" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                        
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xl-6">
                                            <div class="card mb-4 mb-xl-0">
                                                <div class="card-header"><h4 class="card-title">Selección la Licencia</h4></div>
                                                <div class="card-body">
                                                    <div class="form-group">
                                                        <label class="control-label">Licencia:</label>
                                                        <asp:DropDownList runat="server" ID="ddlLicencias" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>
                                <hr />
                                    <div class="row">
                                        <div class="col">
                                            <asp:Button ID="btnAutenticarPrograma" runat="server" CssClass="btn btn-outline-secondary form-control" Text="Seleccionar" OnClick="btnAutenticarPrograma_Click" />
                                        </div>
                                    </div>
                            </div>
                    </div>
                
            
        </div>
    </div>
</main>

</asp:Content>
