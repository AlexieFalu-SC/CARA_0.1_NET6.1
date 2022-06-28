using CARA_Draftv0._1.Models;
using ClosedXML.Excel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Administracion
{
    public partial class adminImportarFacilidades : System.Web.UI.Page
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
                                    if (i == 0)
                                    {
                                        dt.Columns.Add("Email");
                                    }
                                    else if (i == 1)
                                    {
                                        dt.Columns.Add("Nombre de Facilidad");
                                    }
                                    else if (i == 2)
                                    {
                                        dt.Columns.Add("Nombre de Licencia");
                                    }
                                    else if (i == 3)
                                    {
                                        dt.Columns.Add("Numero de Licencia");
                                    }
                                    else if (i == 4)
                                    {
                                        dt.Columns.Add("Fecha Expiracion Licencia");
                                    }
                                    else if (i == 5)
                                    {
                                        dt.Columns.Add("Codigo de Licencia");
                                    }
                                }
                                firstRow = false;
                            }
                            else
                            {
                                if (!row.IsEmpty())
                                {
                                    //Add rows to DataTable.
                                    dt.Rows.Add();
                                    //int i = 0;
                                    for (int i = 0; i < 5; i++)
                                    {
                                        if ((i != 0) && string.IsNullOrWhiteSpace(row.Cell(i + 1).Value.ToString().Trim()))
                                        {
                                            mensaje = "Alguna información del correo electrónico: " + dt.Rows[dt.Rows.Count - 1][0] + " se encuentra en blanco. Favor de arreglarlo para poder importar el documento.";
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                            return;
                                        }
                                        else
                                        {
                                            if (i == 0)
                                            {
                                                string emailActual = row.Cell(i + 1).Value.ToString().Trim();
                                                var emailExiste = manager.FindByEmail(emailActual);

                                                var pkUsuario = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.Email == emailActual).Select(b => b.PK_Usuario).FirstOrDefault();
                                                var pkPrincipal = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.Email == emailActual).Select(b => b.Cuenta_Princiapal).FirstOrDefault();
                                                var emailPrincipal = dsCARA.VW_LISTA_USUARIOS_REGISTRADOS.Where(a => a.PK_Usuario == pkPrincipal).Select(b => b.Email).FirstOrDefault();

                                                if (!emailValidator(row.Cell(i + 1).Value.ToString().Trim()))
                                                {
                                                    mensaje = "El correo electrónico: " + emailActual + " contiene un formato erroneo. Favor de arreglarlo para poder importar el documento.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                                else if (emailExiste == null)
                                                {
                                                    mensaje = "No existe una cuenta con el email: " + row.Cell(i + 1).Value.ToString().Trim() + ". Favor verificar que el email este correcto o que sea la cuenta principal.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                                else if (pkUsuario != pkPrincipal)
                                                {
                                                    mensaje = "El correo electrónico: " + emailActual + " NO es la cuenta principal, la cuenta principal es "+ emailPrincipal + ". Favor de arreglarlo para poder importar el documento.";
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                            }
                                            else if (i == 1)
                                            {
                                                string email = dt.Rows[dt.Rows.Count - 1][0].ToString();
                                                string nbFacilidad = row.Cell(i + 1).Value.ToString().Trim();

                                                int centroExiste = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.Email == email).Where(b => b.Centro == nbFacilidad).Select(f => f.PK_Centro).FirstOrDefault();

                                                if (centroExiste != 0)
                                                {
                                                    mensaje = "Una cuenta con el email: " + email + " y facilidad: " + nbFacilidad + " ya existe. Favor de arreglarlo para poder importar el documento.";
                                                    //this.coverScreen.Visible = false;
                                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                                                    return;
                                                }
                                            }
                                            else if (i == 2)
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
                                                    dt.Rows[dt.Rows.Count - 1][5] = licencias.PK_Licencia.ToString();
                                                }
                                            }
                                            else if (i == 4)
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

                            
                        }

                        this.divExcel.Visible = true;
                        this.btnRegistrar.Visible = true;

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

                mensaje = mensaje.Replace("'", "*");
                //this.coverScreen.Visible = false;

                //ClientScript.RegisterStartupScript(this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error');", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + "hola" + "','error');", true);
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
                        string nbFacilidad = row.Cells[1].Text;

                        string nblicencia = row.Cells[2].Text;
                        int pk_licencia = Convert.ToInt32(row.Cells[5].Text);

                        string numLicencia = row.Cells[3].Text;
                        DateTime fechaExp = Convert.ToDateTime(row.Cells[4].Text);

                        dsCARA.SPC_CENTRO(nbFacilidad, idSlyc, "", email);

                        int pk_centro = dsCARA.VW_CENTROS_ADMINISTRADORES.Where(a => a.Email == email).Where(b => b.Centro == nbFacilidad).Select(f => f.PK_Centro).First();

                        dsCARA.SPC_ATAR_CENTRO_LICENCIA(pk_centro, pk_licencia, numLicencia, fechaExp);

                        dsCARA.SPC_SESION_ACTIVIDAD(PK_Sesion, "ImportarCentro", "C", Usuario.Id, pk_centro, null, null);
                        
                    }

                    mensaje = "El registro de las facilidad fué correcto.";

                    ClientScript.RegisterStartupScript(this.GetType(), "Centros Importados", "sweetAlertRef('Centros Importados','" + mensaje + "','success','" + "App/Administracion/adminListaCentros.aspx" + "');", true);
                }
            }
            catch (Exception)
            {

                throw;
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
    }
}