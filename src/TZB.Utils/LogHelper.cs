using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZB.Utils
{

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 调试
        /// </summary>
        Debug,
        /// <summary>
        /// 信息
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal
    }

    /// <summary>
    /// 消息帮助类
    /// </summary>
    public class LogHelper
    {
        static LogHelper()
        {
            //根目录 bin 下的目录
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
        }
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="log">log4net.Ilog</param>
        /// <param name="messageLevel">消息等级 F,E,W,D,I</param>
        /// <param name="message">消息内容</param>
        public static void WriteLog(LogType logType, string message, object o = null)
        {
            WriteLog(null, logType, message, o);
        }
        /// <summary>
        /// logger为Other的记录日志
        /// </summary>
        /// <param name="message">消息内容</param>
        public static void WriteLog(string message, object o = null)
        {
            WriteLog("Other", LogType.Info, message, o);
        }

        /// <summary>
        /// logger为Other的记录日志
        /// </summary>
        /// <param name="message">消息内容</param>
        public static void VisitLog(string message, object o = null)
        {
            WriteLog("Visit", LogType.Info, message, o);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="loggerName">日志logger</param>
        /// <param name="logType">日志记录类型</param>
        /// <param name="message">消息内容</param>
        public static void WriteLog(string loggerName, LogType logType, string message, object o = null)
        {
            log4net.ILog log;
            if (string.IsNullOrEmpty(loggerName))
                log = _log;
            else
            {
                log = log4net.LogManager.GetLogger(loggerName);
            }
            try
            {
                switch (logType)
                {
                    case LogType.Fatal:
                        message = o == null ? message : message + JsonConvert.SerializeObject(o);
                        log.Fatal(message);
                        break;
                    case LogType.Error:
                        message = o == null ? message : message + JsonConvert.SerializeObject(o);
                        log.Error(message);
                        break;
                    case LogType.Warn:
                        message = o == null ? message : message + JsonConvert.SerializeObject(o);
                        log.Warn(message);
                        break;
                    case LogType.Debug:
                        message = o == null ? message : message + JsonConvert.SerializeObject(o);
                        log.Debug(message);
                        break;
                    default:
                        message = o == null ? message : message + JsonConvert.SerializeObject(o);
                        log.Info(message);
                        break;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("LogHelper记录日志错误", ex.ToString(), EventLogEntryType.Error);
            }
        }
    }
}
