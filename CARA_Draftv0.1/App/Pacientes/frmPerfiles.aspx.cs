using CARA_Draftv0._1.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Pacientes
{
    public partial class frmPerfiles : System.Web.UI.Page
    {
        protected DatosInternos ca_paciente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CA_Paciente"] == null)
            {
                //Session["TipodeAlerta"] = ConstTipoAlerta.Danger;
                //Session["MensajeError"] = "Por favor seleccione el participante";
                //Session["Redirect"] = "Entrada.aspx";
                //Response.Redirect("Mensajes.aspx", false);
                Response.Redirect("~/App/Pacientes/frmconsulta.aspx", false);
                return;
            }
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            this.ca_paciente = (DatosInternos)this.Session["CA_Paciente"];
            int PK_Episodio = Convert.ToInt32(this.Request.QueryString["pk_episodio"].ToString());

            if (!this.IsPostBack)
            {
                this.lblIUP.Text = this.ca_paciente.PK_Paciente.ToString();
                this.lblExpediente.Text = this.ca_paciente.NR_Expediente.ToString();
                this.lblNacimiento.Text = this.ca_paciente.FE_Nacimiento.ToString("MMMM dd, yyyy");
                this.lblGrupoEtnico.Text = this.ca_paciente.DE_GrupoEtnico.ToString();

                this.lblRaza.Text = "";
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<SPR_RAZA_PACIENTE_Result> razas = dsCARA.SPR_RAZA_PACIENTE(this.ca_paciente.PK_Paciente).ToList();

                    if (razas != null)
                    {
                        foreach (var item in razas)
                        {
                            this.lblRaza.Text += dsCARA.CA_LKP_RAZA.Where(a => a.PK_Raza.Equals(item.FK_Raza)).Select(b => b.DE_Raza).SingleOrDefault() + ", ";
                        }
                    }
                }

                this.LeerPerfiles(PK_Episodio);
            }

        }

        protected void LeerPerfiles(int PK_Episodio)
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<SPR_PERFILES_EPISODIO_Result> perfiles = dsCARA.SPR_PERFILES_EPISODIO(PK_Episodio).ToList();

                    gvPerfiles.PageIndex = 1 - 1;
                    gvPerfiles.DataSource = perfiles;
                    gvPerfiles.DataBind();
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.InnerException.Message;
            }
        }
    }
}