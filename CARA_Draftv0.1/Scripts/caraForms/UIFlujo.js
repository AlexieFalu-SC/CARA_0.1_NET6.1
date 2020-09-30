function ddlCondLaboral() {
    try {
        var ddlCondicionLaboral = document.getElementById("ContentPlaceHolder1_wucperfiladmision_ddlCondicionLaboral");
        var ddlNoFuerzaLaboral = document.getElementById("ContentPlaceHolder1_wucperfiladmision_ddlNoFuerzaLaboral");

        if (ddlCondicionLaboral.value === "4") {
            ddlNoFuerzaLaboral.disabled = false;
            ddlNoFuerzaLaboral.value = "0";
        }
        else {
            ddlNoFuerzaLaboral.value = "7";
            ddlNoFuerzaLaboral.disabled = true;
        }

    } catch (ex) {
        alert(ex.message);

    }
}

function ddlFuerzaLaboral() {
    try {
        var ddlCondicionLaboral = document.getElementById("ContentPlaceHolder1_wucperfiladmision_ddlCondicionLaboral");
        var ddlNoFuerzaLaboral = document.getElementById("ContentPlaceHolder1_wucperfiladmision_ddlNoFuerzaLaboral");

        if (ddlNoFuerzaLaboral.value === "7") {
            ddlNoFuerzaLaboral.value = "0";
            alert("Debe seleccionar alguna opción valida, por su selección en Condición Laboral");
        }

    } catch (ex) {
        alert(ex.message);

    }
}

function ddlDrogaSecF() {
    try {
        var ddlDrogaPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlDrogaPrimaria");
        var ddlDrogaSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlDrogaSecundaria");
        var ddlDrogaTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlDrogaTerciaria");

        var ddlToxPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaPrimaria");
        var ddlToxSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaSecundaria");
        var ddlToxTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaTerciaria");

        var ddlViaPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaPrimaria");
        var ddlViaSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaSecundaria");
        var ddlViaTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaTerciaria");

        var ddlFrecPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaPrimaria");
        var ddlFrecSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaSecundaria");
        var ddlFrecTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaTerciaria");

        var txtEdadPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadPrimaria");
        var txtEdadSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadSecundaria");
        var txtEdadTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadTerciaria");

        if (ddlDrogaSec.options[ddlDrogaSec.selectedIndex].text === "No Aplica") {
            ddlToxSec.value = "2";
            ddlViaSec.value = "6";
            ddlFrecSec.value = "6";
            txtEdadSec.value = "0";

            ddlToxSec.disabled = true;
            ddlViaSec.disabled = true;
            ddlFrecSec.disabled = true;
            txtEdadSec.disabled = true;

            ddlDrogaTer.value = "67";
            ddlToxTer.value = "2";
            ddlViaTer.value = "6";
            ddlFrecTer.value = "6";
            txtEdadTer.value = "0";

            ddlDrogaTer.disabled = true;
            ddlToxTer.disabled = true;
            ddlViaTer.disabled = true;
            ddlFrecTer.disabled = true;
            txtEdadTer.disabled = true;

        }
        else {

            if (ddlDrogaPrim.value === "0" || ddlToxPrim.value === "0" || ddlViaPrim.value === "0" || ddlFrecPrim.value === "0" || txtEdadPrim.value === "") {

                ddlDrogaSec.value = "67"
                ddlToxSec.value = "2";
                ddlViaSec.value = "6";
                ddlFrecSec.value = "6";
                txtEdadSec.value = "0";

                ddlToxSec.disabled = true;
                ddlViaSec.disabled = true;
                ddlFrecSec.disabled = true;
                txtEdadSec.disabled = true;

                ddlToxTer.value = "2";
                ddlViaTer.value = "6";
                ddlFrecTer.value = "6";
                txtEdadTer.value = "0";

                ddlDrogaTer.disabled = true;
                ddlToxTer.disabled = true;
                ddlViaTer.disabled = true;
                ddlFrecTer.disabled = true;
                txtEdadTer.disabled = true;
                alert("Debe completar toda información de la primera sustancia");
            }
            else {
                ddlToxSec.disabled = false;
                ddlViaSec.disabled = false;
                ddlFrecSec.disabled = false;
                txtEdadSec.disabled = false;

                ddlDrogaTer.disabled = false;

                if (ddlViaSec.value === "6") {
                    ddlViaSec.value = "0";
                    ddlToxSec.value = "0";
                }

                if (ddlFrecSec.value === "6") {
                    ddlFrecSec.value = "0";
                }

                if (txtEdadSec.value === "0") {
                    txtEdadSec.value = "";
                }
            }

        }
            
    } catch (ex) {
        alert(ex.message);
    }
}

