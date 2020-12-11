$(function () {
/*Dashboard de CARA*/
    $('#ContentPlaceHolder1_lbxNivelSustancia').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_lbxNivelSustancia').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_lbxNivelSustancia').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_lbxCentro').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_lbxCentro').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_lbxCentro').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_lbxGenero').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '170px'
    });
    $('#ContentPlaceHolder1_lbxGenero').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_lbxGenero').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_lbxCentroPerfiles').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_lbxCentroPerfiles').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_lbxCentroPerfiles').multiselect('updateButtonText');


/*Dashboard de Planificacion*/
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxNivelSustancia').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxNivelSustancia').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxNivelSustancia').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxCentro').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxCentro').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxCentro').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGenero').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '170px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGenero').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGenero').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxCentroPerfiles').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxCentroPerfiles').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxCentroPerfiles').multiselect('updateButtonText');

});


/*Dashboard de Planificacion*/
var dtDesde, dtHasta, ajax_data, dtTotalVia, dtTotalToxicologia, dtTotalCentros, dtTotalAdmisiones;
var generos = [], niveles = [], centros = [];

$(document).ready(function () {
    dtDesde = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_txtFechaDesde").value;
    dtHasta = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_txtFechaHasta").value;

    listGenero();

    ajax_data = '{Desde:"' + dtDesde + '", Hasta:"' + dtHasta + '", gen:' + JSON.stringify(generos) + '}'

});

function wsTotales() {

    $.ajax({
        url: "WebMethods/wsRegistradoTablero.asmx/dashCaraTotalPerfiles",
        data: ajax_data,
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var mydata = data.d;
            dtTotalPerfiles = mydata.totalPerfiles;
            dtTotalReferidosCara = mydata.totalReferidosCara;
            dtTotalMasculino = mydata.totalMasculino;
            dtTotalFemenino = mydata.totalFemenino;
            dtPerMasculino = mydata.perMasculino;
            dtPerFemenino = mydata.perFemenino;
            dtTotalFM = mydata.totalFM;
            dtTotalFM = mydata.totalFM;
            dtPerMF = mydata.perMF;
            dtPerMF = mydata.perMF;
            dtEdadPromedio = mydata.edadPromedio;
        },
        error: function () {
            alert("Error");
        }
    }).done(function () {
        $("#totalPerfiles").html(dtTotalPerfiles);
        $("#totalReferidosCara").html(dtTotalReferidosCara);
        $("#totalMasculino").html(dtTotalMasculino);
        $("#totalFemenino").html(dtTotalFemenino);
        $("#totalFM").html(dtTotalFM);
        $("#totalMF").html(dtTotalMF);
        $("#edadPromedioCara").html(dtEdadPromedio);

        document.getElementById('perMasculino').setAttribute("style", "width:" + dtPerMasculino + "%");
        document.getElementById('perFemenino').setAttribute("style", "width:" + dtPerFemenino + "%");
        document.getElementById('perFM').setAttribute("style", "width:" + dtPerFM + "%");
        document.getElementById('perMF').setAttribute("style", "width:" + dtPerMF + "%");
    });
}

function listGenero() {
    generos = [];
    var listGenero = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGenero");

    var a = 0;
    for (var i = 0; i < listGenero.options.length; i++) {
        if (listGenero.options[i].selected == true) {
            generos[a] = { pk_genero: listGenero.options[i].value };
            a++;
        }
    }
}