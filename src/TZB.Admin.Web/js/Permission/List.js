/*管理员-删除*/
function admin_del(obj, id) {
    layer.confirm('确认要删除吗？', function (index) {
        //此处请求后台程序，下方是成功后的前台处理……
        $.ajax({
            url: "/Permission/Delete/" + id,
            type: "post",
            //data: {id:id}
            dataType: "json",
            success: function (res) {
                if (res.Status == 0) {
                    $(obj).parents("tr").remove();
                    layer.msg('已删除!', { icon: 1, time: 2000 });
                }
                else {
                    layer.msg('删除失败!', { icon: 2, time: 2000 });
                }
            }
        });
    });
}