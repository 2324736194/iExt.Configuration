using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Configuration
{
    /// <summary>
    /// 配置文件扩展
    /// </summary>
    public static class ConfigurationExt
    {
        private static readonly KeyValueConfigurationCollection _Settings;

        static ConfigurationExt()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _Settings = configuration.AppSettings.Settings;
        }

        /// <summary>
        /// 获取当前应用程序默认配置文件中指定的设置
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="key">与设置对应的关键字</param>
        /// <param name="comparison">关键字比较枚举（默认忽略大小写）</param>
        /// <returns></returns>
        public static KeyValueConfigurationElement GetSetting(this AppDomain domain, 
            string key, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase)
        {
            if (_Settings.AllKeys.Any(p => string.Equals(p, key, comparison)))
            {
                return _Settings[key];
            }
            throw new KeyNotFoundException($"配置文件中不存在名为 {key} 的应用程序设置");
        }
    }
}
