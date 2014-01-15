$(document).ready(function () {
    $('#btnConvert').click(function () {
        var amount = $('#txtAmount').val();
        var from = $('#ddlfrom').val();
        var to = $('#ddlto').val();
        $.ajax({ type: "POST",
            url: "WebService.asmx/CurrencyConversion",
            data: "{amount:" + amount + ",fromCurrency:'" + from + "',toCurrency:'" + to + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#currency_converter_result').html(data.d);
            }
        });
    });

    $('#controls').hide();
    translate();

    $('#panelIcon').on('click', function () {
        var state = $('#sideBar').attr('data-visible');
        if (state === 'false') {
            $("#sideBar").show('slide', { direction: 'left' }, 200, { queue: false });
            $("#wrapper").animate({
                paddingLeft: '200px'
            }, { duration: 200, queue: false });
            $('#sideBar').attr('data-visible', 'true');
        } else {
            $("#sideBar").hide('slide', { direction: 'left' }, 200, { queue: false });
            $("#wrapper").animate({
                paddingLeft: '0'
            }, { duration: 200, queue: false });
            $('#sideBar').attr('data-visible', 'false');
        }
    });

    $('#controls a').on('click', function (e) {
        e.preventDefault();
        url = $(this).attr('href');
        $(url).show();
    });

    url = $(location).attr('href');
    if (url.indexOf('Racuni') >= 0) {
        percentageBarAcc();
        $('#controls').show();
        $('#controls a').attr('href', '#accountAdd');
    }
    else if (url.indexOf('Prihodki') >= 0) {
        $('#controls').show();
        $('#controls a').attr('href', '#incomeAdd');
        translate();
    }
    else if (url.indexOf('Odhodki') >= 0) {
        $('#controls').show();
        $('#controls a').attr('href', '#outcomeAdd');
        translate();
    }
    else if (url.indexOf('Kategorije') >= 0) {
        percentageBarCat();
        translate();
    }
    else if (url.indexOf('Budget') >= 0) {
        percentageBarBudg();
        translate();
    }
    else {
        dashCanvasData();
    }

    $('#container').on('focusout', '#racuni .listWithBudget li input', function () {
        percentageBarAcc();
    });
    $('#container').on('focusout', '#kategorije .listWithBudget li input', function () {
        percentageBarCat();
    });
    $('#container').on('focusout', '#budget .listWithBudget li input', function () {
        percentageBarBudg();
    });

    $('#accountAdd span').each(function () {
        if ($(this).attr('data-val-isvalid') == "False") {
            $('#accountAdd').show();
            return false;
        }
    });
    $('#incomeAdd span').each(function () {
        if ($(this).attr('data-val-isvalid') == "False") {
            $('#incomeAdd').show();
            console.log("ovdje sam");
            return false;
        }
    });
    $('#outcomeAdd span').each(function () {
        if ($(this).attr('data-val-isvalid') == "False") {
            $('#outcomeAdd').show();
            return false;
        }
    });
});