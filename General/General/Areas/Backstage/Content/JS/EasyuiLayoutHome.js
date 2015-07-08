var InitEvent = function () {
    var InitControl = function () {
        IntiRightKeyMenuArea();
        $('#Contextmenu').menu({
            onClick: function (item) {
                //获取所有tabs
                var tabsItem = $('#BasePageTabs').tabs('tabs');
                switch (item.name) {
                    case "Close":
                        //关闭当前
                        $('#BasePageTabs').tabs('close', rightKey);
                        break;
                    case "CloseOther":
                        //关闭其他
                        GetTabsTitle("closeOther", tabsItem);
                        break;
                    case "CloseAll":
                        //关闭所有
                        GetTabsTitle("closeAll", tabsItem);
                        break;

                }
            }
        })
    };
    var ReturnUrl = function (url, title) {
        if (title != "首页") {
            $("#BasePageTabs").tabs('add', {
                title: title,
                href: url,
                closable: true
            });
            IntiRightKeyMenuArea();//刷新右键菜单区域
        }
    };
    return {
        init: function () {
            InitControl();
        },
        OpenTab: function (returnUrl, tabTitle) {
            if (tabTitle != "" && tabTitle != "首页"
                && returnUrl != "/" && returnUrl != "/Backstage".toLowerCase()
                && returnUrl != "/Backstage/Home/Index".toLowerCase()) {
                ReturnUrl(returnUrl, tabTitle);
            }
        }

    };
}();

//右键选中的Tabs 页 索引
var rightKey = "";
//tabs 右键菜单显示
function TabsOnContextMenu(e, title, index) {
    if (title != "首页") {
        rightKey = title;
        var pos = { left: e.clientX, top: e.clientY };
        $("#Contextmenu").menu('show', pos);
    }
}

//获取待关闭的所有tabs
function GetTabsTitle(closeType, item) {
    var closeTabsTitle = []; //待删除tabs对象 （保存的TABS 标题）
    $.each(item, function () {//循环所有tabs对象集合
        var tab = this;
        var panls = tab.panel('options'); //tabs 的panel 对象
        if (closeType == "closeOther") {//关闭其他
            if (panls.title != rightKey && panls.title != "首页") {
                closeTabsTitle.push(panls.title); //加入待关闭tabs对象中
            }
        } else if (closeType == "closeAll") {//关闭所有
            if (panls.title != "首页") {
                closeTabsTitle.push(panls.title); //加入待关闭tabs对象中
            }

        }
    })
    ColseTabs(closeTabsTitle);
}

//关闭 其他或者全部Tabs页
function ColseTabs(tabsTitle) {
    for (var i = 0; i < tabsTitle.length; i++) {
        $('#BasePageTabs').tabs('close', tabsTitle[i]); //关闭tabs页
    }
}

//菜单点击事件
function TreeOnClick(node) {
    if (node.attributes != null && node.attributes.url != undefined && node.attributes.url != "") {
        if (!$("#BasePageTabs").tabs('exists', node.text)) {
            $("#BasePageTabs").tabs('add', {
                title: node.text,
                href: node.attributes.url,
                closable: true
            });
        } else {
            $("#BasePageTabs").tabs('select', node.text);
            var tab = $('#BasePageTabs').tabs('getSelected');
            tab.panel("refresh", node.attributes.url);
        }
        IntiRightKeyMenuArea();//刷新右键菜单区域
    }
}
//初始化 右键不提示系统右键
function IntiRightKeyMenuArea() {
    //tabs 页 取消系统右键菜单
    var itemNodes = $('.tabs')[0].childNodes;
    for (var i = 0; i < itemNodes.length; i++) {
        //禁止出现右键按钮
        itemNodes[i].oncontextmenu = itemNodes[i].ondragstart = itemNodes[i].onselectstart = itemNodes[i].onbeforecopy = function () { return false; };
    }
    //右键菜单 禁止右键菜单
    // $('#ContextMenu').oncontextmenu = $('#ContextMenu').ondragstart = $('#ContextMenu').onselectstart = $('#ContextMenu').onbeforecopy = function () { return false; };

}