$(function () {
    $("#submit").on("click", function () {
        var formData = $("#form-admin-edit").serializeArray();
        $.ajax({
            url: "/Permission/Edit",
            type: "post",
            data: formData,
            //data: { formData: formData, age: 3 },
            /*
            data:{name: name,
                description: description
            },*/
            dataType: "json",
            success: function (res) {
                if (res.Status == 0) {
                    alert(res.Msg);
                    parent.location.reload();//刷新父窗口
                }
                else {
                    alert(res.Msg);
                }
            },
            error: function () { alert("请求出错"); }
        });
    });
})