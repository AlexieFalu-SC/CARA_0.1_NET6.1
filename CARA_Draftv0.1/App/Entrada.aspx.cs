using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App
{
    public partial class Entrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["Usuario"] == null || Session["PK_Sesion"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx", false);
                    return;
                }
            }
        }
    }
}