<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucListaUsuariosExternos.ascx.cs" Inherits="CARA_Draftv0._1.App.Administracion.wucListaUsuariosExternos" %>

<div class="card">
    <div class="card-header">
        <div class="btn-toolbar justify-content-between" role="toolbar">
            <div>
                <h4>Usuarios Externos</h4>
            </div>
            <div>
            <a class="btn btn-sm btn-light text-primary"  runat="server" href="~/Account/Register">
                <i class="fas fa-fw fa-file-export"></i>
                Registrar Usuario Externos
            </a>
            </div>
        </div>
    </div>
    <div class="card-body">
        <div class="table-responsive">

            <asp:GridView runat="server" ID="gvUsuariosExternosList" CssClass="table table-bordered usuariosExternosListTable" Width="100%" AutoGenerateColumns="false" DataKeyNames="Cuenta_Princiapal" onrowdatabound="gvUsuariosSecList_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:GridView ID="gvUsuariosSecList" runat="server" AutoGenerateColumns="false" DataKeyNames="Cuenta_Princiapal" CssClass="ChildGrid">
                                <Columns>
                                    <asp:TemplateField HeaderText="Usuario">
                                        <ItemTemplate>
                                            <div class="row d-flex align-items-center">
                                                <div class="avatar me-2">
                                                    &nbsp
                                                    <asp:Image ID="profileImg" ImageUrl='<%# Eval("Imagen_Perfil") %>' runat="server" CssClass="avatar-img img-fluid" />
                                                </div>
                                         
                                                &nbsp
                                                <%# Eval("Nombre") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Email" HeaderText="CorreoElectrónico" />
                                    <asp:BoundField DataField="Rol" HeaderText="Rol" />
                                    <asp:TemplateField HeaderText="Módulos Accesibles">
                                        <ItemTemplate>
                                            <div class="row">&nbsp <%# Eval("Accesos") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Confirmado">
                                        <ItemTemplate>
                                            <div class="row">&nbsp <%# Eval("Confirmado") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estatus">
                                        <ItemTemplate>
                                            <div class="row">&nbsp <%# Eval("Estatus") %></div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acciones"> 
                                        <ItemTemplate>
                                            <asp:Label ID="Edit" runat="server" Enabled="true"></asp:Label>
                                            <a href='<%=ResolveClientUrl("~/Account/EditUser.aspx?pk_usuario=")%><%#Eval("PK_Usuario")%>' ><i class='fas fa-fw fa-edit'></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario">
                        <ItemTemplate>
                            <div class="row d-flex align-items-center">
                                <div class="avatar me-2">
                                    &nbsp
                                    <asp:Image ID="profileImg" ImageUrl='<%# Eval("Imagen_Perfil") %>' runat="server" CssClass="avatar-img img-fluid" />
                                </div>
                                         
                                &nbsp
                                <%# Eval("Nombre") %></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Email" HeaderText="CorreoElectrónico" />
                    <asp:BoundField DataField="Rol" HeaderText="Rol" />
                    <asp:TemplateField HeaderText="Módulos Accesibles">
                        <ItemTemplate>
                            <div class="row">&nbsp <%# Eval("Accesos") %></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Confirmado">
                        <ItemTemplate>
                            <div class="row">&nbsp <%# Eval("Confirmado") %></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <div class="row">&nbsp <%# Eval("Estatus") %></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones"> 
                        <ItemTemplate>
                            <asp:Label ID="Edit" runat="server" Enabled="true"></asp:Label>
                            <a href='<%=ResolveClientUrl("~/Account/EditUser.aspx?pk_usuario=")%><%#Eval("PK_Usuario")%>' ><i class='fas fa-fw fa-edit'></i></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                            
                </Columns>
                <EmptyDataTemplate>
                    No existen usuarios adicionales al de usted
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</div>