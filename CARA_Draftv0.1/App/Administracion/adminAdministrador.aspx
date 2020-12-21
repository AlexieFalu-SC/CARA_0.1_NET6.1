<%@ Page Title="" Language="C#" MasterPageFile="~/Website.Master" AutoEventWireup="true" CodeBehind="adminAdministrador.aspx.cs" Inherits="CARA_Draftv0._1.App.Administracion.adminAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    <div id="AdminRegistradoBox" runat="server">

        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-5 border-bottom">
            <h1 class="h2">Administración</h1>
            <div class="btn-toolbar mb-2 mb-md-0">
              <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-outline-secondary">Compartir</button>
            <button type="button" class="btn btn-sm btn-outline-secondary" onclick="javascript:window.print();">Imprimir</button>
              </div>
            </div>
         </div>

        <div class="mb-4">
            

            <div>

                <ul class="nav nav-tabs mb-4" id="myTab" role="tablist">
                  <li class="nav-item" role="presentation">
                    <a class="nav-link active" id="usuariosAdmin-tab" data-toggle="tab" href="#usuariosAdmin" role="tab" aria-controls="usuariosAdmin" aria-selected="true">Usuarios Administradores</a>
                  </li>
                  <li class="nav-item" role="presentation">
                    <a class="nav-link" id="usuarios-tab" data-toggle="tab" href="#usuarios" role="tab" aria-controls="usuarios" aria-selected="false">Usuarios Registrados</a>
                  </li>
                  <li class="nav-item" role="presentation">
                    <a class="nav-link" id="centros-tab" data-toggle="tab" href="#centros" role="tab" aria-controls="centros" aria-selected="false">Centros</a>
                  </li>
                  <li class="nav-item" role="presentation">
                    <a class="nav-link" id="rolesAdmin-tab" data-toggle="tab" href="#rolesAdmin" role="tab" aria-controls="rolesAdmin" aria-selected="false">Roles Administradores</a>
                  </li>
                  <li class="nav-item" role="presentation">
                    <a class="nav-link" id="roles-tab" data-toggle="tab" href="#roles" role="tab" aria-controls="roles" aria-selected="false">Roles Registrados</a>
                  </li>
                </ul>
                <div class="tab-content" id="myTabContent">

                  <div class="tab-pane fade show active" id="usuariosAdmin" role="tabpanel" aria-labelledby="usuariosAdmin-tab">
                      <div class="btn-toolbar justify-content-between mb-4" role="toolbar" aria-label="Toolbar with button groups">
                          <%--<div class="btn-group" role="group" aria-label="First group">
                            <asp:Button ID="btnActivarUsuario" runat="server" CssClass="btn btn-outline-secondary" Text="Activar Usuario" />
                            <asp:Button ID="btnDesactivarUsuario" runat="server" CssClass="btn btn-outline-secondary" Text="Desactivar Usuario" />
                          </div>--%>
                          <div id="divBotonesAdmin" style="padding-top: 10px;">
                                <asp:Button ID="btnAgregarUsuario" runat="server" CssClass="btn btn-outline-secondary" PostBackUrl="~/Account/RegistroRegistrado.aspx?roles=administradores" Text="Agregar Administrativo" />
                          </div>
                        </div>

                      

                      <div class="card mb-4">
                        <div class="card-header">

                            <div class="row">
                       
                                <div class="col-md-4 text-left">
                                    <span>
                                        <asp:Literal ID="LitCantidadUsuarios" runat="server"></asp:Literal>
                                        Usuarios Administradores Encontrados</span>
                                </div>
                            </div>

                        </div>
                
                          <%--<asp:CheckBox ID="CheckBox1" runat="server"/>--%>
                        <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="gvUsuarios_PageIndexChanging" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Usuario">
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>  
                                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                                    </EditItemTemplate>  
                                    <ItemTemplate>  
                                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                                    </ItemTemplate>  
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Roles" HeaderText="Roles" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Cuenta" HeaderText="Cuenta" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Estatus" HeaderText="Estatus" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>                        
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="card-block">
                                    <p class="text-center pt-4 pb-4">Ningún usuario.</p>
                                </div>
                             </EmptyDataTemplate>

                            <PagerSettings Visible="False"></PagerSettings>

                        </asp:GridView>
                    </div>


                      Página #:        
                    <asp:DropDownList ID="ddlJumpTo" runat="server" OnSelectedIndexChanged="PageNumberChanged" AutoPostBack="true"></asp:DropDownList>


                  </div>

                  <div class="tab-pane fade" id="usuarios" role="tabpanel" aria-labelledby="usuarios-tab">
                   <div class="btn-toolbar justify-content-between mb-4" role="toolbar" aria-label="Toolbar with button groups">
                          <%--<div class="btn-group" role="group" aria-label="First group">
                            <asp:Button ID="btnActivarUsuario" runat="server" CssClass="btn btn-outline-secondary" Text="Activar Usuario" />
                            <asp:Button ID="btnDesactivarUsuario" runat="server" CssClass="btn btn-outline-secondary" Text="Desactivar Usuario" />
                          </div>--%>
                          <div id="divBotonesRegistrados" style="padding-top: 10px;">
                                <asp:Button ID="btnAgregarRegistrado" runat="server" CssClass="btn btn-outline-secondary" PostBackUrl="~/Account/RegistroRegistrado.aspx?roles=registrados" Text="Agregar Registrado" />
                          </div>
                        </div>

                      <div class="card mb-4">
                        <div class="card-header">

                            <div class="row">
                       
                                <div class="col-md-4 text-left">
                                    <span>
                                        <asp:Literal ID="LitCantidadRegistrados" runat="server"></asp:Literal>
                                        Usuarios Registrados Encontrados</span>
                                </div>
                            </div>

                        </div>
                
                          <%--<asp:CheckBox ID="CheckBox1" runat="server"/>--%>
                        <asp:GridView ID="gvUsuariosRegistrados" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="gvUsuariosRegistrados_PageIndexChanging" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Usuario">
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>  
                                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                                    </EditItemTemplate>  
                                    <ItemTemplate>  
                                        <asp:CheckBox ID="CheckBox1" runat="server" />  
                                    </ItemTemplate>  
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Roles" HeaderText="Roles" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Cuenta" HeaderText="Cuenta" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Estatus" HeaderText="Estatus" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>                        
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="card-block">
                                    <p class="text-center pt-4 pb-4">Ningún usuario.</p>
                                </div>
                             </EmptyDataTemplate>

                            <PagerSettings Visible="False"></PagerSettings>

                        </asp:GridView>
                    </div>


                      Página #:        
                    <asp:DropDownList ID="ddlJumpToRegistrados" runat="server" OnSelectedIndexChanged="PageNumberChangedRegistrados" AutoPostBack="true"></asp:DropDownList>

                  </div>

                  <div class="tab-pane fade" id="centros" role="tabpanel" aria-labelledby="centros-tab">

                      <div class="btn-toolbar justify-content-between mb-4" role="toolbar" aria-label="Toolbar with button groups">
                          <%--<div class="btn-group" role="group" aria-label="First group">
                            <asp:Button ID="btnActivarUsuario" runat="server" CssClass="btn btn-outline-secondary" Text="Activar Usuario" />
                            <asp:Button ID="btnDesactivarUsuario" runat="server" CssClass="btn btn-outline-secondary" Text="Desactivar Usuario" />
                          </div>--%>
                          <div id="divBotonesCentros" style="padding-top: 10px;">
                                <asp:Button ID="btnRegistrarCentro" runat="server" CssClass="btn btn-outline-secondary" PostBackUrl="~/App/Administracion/agregarCentro.aspx" Text="Registrar Centro" />
                          </div>
                        </div>

                      <div class="card mb-4">
                          <div class="card-header">
                              <div class="row">
                                  <div class="col-md-4 text-left">
                                      <span><asp:Literal ID="LitCantidadCentros" runat="server"></asp:Literal> Centros Encontrados</span>
                                  </div>
                              </div>
                          </div>

                          <asp:GridView ID="gvCentros" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="gvCentros_PageIndexChanging" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Centro" runat="server">
                              <Columns>
                                <asp:BoundField DataField="Centro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ID_Proveedor" HeaderText="ID Proveedor" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Registrado" HeaderText="Registrado" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Estatus" HeaderText="Estatus" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                              </Columns>
                              <EmptyDataTemplate>
                                <div class="card-block">
                                    <p class="text-center pt-4 pb-4">Ningún centro.</p>
                                </div>
                             </EmptyDataTemplate>

                            <PagerSettings Visible="False"></PagerSettings>
                          </asp:GridView>

                      </div>

                      Página #:        
                    <asp:DropDownList ID="ddlJumpCentros" runat="server" OnSelectedIndexChanged="PaginaCambiaCentros" AutoPostBack="true"></asp:DropDownList>

                  </div>

                  <div class="tab-pane fade" id="rolesAdmin" role="tabpanel" aria-labelledby="rolesAdmin-tab">

                      <div class="card mb-4">
                          <div class="card-header">
                              <div class="row">
                                  <div class="col-md-4 text-left">
                                      <span><asp:Literal ID="LitCantidadRoles" runat="server"></asp:Literal> Roles Encontrados</span>
                                  </div>
                              </div>
                          </div>

                          <asp:GridView ID="gvRoles" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="gvRoles_PageIndexChanging" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Roles" runat="server">
                              <Columns>
                                <asp:TemplateField HeaderText="Perfil">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRol" runat="server" Text='<%# Bind("Nombre") %>' OnClick="lnkRol_Click" CommandArgument='<%# Eval("PK_Roles") +","+ Eval("Nombre")%>' CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de Usuarios" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                              </Columns>
                              <EmptyDataTemplate>
                                <div class="card-block">
                                    <p class="text-center pt-4 pb-4">Ningún rol.</p>
                                </div>
                             </EmptyDataTemplate>

                            <PagerSettings Visible="False"></PagerSettings>
                          </asp:GridView>

                      </div>

                      Página #:        
                    <asp:DropDownList ID="ddlJumpRoles" runat="server" OnSelectedIndexChanged="PaginaCambiaRoles" AutoPostBack="true"></asp:DropDownList>

                  </div>

                    <div class="tab-pane fade" id="roles" role="tabpanel" aria-labelledby="roles-tab">
                    
                        <div class="card mb-4">
                          <div class="card-header">
                              <div class="row">
                                  <div class="col-md-4 text-left">
                                      <span><asp:Literal ID="LitCantidadRolesRegistrados" runat="server"></asp:Literal> Roles Encontrados</span>
                                  </div>
                              </div>
                          </div>

                          <asp:GridView ID="gvRolesRegistrados" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="gvRolesRegistrados_PageIndexChanging" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Roles" runat="server">
                              <Columns>
                                <asp:TemplateField HeaderText="Perfil">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRolRegistrado" runat="server" Text='<%# Bind("Nombre") %>' OnClick="lnkRolRegistrado_Click" CommandArgument='<%# Eval("PK_Roles") +","+ Eval("Nombre")%>' CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de Usuarios" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                              </Columns>
                              <EmptyDataTemplate>
                                <div class="card-block">
                                    <p class="text-center pt-4 pb-4">Ningún rol.</p>
                                </div>
                             </EmptyDataTemplate>

                            <PagerSettings Visible="False"></PagerSettings>
                          </asp:GridView>

                      </div>

                      Página #:        
                    <asp:DropDownList ID="ddlJumpRolesRegistrados" runat="server" OnSelectedIndexChanged="PaginaCambiaRolesRegistrados" AutoPostBack="true"></asp:DropDownList>


                  </div>

                </div>

            </div>

        </div>

    </div>
</main>

</asp:Content>
