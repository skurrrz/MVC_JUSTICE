
//HOMEINDEX - when page is ready, it will fade out the login info box
$(document).ready(function () {
    $('.login-info-box').fadeOut();
    $('.login-show').addClass('show-log-panel');
});


//HOMEINDEX page --> Dynamically switches between Login and Register options
$('.login-reg-panel input[type="radio"]').on('change', function () {
    if ($('#log-login-show').is(':checked')) {
        $('.register-info-box').fadeOut();
        $('.login-info-box').fadeIn();

        $('.white-panel').addClass('right-log');
        $('.register-show').addClass('show-log-panel');
        $('.login-show').removeClass('show-log-panel');

    }
    else if ($('#log-reg-show').is(':checked')) {
        $('.register-info-box').fadeIn();
        $('.login-info-box').fadeOut();

        $('.white-panel').removeClass('right-log');

        $('.login-show').addClass('show-log-panel');
        $('.register-show').removeClass('show-log-panel');
    }
});


//Limits the allowed number of checkboxes to be checked to three (_ProductsPartial)
var limit = 3
$('input[type=checkbox]').on('change', function (e) {
    if ($('input[type=checkbox]:checked').length > limit) {
        $(this).prop('checked', false);
        alert("Only 3 items can be compared at once");
    }
});


//collapses menu options in sidebar (_FilterPartial)
$('#body-row .collapse').collapse('hide');


//categories and subcategories - NOT USED
$(function () {
    $('#cat" ').click(function () {
        var val = this.value;

        $.get('@Url.Content("Filter")', { 'val': val }, function (data) {
            $('#search-results').html(data);
        });
    });
});


//gets product_Id of checkboxes (_FilterPartial)
$(function () {
    $('#compareBtn').click(function () {
        var counter = 1;
        $(':checkbox:checked').each(function (i) {
            $('#choice' + counter).val($(this).val());
            counter++;
        });
    });
});