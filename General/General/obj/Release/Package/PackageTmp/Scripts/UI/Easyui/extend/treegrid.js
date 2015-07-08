/** 
* 级联选择父节点 
* @@param {Object} target 
* @@param {Object} id 节点ID 
* @@param {Object} status 节点状态，true:勾选，false:未勾选 
* @@return {TypeName}  
*/
function selectParent(target, id, idField, status) {
    var parent = target.treegrid('getParent', id);
    if (parent) {
        var parentId = parent[idField];
        if (status) {
            target.treegrid('checkRow', parentId);
        }
        //                else{ 
        //                    var children = target.treegrid('getChildren',parentId);
        //                    var rows = target.treegrid("getChecked");                    
        //                    var arr = new Array();
        //                    $.each(rows, function (key, val) {
        //                        arr.push(val.Id);
        //                    });
        //                    console.log(children);
        //                    var hasChildSelected = false;
        //                    for(var i=0;i<children.length;i++){  
        //                        var childId = children[i][idField];
        //                        if($.inArray(childId, arr)){
        //                            hasChildSelected = true;
        //                            break;
        //                        }
        //                    }  
        //                    if(!hasChildSelected) target.treegrid('uncheckRow',parentId);  
        //                }
        selectParent(target, parentId, idField, status);
    }
};
/** 
* 级联选择子节点 
* @@param {Object} target 
* @@param {Object} id 节点ID 
* @@param {Object} deepCascade 是否深度级联 
* @@param {Object} status 节点状态，true:勾选，false:未勾选 
* @@return {TypeName}  
*/
function selectChildren(target, id, idField, deepCascade, status) {
    //深度级联时先展开节点  
    if (status && deepCascade)
        target.treegrid('expand', id);
    //根据ID获取下层孩子节点  
    var children = target.treegrid('getChildren', id);
    for (var i = 0; i < children.length; i++) {
        var childId = children[i][idField];
        if (status)
            target.treegrid('checkRow', childId);
        else
            target.treegrid('uncheckRow', childId);
        selectChildren(target, childId, idField, deepCascade, status); //递归选择子节点  
    }
};

/**
* 扩展树表格级联选择（点击checkbox才生效）：
* 		自定义两个属性：
* 		cascadeCheck ：普通级联（不包括未加载的子节点）
* 		deepCascadeCheck ：深度级联（包括未加载的子节点）
*/
$.extend($.fn.treegrid.defaults, {
    onLoadSuccess: function (row1, data) {
        var target = $(this);
        var opts = $.data(this, "treegrid").options;
        var panel = $(this).datagrid("getPanel");
        var gridBody = panel.find("div.datagrid-body");
        var idField = opts.idField;
        var treeField = opts.treeField;
        gridBody.find("div.datagrid-cell-check input[type=checkbox]").unbind(".treegrid").click(function (e) {
            if (opts.singleSelect) return; //单选不管  
            if (opts.cascadeCheck || opts.deepCascadeCheck) {
                var id = $(this).parent().parent().parent().attr("node-id");
                var status = false;
                if ($(this).attr("checked")) status = true;
                //选中当前节点或取消当前节点
                if (status) {
                    target.treegrid("checkRow", id);
                }
                else {
                    target.treegrid("uncheckRow", id);
                }
                //级联选择父节点                  
                selectParent(target, id, idField, status);
                selectChildren(target, id, idField, opts.deepCascadeCheck, status);
            }
            e.stopPropagation(); //停止事件传播  
        });

        var s = panel;
        var row = s.find("tr.datagrid-row td[field != ck][field != " + treeField + "]");
        var chks = s.find("tr.treegrid-row td[field = IsCheck] input:checkbox");
        row.unbind("click").bind("click", function () {
            return false;
        });

        var selectedRecord = $.grep(data.rows, function (val, key) {
            return val.IsCheck;
        }, false);

        $.each(selectedRecord, function (key, val) {
            target.treegrid("checkRow", val.Id);
        });

        row.find("input:checkbox").bind("click", function (e) {
            if (opts.onClickCheckBox) {
                opts.onClickCheckBox(e, this, target);
            }
            e.stopPropagation();
        });
    }
});