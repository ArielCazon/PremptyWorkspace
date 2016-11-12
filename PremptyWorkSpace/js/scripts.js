$( document ).ready(function() {
  //funcion que muestra calendario
$(function() {
        $( "#FechaFin" ).datepicker({
			showAnim : 'slideDown',
			changeMonth: true, //muestra una lista de los meses
			changeYear: true, //muestra una lista de los años
			monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
			monthNamesShort: ['Ene','Feb','Mar','Abr', 'May','Jun','Jul','Ago','Sep', 'Oct','Nov','Dic'],
			dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
			dayNamesShort: ['Dom','Lun','Mar','Mié','Juv','Vie','S&aacute;b'],
			dayNamesMin: ['Do','Lu','Ma','Mi','Ju','Vi','S&aacute;'],
			weekHeader: 'Sm',
			dateFormat: 'dd/mm/yy',
			minDate: 0,
									  });
    });
});