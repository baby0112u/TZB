using System;

namespace TZB.Entity
{
    /// <summary>
    /// 数据字典 配置信息
    /// Type和Key唯一约束
    /// Parent，Key组成树结构
    /// </summary>
    public class Settings : BaseEntity
    {
        /// <summary>
        /// Type varchar2(20) not null, --类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Key VARCHAR2(50) not null, --值，有字符和数字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Text VARCHAR2(200) not null, --显示的文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Parent VARCHAR2(50) not null, --父级Key
        /// </summary>
        public string Parent { get; set; } = "0";

        /// <summary>
        /// UserId varchar2(10) not null, --员工工号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// UserName varchar2(100) not null, --姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Remark varchar2(1000) not null, --备注，字典说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// OrderIndex INTEGER default 1 not null,--排序，先以OrderIndex,再以时间
        /// </summary>
        public int OrderIndex { set; get; } = 1;

        /// <summary>
        /// UpdateTime DATE default SYSDATE ,--最后一次错误登陆时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// IsRequired bit default false,--是否必选
        /// </summary>
        public bool IsRequired { get; set; } = false;
    }
}