function ddlDrogaTerF() {
    try {
        var ddlDrogaPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlDrogaPrimaria");
        var ddlDrogaSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlDrogaSecundaria");
        var ddlDrogaTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlDrogaTerciaria");

        var ddlToxPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaPrimaria");
        var ddlToxSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaSecundaria");
        var ddlToxTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaTerciaria");

        var ddlViaPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaPrimaria");
        var ddlViaSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaSecundaria");
        var ddlViaTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaTerciaria");

        var ddlFrecPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaPrimaria");
        var ddlFrecSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaSecundaria");
        var ddlFrecTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaTerciaria");

        var txtEdadPrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadPrimaria");
        var txtEdadSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadSecundaria");
        var txtEdadTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadTerciaria");

        if (ddlDrogaTer.options[ddlDrogaTer.selectedIndex].text === "No Aplica") {
            
            ddlToxTer.value = "2";
            ddlViaTer.value = "6";
            ddlFrecTer.value = "6";
            txtEdadTer.value = "0";

            ddlToxTer.disabled = true;
            ddlViaTer.disabled = true;
            ddlFrecTer.disabled = true;
            txtEdadTer.disabled = true;

        }
        else {

            if (ddlDrogaSec.value === "0" || ddlToxSec.value === "0" || ddlViaSec.value === "0" || ddlFrecSec.value === "0" || txtEdadSec.value === "") {

                ddlDrogaTer.value = "67"
                ddlToxTer.value = "2";
                ddlViaTer.value = "6";
                ddlFrecTer.value = "6";
                txtEdadTer.value = "0";

                ddlToxTer.disabled = true;
                ddlViaTer.disabled = true;
                ddlFrecTer.disabled = true;
                txtEdadTer.disabled = true;
                alert("Debe completar toda información de la segunda sustancia");
            }
            else {
                ddlToxTer.disabled = false;
                ddlViaTer.disabled = false;
                ddlFrecTer.disabled = false;
                txtEdadTer.disabled = false;

                if (ddlViaTer.value === "6") {
                    ddlViaTer.value = "0";
                    ddlToxTer.value = "0";
                }

                if (ddlFrecTer.value === "6") {
                    ddlFrecTer.value = "0";
                }

                if (txtEdadTer.value === "0") {
                    txtEdadTer.value = "";
                }
            }

        }

    } catch (ex) {
        alert(ex.message);
    }
}

function txtDrogaCuaF() {
    var txtDrogaCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtDrogaCuarta");
    var txtDrogaQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtDrogaQuinta");

    var ddlToxCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaCuarta");
    var ddlToxQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaQuinta");

    var ddlViaCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaCuarta");
    var ddlViaQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaQuinta");

    var ddlFrecCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaCuarta");
    var ddlFrecQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaQuinta");

    var txtEdadCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadCuarta");
    var txtEdadQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadQuinta");

    if (txtDrogaCua.value === "") {

        ddlToxCua.value = "2";
        ddlViaCua.value = "6";
        ddlFrecCua.value = "6";
        txtEdadCua.value = "0";

        ddlToxCua.disabled = true;
        ddlViaCua.disabled = true;
        ddlFrecCua.disabled = true;
        txtEdadCua.disabled = true;

        txtDrogaQui.value = "";
        ddlToxQui.value = "2";
        ddlViaQui.value = "6";
        ddlFrecQui.value = "6";
        txtEdadQui.value = "0";

        txtDrogaQui.disabled = true;
        ddlToxQui.disabled = true;
        ddlViaQui.disabled = true;
        ddlFrecQui.disabled = true;
        txtEdadQui.disabled = true;
    }
    else {
        ddlToxCua.disabled = false;
        ddlViaCua.disabled = false;
        ddlFrecCua.disabled = false;
        txtEdadCua.disabled = false;

        txtDrogaQui.disabled = false;

        if (ddlViaCua.value === "6") {
            ddlViaCua.value = "0";
            ddlToxCua.value = "0";
        }

        if (ddlFrecCua.value === "6") {
            ddlFrecCua.value = "0";
        }

        if (txtEdadCua.value === "0") {
            txtEdadCua.value = "";
        }
    }
}

