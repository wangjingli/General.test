/// <reference path="../../../../Scripts/UI/Bootstrap/js/jquery-1.11.1.js" />
/// <reference path="tool.js" />


//选中的角色
var selectedrole = "";

function addRole() { }
//查询
function Query() {
    var $from = $("#QuerySection").serialize();
    $("#QuerySection").submit();
}
//删除用户
function Deletefun(thisbtn) {
    bootbox.confirm("确定要删除吗?", function (result) {
        if (result) {
            var idlist = $("#TableBody input[id^='Check-id-']:checked");
            if (idlist.length > 0) {
                var _idlist = {};
                idlist.each(function (index, element) {
                    var _id = this.id;
                    _id = _id.replace("Check-id-", "");
                    _idlist["userList[" + index + "].Id"] = _id;
                });

                var ajax = new InitAjax("GET", "/Backstage/system/deleteUsers", _idlist, thisbtn.id, "正在删除", "删除");
                ajax.send();
                ajax = null;
            }
            else {
                Notify("请选择用户", 'bottom-left', '5000', 'info', 'fa-comment-o', true);
            }
        }
    });
}
//全选
function CheckAll2() {
    var isChecked = $("#CheckAll2").is(':checked');
    //alert(isChecked);
    var idlist = $("#TableBody input[id^='Check-id-']");
    for (var i = 0; i < idlist.length; i++) {
        var element = idlist[i];
        element.checked = $("#CheckAll2")[0].checked;
    }

}



function selectRole(currentNick, currentUser, currentRole, currentRoleNmae) {
    //alert(currentRole);
    //if (currentRole != "null") {
    //    //$("select#RoleList option").attr('selected', 'rrrrrr');
    //    $("select#RoleList option[value='" + currentRole + "']").attr('selected', 'true');
    //}
    //var droprole = document.getElementById("RoleList");
    //droprole.value = currentRole;
    //var index = droprole.selectedIndex;
    //alert(index);
    //for (var i = 0; i < droprole.children.length; i++) {
    //    //alert(droprole.children[i].value + "  " + currentRole);
    //    droprole.children[i].selected = false;
    //    if (droprole.children[i].value == currentRole) {
    //        //alert("ddd");
    //        droprole.children[i].selected = true;
    //        droprole.selectedIndex = index;
    //    }
    //}
    //alert(index);
    //alert(droprole.children[index].value + "---" + droprole.children[index].text);


    bootbox.dialog({
        message: $("#myModal").html(),
        title: "为 " + currentNick + " 选择角色;当前角色：" + currentRoleNmae,
        className: "modal-darkorange",
        buttons: {
            success: {
                label: "<i class=\"icon fa fa-plus\"></i>保存",
                className: "btn-blue",
                callback: function () {

                    if (selectedrole == "" || typeof (selectedrole) == "undefined") {
                        //alert("请选择一个角色");
                        Notify("请选择一个角色", 'bottom-left', '5000', 'danger', 'fa-edit', true);
                        return false;
                    }
                    var role = selectedrole;

                    //alert(currentUser); return;
                    $.ajax({
                        type: "POST",
                        url: '/Backstage/system/selectRoleForUser',
                        data: "userid=" + currentUser + "&roleid=" + role,
                        success: function (result) {
                            Notify(result.msg, 'bottom-left', '5000', 'success', 'fa-check', true);
                            setTimeout("location.reload()", 3000);
                            
                        }
                    });

                    return true;
                }
            }, cacel: {
                label: "<i class=\"icon fa fa-times\"></i>取消",
                className: "btn-blue"
                //callback: function () { alert("cancel"); }
            }

        }
    });
}

function changeRole(drop) {

    var index = drop.selectedIndex;

    selectedrole = drop.children[index].value;

}
