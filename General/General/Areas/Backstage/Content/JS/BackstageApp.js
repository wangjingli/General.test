var BackstageApp = function () {
    //var CheckAll = function () {
    //    $("#CheckAll").click(function () {
    //        var tableCheck = $("#TableBody input[type='checkbox']");
    //        for (var i = 0; i < tableCheck.length; i++) {
    //            var e = tableCheck[i];
    //            if (e.type == 'checkbox' && e != this) {
    //                e.checked = this.checked;
    //            }
    //        }
    //    });
    //}
    return {
        //角色配置权限 适配JS
         InitSystemRoleAllotPower :function () {
            $("#CheckAll").click(function () {
                var tableCheck = $("#TableBody input[type='checkbox']");
                for (var i = 0; i < tableCheck.length; i++) {
                    var e = tableCheck[i];
                    if (e.type == 'checkbox' && e != this) {
                        e.checked = this.checked;
                    }
                }
            });

            $("#TableBody input[type='checkbox']").click(function () {
                //alert($(this).attr("data-parent"));
                var parent = $(this).attr("data-parent");
                if (parent != "") {
                    //var id = "#Check-id-" + parent;
                    if ($("#Check-id-" + parent)[0].checked != this.checked
                        && IsParent(parent, this)) {
                        $("#Check-id-" + parent)[0].checked = this.checked;
                    }
                    //else if ("") {
                    //    $("#Check-id-" + parent)[0].checked = this.checked;
                    //}

                } else {
                    var tableCheck = $("#TableBody input[type='checkbox']");
                    for (var i = 0; i < tableCheck.length; i++) {
                        var e = tableCheck[i];
                        var tableParent = $(e).attr("data-parent");
                        if (e.type == 'checkbox' && e != this &&
                            tableParent != "" && "Check-id-" + tableParent == this.id) {
                            e.checked = this.checked;
                        }
                    }
                    //$("Check-id-" + parent).checked = this.checked;
                }

            });

            function IsParent(Parent, o) {
                var isCheck = false;
                var tableCheck = $("#TableBody input[type='checkbox']");
                for (var i = 0; i < tableCheck.length; i++) {
                    var e = tableCheck[i];
                    var tableParent = $(e).attr("data-parent");
                    if (e.type == 'checkbox' && e.checked != o.checked) {
                        if (e.type == 'checkbox' && e != o && tableParent != "" && tableParent == Parent) {
                            if (e.checked != $("#Check-id-" + tableParent).checked && !e.checked) {
                                isCheck = true;
                            }
                            //alert("id = "+e.id +"  checked="+e.checked );
                            //else if (i == tableCheck.length - 1 && e.checked != checked && tableParent != Parent) {
                            //    isCheck=true
                            //}
                        }
                    }

                }
                return isCheck;
            }
         }






    };
}();