function txtDrogaQuiF() {
    var txtDrogaCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtDrogaCuarta");
    var txtDrogaQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtDrogaQuinta");

    var ddlToxCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaCuarta");
    var ddlToxQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlToxicologiaQuinta");

    var ddlViaCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaCuarta");
    var ddlViaQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlViaQuinta");

    var ddlFrecCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaCuarta");
    var ddlFrecQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlFrecuenciaQuinta");

    var txtEdadCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadCuarta");
    var txtEdadQui = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtEdadQuinta");

    if (txtDrogaQui.value === "") {

        ddlToxQui.value = "2";
        ddlViaQui.value = "6";
        ddlFrecQui.value = "6";
        txtEdadQui.value = "0";

        ddlToxQui.disabled = true;
        ddlViaQui.disabled = true;
        ddlFrecQui.disabled = true;
        txtEdadQui.disabled = true;
    }
    else {

        if (txtDrogaCua.value === "" || ddlToxCua.value === "0" || ddlViaCua.value === "0" || ddlFrecCua.value === "0" || txtEdadCua.value === "") {

            txtDrogaQui.value = ""
            ddlToxQui.value = "2";
            ddlViaQui.value = "6";
            ddlFrecQui.value = "6";
            txtEdadQui.value = "0";

            ddlToxQui.disabled = true;
            ddlViaQui.disabled = true;
            ddlFrecQui.disabled = true;
            txtEdadQui.disabled = true;
            alert("Debe completar toda información de la cuarta sustancia");
        }
        else {
            ddlToxQui.disabled = false;
            ddlViaQui.disabled = false;
            ddlFrecQui.disabled = false;
            txtEdadQui.disabled = false;

            if (ddlViaQui.value === "6") {
                ddlViaQui.value = "0";
                ddlToxQui.value = "0";
            }

            if (ddlFrecQui.value === "6") {
                ddlFrecQui.value = "0";
            }

            if (txtEdadQui.value === "0") {
                txtEdadQui.value = "";
            }
        }
        
    }
}

function ddlSobredosisF() {
    var ddlSobredosis = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlSobredosis");
    var ddlSobrePrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlSobredosisPrimaria");
    var ddlSobreSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlSobredosisSecundaria");
    var txtSobreTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtSobredosisTerciaria");
    var txtSobreCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtSobredosisCuarta");

    if (ddlSobredosis.value === "1") {
        ddlSobrePrim.disabled = false;
        txtSobreTer.disabled = false;

        ddlSobrePrim.value = "0";
        txtSobreTer.value = "";
    }
    else {
        ddlSobrePrim.value = "67";
        ddlSobreSec.value = "67";
        txtSobreTer.value = "";
        txtSobreCua.value = "";

        ddlSobrePrim.disabled = true;
        ddlSobreSec.disabled = true;
        txtSobreTer.disabled = true;
        txtSobreCua.disabled = true;
    }
}

function ddlSobrePrimF() {
    var ddlSobrePrim = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlSobredosisPrimaria");
    var ddlSobreSec = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_ddlSobredosisSecundaria");


    if (ddlSobrePrim.value !== "0") {
        if (ddlSobrePrim.value === "67") {
            ddlSobreSec.value = "67";
            ddlSobreSec.disabled = true;
        }
        else {
            ddlSobreSec.disabled = false;
            if (ddlSobreSec.value === "67") {
                ddlSobreSec.value = "0";
            }
        }
        
    }
    else {
        ddlSobreSec.value = "67";
        ddlSobreSec.disabled = true;
    }
}

function txtSobreCuaF() {
    var txtSobreTer = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtSobredosisTerciaria");
    var txtSobreCua = document.getElementById("ContentPlaceHolder1_wucdrogasadmision_txtSobredosisCuarta");

    if (txtSobreTer.value !== "") {
        txtSobreCua.disabled = false;
    }
    else {
        txtSobreCua.value = "";
        txtSobreCua.disabled = true;
    }
}

var saving = false;
function validate() {
    var isValid = Page_ClientValidate();

    if (!saving) {
        if (isValid) {
            saving = true;
        }
        else {
            scrollToTheError();
        }
        return isValid;
    }
    else { return false; }
}

function scrollToTheError() { $('html,body').animate({ scrollTop: $('.rightFloatAsterisk,.leftFloatAsterisk,.asterisk').filter(':visible').first().offset().top - 5}, 500); }