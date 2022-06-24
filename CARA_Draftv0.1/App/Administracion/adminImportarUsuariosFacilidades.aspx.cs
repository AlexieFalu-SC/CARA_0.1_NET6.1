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
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Columns.Add(cell.Value.ToString());
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
    }
}