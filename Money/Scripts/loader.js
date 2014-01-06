var lang;
$(document).ready(function(){
    lang = 'sl';
    translate();
    
    $('#sl_lang').on('click', function(e) {
	lan = 'sl';
	e.preventDefault();
    });
    $('#gb_lang').on('click', function(e) {
	lan = 'en';
	e.preventDefault();
    });
});

function dashCanvasData() {
    var budget = parseFloat($('#MainContent_budgetT').text().replace(',', '.'));
    var used = parseFloat($('#MainContent_budgetU').text().replace(',', '.'));
    dashCanvas(budget, used);
}

function format(x) {
  return x.replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
