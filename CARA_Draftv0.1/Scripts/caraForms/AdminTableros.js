$(function () {

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

});
