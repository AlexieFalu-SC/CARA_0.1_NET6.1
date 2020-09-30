using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CARA_Draftv0._1.App.Data;
using CARA_Draftv0._1.Models;

namespace CARA_Draftv0._1.App.Perfiles
{
    public partial class frmadmision : System.Web.UI.Page
    {
        protected CARAEntities dsCARA;
        protected DatosInternos ca_paciente;
        ApplicationUser Usuario = new ApplicationUser();
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

            Usuario = (ApplicationUser)Session["Usuario"];

            string Accion = this.Request.QueryString["accion"].ToString();

            if (!this.IsPostBack)
            {
                switch (Accion)
                {
                    case ("crear"):
                        this.btnRegistrar.Visible = true;
                        this.btnModificar.Visible = false;
                        this.btnRegistrarModificar.Visible = false;
                        CrearRegistro();
                        break;
                    case ("leer"):
                        this.btnRegistrar.Visible = false;
                        this.btnModificar.Visible = true;
                        this.btnRegistrarModificar.Visible = false;
                        LeerRegistro();
                        break;
                    case ("actualizar"):
                        this.btnRegistrar.Visible = false;
                        this.btnModificar.Visible = false;
                        this.btnRegistrarModificar.Visible = true;
                        LeerModificar();
                        break;
                    default:
                        break;
                }
            }
        }

        private void CrearRegistro()
        {
            wucdatospersonales.m_frmAccion = frmAccion.Crear;
            wucperfiladmision.m_frmAccion = frmAccion.Crear;
            wucdrogasadmision.m_frmAccion = frmAccion.Crear;

        }

        private void LeerRegistro()
        {
            wucdatospersonales.m_frmAccion = frmAccion.Leer;
            wucperfiladmision.m_frmAccion = frmAccion.Leer;
            wucdrogasadmision.m_frmAccion = frmAccion.Leer;

            wucdatospersonales.PK_Perfil = Convert.ToInt32(this.Request.QueryString["pk_perfil"].ToString());
            wucperfiladmision.PK_Perfil = Convert.ToInt32(this.Request.QueryString["pk_perfil"].ToString());
            wucdrogasadmision.PK_Perfil = Convert.ToInt32(this.Request.QueryString["pk_perfil"].ToString());
        }

        private void LeerModificar()
        {
            wucdatospersonales.m_frmAccion = frmAccion.Actualizar;
            wucperfiladmision.m_frmAccion = frmAccion.Actualizar;
            wucdrogasadmision.m_frmAccion = frmAccion.Actualizar;

            wucdatospersonales.PK_Perfil = Convert.ToInt32(this.Request.QueryString["pk_perfil"].ToString());
            wucperfiladmision.PK_Perfil = Convert.ToInt32(this.Request.QueryString["pk_perfil"].ToString());
            wucdrogasadmision.PK_Perfil = Convert.ToInt32(this.Request.QueryString["pk_perfil"].ToString());
        }

