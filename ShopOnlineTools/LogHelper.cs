using System;
using System.IO;
using log4net;
using log4net.Config;

namespace ShopOnlineTools
{
    public class LogHelper
    {
        static LogHelper()
        {
            //初始化配置Log4文件
            string strFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Config\Log4.config";

            XmlConfigurator.Configure(new FileInfo(strFilePath));
        }

        public LogHelper(Type type)
        {
            logger = LogManager.GetLogger(type);
        }

        #region 字段
        //ILog对象
        private ILog logger = null;
        #endregion


        #region 方法
        public void Info(string strMessage = "系统消息：", Exception exp = null)
        {
            logger.Info(strMessage, exp);
        }

        public void Warn(string strMessage = "警告消息：", Exception exp = null)
        {
            logger.Warn(strMessage, exp);
        }

        public void Error(string strMessage = "错误消息：", Exception exp = null)
        {
            logger.Error(strMessage, exp);
        }

        public void Fatal(string strMessage = "严重错误消息：", Exception exp = null)
        {
            logger.Fatal(strMessage, exp);
        }
        #endregion
    }

}
