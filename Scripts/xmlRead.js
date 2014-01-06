var language;
$(document).ready(function(){
    language = 'slovenian';
    translate();
    
    $('#sl_lang').on('click', function(e) {
	language = 'slovenian';
	e.preventDefault();
	translate();
    });
    $('#gb_lang').on('click', function(e) {
	language = 'english';
	e.preventDefault();
	translate();
    });
});
function translate() {
    $.ajax({
	url: 'lang.xml',
	success: function(xml) {
	    $(xml).find('translation').each(function(){
		var id = $(this).attr('id');
		var text = $(this).find(language).text();
		$("." + id).html(text);
	    });
	}
    });
}

function readIncome() {
    $.ajax({
	url: 'data.xml',
	success: function(xml) {
	    $(xml).find('transaction').each(function(){
		if($(this).attr('type') == 'income'){
		    date = $(this).find('date').text();
		    category = $(this).find('tcategory').text();
		    amount = $(this).find('amount').text();
		    account = $(this).find('taccount').text();
		    line = $('<tr><td>'+date+'</td><td><a href="kategorija.html">'+category+'</a></td><td>'+amount+' €</td><td><a href="racun.html">'+account+'</a></td></tr>');
		    $('#prihodki table tbody').append(line);
		}
	    });
	}
    });
}

function readOutcome() {
    $.ajax({
	url: 'data.xml',
	success: function(xml) {
	    $(xml).find('transaction').each(function(){
		if($(this).attr('type') == 'outcome'){
		    date = $(this).find('date').text();
		    category = $(this).find('tcategory').text();
		    amount = $(this).find('amount').text();
		    account = $(this).find('taccount').text();
		    line = $('<tr><td>'+date+'</td><td><a href="kategorija.html">'+category+'</a></td><td>'+amount+' €</td><td><a href="racun.html">'+account+'</a></td></tr>');
		    $('#odhodki table tbody').append(line);
		}
	    });
	}
    });
}

function readAccounts() {
    $.ajax({
	url: 'data.xml',
	success: function(xml) {
	    $(xml).find('account').each(function(){
		name = $(this).find('name').text();
		balance = $(this).find('balance').text();
		limit = $(this).find('limit').text();
		line = $('<li><h4><a href="racun.html">'+name+'</a></h4><div class="outerBar"><div class="innerBar">'+balance+' €</div></div><input type="text" name="budget" value="'+limit+'"/><span>€</span></li>');
		$('#racuni .listWithBudget').append(line);
	    });
	    percentageBarAcc();
	}
    });
}

function readCategories() {
    $.ajax({
	url: 'data.xml',
	success: function(xml) {
	    $(xml).find('category').each(function(){
		name = $(this).find('name').text();
		budget = $(this).find('budget').text();
		used = $(this).find('used').text();
		line = $('<li><h4><a href="kategorija.html">'+name+'</a></h4><div class="outerBar"><div class="innerBar">'+used+' €</div></div><input type="text" name="budget" value="'+budget+'"/><span>€</span></li>');
		$('#kategorije .listWithBudget').append(line);
	    });
	    percentageBarCat();
	}
    });
}
