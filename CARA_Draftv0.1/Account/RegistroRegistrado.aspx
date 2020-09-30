<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="RegistroRegistrado.aspx.cs" Inherits="CARA_Draftv0._1.Account.RegistroRegistrado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--     <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>
    <link href="<%=ResolveClientUrl("~/Content/account/login.css")%>" type="text/css" rel="stylesheet" />--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    <div id="RegistroRegistradoBox" runat="server">

        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-5 border-bottom">
            <h1 class="h2">Agregar Usuario</h1>
            <div class="btn-toolbar mb-2 mb-md-0">
              <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-outline-secondary">Compartir</button>
            <button type="button" class="btn btn-sm btn-outline-secondary" onclick="javascript:window.print();">Imprimir</button>
              </div>
            </div>
         </div>

        <div class="d-flex justify-content-center mb-4">
            

         
           <%--   <h1 class="h3 mb-3 font-weight-normal">Acceda a su cuenta</h1>
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                    <p class="text-danger">
                                        <asp:Literal runat="server" ID="FailureText" />
                                    </p>
                                </asp:PlaceHolder>
              <asp:Label runat="server" AssociatedControlID="Email" CssClass="sr-only">Email</asp:Label>

                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Placeholder="Correo Electrónico" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                            CssClass="text-danger" ErrorMessage="The email field is required." />

                <asp:Label runat="server" AssociatedControlID="Password" CssClass="sr-only">Password</asp:Label>

                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Placeholder="Contraseña"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                  <div class="checkbox mb-3">
                 
                      <asp:CheckBox runat="server" ID="RememberMe" />
                      <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                  </div>
                <asp:Button runat="server"  Text="Acceder" CssClass="btn btn-lg btn-primary btn-block" />
              <p class="mt-5 mb-3 text-muted">&copy; 2017-2020</p>--%>

             
            <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <div class="card">
              <div class="card-header text-center">
                Nuevo Usuario
              </div>
              <div class="card-body">

            <div class="form">
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-12 control-label">Email</asp:Label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="El campo de email es requerido." />
                        </div>
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="txtTel" CssClass="col-md-12 control-label">Teléfono</asp:Label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtTel" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTel"
                                CssClass="text-danger" ErrorMessage="El campo de teléfono es requerido." />
                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="txtNB_Primero" CssClass="col-md-12 control-label">Primer Nombre</asp:Label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtNB_Primero" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNB_Primero"
                                CssClass="text-danger" ErrorMessage="El primer nombre es requerido." />
                        </div>
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="txtNB_Segundo" CssClass="col-md-12 control-label">Segundo Nombre</asp:Label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtNB_Segundo" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="txtAP_Primero" CssClass="col-md-12 control-label">Primer Apellido</asp:Label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtAP_Primero" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAP_Primero"
                                CssClass="text-danger" ErrorMessage="El primer apellido es requerido." />
                        </div>
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="txtAP_Segundo" CssClass="col-md-12 control-label">Segundo Apellido</asp:Label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="txtAP_Segundo" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRol" CssClass="col-md-12 control-label">Role</asp:Label>
                    <div class="col-md-12">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlRol"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRol" InitialValue="0"
                                CssClass="text-danger" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Rol de Usuario." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Register" OnClick="BtnRegistrar_Click" CssClass="btn btn-outline-secondary" />
                    </div>
                </div>
            </div>

      </div>
      <div class="card-footer text-muted text-center">
    2 days ago
  </div>
</div>

        </div>

    </div>
</main>

<script type="text/javascript">
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }

    function sweetAlertRef(titulo, texto, icono, ref) {

        swal({
            title: titulo,
            text: texto,
            icon: icono
        }).then((value) => { window.location.href = ref; });
    }

    function sweetAlert(titulo, texto, icono) {
        swal({
            title: titulo,
            text: texto,
            icon: icono
        })
    }
</script>

</asp:Content>
