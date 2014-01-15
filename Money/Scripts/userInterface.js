$(document).ready(function(){
    $('#container').on('focus', 'input[name=date]', function(){
	$(this).datepicker({
	    showOtherMonths: true,
	    selectOtherMonths: true
	});
	$(this).datepicker($.datepicker.regional['sl']);
    });
    
    var availableTags = [
      "Hrana",
      "Prodaja",
      "Programiranje",
      "Stanovanje",
    ];
    $('#container').on('focus', 'input[name=category]', function(){
	$(this).autocomplete({
	    source: availableTags
	});
    });
});

function percentageBarAcc() {
    $('.listWithBudget li').each(function() {
	perc = 0;
	budget = parseFloat($(this).children('input').val());
	used = parseFloat($(this).find('.innerBar').text());
	if(used < 0) {
	    used = Math.abs(used);
	    perc = Math.round((used*100)/budget)-1;
	    if(perc > 100)
		perc = 80;
	    $(this).find('.innerBar').css('background', '#e67e22');
	    $(this).find('[name=budget]').css('color', '#e67e22');
	}
	else {
	    perc = Math.round((used*100)/budget)-1;
	    if(perc > 100)
		perc = 80;
	    if(perc < 10.0) {
		$(this).find('.innerBar').css('background', '#f1c40f');
	    }
	    if(perc < 5.0) {
		$(this).find('.innerBar').css('background', '#e67e22');
	    }
	    if(perc > 10.0) {
		$(this).find('.innerBar').css('background', '#2ecc71');
	    }
	}
	perc = perc+'%';
	$(this).find('.innerBar').width(perc);
    });
}

function percentageBarCat() {
    $('.listWithBudget li').each(function() {
	budget = parseFloat($(this).children('input').val());
	used = parseFloat($(this).find('.innerBar').text());
	perc = Math.round((used*100)/budget)-1;
	if(perc < 80.0) {
	    $(this).find('.innerBar').css('background', '#2ecc71');
	}
	if(perc > 80.0) {
	    $(this).find('.innerBar').css('background', '#f1c40f');
	}
	if(perc > 95.0) {
	    $(this).find('.innerBar').css('background', '#e67e22');
	}
	if(perc > 100.0) {
	    $(this).find('.innerBar').css('background', '#e67e22');
	    perc = perc % 100;
	}
	perc = perc+'%';
	$(this).find('.innerBar').width(perc);
    });
}

function percentageBarBudg() {
    $('.listWithBudget li').each(function() {
	budget = parseFloat($(this).children('input').val());
	used = parseFloat($(this).find('.innerBar').text());
	perc = Math.round((used*100)/budget)-1;
	if(perc < 80.0) {
	    $(this).find('.innerBar').css('background', '#2ecc71');
	}
	if(perc > 80.0) {
	    $(this).find('.innerBar').css('background', '#f1c40f');
	}
	if(perc > 95.0) {
	    $(this).find('.innerBar').css('background', '#e67e22');
	}
	if(perc > 100.0) {
	    $(this).find('.innerBar').css('background', '#e67e22');
	    perc = perc % 100;
	}
	perc = perc+'%';
	$(this).find('.innerBar').width(perc);
    });
}