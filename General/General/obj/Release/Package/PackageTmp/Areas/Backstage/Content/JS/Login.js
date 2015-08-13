var InitAppValidate = function () {
    var LoginSubmit = function () {
        $('#LoginForm input').keypress(function (e) {
            if (e.which == 13) {
                if ($('#LoginForm').validate().form()) {
                    //alert(0);
                    $('#LoginForm').submit();
                    //alert(1);
                }
                return false;
            }
        });
    }
    return { init: function () { LoginSubmit(); }, logout: function () { alert("out") } };
} ();