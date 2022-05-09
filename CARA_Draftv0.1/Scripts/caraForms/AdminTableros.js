
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

    $('#ContentPlaceHolder1_lbxReferido').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
$('#ContentPlaceHolder1_lbxReferido').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_lbxReferido').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_lbxMunicipios').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_lbxMunicipios').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_lbxMunicipios').multiselect('updateButtonText');


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

    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxFuenteReferido').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxFuenteReferido').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxFuenteReferido').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGrupoEdades').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGrupoEdades').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGrupoEdades').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxSobredosis').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxSobredosis').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxSobredosis').multiselect('updateButtonText');

    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxMunicipios').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        buttonClass: 'form-control',
        buttonWidth: '190px'
    });
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxMunicipios').multiselect('selectAll', false);
    $('#ContentPlaceHolder1_wucanaliticaPlanificacion_lbxMunicipios').multiselect('updateButtonText');

});


/*Dashboard de Planificacion*/
//var plnDesde, plnHasta, plnAjax_data, plnTotalVia, plnTotalToxicologia, plnTotalCentros, plnTotalAdmisiones, plnDrogasUso;
//var plnGeneros = [], plnNiveles = [], plnCentros = [];

//google.charts.load('current', { 'packages': ['line', 'bar', 'corechart', 'controls', 'table'] });

//$(document).ready(function () {
//    plnDesde = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_txtFechaDesde").value;
//    plnHasta = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_txtFechaHasta").value;

//    plnlistGenero();

//    plnlistNivelCuidado();

//    plnlistCentro();

//    plnAjax_data = '{Desde:"' + plnDesde + '", Hasta:"' + plnHasta + '", gen:' + JSON.stringify(plnGeneros) + ', Niveles:' + JSON.stringify(plnNiveles) + ', Centros:' + JSON.stringify(plnCentros) + '}'

//    wsplnTotales();

//    wsplnDrogasUso();
//});

//function changeFilter() {
//    plnDesde = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_txtFechaDesde").value;
//    plnHasta = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_txtFechaHasta").value;
   
//    plnlistGenero();

//    plnlistNivelCuidado();

//    plnlistCentro();

//    plnAjax_data = '{Desde:"' + plnDesde + '", Hasta:"' + plnHasta + '", gen:' + JSON.stringify(plnGeneros) + ', Niveles:' + JSON.stringify(plnNiveles) + ', Centros:' + JSON.stringify(plnCentros) + '}'

//    wsplnTotales();

//    wsplnDrogasUso();
//}

//function wsplnTotales() {

//    $.ajax({
//        url: "WebMethods/wsPlanificacionTablero.asmx/dashTotales",
//        data: plnAjax_data,
//        dataType: "json",
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            var mydata = data.d;
//            plnTotalToxicologia = mydata.totalToxicologia;
//            plnTotalCentros = mydata.totalCentros;
//            plnTotalAdmisiones = mydata.totalAdmisiones;

//        },
//        error: function () {
//            alert("Error");
//        }
//    }).done(function () {
//        $('#ContentPlaceHolder1_wucanaliticaPlanificacion_totalToxicologia').html(plnTotalToxicologia);
//        $('#ContentPlaceHolder1_wucanaliticaPlanificacion_totalCentros').html(plnTotalCentros);
//        $('#ContentPlaceHolder1_wucanaliticaPlanificacion_totalAdmisiones').html(plnTotalAdmisiones);
//    });

    
//}

//function wsplnDrogasUso() {
//    $.ajax({
//        url: "WebMethods/wsPlanificacionTablero.asmx/dashDrogasUso",
//        data: plnAjax_data,
//        dataType: "json",
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            plnDrogasUso = data.d;
//        },
//        error: function () {
//            alert("Error");
//        }
//    }).done(function () {
//        google.charts.setOnLoadCallback(plnChartDrogasUso);
//    });
//}

//function plnChartDrogasUso() {
    
//    var data = new google.visualization.arrayToDataTable(plnDrogasUso);
//    var options = {
//        title: 'Drogas de Uso',
//        bars: 'horizontal',
//        legend: { position: "none" },
//        chartArea: { left: 0, top: 0, width: '100%', height: '100%' },
//        axes: {
//            x: {
//                0: { side: 'top', label: 'Cantidad' } // Top x-axis.
//            }
//        },
//        bar: { groupWidth: "90%" },
//        sort: 'enable'

//    };
//    var drogas_chart = new google.charts.Bar(document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_drogas_chart"));
//    drogas_chart.draw(data, options);
//}

//function plnlistGenero() {
//    plnGeneros = [];
//    var plnlistGenero = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_lbxGenero");

//    var a = 0;
//    for (var i = 0; i < plnlistGenero.options.length; i++) {
//        if (plnlistGenero.options[i].selected == true) {
//            plnGeneros[a] = { pk_genero: plnlistGenero.options[i].value };
//            a++;
//        }
//    }
//}

//function plnlistNivelCuidado() {
//    plnNiveles = [];
//    var plnlistNiveles = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_lbxNivelSustancia");

//    var a = 0;
//    for (var i = 0; i < plnlistNiveles.options.length; i++) {
//        if (plnlistNiveles.options[i].selected == true) {
//            plnNiveles[a] = { pk_nivel: plnlistNiveles.options[i].value };
//            a++;
//        }
//    }
//}

//function plnlistCentro() {
//    plnCentros = [];
//    var plnlistCentros = document.getElementById("ContentPlaceHolder1_wucanaliticaPlanificacion_lbxCentro");

//    var a = 0;
//    for (var i = 0; i < plnlistCentros.options.length; i++) {
//        if (plnlistCentros.options[i].selected == true) {
//            plnCentros[a] = { pk_centro: plnlistCentros.options[i].value };
//            a++;
//        }
//    }
//}