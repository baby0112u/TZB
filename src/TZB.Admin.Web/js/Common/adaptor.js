jQuery.extend({
    cookie: function (name, value, options) {
        if (typeof value != 'undefined') { // name and value given, set cookie
            options = options || { path: '/' };
            if (value === null) {
                value = '';
                options.expires = -1;
            }
            var expires = '';
            if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
                var date;
                if (typeof options.expires == 'number') {
                    date = new Date();
                    date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
                } else {
                    date = options.expires;
                }
                expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
            }
            var path = options.path ? '; path=' + options.path : '';
            var domain = options.domain ? '; domain=' + options.domain : '';
            var secure = options.secure ? '; secure' : '';
            document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
        } else { // only name given, get cookie
            var cookieValue = null;
            if (document.cookie && document.cookie != '') {
                var cookies = document.cookie.split(';');
                for (var i = 0; i < cookies.length; i++) {
                    var cookie = jQuery.trim(cookies[i]);
                    // Does this cookie string begin with the name we want?
                    if (cookie.substring(0, name.length + 1) == (name + '=')) {
                        cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                        break;
                    }
                }
            }
            return cookieValue;
        }
    },
    cookieName: "oem.sessionid",
    cookieFuncName: "cookieFuncName",
    cookieClear: function () {
        $.cookie($.cookieName, null);
    },
    cookieSet: function (v) {
        try {
            (top.$ || $).cookie($.cookieName, v);
        }
        catch (err) {
            $.cookie($.cookieName, v);
        }
    },
    cookieCheck: function () {
        try {
            if ((top.$ || $).oemCookie() == "" || (top.$ || $).oemCookie() == null)
                window.location = "/login.html?href=" + escape(window.location);
        }
        catch (err) {
            if ($.oemCookie() == "" || $.oemCookie() == null)
                window.location = "/login.html?href=" + escape(window.location);
        }
    },
    oemCookie: function () {
        var cookie;
        try {
            cookie = (top.$ || $).cookie($.cookieName);
        }
        catch (err) {
            cookie = $.cookie($.cookieName);
        }
        if (!cookie) {
            cookie = $.getPara($.cookieName);
        }
        return cookie;
    },
    tokenUrl: function (url, token) {
        var _url = url;
        if (_url.indexOf('{bst_token}') > -1) {
            _url = _url.replace('{bst_token}', token);
        } else if (_url.indexOf('bst_token') > -1) {
            _url = _url.replace('bst_token%3d', 'bst_token%3d' + token);
        }
        if (_url.indexOf('{oem.sessionid}') > -1) {
            _url = _url.replace('{oem.sessionid}', $.cookie($.cookieName));
        } else if (_url.indexOf('oem.sessionid') > -1) {
            _url = _url.replace('oem.sessionid%3d', 'oem.sessionid%3d' + $.cookie($.cookieName));
        }
        return _url;
    },
    cookieUrl: function (url) {
        var cookie;
        cookie = $.cookie($.cookieName);
        if (!cookie) {
            if ($.getPara($.cookieName) != "") {
                cookie = $.getPara($.cookieName);
                $.cookieSet(cookie);
            }
            else
                return url;
        }
        if (url.indexOf("?") == -1)
            url = url + "?";
        else
            url = url + "&";
        url = url + $.cookieName + "=" + cookie;
        url = url + '&t=' + new Date().getTime();
        return url;
    },
    getPara: function (name, url) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        if (url) {
            if (url.indexOf("?") != -1)
                url = url.split("?")[1];
        } else if (window.location.search.length > 1) {
            url = decodeURI(window.location.search.substr(1));
        } else {
            return '';
        }
        var r = url.match(reg);
        if (r != null) return unescape(r[2]); return '';
    },
    ajaxHandler: function (ajaxObj) {
        var g = {
            // 加载进度条
            loading: function (_msg) {
                var loadimg = "<span class='ajax_msg'></span>";
                if (!ajaxObj.loading || !ajaxObj.loading.id)
                    ajaxObj.loading = { id: "ajaxmsg", message: "" };
                var msg = "";
                if (_msg && _msg != "")
                    msg = _msg;
                else
                    msg = loadimg + ajaxObj.loading.message;
                if ($("#" + ajaxObj.loading.id).length == 0) {
                    $("body").append("<div id='" + ajaxObj.loading.id + "'></div>");
                    $('#' + ajaxObj.loading.id).html(msg);

                    $('#' + ajaxObj.loading.id).addClass("loading_img").css({ position: 'fixed', top: '50%', left: '50%', padding: '50px 50px', color: '#fff', cursor: 'pointer', margin: ' -50px 0px 0px -50px' });
                    var _msgwidth = Math.round($('#' + ajaxObj.loading.id).width() / 2);
                    $('#' + ajaxObj.loading.id).css({ margin: "0 0 0 -" + _msgwidth + 'px' });
                    $('#' + ajaxObj.loading.id).show();
                    $('#' + ajaxObj.loading.id).bind('click', function () { $('#' + ajaxObj.loading.id).fadeTo("normal", 0.5).slideUp("normal"); });
                } else {

                    $('#' + ajaxObj.loading.id).html(msg);
                    if ($('#' + ajaxObj.loading.id).css("position") == "fixed") {
                        var _msgwidth = Math.round($('#' + ajaxObj.loading.id).width() / 2);
                        $('#' + ajaxObj.loading.id).css({ margin: "0 0 0 -" + _msgwidth + 'px' });
                    }
                    $('#' + ajaxObj.loading.id).show();
                }

            },
            // 隐藏进度条
            hideload: function () {
                if (!ajaxObj.loading || !ajaxObj.loading.id) return;
                $('#' + ajaxObj.loading.id).hide();
            },
            // 成功返回处理
            success: function (data, textStatus) {
                try {
                    if (data == undefined || data == '') {
                        g.hideload();
                        return;
                    }
                    var result = data;
                    if (result instanceof Array)
                        result = result[0];
                    if (result.State == 0) {
                        g.hideload();
                        if (ajaxObj.success) ajaxObj.success(result.Data, (result.Page || null), (result.DataDifferTime || null));
                    } else {
                        if ($.trim(result.ErrMsg) == "异常") {
                            result.ErrMsg = "系统繁忙，请稍后再试！";
                        }
                        g.loading(result.ErrMsg ? result.ErrMsg : result.Message);
                        if (ajaxObj.failure) ajaxObj.failure(result.ErrMsg ? result.ErrMsg : result.Message);
                        setTimeout(function () {
                            g.hideload();
                        }, 3000);
                    }

                    $("#loadingStyle").hide();
                } catch (e) {
                    g.loading("系统繁忙，请稍后再试！");
                    setTimeout(function () {
                        g.hideload();
                    }, 3000);
                }
            },
            // 失败返回处理
            error: function (xmlhttp, textStatus, errorThrown, errFrom) {
                if (errorThrown && errorThrown.message && errorThrown.message.indexOf(' was not called') > 0) {
                    xmlhttp.status = '403';
                }
                if (xmlhttp && xmlhttp.status == '200') {
                    // 有空跟踪
                } else if (xmlhttp && xmlhttp.status == '403') {
                    if (top != self && self.location.href.indexOf('webui/index/index.html') == -1) {
                        $.openPage('login', '/login.html?type=checklogin&errFrom=' + errFrom, '请登录', 980, 460, '', false);
                    } else {
                        location.href = "/login.html?href=" + escape(location.href);
                    }
                } else {
                    //alert("对不起，网络连接出错，请联系管理员！原因:" + errorThrown + "-" + textStatus);
                    //alert($.toJSON(xmlhttp));
                }
            },
            // 提交动作
            submit: function () {
                var r = {};
                var param = null;
                if (ajaxObj.model) {
                    if (typeof ajaxObj.model == "function") {
                        param = ajaxObj.model();
                    } else {
                        param = ajaxObj.model;
                    }
                }
                if (ajaxObj.check && !ajaxObj.check(param)) {
                    g.hideload();
                    return;
                }
                if (ajaxObj.urlType) {
                    r.Type = ajaxObj.urlType;
                    r.Param = param;
                    if (ajaxObj.Page) r.Page = ajaxObj.Page;
                    if (ajaxObj.ColOrder) r.ColOrder = ajaxObj.ColOrder;

                } else {
                    r = param;
                }

                var dataType = ajaxObj.dataType || "json";
                var url = ajaxObj.url || App_Config.NewJunhong + "/AjaxMappingHandler.aspx";
                url = $.cookieUrl(url);
                var option = {
                    type: 'post',
                    dataType: dataType,
                    url: url,
                    data: "data=" + $.toJSON(r).replace(/\+/g, '%2B'),
                    success: g.success,

                    error: g.error
                };
                if (url.indexOf("http") == 0) {
                    option.dataType = "jsonp";
                    option.jsonp = "jsonpcallback";
                }
                var _ajax = $.ajax(option);
                return _ajax;
            }
        };
        g.loading();
        return g.submit();
    }
});