        #region Botones
        protected void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            GuardarAdmision();
        }

        protected void btnModificar_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/App/Perfiles/frmadmision.aspx?accion=actualizar&pk_perfil=" + this.Request.QueryString["pk_perfil"].ToString());
        }

        protected void btnRegistrarModificar_Click(object sender, System.EventArgs e)
        {
            GuardarModificacion();
        }
        protected void btnAutenticarPrograma_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Metodos
        private void PrepararDropDownLists()
        {
           
        }

        private void GuardarAdmision()
        {
            this.ca_paciente = (DatosInternos)this.Session["CA_Paciente"];

            int FK_Paciente = this.ca_paciente.PK_Paciente;
            int FK_Centro = this.ca_paciente.FK_Centro;
            int PK_Episodio = 0;

            string mensaje = string.Empty;

            System.Data.Entity.Core.Objects.ObjectParameter pk_Episodio_Output = new System.Data.Entity.Core.Objects.ObjectParameter("PK_Episodio", typeof(int));

            System.Data.Entity.Core.Objects.ObjectParameter pk_Perfil_Output = new System.Data.Entity.Core.Objects.ObjectParameter("PK_Perfil", typeof(int));

            /*Propiedades de wucDatosPersonales*/
            DateTime FE_Episodio = this.wucdatospersonales.FE_Admision;
            int FK_EstadoServicio = this.wucdatospersonales.FK_EstadoServicio;
            int NR_DiasEspera = this.wucdatospersonales.NR_DiasEspera;
            int NR_ArrestosMesPasado = this.wucdatospersonales.NR_ArrestosMesPasado;
            int FK_FuenteReferido = this.wucdatospersonales.FK_FuenteReferido;
            int FK_EpisodiosPrevios = this.wucdatospersonales.FK_EpisodiosPrevios;
            int FK_GrupoApoyoMesPasado = this.wucdatospersonales.FK_GrupoApoyoMesPasado;

            /*Propiedades de wucPerfilAdmision*/
            int FK_Genero = this.wucperfiladmision.FK_Genero;
            int NR_Edad = this.wucperfiladmision.NR_Edad;
            int FK_EstadoMarital = this.wucperfiladmision.FK_EstadoMarital;
            int FK_Residencia = this.wucperfiladmision.FK_Residencia;
            int FK_HijosMenoresCuido = this.wucperfiladmision.FK_HijosMenoresCuido;
            int FK_Embarazada = this.wucperfiladmision.FK_Embarazada;
            int FK_Veterano = this.wucperfiladmision.FK_Veterano;
            int FK_Escolaridad = this.wucperfiladmision.FK_Escolaridad;
            int FK_CondicionLaboral = this.wucperfiladmision.FK_CondicionLaboral;
            int FK_NoFuerzaLaboral = this.wucperfiladmision.FK_NoFuerzaLaboral;
            int FK_Estudios = this.wucperfiladmision.FK_Estudios;
            int FK_FuenteIngreso = this.wucperfiladmision.FK_FuenteIngreso;

            /*Propiedades de wucDrogaAdmision*/

                /*Droga Primaria*/
            int FK_DrogaPrimaria = this.wucdrogasadmision.FK_DrogaPrimaria;
            bool IN_ToxicologiaPrimaria = this.wucdrogasadmision.IN_ToxicologiaPrimaria;
            int FK_ViaPrimaria = this.wucdrogasadmision.FK_ViaPrimaria;
            int FK_FrecuenciaPrimaria = this.wucdrogasadmision.FK_FrecuenciaPrimaria;
            int NR_EdadPrimaria = this.wucdrogasadmision.NR_EdadPrimaria;
                /*Droga Secundaria*/
            int FK_DrogaSecundaria = this.wucdrogasadmision.FK_DrogaSecundaria;
            bool IN_ToxicologiaSecundaria = this.wucdrogasadmision.IN_ToxicologiaSecundaria;
            int FK_ViaSecundaria = this.wucdrogasadmision.FK_ViaSecundaria;
            int FK_FrecuenciaSecundaria = this.wucdrogasadmision.FK_FrecuenciaSecundaria;
            int NR_EdadSecundaria = this.wucdrogasadmision.NR_EdadSecundaria;
                /*Droga Terciaria*/
            int FK_DrogaTerciaria = this.wucdrogasadmision.FK_DrogaTerciaria;
            bool IN_ToxicologiaTerciaria = this.wucdrogasadmision.IN_ToxicologiaTerciaria;
            int FK_ViaTerciaria = this.wucdrogasadmision.FK_ViaTerciaria;
            int FK_FrecuenciaTerciaria = this.wucdrogasadmision.FK_FrecuenciaTerciaria;
            int NR_EdadTerciaria = this.wucdrogasadmision.NR_EdadTerciaria;
                /*Droga Cuarta*/
            string NB_DrogaCuarta = this.wucdrogasadmision.NB_DrogaCuarta;
            bool IN_ToxicologiaCuarta = this.wucdrogasadmision.IN_ToxicologiaCuarta;
            int FK_ViaCuarta = this.wucdrogasadmision.FK_ViaCuarta;
            int FK_FrecuenciaCuarta = this.wucdrogasadmision.FK_FrecuenciaCuarta;
            int NR_EdadCuarta = this.wucdrogasadmision.NR_EdadCuarta;
                /*Droga Quinta*/
            string NB_DrogaQuinta = this.wucdrogasadmision.NB_DrogaQuinta;
            bool IN_ToxicologiaQuinta = this.wucdrogasadmision.IN_ToxicologiaQuinta;
            int FK_ViaQuinta = this.wucdrogasadmision.FK_ViaQuinta;
            int FK_FrecuenciaQuinta = this.wucdrogasadmision.FK_FrecuenciaQuinta;
            int NR_EdadQuinta = this.wucdrogasadmision.NR_EdadQuinta;
                /*Sobredosis*/
            bool IN_Sobredosis = this.wucdrogasadmision.IN_Sobredosis;
            int FK_DrogaSobredosisPrimaria = this.wucdrogasadmision.FK_DrogaSobredosisPrimaria;
            int FK_DrogaSobredosisSecundaria = this.wucdrogasadmision.FK_DrogaSobredosisSecundaria;
            string DE_DrogaSobredosisTerciaria = this.wucdrogasadmision.DE_DrogaSobredosisTerciaria;
            string DE_DrogaSobredosisCuarta = this.wucdrogasadmision.DE_DrogaSobredosisCuarta;
                /*Diagnosticos Primaria*/
            int FK_ICDX_Primaria = this.wucdrogasadmision.FK_ICDX_Primaria;
            int FK_DSMV_Primaria = this.wucdrogasadmision.FK_DSMV_Primaria;
            int FK_CondicionFisicaPrimaria = this.wucdrogasadmision.FK_CondicionFisicaPrimaria;
                /*Diagnosticos Secundaria*/
            int FK_ICDX_Secundaria = this.wucdrogasadmision.FK_ICDX_Secundaria;
            int FK_DSMV_Secundaria = this.wucdrogasadmision.FK_DSMV_Secundaria;
            int FK_CondicionFisicaSecundaria = this.wucdrogasadmision.FK_CondicionFisicaSecundaria;
                /*Diagnosticos Terciaria*/
            int FK_ICDX_Terciaria = this.wucdrogasadmision.FK_ICDX_Terciaria;
            int FK_DSMV_Terciaria = this.wucdrogasadmision.FK_DSMV_Terciaria;
            int FK_CondicionFisicaTerciaria = this.wucdrogasadmision.FK_CondicionFisicaTerciaria;
                /*Diagnosticos Cuarta*/
            int FK_ICDX_Cuarta = this.wucdrogasadmision.FK_ICDX_Cuarta;
            int FK_DSMV_Cuarta = this.wucdrogasadmision.FK_DSMV_Cuarta;
            int FK_CondicionFisicaCuarta = this.wucdrogasadmision.FK_CondicionFisicaCuarta;
                /*Nivel Cuidado*/
            int FK_NivelSustancia = this.wucdrogasadmision.FK_NivelSustancia;
                /*Seguro Salud*/
            int FK_SeguroSalud = this.wucdrogasadmision.FK_SeguroSalud;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var spc_episodio = dsCARA.SPC_EPISODIO(FK_Paciente,FK_Centro,FE_Episodio,null,FK_EstadoServicio,FK_FuenteReferido,FK_EpisodiosPrevios,FK_NivelSustancia,NR_DiasEspera, pk_Episodio_Output);

                    PK_Episodio = Convert.ToInt32(pk_Episodio_Output.Value);

                    var spc_perfil = dsCARA.SPC_PERFIL
                        (
                            PK_Episodio, FE_Episodio, "AD", NR_ArrestosMesPasado, FK_GrupoApoyoMesPasado, FK_Genero, NR_Edad, FK_Residencia, FK_Embarazada, FK_HijosMenoresCuido, FK_Veterano,
                            FK_Escolaridad, FK_CondicionLaboral, FK_NoFuerzaLaboral, FK_Estudios, FK_FuenteIngreso, FK_DrogaPrimaria, IN_ToxicologiaPrimaria, FK_ViaPrimaria, FK_FrecuenciaPrimaria,
                            NR_EdadPrimaria, FK_DrogaSecundaria, IN_ToxicologiaSecundaria, FK_ViaSecundaria, FK_FrecuenciaSecundaria, NR_EdadSecundaria, FK_DrogaTerciaria, IN_ToxicologiaTerciaria,
                            FK_ViaTerciaria, FK_FrecuenciaTerciaria, NR_EdadTerciaria, NB_DrogaCuarta, IN_ToxicologiaCuarta, FK_ViaCuarta, FK_FrecuenciaCuarta, NR_EdadCuarta,
                            NB_DrogaQuinta, IN_ToxicologiaQuinta, FK_ViaQuinta, FK_FrecuenciaQuinta, NR_EdadQuinta, FK_DrogaSobredosisPrimaria, FK_DrogaSobredosisSecundaria, DE_DrogaSobredosisTerciaria,
                            DE_DrogaSobredosisCuarta, FK_ICDX_Primaria, FK_ICDX_Secundaria, FK_ICDX_Terciaria, FK_ICDX_Cuarta, FK_DSMV_Primaria, FK_DSMV_Secundaria, FK_DSMV_Terciaria, FK_DSMV_Cuarta,
                            FK_CondicionFisicaPrimaria, FK_CondicionFisicaSecundaria, FK_CondicionFisicaTerciaria, FK_CondicionFisicaCuarta, FK_SeguroSalud, FK_EstadoMarital, FE_Episodio, Usuario.Id,IN_Sobredosis,
                            pk_Perfil_Output
                        );

                    int PK_Perfil = Convert.ToInt32(pk_Perfil_Output.Value);

                    mensaje = "El perfil fué registrado correctamente.";

                    ClientScript.RegisterStartupScript(this.GetType(), "Perfil Registrado", "sweetAlertRef('Perfil Registrado','" + mensaje + "','success','App/Perfiles/frmadmision.aspx?accion=leer&pk_perfil=" + PK_Perfil.ToString() + "');", true);
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

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }
        }

        private void GuardarModificacion()
        {
            this.ca_paciente = (DatosInternos)this.Session["CA_Paciente"];

            int FK_Paciente = this.ca_paciente.PK_Paciente;
            int FK_Centro = this.ca_paciente.FK_Centro;
            int PK_Episodio = 0;
            int PK_Perfil = Convert.ToInt32(this.Request.QueryString["pk_perfil"].ToString());

            string mensaje = string.Empty;


            /*Propiedades de wucDatosPersonales*/
            DateTime FE_Episodio = this.wucdatospersonales.FE_Admision;
            int FK_EstadoServicio = this.wucdatospersonales.FK_EstadoServicio;
            int NR_DiasEspera = this.wucdatospersonales.NR_DiasEspera;
            int NR_ArrestosMesPasado = this.wucdatospersonales.NR_ArrestosMesPasado;
            int FK_FuenteReferido = this.wucdatospersonales.FK_FuenteReferido;
            int FK_EpisodiosPrevios = this.wucdatospersonales.FK_EpisodiosPrevios;
            int FK_GrupoApoyoMesPasado = this.wucdatospersonales.FK_GrupoApoyoMesPasado;

            /*Propiedades de wucPerfilAdmision*/
            int FK_Genero = this.wucperfiladmision.FK_Genero;
            int NR_Edad = this.wucperfiladmision.NR_Edad;
            int FK_EstadoMarital = this.wucperfiladmision.FK_EstadoMarital;
            int FK_Residencia = this.wucperfiladmision.FK_Residencia;
            int FK_HijosMenoresCuido = this.wucperfiladmision.FK_HijosMenoresCuido;
            int FK_Embarazada = this.wucperfiladmision.FK_Embarazada;
            int FK_Veterano = this.wucperfiladmision.FK_Veterano;
            int FK_Escolaridad = this.wucperfiladmision.FK_Escolaridad;
            int FK_CondicionLaboral = this.wucperfiladmision.FK_CondicionLaboral;
            int FK_NoFuerzaLaboral = this.wucperfiladmision.FK_NoFuerzaLaboral;
            int FK_Estudios = this.wucperfiladmision.FK_Estudios;
            int FK_FuenteIngreso = this.wucperfiladmision.FK_FuenteIngreso;

            /*Propiedades de wucDrogaAdmision*/

            /*Droga Primaria*/
            int FK_DrogaPrimaria = this.wucdrogasadmision.FK_DrogaPrimaria;
            bool IN_ToxicologiaPrimaria = this.wucdrogasadmision.IN_ToxicologiaPrimaria;
            int FK_ViaPrimaria = this.wucdrogasadmision.FK_ViaPrimaria;
            int FK_FrecuenciaPrimaria = this.wucdrogasadmision.FK_FrecuenciaPrimaria;
            int NR_EdadPrimaria = this.wucdrogasadmision.NR_EdadPrimaria;
            /*Droga Secundaria*/
            int FK_DrogaSecundaria = this.wucdrogasadmision.FK_DrogaSecundaria;
            bool IN_ToxicologiaSecundaria = this.wucdrogasadmision.IN_ToxicologiaSecundaria;
            int FK_ViaSecundaria = this.wucdrogasadmision.FK_ViaSecundaria;
            int FK_FrecuenciaSecundaria = this.wucdrogasadmision.FK_FrecuenciaSecundaria;
            int NR_EdadSecundaria = this.wucdrogasadmision.NR_EdadSecundaria;
            /*Droga Terciaria*/
            int FK_DrogaTerciaria = this.wucdrogasadmision.FK_DrogaTerciaria;
            bool IN_ToxicologiaTerciaria = this.wucdrogasadmision.IN_ToxicologiaTerciaria;
            int FK_ViaTerciaria = this.wucdrogasadmision.FK_ViaTerciaria;
            int FK_FrecuenciaTerciaria = this.wucdrogasadmision.FK_FrecuenciaTerciaria;
            int NR_EdadTerciaria = this.wucdrogasadmision.NR_EdadTerciaria;
            /*Droga Cuarta*/
            string NB_DrogaCuarta = this.wucdrogasadmision.NB_DrogaCuarta;
            bool IN_ToxicologiaCuarta = this.wucdrogasadmision.IN_ToxicologiaCuarta;
            int FK_ViaCuarta = this.wucdrogasadmision.FK_ViaCuarta;
            int FK_FrecuenciaCuarta = this.wucdrogasadmision.FK_FrecuenciaCuarta;
            int NR_EdadCuarta = this.wucdrogasadmision.NR_EdadCuarta;
            /*Droga Quinta*/
            string NB_DrogaQuinta = this.wucdrogasadmision.NB_DrogaQuinta;
            bool IN_ToxicologiaQuinta = this.wucdrogasadmision.IN_ToxicologiaQuinta;
            int FK_ViaQuinta = this.wucdrogasadmision.FK_ViaQuinta;
            int FK_FrecuenciaQuinta = this.wucdrogasadmision.FK_FrecuenciaQuinta;
            int NR_EdadQuinta = this.wucdrogasadmision.NR_EdadQuinta;
            /*Sobredosis*/
            bool IN_Sobredosis = this.wucdrogasadmision.IN_Sobredosis;
            int FK_DrogaSobredosisPrimaria = this.wucdrogasadmision.FK_DrogaSobredosisPrimaria;
            int FK_DrogaSobredosisSecundaria = this.wucdrogasadmision.FK_DrogaSobredosisSecundaria;
            string DE_DrogaSobredosisTerciaria = this.wucdrogasadmision.DE_DrogaSobredosisTerciaria;
            string DE_DrogaSobredosisCuarta = this.wucdrogasadmision.DE_DrogaSobredosisCuarta;
            /*Diagnosticos Primaria*/
            int FK_ICDX_Primaria = this.wucdrogasadmision.FK_ICDX_Primaria;
            int FK_DSMV_Primaria = this.wucdrogasadmision.FK_DSMV_Primaria;
            int FK_CondicionFisicaPrimaria = this.wucdrogasadmision.FK_CondicionFisicaPrimaria;
            /*Diagnosticos Secundaria*/
            int FK_ICDX_Secundaria = this.wucdrogasadmision.FK_ICDX_Secundaria;
            int FK_DSMV_Secundaria = this.wucdrogasadmision.FK_DSMV_Secundaria;
            int FK_CondicionFisicaSecundaria = this.wucdrogasadmision.FK_CondicionFisicaSecundaria;
            /*Diagnosticos Terciaria*/
            int FK_ICDX_Terciaria = this.wucdrogasadmision.FK_ICDX_Terciaria;
            int FK_DSMV_Terciaria = this.wucdrogasadmision.FK_DSMV_Terciaria;
            int FK_CondicionFisicaTerciaria = this.wucdrogasadmision.FK_CondicionFisicaTerciaria;
            /*Diagnosticos Cuarta*/
            int FK_ICDX_Cuarta = this.wucdrogasadmision.FK_ICDX_Cuarta;
            int FK_DSMV_Cuarta = this.wucdrogasadmision.FK_DSMV_Cuarta;
            int FK_CondicionFisicaCuarta = this.wucdrogasadmision.FK_CondicionFisicaCuarta;
            /*Nivel Cuidado*/
            int FK_NivelSustancia = this.wucdrogasadmision.FK_NivelSustancia;
            /*Seguro Salud*/
            int FK_SeguroSalud = this.wucdrogasadmision.FK_SeguroSalud;

            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    PK_Episodio = dsCARA.CA_PERFIL.Where(a => a.PK_Perfil.Equals(PK_Perfil)).Select(b => b.FK_Episodio).SingleOrDefault();

                    var spu_episodio = dsCARA.SPU_EPISODIO(PK_Episodio, FE_Episodio, null, FK_EstadoServicio, FK_FuenteReferido, FK_EpisodiosPrevios, FK_NivelSustancia, NR_DiasEspera);

                    var spu_perfil = dsCARA.SPU_PERFIL
                        (
                            PK_Perfil, FE_Episodio, "AD", NR_ArrestosMesPasado, FK_GrupoApoyoMesPasado, FK_Genero, NR_Edad, FK_Residencia, FK_Embarazada, FK_HijosMenoresCuido, FK_Veterano,
                            FK_Escolaridad, FK_CondicionLaboral, FK_NoFuerzaLaboral, FK_Estudios, FK_FuenteIngreso, FK_DrogaPrimaria, IN_ToxicologiaPrimaria, FK_ViaPrimaria, FK_FrecuenciaPrimaria,
                            NR_EdadPrimaria, FK_DrogaSecundaria, IN_ToxicologiaSecundaria, FK_ViaSecundaria, FK_FrecuenciaSecundaria, NR_EdadSecundaria, FK_DrogaTerciaria, IN_ToxicologiaTerciaria,
                            FK_ViaTerciaria, FK_FrecuenciaTerciaria, NR_EdadTerciaria, NB_DrogaCuarta, IN_ToxicologiaCuarta, FK_ViaCuarta, FK_FrecuenciaCuarta, NR_EdadCuarta,
                            NB_DrogaQuinta, IN_ToxicologiaQuinta, FK_ViaQuinta, FK_FrecuenciaQuinta, NR_EdadQuinta, FK_DrogaSobredosisPrimaria, FK_DrogaSobredosisSecundaria, DE_DrogaSobredosisTerciaria,
                            DE_DrogaSobredosisCuarta, FK_ICDX_Primaria, FK_ICDX_Secundaria, FK_ICDX_Terciaria, FK_ICDX_Cuarta, FK_DSMV_Primaria, FK_DSMV_Secundaria, FK_DSMV_Terciaria, FK_DSMV_Cuarta,
                            FK_CondicionFisicaPrimaria, FK_CondicionFisicaSecundaria, FK_CondicionFisicaTerciaria, FK_CondicionFisicaCuarta, FK_SeguroSalud, FK_EstadoMarital, FE_Episodio, Usuario.Id, IN_Sobredosis
                        );

                    mensaje = "El perfil fué modificado correctamente.";

                    ClientScript.RegisterStartupScript(this.GetType(), "Perfil Modificado", "sweetAlertRef('Perfil Modificado','" + mensaje + "','success','App/Perfiles/frmadmision.aspx?accion=leer&pk_perfil="+ PK_Perfil+"');", true);
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

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error ", "sweetAlert('Error','" + mensaje + "','error')", true);
            }
        }

        #endregion
    }
}