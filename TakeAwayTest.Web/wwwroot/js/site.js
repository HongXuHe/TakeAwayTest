
$(document).ready(function () {
    $("#submit").prop("disabled", true);
    var numberRegex = /^[+-]?\d+(\.\d+)?([eE][+-]?\d+)?$/;

    // valid Name input
    $("#Name").on("change keyup",function () {
        if ($(this).val().length === 0) {
            $(this).removeClass('is-valid');
            $(this).addClass('is-invalid');
            $("#submit").prop("disabled", true);
        } else {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
            if (numberRegex.test($('#Number').val())) {
                $("#submit").prop("disabled", false);
            }
        }
    })

    //valid for Number input
    $("#Number").on("change keyup",function () {
        
        var str = $(this).val();
        if (numberRegex.test(str)) {
            $(this).removeClass('is-invalid');
            $(this).addClass('is-valid');
            if ($("#Name").val().length !== 0) {
                $("#submit").prop("disabled", false);
            }
        } else {
            $(this).removeClass('is-valid');
            $(this).addClass('is-invalid');
            $("#submit").prop("disabled", true);
        }  
    })
});