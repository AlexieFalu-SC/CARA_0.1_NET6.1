using CARA_Draftv0._1.App.Data;
using CARA_Draftv0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Pacientes
{
    public partial class frmEditar : System.Web.UI.Page
    {
        private int m_PK_Centro;
        ApplicationUser Usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            Usuario = (ApplicationUser)Session["Usuario"];

            this.m_PK_Centro = Convert.ToInt32(this.Session["PK_Centro"].ToString());

            string Accion = this.Request.QueryString["accion"].ToString();

            if (!this.IsPostBack)
            {
                PrepararDropDownLists();

                switch (Accion)
                {
                    case ("crear"):
                        this.btnRegistrar.Visible = true;
                        this.btnModificar.Visible = false;
                        this.lblIUP.Text = "No Registrado";
                        break;
                    case ("editar"):
                        this.btnRegistrar.Visible = false;
                        this.btnModificar.Visible = true;
                        
                        if(Session["CA_Paciente"] != null)
                        {
                            DatosInternos ca_paciente = new DatosInternos();
                            ca_paciente = (DatosInternos)this.Session["CA_Paciente"];

                            this.lblIUP.Text = ca_paciente.PK_Paciente.ToString();
                            this.txtExpediente.Text = ca_paciente.NR_Expediente;
                            this.txtNacimiento.Text = ca_paciente.FE_Nacimiento.ToString("yyyy-MM-dd");
                            this.ddlGrupoEtnico.SelectedValue = ca_paciente.FK_GrupoEtnico.ToString();
                            this.ddlGenero.SelectedValue = ca_paciente.FK_Genero.ToString();

                            using (CARAEntities dsCARA = new CARAEntities())
                            {
                                List<SPR_RAZA_PACIENTE_Result> razas = dsCARA.SPR_RAZA_PACIENTE(ca_paciente.PK_Paciente).ToList();

                                if(razas != null)
                                {
                                    foreach (var item in razas)
                                    {
                                        for (int i = 0; i < lbxRaza.Items.Count; i++)
                                        {
                                            if(lbxRaza.Items[i].Value == item.FK_Raza.ToString())
                                            {
                                                lbxRaza.Items[i].Selected = true;
                                            }
                                        }
                                    }
                                }
                            }
                                
                        }
                        else
                        {
                            Response.Redirect("~/App/Pacientes/frmconsulta.aspx", false);
                            return;
                        }
                        
                        break;
                }

                
            }
        }

        private void PrepararDropDownLists()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    ddlGenero.DataValueField = "PK_Genero";
                    ddlGenero.DataTextField = "DE_Genero";
                    ddlGenero.DataSource = dsCARA.CA_LKP_GENERO.ToList();
                    ddlGenero.DataBind();
                    ddlGenero.Items.Insert(0, new ListItem("", "0"));

                    ddlGrupoEtnico.DataValueField = "PK_GrupoEtnico";
                    ddlGrupoEtnico.DataTextField = "DE_GrupoEtnico";
                    ddlGrupoEtnico.DataSource = dsCARA.CA_LKP_GRUPO_ETNICO.ToList();
                    ddlGrupoEtnico.DataBind();
                    ddlGrupoEtnico.Items.Insert(0, new ListItem("", "0"));

                    lbxRaza.DataValueField = "PK_Raza";
                    lbxRaza.DataTextField = "DE_Raza";
                    lbxRaza.DataSource = dsCARA.CA_LKP_RAZA.ToList();
                    lbxRaza.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnConsultar_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/App/Perfiles/frmadmision.aspx");
        }

        protected void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            int CA_Paciente = this.GuardarRegistro();

            if (CA_Paciente != 0)
            {
                string mensaje = "El paciente fué registrado correctamente.";

                ClientScript.RegisterStartupScript(this.GetType(), "Paciente Registrado", "sweetAlertRef('Paciente Registrado','" + mensaje + "','success','App/Perfiles/frmadmision.aspx?accion=crear');", true);
            }
            else
            {
                this.lblIUP.Text = "error";
            }
            
        }

        protected void btnEditar_Click(object sender, System.EventArgs e)
        {
            int CA_Paciente = this.GuardarCambio();

            if (CA_Paciente != 0)
            {
                string mensaje = "El paciente fué modificado correctamente.";

                ClientScript.RegisterStartupScript(this.GetType(), "Paciente Modificado", "sweetAlertRef('Paciente Modificado','" + mensaje + "','success','App/Pacientes/frmVisualizar.aspx?centro=crear');", true);
                
            }
            else
            {
                this.lblIUP.Text = "error";
            }

        }

        private int GuardarRegistro()
        {
            int PK_Paciente = 0;
            DatosInternos ca_paciente = new DatosInternos();

            DateTime FE_Nacimiento = Convert.ToDateTime(this.txtNacimiento.Text);
            int FK_Centro = this.m_PK_Centro;
            int FK_GrupoEtnico = Convert.ToInt32(this.ddlGrupoEtnico.SelectedValue);
            string NR_Expediente = this.txtExpediente.Text;
            int FK_Genero = Convert.ToInt32(this.ddlGenero.SelectedValue);

            System.Data.Entity.Core.Objects.ObjectParameter myOutputParamString = new System.Data.Entity.Core.Objects.ObjectParameter("PK_Paciente", typeof(int));

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var spc = dsCARA.SPC_PACIENTE(FE_Nacimiento, FK_Centro, FK_GrupoEtnico, NR_Expediente, FK_Genero, myOutputParamString);

                    PK_Paciente = Convert.ToInt32(myOutputParamString.Value);

                    this.lblIUP.Text = PK_Paciente.ToString();

                    ca_paciente  = new DatosInternos()
                    {
                        PK_Paciente = PK_Paciente,
                        FK_Centro = FK_Centro,
                        FE_Nacimiento = FE_Nacimiento,
                        FK_GrupoEtnico = FK_GrupoEtnico,
                        DE_GrupoEtnico = this.ddlGrupoEtnico.SelectedItem.Text,
                        NR_Expediente = NR_Expediente,
                        FK_Genero = FK_Genero,
                        DE_Genero = this.ddlGenero.SelectedItem.Text
                    };
                    
                   
                   

                    foreach (ListItem item in lbxRaza.Items)
                    {
                        if (item.Selected)
                        {
                            dsCARA.SPC_RAZA_PACIENTE(PK_Paciente, Convert.ToInt32(item.Value));
                        }
                    }

                    Session["CA_Paciente"] = ca_paciente;
                }
            }
            catch (Exception ex)
            {
                string mensaje;

                if (ex.InnerException == null)
                {
                    mensaje = ex.Message;
                }
                else
                {
                    mensaje = ex.InnerException.Message;
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }

            return PK_Paciente;
        }

        private int GuardarCambio()
        {
            DatosInternos ca_paciente = new DatosInternos();
            ca_paciente = (DatosInternos)this.Session["CA_Paciente"];

            int PK_Paciente = 0;

            DateTime FE_Nacimiento = Convert.ToDateTime(this.txtNacimiento.Text);
            int FK_Centro = this.m_PK_Centro;
            int FK_GrupoEtnico = Convert.ToInt32(this.ddlGrupoEtnico.SelectedValue);
            string NR_Expediente = this.txtExpediente.Text;
            int FK_Genero = Convert.ToInt32(this.ddlGenero.SelectedValue);

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                   dsCARA.SPU_PACIENTE(ca_paciente.PK_Paciente,FE_Nacimiento, FK_Centro, FK_GrupoEtnico, NR_Expediente, FK_Genero);

                    PK_Paciente = ca_paciente.PK_Paciente;

                    ca_paciente.PK_Paciente = PK_Paciente;
                    ca_paciente.FK_Centro = FK_Centro;
                    ca_paciente.FE_Nacimiento = FE_Nacimiento;
                    ca_paciente.FK_GrupoEtnico = FK_GrupoEtnico;
                    ca_paciente.DE_GrupoEtnico = this.ddlGrupoEtnico.SelectedItem.Text;
                    ca_paciente.NR_Expediente = NR_Expediente;
                    ca_paciente.FK_Genero = FK_Genero;
                    ca_paciente.DE_Genero = this.ddlGenero.SelectedItem.Text;

                    this.lblIUP.Text = PK_Paciente.ToString();

                    dsCARA.SPD_RAZA_PACIENTE(PK_Paciente);

                    foreach (ListItem item in lbxRaza.Items)
                    {
                        if(item.Selected)
                        {
                            dsCARA.SPC_RAZA_PACIENTE(PK_Paciente, Convert.ToInt32(item.Value));
                        }
                    }

                    Session["CA_Paciente"] = ca_paciente;
                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }

            return PK_Paciente;
        }

        protected void btnBorrar_Click(object sender, System.EventArgs e)
        {

        }
    }
}