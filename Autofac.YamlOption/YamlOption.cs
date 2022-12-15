using System;
using YamlDotNet.Serialization;

// ReSharper disable once CheckNamespace
namespace Autofac
{
    /// <summary>
    /// 以Yaml表达的选项数据。静态帮助类。
    /// </summary>
    public static class YamlOption
    {
        /// <summary>
        /// 将指定的对象生成以Yaml表达的选项数据
        /// </summary>
        /// <typeparam name="T">指定的对象</typeparam>
        /// <param name="option">指定的对象实例</param>
        /// <returns></returns>
        public static string BuildOptionData<T>(T option) 
            where T : class
        {
            if (option == null)
                throw new ArgumentNullException(nameof(option));
            var ys = new Serializer();
            var yaml = ys.Serialize(option);
            return yaml;
        }
    }
}