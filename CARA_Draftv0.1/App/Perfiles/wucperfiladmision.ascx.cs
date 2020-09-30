using CARA_Draftv0._1.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Perfiles
{
    public partial class wucperfiladmision : System.Web.UI.UserControl
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

                this.lblNacimiento.Text = this.ca_paciente.FE_Nacimiento.ToString("yyyy-MM-dd");
                this.lblEdad.Text = Edad(this.ca_paciente.FE_Nacimiento).ToString();
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
            //this.ddlGenero.Enabled = true;
            //this.ddlEstadoMarital.Enabled = true;
            //this.ddlResidencia.Enabled = true;
            //this.ddlMenoresCuidado.Enabled = true;
            //this.ddlEmbarazada.Enabled = true;
            //this.ddlVeterano.Enabled = true;
            //this.ddlEscolaridad.Enabled = true;
            //this.ddlCondicionLaboral.Enabled = true;
            //this.ddlNoFuerzaLaboral.Enabled = true;
            //this.ddlEstudio.Enabled = true;
            //this.ddlFuenteIngreso.Enabled = true;
        }

        private void LeerRegistro()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var perfil = dsCARA.CA_PERFIL.Where(a => a.PK_Perfil.Equals(PK_Perfil)).FirstOrDefault();

                    var episodio = dsCARA.CA_EPISODIO.Where(a => a.PK_Episodio.Equals(perfil.FK_Episodio)).FirstOrDefault();

                    this.lblGenero.Text = dsCARA.CA_LKP_GENERO.Where(a => a.PK_Genero.Equals(perfil.FK_Genero)).Select(b => b.DE_Genero).SingleOrDefault();
                    this.lblEstadoMarital.Text = dsCARA.CA_LKP_ESTADO_MARITAL.Where(a => a.PK_EstadoMarital.Equals(perfil.FK_EstadoMarital)).Select(b => b.DE_EstadoMarital).SingleOrDefault();
                    this.lblResidencia.Text = dsCARA.CA_LKP_RESIDENCIA.Where(a => a.PK_Residencia.Equals(perfil.FK_Residencia)).Select(b => b.DE_Residencia).SingleOrDefault();
                    this.lblMenoresCuidado.Text = dsCARA.CA_LKP_MENORES_CUSTODIA.Where(a => a.PK_MenoresCustodia.Equals(perfil.FK_HijosMenoresCuido)).Select(b => b.DE_MenoresCustodia).SingleOrDefault();
                    this.lblEmbarazada.Text = dsCARA.CA_LKP_EMBARAZADA.Where(a => a.PK_Embarazada.Equals(perfil.FK_Embarazada)).Select(b => b.DE_Embarazada).SingleOrDefault();
                    this.lblVeterano.Text = dsCARA.CA_LKP_VETERANO.Where(a => a.PK_Veterano.Equals(perfil.FK_Veterano)).Select(b => b.DE_Veterano).SingleOrDefault();
                    this.lblEscolaridad.Text = dsCARA.CA_LKP_ESCOLARIDAD.Where(a => a.PK_Escolaridad.Equals(perfil.FK_Escolaridad)).Select(b => b.DE_Escolaridad).SingleOrDefault();
                    this.lblCondicionLaboral.Text = dsCARA.CA_LKP_CONDICION_LABORAL.Where(a => a.PK_CondicionLaboral.Equals(perfil.FK_CondicionLaboral)).Select(b => b.DE_CondicionLaboral).SingleOrDefault();
                    this.lblNoFuerzaLaboral.Text = dsCARA.CA_LKP_FUERZA_LABORAL.Where(a => a.PK_FuerzaLaboral.Equals(perfil.FK_NoFuerzaLaboral)).Select(b => b.DE_FuerzaLaboral).SingleOrDefault();
                    this.lblEstudio.Text = dsCARA.CA_LKP_ESTUDIOS.Where(a => a.PK_Estudios.Equals(perfil.FK_Estudios)).Select(b => b.DE_Estudios).SingleOrDefault();
                    this.lblFuenteIngreso.Text = dsCARA.CA_LKP_FUENTE_INGRESO.Where(a => a.PK_FuenteIngreso.Equals(perfil.FK_FuenteIngreso)).Select(b => b.DE_FuenteIngreso).SingleOrDefault();

                    this.ddlGenero.Visible = false;
                    this.ddlEstadoMarital.Visible = false;
                    this.ddlResidencia.Visible = false;
                    this.ddlMenoresCuidado.Visible = false;
                    this.ddlEmbarazada.Visible = false;
                    this.ddlVeterano.Visible = false;
                    this.ddlEscolaridad.Visible = false;
                    this.ddlCondicionLaboral.Visible = false;
                    this.ddlNoFuerzaLaboral.Visible = false;
                    this.ddlEstudio.Visible = false;
                    this.ddlFuenteIngreso.Visible = false;
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

                    this.ddlGenero.Visible = true;
                    this.ddlEstadoMarital.Visible = true;
                    this.ddlResidencia.Visible = true;
                    this.ddlMenoresCuidado.Visible = true;
                    this.ddlEmbarazada.Visible = true;
                    this.ddlVeterano.Visible = true;
                    this.ddlEscolaridad.Visible = true;
                    this.ddlCondicionLaboral.Visible = true;
                    this.ddlNoFuerzaLaboral.Visible = true;
                    this.ddlEstudio.Visible = true;
                    this.ddlFuenteIngreso.Visible = true;

                    this.ddlGenero.SelectedValue = perfil.FK_Genero.ToString();
                    this.ddlEstadoMarital.SelectedValue = perfil.FK_EstadoMarital.ToString();
                    this.ddlResidencia.SelectedValue = perfil.FK_Residencia.ToString();
                    this.ddlMenoresCuidado.SelectedValue = perfil.FK_HijosMenoresCuido.ToString();
                    this.ddlEmbarazada.SelectedValue = perfil.FK_Embarazada.ToString();
                    this.ddlVeterano.SelectedValue = perfil.FK_Veterano.ToString();
                    this.ddlEscolaridad.SelectedValue = perfil.FK_Escolaridad.ToString();
                    this.ddlCondicionLaboral.SelectedValue = perfil.FK_CondicionLaboral.ToString();
                    this.ddlNoFuerzaLaboral.SelectedValue = perfil.FK_NoFuerzaLaboral.ToString();
                    this.ddlEstudio.SelectedValue = perfil.FK_Estudios.ToString();
                    this.ddlFuenteIngreso.SelectedValue = perfil.FK_FuenteIngreso.ToString();

                    
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
                    ddlGenero.DataValueField = "PK_Genero";
                    ddlGenero.DataTextField = "DE_Genero";
                    ddlGenero.DataSource = dsCARA.CA_LKP_GENERO.ToList();
                    ddlGenero.DataBind();
                    ddlGenero.Items.Insert(0, new ListItem("", "0"));

                    ddlEstadoMarital.DataValueField = "PK_EstadoMarital";
                    ddlEstadoMarital.DataTextField = "DE_EstadoMarital";
                    ddlEstadoMarital.DataSource = dsCARA.CA_LKP_ESTADO_MARITAL.ToList();
                    ddlEstadoMarital.DataBind();
                    ddlEstadoMarital.Items.Insert(0, new ListItem("", "0"));

                    ddlResidencia.DataValueField = "PK_Residencia";
                    ddlResidencia.DataTextField = "DE_Residencia";
                    ddlResidencia.DataSource = dsCARA.CA_LKP_RESIDENCIA.ToList();
                    ddlResidencia.DataBind();
                    ddlResidencia.Items.Insert(0, new ListItem("", "0"));

                    ddlMenoresCuidado.DataValueField = "PK_MenoresCustodia";
                    ddlMenoresCuidado.DataTextField = "DE_MenoresCustodia";
                    ddlMenoresCuidado.DataSource = dsCARA.CA_LKP_MENORES_CUSTODIA.ToList();
                    ddlMenoresCuidado.DataBind();
                    ddlMenoresCuidado.Items.Insert(0, new ListItem("", "0"));

                    ddlEmbarazada.DataValueField = "PK_Embarazada";
                    ddlEmbarazada.DataTextField = "DE_Embarazada";
                    ddlEmbarazada.DataSource = dsCARA.CA_LKP_EMBARAZADA.ToList();
                    ddlEmbarazada.DataBind();
                    ddlEmbarazada.Items.Insert(0, new ListItem("", "0"));

                    ddlVeterano.DataValueField = "PK_Veterano";
                    ddlVeterano.DataTextField = "DE_Veterano";
                    ddlVeterano.DataSource = dsCARA.CA_LKP_VETERANO.ToList();
                    ddlVeterano.DataBind();
                    ddlVeterano.Items.Insert(0, new ListItem("", "0"));

                    ddlEscolaridad.DataValueField = "PK_Escolaridad";
                    ddlEscolaridad.DataTextField = "DE_Escolaridad";
                    ddlEscolaridad.DataSource = dsCARA.CA_LKP_ESCOLARIDAD.ToList();
                    ddlEscolaridad.DataBind();
                    ddlEscolaridad.Items.Insert(0, new ListItem("", "0"));

                    ddlCondicionLaboral.DataValueField = "PK_CondicionLaboral";
                    ddlCondicionLaboral.DataTextField = "DE_CondicionLaboral";
                    ddlCondicionLaboral.DataSource = dsCARA.CA_LKP_CONDICION_LABORAL.ToList();
                    ddlCondicionLaboral.DataBind();
                    ddlCondicionLaboral.Items.Insert(0, new ListItem("", "0"));

                    ddlNoFuerzaLaboral.DataValueField = "PK_FuerzaLaboral";
                    ddlNoFuerzaLaboral.DataTextField = "DE_FuerzaLaboral";
                    ddlNoFuerzaLaboral.DataSource = dsCARA.CA_LKP_FUERZA_LABORAL.ToList();
                    ddlNoFuerzaLaboral.DataBind();
                    ddlNoFuerzaLaboral.Items.Insert(0, new ListItem("", "0"));

                    ddlEstudio.DataValueField = "PK_Estudios";
                    ddlEstudio.DataTextField = "DE_Estudios";
                    ddlEstudio.DataSource = dsCARA.CA_LKP_ESTUDIOS.ToList();
                    ddlEstudio.DataBind();
                    ddlEstudio.Items.Insert(0, new ListItem("", "0"));

                    ddlFuenteIngreso.DataValueField = "PK_FuenteIngreso";
                    ddlFuenteIngreso.DataTextField = "DE_FuenteIngreso";
                    ddlFuenteIngreso.DataSource = dsCARA.CA_LKP_FUENTE_INGRESO.ToList();
                    ddlFuenteIngreso.DataBind();
                    ddlFuenteIngreso.Items.Insert(0, new ListItem("", "0"));

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private int Edad(DateTime FE_Nacimiento)
        {
            var perfil = DateTime.Today;
            var edad = perfil.Year - FE_Nacimiento.Year;

            if (FE_Nacimiento.Date > perfil.AddYears(-edad)) edad--;

            return edad;
        }

        #region Propiedades

        public int FK_Genero
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlGenero.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlGenero.SelectedValue.ToString());
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

        public int NR_Edad
        {
            get
            {
                try
                {
                    return Edad(this.ca_paciente.FE_Nacimiento);
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int FK_EstadoMarital
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlEstadoMarital.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlEstadoMarital.SelectedValue.ToString());
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

        public int FK_Residencia
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlResidencia.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlResidencia.SelectedValue.ToString());
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

        public int FK_HijosMenoresCuido
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlMenoresCuidado.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlMenoresCuidado.SelectedValue.ToString());
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

        public int FK_Embarazada
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlEmbarazada.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlEmbarazada.SelectedValue.ToString());
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

        public int FK_Veterano
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlVeterano.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlVeterano.SelectedValue.ToString());
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

        public int FK_Escolaridad
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlEscolaridad.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlEscolaridad.SelectedValue.ToString());
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

        public int FK_CondicionLaboral
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlCondicionLaboral.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlCondicionLaboral.SelectedValue.ToString());
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

        public int FK_NoFuerzaLaboral
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlNoFuerzaLaboral.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlNoFuerzaLaboral.SelectedValue.ToString());
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

        public int FK_Estudios
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlEstudio.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlEstudio.SelectedValue.ToString());
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

        public int FK_FuenteIngreso
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFuenteIngreso.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFuenteIngreso.SelectedValue.ToString());
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