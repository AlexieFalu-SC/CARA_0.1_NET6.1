using CARA_Draftv0._1.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Pacientes
{
    public partial class frmconsulta : System.Web.UI.Page
    {
        private int m_PK_Centro;
        protected string Centro;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Account/Login.aspx", false);
                return;
            }

            this.m_PK_Centro = Convert.ToInt32(this.Session["PK_Centro"].ToString());

            Centro = this.Request.QueryString["centro"].ToString();
            if (!this.IsPostBack)
            {
                switch (Centro)
                {
                    case ("crear"):
                        this.btnRegistrar.Visible = true;
                        break;
                    case ("leer"):
                        this.btnRegistrar.Visible = false;
                        break;
                    default:
                        break;
                }

                PrepararDropDownLists();
                this.FillJumpToList(0);

            }
        }

        private int BindGridView(int pagina)
        {
            int a = 0;
            int PK_Paciente;
            string NR_Expediente = txtExpediente.Text;
            int FK_Centro = this.m_PK_Centro;
            int FK_GrupoEtnico = Convert.ToInt32(this.ddlGrupoEtnico.SelectedValue);
            int FK_Genero = Convert.ToInt32(this.ddlGenero.SelectedValue);

            DateTime FE_Nacimiento;

            if(txtIUP.Text == "")
            {
                PK_Paciente = 0;
            }
            else
            {
                PK_Paciente = Convert.ToInt32(txtIUP.Text);
            }

            if (txtNacimiento.Text == "")
            {
                FE_Nacimiento = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                FE_Nacimiento = Convert.ToDateTime(txtNacimiento.Text);
            }

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    List<SPR_PACIENTE_CENTRO_Result> pacientes = dsCARA.SPR_PACIENTE_CENTRO(PK_Paciente,NR_Expediente,FE_Nacimiento,FK_Centro,FK_GrupoEtnico,FK_Genero).ToList();

                    gvPcientes.PageIndex = pagina - 1;
                    gvPcientes.DataSource = pacientes;
                    gvPcientes.DataBind();
                    a = pacientes.Count();
                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }

            return a;
        }

        private void FillJumpToList(int TotalRows)

        {
            int PageCount = this.CalculateTotalPages(TotalRows);
            for (int i = 1; i <= PageCount; i++)
            {
                ddlJumpTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void PageNumberChanged(object sender, EventArgs e)
        {
            int PageNo = Convert.ToInt32(ddlJumpTo.SelectedItem.Value);
            this.BindGridView(PageNo);
        }

        private int CalculateTotalPages(int intTotalRows)
        {
            int intPageCount = 1;
            double dblPageCount = (double)(Convert.ToDecimal(intTotalRows)

                                    / Convert.ToDecimal(gvPcientes.PageSize));

            intPageCount = Convert.ToInt32(Math.Ceiling(dblPageCount));
            return intPageCount;
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
                    ddlGenero.Items.Insert(0, new ListItem("Todos", "0"));

                    ddlGrupoEtnico.DataValueField = "PK_GrupoEtnico";
                    ddlGrupoEtnico.DataTextField = "DE_GrupoEtnico";
                    ddlGrupoEtnico.DataSource = dsCARA.CA_LKP_GRUPO_ETNICO.ToList();
                    ddlGrupoEtnico.DataBind();
                    ddlGrupoEtnico.Items.Insert(0, new ListItem("Todos", "0"));

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
            int TotalReg = BindGridView(1);
            this.FillJumpToList(TotalReg);

            
        }

        protected void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/App/Pacientes/frmEditar.aspx?accion=crear");
        }

        protected void btnBorrar_Click(object sender, System.EventArgs e)
        {

        }

        protected void lnkExpediente_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            int PK_Paciente = Convert.ToInt32(btn.CommandArgument);

            //try
            //{
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var paciente = dsCARA.SPR_PACIENTE(PK_Paciente).SingleOrDefault();

                    DatosInternos ca_paciente = new DatosInternos()
                    {
                        PK_Paciente = paciente.PK_Paciente,
                        FK_Centro = paciente.FK_Centro,
                        NB_Centro = paciente.NB_Centro,
                        FE_Nacimiento = paciente.FE_Nacimiento,
                        FK_GrupoEtnico = paciente.FK_GrupoEtnico,
                        DE_GrupoEtnico = paciente.DE_GrupoEtnico,
                        NR_Expediente = paciente.NR_Expediente,
                        FK_Genero = Convert.ToInt32(paciente.FK_Genero),
                        DE_Genero = paciente.DE_Genero

                    };

                    Session["CA_Paciente"] = ca_paciente;

                    Response.Redirect("~/App/Pacientes/frmVisualizar.aspx?centro=" + Centro);
                }
            //}
            //catch (Exception ex)
            //{

            //    string mensaje = ex.InnerException.Message;
            //}
        }
    }
}