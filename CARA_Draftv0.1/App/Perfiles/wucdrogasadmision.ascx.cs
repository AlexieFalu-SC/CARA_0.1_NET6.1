using CARA_Draftv0._1.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CARA_Draftv0._1.App.Perfiles
{
    public partial class wucdrogasadmision : System.Web.UI.UserControl
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
            using (CARAEntities dsCARA = new CARAEntities())
            {
                /*Drogas de Uso*/
                string drogaNoAplica = dsCARA.CA_LKP_SUSTANCIA.Where(a => a.DE_Sustancia.Equals("No Aplica")).Select(b => b.PK_Sustancia).Single().ToString();
                string viaNoAplica = dsCARA.CA_LKP_VIA_SUSTANCIA.Where(a => a.DE_ViaSustancia.Equals("No Aplica")).Select(b => b.PK_ViaSustancia).Single().ToString();
                string frecNoAplica = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.Where(a => a.DE_FrecuenciaSustancia.Equals("No Aplica")).Select(b => b.PK_FrecuenciaSustancia).Single().ToString();

                

                this.ddlDrogaSecundaria.SelectedValue = drogaNoAplica;
                this.ddlToxicologiaSecundaria.SelectedValue = "2";
                this.ddlViaSecundaria.SelectedValue = viaNoAplica;
                this.ddlFrecuenciaSecundaria.SelectedValue = frecNoAplica;
                this.txtEdadSecundaria.Text = "0";

                


                this.ddlToxicologiaSecundaria.Enabled = false;
                this.ddlViaSecundaria.Enabled =false;
                this.ddlFrecuenciaSecundaria.Enabled = false;
                this.txtEdadSecundaria.Enabled = false;

                this.ddlDrogaTerciaria.SelectedValue = drogaNoAplica;
                this.ddlToxicologiaTerciaria.SelectedValue = "2";
                this.ddlViaTerciaria.SelectedValue = viaNoAplica;
                this.ddlFrecuenciaTerciaria.SelectedValue = frecNoAplica;
                this.txtEdadTerciaria.Text = "0";

                

                this.ddlDrogaTerciaria.Enabled = false;
                this.ddlToxicologiaTerciaria.Enabled = false;
                this.ddlViaTerciaria.Enabled = false;
                this.ddlFrecuenciaTerciaria.Enabled = false;
                this.txtEdadTerciaria.Enabled = false;

                this.txtDrogaCuarta.Text = "";
                this.ddlToxicologiaCuarta.SelectedValue = "2";
                this.ddlViaCuarta.SelectedValue = viaNoAplica;
                this.ddlFrecuenciaCuarta.SelectedValue = frecNoAplica;
                this.txtEdadCuarta.Text = "0";

                


                this.ddlToxicologiaCuarta.Enabled = false;
                this.ddlViaCuarta.Enabled = false;
                this.ddlFrecuenciaCuarta.Enabled = false;
                this.txtEdadCuarta.Enabled = false;

                this.txtDrogaQuinta.Text = "";
                this.ddlToxicologiaQuinta.SelectedValue = "2";
                this.ddlViaQuinta.SelectedValue = viaNoAplica;
                this.ddlFrecuenciaQuinta.SelectedValue = frecNoAplica;
                this.txtEdadQuinta.Text = "0";

                

                this.txtDrogaQuinta.Enabled = false;
                this.ddlToxicologiaQuinta.Enabled = false;
                this.ddlViaQuinta.Enabled = false;
                this.ddlFrecuenciaQuinta.Enabled = false;
                this.txtEdadQuinta.Enabled = false;

                /*Sobredosis*/
                this.ddlSobredosisPrimaria.SelectedValue = drogaNoAplica;
                this.ddlSobredosisPrimaria.Enabled = false;

                this.ddlSobredosisSecundaria.SelectedValue = drogaNoAplica;
                this.ddlSobredosisSecundaria.Enabled = false;

                this.txtSobredosisTerciaria.Enabled = false;
                this.txtSobredosisCuarta.Enabled = false;

                /*Diagnosticos*/

                //string icdxNoAplica = dsCARA.CA_LKP_ICDX.Where(a => a.DE_ICDX.Equals("No Aplica")).Select(b => b.PK_ICDX).Single().ToString();
                //string dsmvNoAplica = dsCARA.CA_LKP_DSMV.Where(a => a.DE_DSMV.Equals("No Aplica")).Select(b => b.PK_DSMV).Single().ToString();
                //string condNoAplica = dsCARA.CA_LKP_CONDICIONES_FISICAS.Where(a => a.DE_CondicionesFisicas.Equals("Ningún diagnóstico")).Select(b => b.PK_CondicionesFisicas).Single().ToString();

                //this.ddlICDXSecundaria.SelectedValue = icdxNoAplica;
                //this.ddlDSMVSecundaria.SelectedValue = dsmvNoAplica;
                //this.ddlCondicionSecundaria.SelectedValue = condNoAplica;
                //this.ddlICDXSecundaria.Enabled = false;
                //this.ddlDSMVSecundaria.Enabled = false;
                //this.ddlCondicionSecundaria.Enabled = false;

                //this.ddlICDXTerciaria.SelectedValue = icdxNoAplica;
                //this.ddlDSMVTerciaria.SelectedValue = dsmvNoAplica;
                //this.ddlCondicionTerciaria.SelectedValue = condNoAplica;
                //this.ddlICDXTerciaria.Enabled = false;
                //this.ddlDSMVTerciaria.Enabled = false;
                //this.ddlCondicionTerciaria.Enabled = false;

                //this.ddlICDXCuarta.SelectedValue = icdxNoAplica;
                //this.ddlDSMVCuarta.SelectedValue = dsmvNoAplica;
                //this.ddlCondicionCuarta.SelectedValue = condNoAplica;
                //this.ddlICDXCuarta.Enabled = false;
                //this.ddlDSMVCuarta.Enabled = false;
                //this.ddlCondicionCuarta.Enabled = false;
            }

        }

        private void LeerRegistro()
        {
            try
            {
                using (CARAEntities dsCARA = new CARAEntities())
                {
                    var perfil = dsCARA.CA_PERFIL.Where(a => a.PK_Perfil.Equals(PK_Perfil)).FirstOrDefault();

                    var episodio = dsCARA.CA_EPISODIO.Where(a => a.PK_Episodio.Equals(perfil.FK_Episodio)).FirstOrDefault();

                    /*Drogas de Uso*/
                    this.lblDrogaPrimaria.Text = dsCARA.CA_LKP_SUSTANCIA.Where(a => a.PK_Sustancia.Equals(perfil.FK_DrogaPrimaria)).Select(b => b.DE_Sustancia).SingleOrDefault();
                    if (perfil.IN_ToxicologiaPrimaria == true) { this.lblToxicologiaPrimaria.Text = "Si"; } else { this.lblToxicologiaPrimaria.Text = "No"; }
                    this.lblViaPrimaria.Text = dsCARA.CA_LKP_VIA_SUSTANCIA.Where(a => a.PK_ViaSustancia.Equals(perfil.FK_ViaPrimaria)).Select(b => b.DE_ViaSustancia).SingleOrDefault();
                    this.lblFrecuenciaPrimaria.Text = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.Where(a => a.PK_FrecuenciaSustancia.Equals(perfil.FK_FrecuenciaPrimaria)).Select(b => b.DE_FrecuenciaSustancia).SingleOrDefault();
                    this.lblEdadPrimaria.Text = perfil.NR_EdadPrimaria.ToString();

                    this.lblDrogaSecundaria.Text = dsCARA.CA_LKP_SUSTANCIA.Where(a => a.PK_Sustancia.Equals(perfil.FK_DrogaSecundaria)).Select(b => b.DE_Sustancia).SingleOrDefault();
                    if (perfil.IN_ToxicologiaSecundaria == true) { this.lblToxicologiaSecundaria.Text = "Si"; } else { this.lblToxicologiaSecundaria.Text = "No"; }
                    this.lblViaSecundaria.Text = dsCARA.CA_LKP_VIA_SUSTANCIA.Where(a => a.PK_ViaSustancia.Equals(perfil.FK_ViaSecundaria)).Select(b => b.DE_ViaSustancia).SingleOrDefault();
                    this.lblFrecuenciaSecundaria.Text = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.Where(a => a.PK_FrecuenciaSustancia.Equals(perfil.FK_FrecuenciaSecundaria)).Select(b => b.DE_FrecuenciaSustancia).SingleOrDefault();
                    this.lblEdadSecundaria.Text = perfil.NR_EdadSecundaria.ToString();

                    this.lblDrogaTerciaria.Text = dsCARA.CA_LKP_SUSTANCIA.Where(a => a.PK_Sustancia.Equals(perfil.FK_DrogaTerciaria)).Select(b => b.DE_Sustancia).SingleOrDefault();
                    if (perfil.IN_ToxicologiaTerciaria == true) { this.lblToxicologiaTerciaria.Text = "Si"; } else { this.lblToxicologiaTerciaria.Text = "No"; }
                    this.lblViaTerciaria.Text = dsCARA.CA_LKP_VIA_SUSTANCIA.Where(a => a.PK_ViaSustancia.Equals(perfil.FK_ViaTerciaria)).Select(b => b.DE_ViaSustancia).SingleOrDefault();
                    this.lblFrecuenciaTerciaria.Text = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.Where(a => a.PK_FrecuenciaSustancia.Equals(perfil.FK_FrecuenciaTerciaria)).Select(b => b.DE_FrecuenciaSustancia).SingleOrDefault();
                    this.lblEdadTerciaria.Text = perfil.NR_EdadTerciaria.ToString();

                    this.lblDrogaCuarta.Text = perfil.NB_DrogaCuarta.ToString();
                    if (perfil.IN_ToxicologiaCuarta == true) { this.lblToxicologiaCuarta.Text = "Si"; } else { this.lblToxicologiaCuarta.Text = "No"; }
                    this.lblViaCuarta.Text = dsCARA.CA_LKP_VIA_SUSTANCIA.Where(a => a.PK_ViaSustancia.Equals(perfil.FK_ViaCuarta)).Select(b => b.DE_ViaSustancia).SingleOrDefault();
                    this.lblFrecuenciaCuarta.Text = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.Where(a => a.PK_FrecuenciaSustancia.Equals(perfil.FK_FrecuenciaCuarta)).Select(b => b.DE_FrecuenciaSustancia).SingleOrDefault();
                    this.lblEdadCuarta.Text = perfil.NR_EdadCuarta.ToString();

                    this.lblDrogaQuinta.Text = perfil.NB_DrogaQuinta.ToString();
                    if (perfil.IN_ToxicologiaQuinta == true) { this.lblToxicologiaQuinta.Text = "Si"; } else { this.lblToxicologiaQuinta.Text = "No"; }
                    this.lblViaQuinta.Text = dsCARA.CA_LKP_VIA_SUSTANCIA.Where(a => a.PK_ViaSustancia.Equals(perfil.FK_ViaQuinta)).Select(b => b.DE_ViaSustancia).SingleOrDefault();
                    this.lblFrecuenciaQuinta.Text = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.Where(a => a.PK_FrecuenciaSustancia.Equals(perfil.FK_FrecuenciaQuinta)).Select(b => b.DE_FrecuenciaSustancia).SingleOrDefault();
                    this.lblEdadQuinta.Text = perfil.NR_EdadQuinta.ToString();

                    /*Sobredosis*/
                    if (perfil.IN_Sobredosis == true) { this.lblSobredosis.Text = "Si"; } else { this.lblSobredosis.Text = "No"; }
                    this.lblSobredosisPrimaria.Text = dsCARA.CA_LKP_SUSTANCIA.Where(a => a.PK_Sustancia.Equals(perfil.FK_DrogaSobredosisPrimaria)).Select(b => b.DE_Sustancia).SingleOrDefault();
                    this.lblSobredosisSecundaria.Text = dsCARA.CA_LKP_SUSTANCIA.Where(a => a.PK_Sustancia.Equals(perfil.FK_DrogaSobredosisSecundaria)).Select(b => b.DE_Sustancia).SingleOrDefault();
                    this.lblSobredosisTerciaria.Text = perfil.DE_DrogaSobredosisTerciaria.ToString();
                    this.lblSobredosisCuarta.Text = perfil.DE_DrogaSobredosisCuarta.ToString();

                    /*Diagnosticos*/
                    this.lblICDXPrimaria.Text = dsCARA.CA_LKP_ICDX.Where(a => a.PK_ICDX.Equals(perfil.FK_ICDX_Primaria)).Select(b => b.DE_ICDX).SingleOrDefault();
                    this.lblDSMVPrimaria.Text = dsCARA.CA_LKP_DSMV.Where(a => a.PK_DSMV.Equals(perfil.FK_DSMV_Primaria)).Select(b => b.DE_DSMV).SingleOrDefault();
                    this.lblCondicionPrimaria.Text = dsCARA.CA_LKP_CONDICIONES_FISICAS.Where(a => a.PK_CondicionesFisicas.Equals(perfil.FK_CondicionFisicaPrimaria)).Select(b => b.DE_CondicionesFisicas).SingleOrDefault();

                    this.lblICDXSecundaria.Text = dsCARA.CA_LKP_ICDX.Where(a => a.PK_ICDX.Equals(perfil.FK_ICDX_Secundaria)).Select(b => b.DE_ICDX).SingleOrDefault();
                    this.lblDSMVSecundaria.Text = dsCARA.CA_LKP_DSMV.Where(a => a.PK_DSMV.Equals(perfil.FK_DSMV_Secundaria)).Select(b => b.DE_DSMV).SingleOrDefault();
                    this.lblCondicionSecundaria.Text = dsCARA.CA_LKP_CONDICIONES_FISICAS.Where(a => a.PK_CondicionesFisicas.Equals(perfil.FK_CondicionFisicaSecundaria)).Select(b => b.DE_CondicionesFisicas).SingleOrDefault();

                    this.lblICDXTerciaria.Text = dsCARA.CA_LKP_ICDX.Where(a => a.PK_ICDX.Equals(perfil.FK_ICDX_Terciaria)).Select(b => b.DE_ICDX).SingleOrDefault();
                    this.lblDSMVTerciaria.Text = dsCARA.CA_LKP_DSMV.Where(a => a.PK_DSMV.Equals(perfil.FK_DSMV_Terciaria)).Select(b => b.DE_DSMV).SingleOrDefault();
                    this.lblCondicionTerciaria.Text = dsCARA.CA_LKP_CONDICIONES_FISICAS.Where(a => a.PK_CondicionesFisicas.Equals(perfil.FK_CondicionFisicaTerciaria)).Select(b => b.DE_CondicionesFisicas).SingleOrDefault();

                    this.lblICDXCuarta.Text = dsCARA.CA_LKP_ICDX.Where(a => a.PK_ICDX.Equals(perfil.FK_ICDX_Cuarta)).Select(b => b.DE_ICDX).SingleOrDefault();
                    this.lblDSMVCuarta.Text = dsCARA.CA_LKP_DSMV.Where(a => a.PK_DSMV.Equals(perfil.FK_DSMV_Cuarta)).Select(b => b.DE_DSMV).SingleOrDefault();
                    this.lblCondicionCuarta.Text = dsCARA.CA_LKP_CONDICIONES_FISICAS.Where(a => a.PK_CondicionesFisicas.Equals(perfil.FK_CondicionFisicaCuarta)).Select(b => b.DE_CondicionesFisicas).SingleOrDefault();

                    /*Nivel Cuidado y Plan de Salud*/
                    this.lblNivelSustancia.Text = dsCARA.CA_LKP_NIVEL_SUSTANCIA.Where(a => a.PK_NivelSustancia.Equals(episodio.FK_NivelSustancia)).Select(b => b.DE_NivelSustancia).SingleOrDefault();
                    this.lblSeguroSalud.Text = dsCARA.CA_LKP_SEGURO_SALUD.Where(a => a.PK_SeguroSalud.Equals(perfil.FK_SeguroSalud)).Select(b => b.DE_SeguroSalud).SingleOrDefault();


                    /*Drogas de Uso*/
                    this.ddlDrogaPrimaria.Visible = false;
                    this.ddlToxicologiaPrimaria.Visible = false;
                    this.ddlViaPrimaria.Visible = false;
                    this.ddlFrecuenciaPrimaria.Visible = false;
                    this.txtEdadPrimaria.Visible = false;

                    this.ddlDrogaSecundaria.Visible = false;
                    this.ddlToxicologiaSecundaria.Visible = false;
                    this.ddlViaSecundaria.Visible = false;
                    this.ddlFrecuenciaSecundaria.Visible = false;
                    this.txtEdadSecundaria.Visible = false;

                    this.ddlDrogaTerciaria.Visible = false;
                    this.ddlToxicologiaTerciaria.Visible = false;
                    this.ddlViaTerciaria.Visible = false;
                    this.ddlFrecuenciaTerciaria.Visible = false;
                    this.txtEdadTerciaria.Visible = false;

                    this.txtDrogaCuarta.Visible = false;
                    this.ddlToxicologiaCuarta.Visible = false;
                    this.ddlViaCuarta.Visible = false;
                    this.ddlFrecuenciaCuarta.Visible = false;
                    this.txtEdadCuarta.Visible = false;

                    this.txtDrogaQuinta.Visible = false;
                    this.ddlToxicologiaQuinta.Visible = false;
                    this.ddlViaQuinta.Visible = false;
                    this.ddlFrecuenciaQuinta.Visible = false;
                    this.txtEdadQuinta.Visible = false;

                    /*Sobredosis*/
                    this.ddlSobredosis.Visible = false;
                    this.ddlSobredosisPrimaria.Visible = false;
                    this.ddlSobredosisSecundaria.Visible = false;
                    this.txtSobredosisTerciaria.Visible = false;
                    this.txtSobredosisCuarta.Visible = false;

                    /*Diagnosticos*/
                    this.ddlICDXPrimaria.Visible = false;
                    this.ddlDSMVPrimaria.Visible = false;
                    this.ddlCondicionPrimaria.Visible = false;

                    this.ddlICDXSecundaria.Visible = false;
                    this.ddlDSMVSecundaria.Visible = false;
                    this.ddlCondicionSecundaria.Visible = false;

                    this.ddlICDXTerciaria.Visible = false;
                    this.ddlDSMVTerciaria.Visible = false;
                    this.ddlCondicionTerciaria.Visible = false;

                    this.ddlICDXCuarta.Visible = false;
                    this.ddlDSMVCuarta.Visible = false;
                    this.ddlCondicionCuarta.Visible = false;

                    /*Nivel Cuidado y Plan de Salud*/
                    this.ddlNivelSustancia.Visible = false;
                    this.ddlSeguroSalud.Visible = false;
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

                    /*Drogas de Uso*/
                    this.ddlDrogaPrimaria.Visible = true;
                    this.ddlToxicologiaPrimaria.Visible = true;
                    this.ddlViaPrimaria.Visible = true;
                    this.ddlFrecuenciaPrimaria.Visible = true;
                    this.txtEdadPrimaria.Visible = true;

                    this.ddlDrogaSecundaria.Visible = true;
                    this.ddlToxicologiaSecundaria.Visible = true;
                    this.ddlViaSecundaria.Visible = true;
                    this.ddlFrecuenciaSecundaria.Visible = true;
                    this.txtEdadSecundaria.Visible = true;

                    this.ddlDrogaTerciaria.Visible = true;
                    this.ddlToxicologiaTerciaria.Visible = true;
                    this.ddlViaTerciaria.Visible = true;
                    this.ddlFrecuenciaTerciaria.Visible = true;
                    this.txtEdadTerciaria.Visible = true;

                    this.txtDrogaCuarta.Visible = true;
                    this.ddlToxicologiaCuarta.Visible = true;
                    this.ddlViaCuarta.Visible = true;
                    this.ddlFrecuenciaCuarta.Visible = true;
                    this.txtEdadCuarta.Visible = true;

                    this.txtDrogaQuinta.Visible = true;
                    this.ddlToxicologiaQuinta.Visible = true;
                    this.ddlViaQuinta.Visible = true;
                    this.ddlFrecuenciaQuinta.Visible = true;
                    this.txtEdadQuinta.Visible = true;

                    /*Sobredosis*/
                    this.ddlSobredosis.Visible = true;
                    this.ddlSobredosisPrimaria.Visible = true;
                    this.ddlSobredosisSecundaria.Visible = true;
                    this.txtSobredosisTerciaria.Visible = true;
                    this.txtSobredosisCuarta.Visible = true;

                    /*Diagnosticos*/
                    this.ddlICDXPrimaria.Visible = true;
                    this.ddlDSMVPrimaria.Visible = true;
                    this.ddlCondicionPrimaria.Visible = true;

                    this.ddlICDXSecundaria.Visible = true;
                    this.ddlDSMVSecundaria.Visible = true;
                    this.ddlCondicionSecundaria.Visible = true;

                    this.ddlICDXTerciaria.Visible = true;
                    this.ddlDSMVTerciaria.Visible = true;
                    this.ddlCondicionTerciaria.Visible = true;

                    this.ddlICDXCuarta.Visible = true;
                    this.ddlDSMVCuarta.Visible = true;
                    this.ddlCondicionCuarta.Visible = true;

                    /*Nivel Cuidado y Plan de Salud*/
                    this.ddlNivelSustancia.Visible = true;
                    this.ddlSeguroSalud.Visible = true;

                    /*Drogas de Uso*/
                    this.ddlDrogaPrimaria.SelectedValue = perfil.FK_DrogaPrimaria.ToString();
                    if (perfil.IN_ToxicologiaPrimaria == true) { this.ddlToxicologiaPrimaria.SelectedValue = "1"; } else { this.ddlToxicologiaPrimaria.SelectedValue = "2"; }
                    this.ddlViaPrimaria.SelectedValue = perfil.FK_ViaPrimaria.ToString();
                    this.ddlFrecuenciaPrimaria.SelectedValue = perfil.FK_FrecuenciaPrimaria.ToString();
                    this.txtEdadPrimaria.Text = perfil.NR_EdadPrimaria.ToString();

                    this.ddlDrogaSecundaria.SelectedValue = perfil.FK_DrogaSecundaria.ToString();
                    if (perfil.IN_ToxicologiaSecundaria == true) { this.ddlToxicologiaSecundaria.SelectedValue = "1"; } else { this.ddlToxicologiaSecundaria.SelectedValue = "2"; }
                    this.ddlViaSecundaria.SelectedValue = perfil.FK_ViaSecundaria.ToString();
                    this.ddlFrecuenciaSecundaria.SelectedValue = perfil.FK_FrecuenciaSecundaria.ToString();
                    this.txtEdadSecundaria.Text = perfil.NR_EdadSecundaria.ToString();

                    this.ddlDrogaTerciaria.SelectedValue = perfil.FK_DrogaTerciaria.ToString();
                    if (perfil.IN_ToxicologiaTerciaria == true) { this.ddlToxicologiaTerciaria.SelectedValue = "1"; } else { this.ddlToxicologiaTerciaria.SelectedValue = "2"; }
                    this.ddlViaTerciaria.SelectedValue = perfil.FK_ViaTerciaria.ToString();
                    this.ddlFrecuenciaTerciaria.SelectedValue = perfil.FK_FrecuenciaTerciaria.ToString();
                    this.txtEdadTerciaria.Text = perfil.NR_EdadTerciaria.ToString();

                    this.txtDrogaCuarta.Text = perfil.NB_DrogaCuarta.ToString();
                    if (perfil.IN_ToxicologiaCuarta == true) { this.ddlToxicologiaCuarta.SelectedValue = "1"; } else { this.ddlToxicologiaCuarta.SelectedValue = "2"; }
                    this.ddlViaCuarta.SelectedValue = perfil.FK_ViaCuarta.ToString();
                    this.ddlFrecuenciaCuarta.SelectedValue = perfil.FK_FrecuenciaCuarta.ToString();
                    this.txtEdadCuarta.Text = perfil.NR_EdadCuarta.ToString();

                    this.txtDrogaQuinta.Text = perfil.NB_DrogaQuinta.ToString();
                    if (perfil.IN_ToxicologiaQuinta == true) { this.ddlToxicologiaQuinta.SelectedValue = "1"; } else { this.ddlToxicologiaQuinta.SelectedValue = "2"; }
                    this.ddlViaQuinta.SelectedValue = perfil.FK_ViaQuinta.ToString();
                    this.ddlFrecuenciaQuinta.SelectedValue = perfil.FK_FrecuenciaQuinta.ToString();
                    this.txtEdadQuinta.Text = perfil.NR_EdadQuinta.ToString();

                    /*Sobredosis*/
                    if (perfil.IN_Sobredosis == true) { this.ddlSobredosis.SelectedValue = "1"; } else { this.ddlSobredosis.SelectedValue = "2"; }
                    this.ddlSobredosisPrimaria.SelectedValue = perfil.FK_DrogaSobredosisPrimaria.ToString();
                    this.ddlSobredosisSecundaria.SelectedValue = perfil.FK_DrogaSobredosisSecundaria.ToString();
                    this.txtSobredosisTerciaria.Text = perfil.DE_DrogaSobredosisTerciaria.ToString();
                    this.txtSobredosisCuarta.Text = perfil.DE_DrogaSobredosisCuarta.ToString();

                    /*Diagnosticos*/
                    this.ddlICDXPrimaria.SelectedValue = perfil.FK_ICDX_Primaria.ToString();
                    this.ddlDSMVPrimaria.SelectedValue = perfil.FK_DSMV_Primaria.ToString();
                    this.ddlCondicionPrimaria.SelectedValue = perfil.FK_CondicionFisicaPrimaria.ToString();

                    this.ddlICDXSecundaria.SelectedValue = perfil.FK_ICDX_Secundaria.ToString();
                    this.ddlDSMVSecundaria.SelectedValue = perfil.FK_DSMV_Secundaria.ToString();
                    this.ddlCondicionSecundaria.SelectedValue = perfil.FK_CondicionFisicaSecundaria.ToString();

                    this.ddlICDXTerciaria.SelectedValue = perfil.FK_ICDX_Terciaria.ToString();
                    this.ddlDSMVTerciaria.SelectedValue = perfil.FK_DSMV_Terciaria.ToString();
                    this.ddlCondicionTerciaria.SelectedValue = perfil.FK_CondicionFisicaTerciaria.ToString();

                    this.ddlICDXCuarta.SelectedValue = perfil.FK_ICDX_Cuarta.ToString();
                    this.ddlDSMVCuarta.SelectedValue = perfil.FK_DSMV_Cuarta.ToString();
                    this.ddlCondicionCuarta.SelectedValue = perfil.FK_CondicionFisicaCuarta.ToString();

                    /*Nivel Cuidado y Plan de Salud*/
                    this.ddlNivelSustancia.SelectedValue = episodio.FK_NivelSustancia.ToString();
                    this.ddlSeguroSalud.SelectedValue = perfil.FK_SeguroSalud.ToString();


                    
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
                    ddlDrogaPrimaria.DataValueField = "PK_Sustancia";
                    ddlDrogaPrimaria.DataTextField = "DE_Sustancia";
                    ddlDrogaPrimaria.DataSource = dsCARA.CA_LKP_SUSTANCIA.ToList();
                    ddlDrogaPrimaria.DataBind();
                    ddlDrogaPrimaria.Items.Insert(0, new ListItem("", "0"));

                    ddlViaPrimaria.DataValueField = "PK_ViaSustancia";
                    ddlViaPrimaria.DataTextField = "DE_ViaSustancia";
                    ddlViaPrimaria.DataSource = dsCARA.CA_LKP_VIA_SUSTANCIA.ToList();
                    ddlViaPrimaria.DataBind();
                    ddlViaPrimaria.Items.Insert(0, new ListItem("", "0"));

                    ddlFrecuenciaPrimaria.DataValueField = "PK_FrecuenciaSustancia";
                    ddlFrecuenciaPrimaria.DataTextField = "DE_FrecuenciaSustancia";
                    ddlFrecuenciaPrimaria.DataSource = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.ToList();
                    ddlFrecuenciaPrimaria.DataBind();
                    ddlFrecuenciaPrimaria.Items.Insert(0, new ListItem("", "0"));

                    ddlDrogaSecundaria.DataValueField = "PK_Sustancia";
                    ddlDrogaSecundaria.DataTextField = "DE_Sustancia";
                    ddlDrogaSecundaria.DataSource = dsCARA.CA_LKP_SUSTANCIA.ToList();
                    ddlDrogaSecundaria.DataBind();
                    ddlDrogaSecundaria.Items.Insert(0, new ListItem("", "0"));

                    ddlViaSecundaria.DataValueField = "PK_ViaSustancia";
                    ddlViaSecundaria.DataTextField = "DE_ViaSustancia";
                    ddlViaSecundaria.DataSource = dsCARA.CA_LKP_VIA_SUSTANCIA.ToList();
                    ddlViaSecundaria.DataBind();
                    ddlViaSecundaria.Items.Insert(0, new ListItem("", "0"));

                    ddlFrecuenciaSecundaria.DataValueField = "PK_FrecuenciaSustancia";
                    ddlFrecuenciaSecundaria.DataTextField = "DE_FrecuenciaSustancia";
                    ddlFrecuenciaSecundaria.DataSource = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.ToList();
                    ddlFrecuenciaSecundaria.DataBind();
                    ddlFrecuenciaSecundaria.Items.Insert(0, new ListItem("", "0"));

                    ddlDrogaTerciaria.DataValueField = "PK_Sustancia";
                    ddlDrogaTerciaria.DataTextField = "DE_Sustancia";
                    ddlDrogaTerciaria.DataSource = dsCARA.CA_LKP_SUSTANCIA.ToList();
                    ddlDrogaTerciaria.DataBind();
                    ddlDrogaTerciaria.Items.Insert(0, new ListItem("", "0"));

                    ddlViaTerciaria.DataValueField = "PK_ViaSustancia";
                    ddlViaTerciaria.DataTextField = "DE_ViaSustancia";
                    ddlViaTerciaria.DataSource = dsCARA.CA_LKP_VIA_SUSTANCIA.ToList();
                    ddlViaTerciaria.DataBind();
                    ddlViaTerciaria.Items.Insert(0, new ListItem("", "0"));

                    ddlFrecuenciaTerciaria.DataValueField = "PK_FrecuenciaSustancia";
                    ddlFrecuenciaTerciaria.DataTextField = "DE_FrecuenciaSustancia";
                    ddlFrecuenciaTerciaria.DataSource = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.ToList();
                    ddlFrecuenciaTerciaria.DataBind();
                    ddlFrecuenciaTerciaria.Items.Insert(0, new ListItem("", "0"));

                    ddlViaCuarta.DataValueField = "PK_ViaSustancia";
                    ddlViaCuarta.DataTextField = "DE_ViaSustancia";
                    ddlViaCuarta.DataSource = dsCARA.CA_LKP_VIA_SUSTANCIA.ToList();
                    ddlViaCuarta.DataBind();
                    ddlViaCuarta.Items.Insert(0, new ListItem("", "0"));

                    ddlFrecuenciaCuarta.DataValueField = "PK_FrecuenciaSustancia";
                    ddlFrecuenciaCuarta.DataTextField = "DE_FrecuenciaSustancia";
                    ddlFrecuenciaCuarta.DataSource = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.ToList();
                    ddlFrecuenciaCuarta.DataBind();
                    ddlFrecuenciaCuarta.Items.Insert(0, new ListItem("", "0"));

                    ddlViaQuinta.DataValueField = "PK_ViaSustancia";
                    ddlViaQuinta.DataTextField = "DE_ViaSustancia";
                    ddlViaQuinta.DataSource = dsCARA.CA_LKP_VIA_SUSTANCIA.ToList();
                    ddlViaQuinta.DataBind();
                    ddlViaQuinta.Items.Insert(0, new ListItem("", "0"));

                    ddlFrecuenciaQuinta.DataValueField = "PK_FrecuenciaSustancia";
                    ddlFrecuenciaQuinta.DataTextField = "DE_FrecuenciaSustancia";
                    ddlFrecuenciaQuinta.DataSource = dsCARA.CA_LKP_FRECUENCIA_SUSTANCIA.ToList();
                    ddlFrecuenciaQuinta.DataBind();
                    ddlFrecuenciaQuinta.Items.Insert(0, new ListItem("", "0"));

                    ddlSobredosisPrimaria.DataValueField = "PK_Sustancia";
                    ddlSobredosisPrimaria.DataTextField = "DE_Sustancia";
                    ddlSobredosisPrimaria.DataSource = dsCARA.CA_LKP_SUSTANCIA.ToList();
                    ddlSobredosisPrimaria.DataBind();
                    ddlSobredosisPrimaria.Items.Insert(0, new ListItem("", "0"));

                    ddlSobredosisSecundaria.DataValueField = "PK_Sustancia";
                    ddlSobredosisSecundaria.DataTextField = "DE_Sustancia";
                    ddlSobredosisSecundaria.DataSource = dsCARA.CA_LKP_SUSTANCIA.ToList();
                    ddlSobredosisSecundaria.DataBind();
                    ddlSobredosisSecundaria.Items.Insert(0, new ListItem("", "0"));

                    ddlICDXPrimaria.DataValueField = "PK_ICDX";
                    ddlICDXPrimaria.DataTextField = "DE_ICDX";
                    ddlICDXPrimaria.DataSource = dsCARA.CA_LKP_ICDX.ToList();
                    ddlICDXPrimaria.DataBind();
                    ddlICDXPrimaria.Items.Insert(0, new ListItem("", "0"));

                    ddlICDXSecundaria.DataValueField = "PK_ICDX";
                    ddlICDXSecundaria.DataTextField = "DE_ICDX";
                    ddlICDXSecundaria.DataSource = dsCARA.CA_LKP_ICDX.ToList();
                    ddlICDXSecundaria.DataBind();
                    ddlICDXSecundaria.Items.Insert(0, new ListItem("", "0"));

                    ddlICDXTerciaria.DataValueField = "PK_ICDX";
                    ddlICDXTerciaria.DataTextField = "DE_ICDX";
                    ddlICDXTerciaria.DataSource = dsCARA.CA_LKP_ICDX.ToList();
                    ddlICDXTerciaria.DataBind();
                    ddlICDXTerciaria.Items.Insert(0, new ListItem("", "0"));

                    ddlICDXCuarta.DataValueField = "PK_ICDX";
                    ddlICDXCuarta.DataTextField = "DE_ICDX";
                    ddlICDXCuarta.DataSource = dsCARA.CA_LKP_ICDX.ToList();
                    ddlICDXCuarta.DataBind();
                    ddlICDXCuarta.Items.Insert(0, new ListItem("", "0"));

                    ddlDSMVPrimaria.DataValueField = "PK_DSMV";
                    ddlDSMVPrimaria.DataTextField = "DE_DSMV";
                    ddlDSMVPrimaria.DataSource = dsCARA.CA_LKP_DSMV.ToList();
                    ddlDSMVPrimaria.DataBind();
                    ddlDSMVPrimaria.Items.Insert(0, new ListItem("", "0"));

                    ddlDSMVSecundaria.DataValueField = "PK_DSMV";
                    ddlDSMVSecundaria.DataTextField = "DE_DSMV";
                    ddlDSMVSecundaria.DataSource = dsCARA.CA_LKP_DSMV.ToList();
                    ddlDSMVSecundaria.DataBind();
                    ddlDSMVSecundaria.Items.Insert(0, new ListItem("", "0"));

                    ddlDSMVTerciaria.DataValueField = "PK_DSMV";
                    ddlDSMVTerciaria.DataTextField = "DE_DSMV";
                    ddlDSMVTerciaria.DataSource = dsCARA.CA_LKP_DSMV.ToList();
                    ddlDSMVTerciaria.DataBind();
                    ddlDSMVTerciaria.Items.Insert(0, new ListItem("", "0"));

                    ddlDSMVCuarta.DataValueField = "PK_DSMV";
                    ddlDSMVCuarta.DataTextField = "DE_DSMV";
                    ddlDSMVCuarta.DataSource = dsCARA.CA_LKP_DSMV.ToList();
                    ddlDSMVCuarta.DataBind();
                    ddlDSMVCuarta.Items.Insert(0, new ListItem("", "0"));

                    ddlCondicionPrimaria.DataValueField = "PK_CondicionesFisicas";
                    ddlCondicionPrimaria.DataTextField = "DE_CondicionesFisicas";
                    ddlCondicionPrimaria.DataSource = dsCARA.CA_LKP_CONDICIONES_FISICAS.ToList();
                    ddlCondicionPrimaria.DataBind();
                    ddlCondicionPrimaria.Items.Insert(0, new ListItem("", "0"));

                    ddlCondicionSecundaria.DataValueField = "PK_CondicionesFisicas";
                    ddlCondicionSecundaria.DataTextField = "DE_CondicionesFisicas";
                    ddlCondicionSecundaria.DataSource = dsCARA.CA_LKP_CONDICIONES_FISICAS.ToList();
                    ddlCondicionSecundaria.DataBind();
                    ddlCondicionSecundaria.Items.Insert(0, new ListItem("", "0"));

                    ddlCondicionTerciaria.DataValueField = "PK_CondicionesFisicas";
                    ddlCondicionTerciaria.DataTextField = "DE_CondicionesFisicas";
                    ddlCondicionTerciaria.DataSource = dsCARA.CA_LKP_CONDICIONES_FISICAS.ToList();
                    ddlCondicionTerciaria.DataBind();
                    ddlCondicionTerciaria.Items.Insert(0, new ListItem("", "0"));

                    ddlCondicionCuarta.DataValueField = "PK_CondicionesFisicas";
                    ddlCondicionCuarta.DataTextField = "DE_CondicionesFisicas";
                    ddlCondicionCuarta.DataSource = dsCARA.CA_LKP_CONDICIONES_FISICAS.ToList();
                    ddlCondicionCuarta.DataBind();
                    ddlCondicionCuarta.Items.Insert(0, new ListItem("", "0"));

                    ddlNivelSustancia.DataValueField = "PK_NivelSustancia";
                    ddlNivelSustancia.DataTextField = "DE_NivelSustancia";
                    ddlNivelSustancia.DataSource = dsCARA.CA_LKP_NIVEL_SUSTANCIA.ToList();
                    ddlNivelSustancia.DataBind();
                    ddlNivelSustancia.Items.Insert(0, new ListItem("", "0"));

                    ddlSeguroSalud.DataValueField = "PK_SeguroSalud";
                    ddlSeguroSalud.DataTextField = "DE_SeguroSalud";
                    ddlSeguroSalud.DataSource = dsCARA.CA_LKP_SEGURO_SALUD.ToList();
                    ddlSeguroSalud.DataBind();
                    ddlSeguroSalud.Items.Insert(0, new ListItem("", "0"));

                    this.rvEdadPrimaria.MaximumValue = Edad(this.ca_paciente.FE_Nacimiento).ToString();
                    this.rvEdadSecundaria.MaximumValue = Edad(this.ca_paciente.FE_Nacimiento).ToString();
                    this.rvEdadTerciaria.MaximumValue = Edad(this.ca_paciente.FE_Nacimiento).ToString();
                    this.rvEdadCuarta.MaximumValue = Edad(this.ca_paciente.FE_Nacimiento).ToString();
                    this.rvEdadQuinta.MaximumValue = Edad(this.ca_paciente.FE_Nacimiento).ToString();

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

        public int FK_DrogaPrimaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlDrogaPrimaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlDrogaPrimaria.SelectedValue.ToString());
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

        public bool IN_ToxicologiaPrimaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlToxicologiaPrimaria.SelectedValue.ToString()) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;//Default No aplica
                }
            }
        }

        public int FK_ViaPrimaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlViaPrimaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlViaPrimaria.SelectedValue.ToString());
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

        public int FK_FrecuenciaPrimaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFrecuenciaPrimaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFrecuenciaPrimaria.SelectedValue.ToString());
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

        public int NR_EdadPrimaria
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.txtEdadPrimaria.Text);
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int FK_DrogaSecundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlDrogaSecundaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlDrogaSecundaria.SelectedValue.ToString());
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

        public bool IN_ToxicologiaSecundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlToxicologiaSecundaria.SelectedValue.ToString()) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;//Default No aplica
                }
            }
        }

        public int FK_ViaSecundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlViaSecundaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlViaSecundaria.SelectedValue.ToString());
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

        public int FK_FrecuenciaSecundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFrecuenciaSecundaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFrecuenciaSecundaria.SelectedValue.ToString());
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

        public int NR_EdadSecundaria
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.txtEdadSecundaria.Text);
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public int FK_DrogaTerciaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlDrogaTerciaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlDrogaTerciaria.SelectedValue.ToString());
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

        public bool IN_ToxicologiaTerciaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlToxicologiaTerciaria.SelectedValue.ToString()) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;//Default No aplica
                }
            }
        }

        public int FK_ViaTerciaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlViaTerciaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlViaTerciaria.SelectedValue.ToString());
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

        public int FK_FrecuenciaTerciaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFrecuenciaTerciaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFrecuenciaTerciaria.SelectedValue.ToString());
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

        public int NR_EdadTerciaria
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.txtEdadTerciaria.Text);
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public string NB_DrogaCuarta
        {
            get
            {
                try
                {
                    if (this.txtDrogaCuarta.Text != "")
                    {
                        return this.txtDrogaCuarta.Text;
                    }
                    else
                    {
                        return "No Aplica";
                    }
                }
                catch 
                {

                    return "No Aplica";
                }
            }
        }

        public bool IN_ToxicologiaCuarta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlToxicologiaCuarta.SelectedValue.ToString()) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;//Default No aplica
                }
            }
        }

        public int FK_ViaCuarta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlViaCuarta.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlViaCuarta.SelectedValue.ToString());
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

        public int FK_FrecuenciaCuarta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFrecuenciaCuarta.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFrecuenciaCuarta.SelectedValue.ToString());
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

        public int NR_EdadCuarta
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.txtEdadCuarta.Text);
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public string NB_DrogaQuinta
        {
            get
            {
                try
                {
                    if (this.txtDrogaQuinta.Text != "")
                    {
                        return this.txtDrogaQuinta.Text;
                    }
                    else
                    {
                        return "No Aplica";
                    }
                }
                catch
                {

                    return "No Aplica";
                }
            }
        }

        public bool IN_ToxicologiaQuinta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlToxicologiaQuinta.SelectedValue.ToString()) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;//Default No aplica
                }
            }
        }

        public int FK_ViaQuinta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlViaQuinta.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlViaQuinta.SelectedValue.ToString());
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

        public int FK_FrecuenciaQuinta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlFrecuenciaQuinta.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlFrecuenciaQuinta.SelectedValue.ToString());
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

        public int NR_EdadQuinta
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.txtEdadQuinta.Text);
                }
                catch
                {
                    return 7;//Default No aplica
                }
            }
        }

        public bool IN_Sobredosis
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlSobredosis.SelectedValue.ToString()) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false; //Default No aplica
                }
            }
        }

        public int FK_DrogaSobredosisPrimaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlSobredosisPrimaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlSobredosisPrimaria.SelectedValue.ToString());
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

        public int FK_DrogaSobredosisSecundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlSobredosisSecundaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlSobredosisSecundaria.SelectedValue.ToString());
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

        public string DE_DrogaSobredosisTerciaria
        {
            get
            {
                try
                {
                    if (this.txtSobredosisTerciaria.Text != "")
                    {
                        return this.txtSobredosisTerciaria.Text;
                    }
                    else
                    {
                        return "No Aplica";
                    }
                }
                catch
                {

                    return "No Aplica";
                }
            }
        }

        public string DE_DrogaSobredosisCuarta
        {
            get
            {
                try
                {
                    if (this.txtSobredosisCuarta.Text != "")
                    {
                        return this.txtSobredosisCuarta.Text;
                    }
                    else
                    {
                        return "No Aplica";
                    }
                }
                catch
                {

                    return "No Aplica";
                }
            }
        }

        public int FK_ICDX_Primaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlICDXPrimaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlICDXPrimaria.SelectedValue.ToString());
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

        public int FK_DSMV_Primaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlDSMVPrimaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlDSMVPrimaria.SelectedValue.ToString());
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

        public int FK_CondicionFisicaPrimaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlCondicionPrimaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlCondicionPrimaria.SelectedValue.ToString());
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

        public int FK_ICDX_Secundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlICDXSecundaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlICDXSecundaria.SelectedValue.ToString());
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

        public int FK_DSMV_Secundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlDSMVSecundaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlDSMVSecundaria.SelectedValue.ToString());
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

        public int FK_CondicionFisicaSecundaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlCondicionSecundaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlCondicionSecundaria.SelectedValue.ToString());
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

        public int FK_ICDX_Terciaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlICDXTerciaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlICDXTerciaria.SelectedValue.ToString());
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

        public int FK_DSMV_Terciaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlDSMVTerciaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlDSMVTerciaria.SelectedValue.ToString());
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

        public int FK_CondicionFisicaTerciaria
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlCondicionTerciaria.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlCondicionTerciaria.SelectedValue.ToString());
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

        public int FK_ICDX_Cuarta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlICDXCuarta.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlICDXCuarta.SelectedValue.ToString());
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

        public int FK_DSMV_Cuarta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlDSMVCuarta.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlDSMVCuarta.SelectedValue.ToString());
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

        public int FK_CondicionFisicaCuarta
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlCondicionCuarta.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlCondicionCuarta.SelectedValue.ToString());
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

        public int FK_NivelSustancia
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlNivelSustancia.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlNivelSustancia.SelectedValue.ToString());
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

        public int FK_SeguroSalud
        {
            get
            {
                try
                {
                    if (Convert.ToInt32(this.ddlSeguroSalud.SelectedValue.ToString()) != 0)
                    {
                        return Convert.ToInt32(this.ddlSeguroSalud.SelectedValue.ToString());
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