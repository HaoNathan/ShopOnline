layui.define("layer", function (exports) {
    var layer = layer === parent ? layui.layer : top.layui.layer;
    $ = layui.$;
    var loadIndex;
    window.OnAjaxBegin=function() {
        loadIndex = layer.load(1);

    }
    window.OnAjaxFailure = function () {
        layer.close(loadIndex);
        layer.alert("error",
            {
                title: "提示",
                icon: 2
            });
    }
    window.OnAjaxComplete = function () {
        layer.close(loadIndex);

    }
    var instance = {
        handleResult: function(result, success) {
            if (result.IsSuccess) {
                success && success(result.data);
            } else {
                layer.alert(result.Info,
                    {
                        title: "提示",
                        icon: 2
                    });
            }
        },
            ajaxRequest: function(url, data, success, option) {
            option = option || {};
            return $.ajax({
                url: url,
                type: option.type || 'post',
                dataType: option.dataType || 'json',
                data: data,
                beforeSend: function() {
                    loadIndex = layer.load(1);
                },
                error: function() {
                    layer.close(loadIndex);
                    layer.alert("error",
                        {
                            title: "提示",
                            icon: 2
                        });
                },
                success: function(result) {
                    instance.handleResult(result, success);
                },
                complete:function() {
                    layer.close(loadIndex);
                }
            });
        }
    }
    exports("request",instance);
});