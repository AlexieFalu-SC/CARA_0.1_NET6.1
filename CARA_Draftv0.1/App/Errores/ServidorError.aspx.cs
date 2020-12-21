using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Errores
{
    public partial class ServidorError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception err = Session["LastError"] as Exception;

            if (err != null)
            {
                err = err.GetBaseException();
                Session["LastError"] = null;
                Console.WriteLine("El número de referencia para este error es REF#" + "Error Message: " + err.Message + " Source: " + err.Source + " InnerException: " + ((err.InnerException != null) ? err.InnerException.ToString() : "") + " StackTrace: " + err.StackTrace + ".");              
            }
            else
            {
                this.Response.Redirect("~/App/Entrada");
                return;
            }


            //Exception ex = Server.GetLastError();
            //Server.ClearError();
        }
    }
}