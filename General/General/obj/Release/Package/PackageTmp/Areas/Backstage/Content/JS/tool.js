/// <reference path="../../../../Scripts/UI/Bootstrap/js/jquery-1.11.1.js" />


var InitAjax = function (type, url, data, btn, btnOperationingText, btnCompleteText) {
    /// <summary>自定义ajax函数</summary>
    /// <param name="type" type="String">ajax访问类型:post/get.</param>
    /// <param name="url" type="String">The radius of the circle.</param>
    /// <param name="data" type="String">The radius of the circle.</param>
    /// <param name="btn" type="String">The radius of the circle.</param>
    /// <param name="btnOperationingText" type="String">The radius of the circle.</param>
    /// <param name="btnCompleteText" type="String">The radius of the circle.</param>

    var _type = type, _url = url, _data = data, _btn = btn, _btnOperationingText = btnOperationingText, _btnCompleteText = btnCompleteText;
    var sendFun = function () {

        $.ajax({
            type: type,
            url: url,
            data: data,
            cache: false,
            beforeSend: function () {
                //发送请求之前
                $("#"+btn).val(btnOperationingText);
            },
            success: function (result) {
                if (result.code > 0) {
                    Notify(result.msg, 'bottom-left', '5000', 'success', 'fa-edit', true);
                    setTimeout("location.reload()", 3000);
                }
                else {
                    Notify(result.msg, 'bottom-left', '5000', 'danger', 'fa-edit', true);
                }
            },
            error: function () {
                Notify("操作异常", 'bottom-right', '5000', 'danger', 'fa-edit', true);
            },
            complete: function () {
                $("#" + btn).val(btnCompleteText);
            }
        });
    }
    return { send: function () { sendFun(_type, _url, _data, _btn, _btnOperationingText, _btnCompleteText); } };
}

