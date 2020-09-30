using CARA_Draftv0._1.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Perfiles
{
    public partial class wucdatospersonales : System.Web.UI.UserControl
    {

        protected DatosInternos ca_paciente;
        public frmAccion m_frmAccion;
        public int PK_Perfil;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ca_paciente = (DatosInternos)this.Session["CA_Paciente"];
            
            if (!this.IsPostBack)
            {
                PrepararDropDownLists();
                this.lblCentro.Text = this.ca_paciente.NB_Centro;
                this.lblIUP.Text = this.ca_paciente.PK_Paciente.ToString();
                this.txtFechaAdmision.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");

                switch (m_frmAccion)
                {
                    case frmAccion.Crear:
                        CrearRegistro();
                        break;
                    case frmAccion.Leer:
                        LeerRegistro();
                        break;
                    case frmAccion.Actualizar:
                        LeerModificar();
                        break;
                    case frmAccion.Eliminar:
                        break;
                    default:
                        break;
                }
                
            }
               
        }

        private void CrearRegistro()
        {
            

            //this.txtFechaAdmision.Enabled = true;
            //this.txtHoraAdmision.Enabled = true;
            //this.ddlEstadoServicio.Enabled = true;
            //this.txtDiasEspera.Enabled = true;
            //this.txtArrestos.Enabled = true;
            //this.ddlFuenteReferido.Enabled = true;
            //this.ddlEpisodiosPrevios.Enabled = true;
            //this.ddlFrecuenciaApoyo.Enabled = true;
        }

        private void LeerRegistro()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var perfil = dsCARA.CA_PERFIL.Where(a => a.PK_Perfil.Equals(PK_Perfil)).FirstOrDefault();

                    var episodio = dsCARA.CA_EPISODIO.Where(a => a.PK_Episodio.Equals(perfil.FK_Episodio)).FirstOrDefault();

                    this.lblFechaAdmision.Text = DateTime.Parse(perfil.FE_Perfil.ToString()).ToShortDateString();
                    this.lblHoraAdmision.Text = DateTime.Parse(perfil.FE_Perfil.ToString()).ToShortTimeString();
                    this.lblEstadoServicio.Text = dsCARA.CA_LKP_ESTADO_SERVICIO.Where(a => a.PK_EstadoServicio.Equals(episodio.FK_EstadoServicio)).Select(b => b.DE_EstadoServicio).SingleOrDefault();
                    this.lblDiasEspera.Text = episodio.NR_DiasEspera.ToString();
                    this.lblArrestos.Text = perfil.NR_ArrestosMesPasado.ToString();
                    this.lblFuenteReferido.Text = dsCARA.CA_LKP_FUENTE_REFERIDO.Where(a => a.PK_FuenteReferido.Equals(episodio.FK_FuenteReferido)).Select(b => b.DE_FuenteReferido).SingleOrDefault();
                    this.lblEpisodiosPrevios.Text = dsCARA.CA_LKP_EPISODIOS_PREVIO.Where(a => a.PK_EpisodiosPrevio.Equals(episodio.FK_EpisodiosPrevios)).Select(b => b.DE_EpisodiosPrevio).SingleOrDefault(); 
                    this.lblFrecuenciaApoyo.Text = dsCARA.CA_LKP_FRECUENCIA_APOYO.Where(a => a.PK_FrecuenciaApoyo.Equals(perfil.FK_GrupoApoyoMesPasado)).Select(b => b.DE_FrecuenciaApoyo).SingleOrDefault(); 

                    this.txtFechaAdmision.Visible = false;
                    this.txtHoraAdmision.Visible = false;
                    this.ddlEstadoServicio.Visible = false;
                    this.txtDiasEspera.Visible = false;
                    this.txtArrestos.Visible = false;
                    this.ddlFuenteReferido.Visible = false;
                    this.ddlEpisodiosPrevios.Visible = false;
                    this.ddlFrecuenciaApoyo.Visible = false;

                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }
        }

        private void LeerModificar()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var perfil = dsCARA.CA_PERFIL.Where(a => a.PK_Perfil.Equals(PK_Perfil)).FirstOrDefault();

                    var episodio = dsCARA.CA_EPISODIO.Where(a => a.PK_Episodio.Equals(perfil.FK_Episodio)).FirstOrDefault();

                    this.txtFechaAdmision.Visible = true;
                    this.txtHoraAdmision.Visible = true;
                    this.ddlEstadoServicio.Visible = true;
                    this.txtDiasEspera.Visible = true;
                    this.txtArrestos.Visible = true;
                    this.ddlFuenteReferido.Visible = true;
                    this.ddlEpisodiosPrevios.Visible = true;
                    this.ddlFrecuenciaApoyo.Visible = true;

                    this.txtFechaAdmision.Text = perfil.FE_Perfil.ToString("yyyy-MM-dd");
                    this.txtHoraAdmision.Text = perfil.FE_Perfil.ToString("hh\\:mm");
                    this.ddlEstadoServicio.SelectedValue = episodio.FK_EstadoServicio.ToString();
                    this.txtDiasEspera.Text = episodio.NR_DiasEspera.ToString();
                    this.txtArrestos.Text = perfil.NR_ArrestosMesPasado.ToString();
                    this.ddlFuenteReferido.SelectedValue = episodio.FK_FuenteReferido.ToString();
                    this.ddlEpisodiosPrevios.SelectedValue = episodio.FK_EpisodiosPrevios.ToString();
                    this.ddlFrecuenciaApoyo.SelectedValue = perfil.FK_GrupoApoyoMesPasado.ToString();

                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.InnerException.Message;
            }
        }

        private void PrepararDropDownLists()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    ddlEstadoServicio.DataValueField = "PK_EstadoServicio";
                    ddlEstadoServicio.DataTextField = "DE_EstadoServicio";
                    ddlEstadoServicio.DataSource = dsCARA.CA_LKP_ESTADO_SERVICIO.ToList();
                    ddlEstadoServicio.DataBind();
                    ddlEstadoServicio.Items.Insert(0, new ListItem("", "0"));

                    ddlFuenteReferido.DataValueField = "PK_FuenteReferido";
                    ddlFuenteReferido.DataTextField = "DE_FuenteReferido";
                    ddlFuenteReferido.DataSource = dsCARA.CA_LKP_FUENTE_REFERIDO.ToList();
                    ddlFuenteReferido.DataBind();
                    ddlFuenteReferido.Items.Insert(0, new ListItem("", "0"));

                    ddlEpisodiosPrevios.DataValueField = "PK_EpisodiosPrevio";
                    ddlEpisodiosPrevios.DataTextField = "DE_EpisodiosPrevio";
                    ddlEpisodiosPrevios.DataSource = dsCARA.CA_LKP_EPISODIOS_PREVIO.ToList();
                    ddlEpisodiosPrevios.DataBind();
                    ddlEpisodiosPrevios.Items.Insert(0, new ListItem("", "0"));

                    ddlFrecuenciaApoyo.DataValueField = "PK_FrecuenciaApoyo";
                    ddlFrecuenciaApoyo.DataTextField = "DE_FrecuenciaApoyo";
                    ddlFrecuenciaApoyo.DataSource = dsCARA.CA_LKP_FRECUENCIA_APOYO.ToList();
                    ddlFrecuenciaApoyo.DataBind();
                    ddlFrecuenciaApoyo.Items.Insert(0, new ListItem("", "0"));

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        #region Propiedades
        public DateTime FE_Admision
        {
            get
            {
                DateTime dt = new DateTime();
                DateTime hora = new DateTime();
                DateTime fecha = new DateTime();
                try
                {
                    fecha = Convert.ToDateTime(this.txtFechaAdmision.Text);
                    hora = Convert.ToDateTime(this.txtHoraAdmision.Text);

                    DateTime FE_Admision = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute,0);

                    return FE_Admision;
                    
                }
                catch
                {
                    return dt; 
                }
            }
        }

        public int FK_EstadoServicio
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlEstadoServicio.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlEstadoServicio.SelectedValue.ToString());
                    }
                    else
                    {
                        throw new Exception("No aplica");
                    }
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int NR_DiasEspera
        {
            get
            {
                try
                {
                    
                     return Convert.ToInt32(this.txtDiasEspera.Text);
                    
                    
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int NR_ArrestosMesPasado
        {
            get
            {
                try
                {

                    return Convert.ToInt32(this.txtArrestos.Text);

                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int FK_FuenteReferido
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFuenteReferido.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFuenteReferido.SelectedValue.ToString());
                    }
                    else
                    {
                        throw new Exception("No aplica");
                    }
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int FK_EpisodiosPrevios
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlEpisodiosPrevios.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlEpisodiosPrevios.SelectedValue.ToString());
                    }
                    else
                    {
                        throw new Exception("No aplica");
                    }
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int FK_GrupoApoyoMesPasado
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFrecuenciaApoyo.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFrecuenciaApoyo.SelectedValue.ToString());
                    }
                    else
                    {
                        throw new Exception("No aplica");
                    }
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }
        #endregion
    }
}