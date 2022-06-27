using CARA_Draftv0._1.Models;
using ClosedXML.Excel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class adminImportarUsuariosFacilidades : System.Web.UI.Page
    {
        ApplicationDbContext context = new ApplicationDbContext();
        ApplicationUser Usuario = new ApplicationUser();
        protected string PK_Sesion;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            PK_Sesion = Session["PK_Sesion"].ToString();
            Usuario = (ApplicationUser)Session["Usuario"];

            string mensaje = string.Empty;

            Guid idSlyc = Guid.NewGuid();

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    //Open the Excel file using ClosedXML.
                    using (XLWorkbook workBook = new XLWorkbook(FileUpload1.PostedFile.InputStream))
                    {
                        //Read the first Sheet from Excel file.
                        IXLWorksheet workSheet = workBook.Worksheet(1);

                        //Create a new DataTable.
                        DataTable dt = new DataTable();

                        //Loop through the Worksheet rows.
                        bool firstRow = true;
                        foreach (IXLRow row in workSheet.Rows())
                        {
                            //Use the first row to add columns to DataTable.
                            if (firstRow)
                            {
                                //foreach (IXLCell cell in row.Cells())
                                //{
                                //    dt.Columns.Add(cell.Value.ToString());
                                //}
                                for (int i = 0; i < 11; i++)
                                {
                                    if(i == 0)
                                    {
                                        dt.Columns.Add("Email");
                                    }
                                    else if (i == 1)
                                    {
                                        dt.Columns.Add("Nombre Primero");
                                    }
                                    else if (i == 2)
                                    {
                                        dt.Columns.Add("Nombre Segundo");
                                    }
                                    else if (i == 3)
                                    {
                                        dt.Columns.Add("Apellido Primero");
                                    }
                                    else if (i == 4)
                                    {
                                        dt.Columns.Add("Apellido Segundo");
                                    }
                                    else if (i == 5)
                                    {
                                        dt.Columns.Add("Telefono");
                                    }
                                    else if (i == 6)
                                    {
                                        dt.Columns.Add("Nombre de Facilidad");
                                    }
                                    else if (i == 7)
                                    {
                                        dt.Columns.Add("Nombre de Licencia");
                                    }
                                    else if (i == 8)
                                    {
                                        dt.Columns.Add("Numero de Licencia");
                                    }
                                    else if (i == 9)
                                    {
                                        dt.Columns.Add("Fecha Expiracion Licencia");
                                    }
                                    else if (i == 10)
                                    {
                                        dt.Columns.Add("Codigo de Licencia");
                                    }
                                }
                                firstRow = false;
                            }
                            else
                            {
                                if(!row.IsEmpty())
                                {
                                    //Add rows to DataTable.
                                    dt.Rows.Add();
                                    //int i = 0;
                                    for (int i = 0; i < 10; i++)
                                    {
                                        if ((i != 0 && i != 2 && i != 4) && string.IsNullOrWhiteSpace(row.Cell(i + 1).Value.ToString().Trim()))
                                        {
                                            mensaje = "Alguna información del correo electrónico: " + dt.Rows[dt.Rows.Count - 1][0] + " se encuentra en blanco. Favor de arreglarlo para poder importar el documento.";
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                            return;
                                        }
                                        else
                                        {
                                            if (i == 0)
                                            {
                                                var emailExiste = manager.FindByEmail(row.Cell(i + 1).Value.ToString().Trim());

                                                if (!emailValidator(row.Cell(i + 1).Value.ToString().Trim()))
                                                {
                                                    mensaje = "El correo electrónico: " + row.Cell(i + 1).Value.ToString().Trim() + " contiene un formato erroneo. Favor de arreglarlo para poder importar el documento.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                                else if (emailExiste != null)
                                                {
                                                    mensaje = "Una cuenta con el email: " + row.Cell(i + 1).Value.ToString().Trim() + " ya existe. Si desea registrarle una facilidad a dicha cuenta, favor acceder a la pantalla de agregar facilidades.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                            }
                                            else if (i == 5)
                                            {
                                                if (!phoneValidator(row.Cell(i + 1).Value.ToString().Trim()))
                                                {
                                                    mensaje = "El teléfono del correo electrónico: " + dt.Rows[dt.Rows.Count - 1][0] + " contiene un formato erroneo. Favor de arreglarlo para poder importar el documento.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                            }
                                            else if (i == 7)
                                            {
                                                string licencia = row.Cell(i + 1).Value.ToString().ToUpper().Trim();
                                                var licencias = dsCARA.CA_LICENCIA.Where(a => a.NB_Licencia.ToUpper() == licencia).FirstOrDefault();

                                                if (licencias == null)
                                                {
                                                    mensaje = "El nombre de la licencia del correo electrónico: " + dt.Rows[dt.Rows.Count - 1][0] + " contiene un formato erroneo al nombre que contiene el sistema. Favor de arreglarlo para poder importar el documento.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                                else
                                                {
                                                    dt.Rows[dt.Rows.Count - 1][10] = licencias.PK_Licencia.ToString();
                                                }
                                            }
                                            else if (i == 9)
                                            {
                                                DateTime dDate;

                                                if (DateTime.TryParse(row.Cell(i + 1).Value.ToString().ToUpper().Trim(), out dDate))
                                                {
                                                    String.Format("{0:d/MM/yyyy}", dDate);
                                                }
                                                else
                                                {
                                                    mensaje = "La fecha de expiración de licencia del correo electrónico: " + dt.Rows[dt.Rows.Count - 1][0] + " contiene un formato erroneo. Favor de arreglarlo para poder importar el documento.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                            }
                                            dt.Rows[dt.Rows.Count - 1][i] = row.Cell(i + 1).Value.ToString().ToUpper().Trim();
                                            //i++;
                                        }

                                    }
                                }
                                
                            }

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            this.divExcel.Visible = true;
                            this.btnRegistrar.Visible = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }

                //this.coverScreen.Visible = false;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                return;
            }


            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            PK_Sesion = Session["PK_Sesion"].ToString();
            Usuario = (ApplicationUser)Session["Usuario"];

            string mensaje = string.Empty;

            Guid idSlyc = Guid.NewGuid();

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        string email = row.Cells[0].Text;
                        string nbPrimero = row.Cells[1].Text;
                        string nbSegundo = row.Cells[2].Text;
                        string apPrimero = row.Cells[3].Text;
                        string apSegundo = row.Cells[4].Text;
                        string telefono = row.Cells[5].Text;
                        string nbFacilidad = row.Cells[6].Text;

                        string nblicencia = row.Cells[7].Text;
                        int pk_licencia = Convert.ToInt32(row.Cells[10].Text);

                        string numLicencia = row.Cells[8].Text;
                        DateTime fechaExp = Convert.ToDateTime(row.Cells[9].Text);

                        var user = new ApplicationUser()
                        {
                            UserName = email.ToLower(),
                            Email = email.ToLower(),
                            NB_Primero = nbPrimero,
                            NB_Segundo = nbSegundo,
                            AP_Primero = apPrimero,
                            AP_Segundo = apSegundo,
                            Tel_Celular = telefono,
                            Tel_Trabajo = telefono,
                            PasswordChanged = false,
                            Active = true,
                            EmailConfirmed = false,
                            LockoutEnabled = false
                        };

                        //var newuser = userManager.Create(user, password);
                        var newuser = userManager.Create(user);

                        if (newuser.Succeeded)
                        {
                            userManager.AddToRole(user.Id, "Registrado Administrativo");

                            dsCARA.SPC_CENTRO(nbFacilidad, idSlyc, "", email);

                            int pk_centro = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.Email == email.ToLower()).Select(f => f.PK_Centro).First();

                            dsCARA.SPC_ATAR_CENTRO_LICENCIA(pk_centro, pk_licencia, numLicencia, fechaExp);

                            dsCARA.SPC_SESION_ACTIVIDAD(PK_Sesion, "UsuarioRegistrado", "C", user.Id, pk_centro, null, null);

                            string code = manager.GenerateEmailConfirmationToken(user.Id);
                            string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                            string body = CreateBody(callbackUrl, "1234", nbPrimero, apPrimero, email);
                            manager.SendEmail(user.Id, "Confirmacion de su cuenta", body);
                        }

                    }

                    mensaje = "El registro de los nuevos usuarios y su primera facilidad fué correcto. Se envió un email de confirmación a los nuevos usuario para realizar la confirmación de cuenta.";

                    ClientScript.RegisterStartupScript(this.GetType(), "Usuario Registrado", "sweetAlertRef('Usuario Registrado','" + mensaje + "','success','" + "App/Administracion/adminListaUsuarios.aspx" + "');", true);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }

                //this.coverScreen.Visible = false;

                ClientScript.RegisterStartupScript(this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                return;
            }
        }

        private static bool emailValidator(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private static bool phoneValidator(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }
            //var pattern = @"^[\+]?[{1}]?[(]?[2-9]\d{2}[)]?[-\s\.]?[2-9]\d{2}[-\s\.]?[0-9]{4}$";
            var pattern = @"^\d{10}$";
            var options = System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.IgnoreCase;
            return System.Text.RegularExpressions.Regex.IsMatch(phone, pattern, options);
        }

        private string CreateBody(string Code, string password, string nbPrimero, string apPrimero,string email)
        {
            string body = string.Empty;
            string code = "<a href =\"" + Code + "\" class=\"es-button\" target=\"_blank\" style=\"mso-style-priority:100 !important;text-decoration:none;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;font-size:18px;color:#4A7EB0;border-style:solid;border-color:#EFEFEF;border-width:10px 25px;display:inline-block;background:#EFEFEF;border-radius:0px;font-weight:normal;font-style:normal;line-height:22px;width:auto;text-align:center;\">Confirmar Cuenta</a>";
            using (StreamReader reader = new StreamReader(Server.MapPath("~/App/EmailsHTML/ConfirmacionCuenta.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{NombreCompleto}", nbPrimero + " " + apPrimero);
            body = body.Replace("{email}", email);
            body = body.Replace("{password}", password);
            body = body.Replace("{botonConfirmar}", code);

            return body;

        }
    }
}