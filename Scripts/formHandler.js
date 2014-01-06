$(document).ready(function(){
    
    var characterReg = /^\s*[a-zA-Z0-9,\s]+\s*$/;
    var dateReg = /^(([1-9]|[0-2]\d|[3][0-1])\.([1-9]|[0]\d|[1][0-2])\.[2][0]\d{2})$|^(([1-9]|[0-2]\d|[3][0-1])\.([1-9]|[0]\d|[1][0-2])\.[2][0]\d{2}\s([1-9]|[0-1]\d|[2][0-3])\:[0-5]\d)$/;
    var numberReg = /^\d+(?:\.\d\d?)?$/;
    
    /*
     * odhodki
     */
    $('#container').on('submit', '#outcomeAdd form', function(e) {
	$('#outcomeAdd span').remove();
	
	var category = $('input[name=category]').val();
	var date = $('input[name=date]').val();
	var amount = $('input[name=amount]').val();
	var account = $('input[name=account]').val();
	var error = 0;
	
	if(!characterReg.test(category)) {
	    error++;
	    msg = $('<span class="err">Dovoljene samo črke in številke</span>');
	    $('input[name=category]').after(msg);
	}
	
	if(!dateReg.test(date)) {
	    error++;
	    msg = $('<span class="err">datumi v obliki dd.mm.yyyy</span>');
	    $('input[name=date]').after(msg);
	}
	
	if(!numberReg.test(amount)) {
	    error++;
	    msg = $('<span class="err">Dovoljene številke v obliki 1,23</span>');
	    $('input[name=amount]').after(msg);
	}
	
	if(error === 0) {
	    var formURL = $(this).attr("action");
	    $.ajax({
		url : formURL,
		type: "POST",
		data: {category: category, date: date, amount: amount, account: account},
		success:function(data) {
		    $('#outcomeAdd').remove();
		    $('#container').load('odhodki.html', function() {
		    $('#controls').show();
		    $('#controls a').attr('href', 'odhodkiDodaj.html');
		    translate ();
		    odhodki_Dashboard()
		    });
		},
		error: function (xhr, ajaxOptions, thrownError) {
		    alert(thrownError);
		}
	    });
	}
	e.preventDefault();
    });
    
    /*
     * prihodki
     */
    $('#container').on('submit', '#incomeAdd form', function(e) {
	$('#incomeAdd span').remove();
	
	var category = $('input[name=category]').val();
	var date = $('input[name=date]').val();
	var amount = $('input[name=amount]').val();
	var account = $('input[name=account]').val();
	var error = 0;
	
	if(!characterReg.test(category)) {
	    error++;
	    msg = $('<span class="err">Dovoljene samo črke in številke</span>');
	    $('input[name=category]').after(msg);
	}
	
	if(!dateReg.test(date)) {
	    error++;
	    msg = $('<span class="err">datumi v obliki dd.mm.yyyy</span>');
	    $('input[name=date]').after(msg);
	}
	
	if(!numberReg.test(amount)) {
	    error++;
	    msg = $('<span class="err">Dovoljene številke v obliki 1,23</span>');
	    $('input[name=amount]').after(msg);
	}
	
	if(error === 0) {
	    var formURL = $(this).attr("action");
	    $.ajax({
		url : formURL,
		type: "POST",
		data: {category: category, date: date, amount: amount, account: account},
		success:function(data) {
		    $('#incomeAdd').remove();
		    $('#container').load('prihodki.html', function() {
		    $('#controls').show();
		    $('#controls a').attr('href', 'prihodkiDodaj.html');
		    translate ();
		    prihodki_Dashboard();
		    });
		},
		error: function (xhr, ajaxOptions, thrownError) {
		    alert(thrownError);
		}
	    }); 
	}
	e.preventDefault();
    });
    
    /*
     * kategorije
     */
    $('#container').on('submit', '#categoryAdd form', function(e) {

	$('#categoryAdd span').remove();
	
	var category = $('input[name=name]').val();
	var amount = $('input[name=budget]').val();
	var error = 0;
	
	if(!characterReg.test(category)) {
	    error++;
	    msg = $('<span class="err">Dovoljene samo črke in številke</span>');
	    $('input[name=name]').after(msg);
	}
	
	if(!numberReg.test(amount)) {
	    error++;
	    msg = $('<span class="err">Dovoljene številke v obliki 1,23</span>');
	    $('input[name=budget]').after(msg);
	}
	
	if(error === 0) {
	    var formURL = $(this).attr("action");
	    $.ajax({
		url : formURL,
		type: "POST",
		data: {category: category, amount: amount},
		success:function(data) {
		    $('#categoryAdd').remove();
		    kategorije_Dashboard()
		    //translate ();
		},
		error: function (xhr, ajaxOptions, thrownError) {
		    alert(thrownError);
		}
	    }); 
	}
	e.preventDefault();
    });
    
    /*
     * racuni
     */
    $('#container').on('submit', '#accountAdd form', function(e) {
	$('#accountAdd span').remove();
	
	var name = $('input[name=name]').val();
	var amount = $('input[name=initialAmount]').val();
	var limit = $('input[name=limit]').val();
	var error = 0;
	
	if(!characterReg.test(name)) {
	    error++;
	    msg = $('<span class="err">Dovoljene samo črke in številke</span>');
	    $('input[name=name]').after(msg);
	}
	
	if(!numberReg.test(amount)) {
	    error++;
	    msg = $('<span class="err">Dovoljene številke v obliki 1,23</span>');
	    $('input[name=initialAmount]').after(msg);
	}
	
	if(!numberReg.test(limit)) {
	    error++;
	    msg = $('<span class="err">Dovoljene številke v obliki 1,23</span>');
	    $('input[name=limit]').after(msg);
	}
	
	if(error === 0) {
	    var formURL = $(this).attr("action");
	    $.ajax({
		url : formURL,
		type: "POST",
		data: {name: name, amount: amount, limit: limit},
		success:function(data) {
		    $('#accountAdd').hide();
		},
		error: function (xhr, ajaxOptions, thrownError) {
		    alert(thrownError);
		}
	    });
	}
        e.preventDefault();
    });
    
    /*
     * uporabnik
     */
    $('#container').on('submit', '#userData', function(e) {
	$('#userData span').remove();
	
	var characterReg = /^\s*[a-zA-Z,\s]+\s*$/;
	var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
	
	var name = $('input[name=name]').val();
	var email = $('input[name=email]').val();
	var email2 = $('input[name=emailRepeat]').val();
	var passwordN = $('input[name=passwordNew]').val();
	var passwordR = $('input[name=passwordRepeat]').val();
	var error = 0;
	
	if(!characterReg.test(name)) {
	    error++;
	    msg = $('<span class="err">Dovoljene samo črke</span>');
	    $('input[name=name]').after(msg);
	}
	
	if(!emailReg.test(email)) {
	    error++;
	    msg = $('<span class="err">Email v obliki naslov@primer.com</span>');
	    $('input[name=email]').after(msg);
	}
	if(email != email2){
	    error++;
	    msg = $('<span class="err">Emaila se ne ujemata</span>');
	    $('input[name=emailRepeat]').after(msg);
	}
	
	if(passwordN != passwordR){
	    error++;
	    msg = $('<span class="err">Gesli se ne ujemata</span>');
	    $('input[name=passwordRepeat]').after(msg);
	}
	
	if(error === 0)
	    $(this).closest('.dialog').remove();
        
        e.preventDefault();
    });
    
    /*
     * login
     */
    /*$('body').on('submit', '#login_form', function(e) {
        var username = $('input[name=username]').val();
	var password = $('input[name=password]').val();
        var remember = $('input[name=remember]').val();
        
	var formURL = $(this).attr("action");

        $.ajax({
            url : formURL,
            type: "POST",
            data: {username: username, password: password, remember: remember},
            success:function(data) {
                if(data == 1) { // napačno geslo
                    $('body').prepend('<h3>Napačno geslo</h3>');
                }
                else if(data == 2) { // ni vnešeno
                    $('body').prepend('<h3>Vnesite uporabniško ime in geslo</h3>');
                }
                else if(data == 0) { // ok
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError);
            }
        });
        e.preventDefault();
    });*/
});