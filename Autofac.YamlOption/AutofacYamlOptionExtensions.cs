using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

// ReSharper disable once CheckNamespace
namespace Autofac
{
    public static class AutofacYamlOptionExtensions
    {
        private static readonly Dictionary<string, string> _YamlContentMap = new Dictionary<string, string>();
        private static readonly Dictionary<string, object> _OptionMap = new Dictionary<string, object>();

        public static ContainerBuilder RegisterOptionYamlFiles(this ContainerBuilder container, params string[] fileNames)
        {
            if (null == fileNames)
                return container;
            foreach (var fileName in fileNames)
            {
                if (!File.Exists(fileName))
                    break;
                var content = File.ReadAllText(fileName);
                var optionName = fileName.Substring(0, fileName.LastIndexOf('.'));
                _YamlContentMap.Add(optionName, content);
            }

            return container;
        }

        public static ContainerBuilder RegisterOption<T>(this ContainerBuilder container)
        {
            var type = typeof(T);
            var key = type.Name;
            if (!_YamlContentMap.ContainsKey(key))
                return container;
            var deser = new Deserializer();
            container.Register<T>(
                    c =>
                    {
                        if (!_OptionMap.ContainsKey(key))
                        {
                            var content = _YamlContentMap[key];
                            var option = deser.Deserialize<T>(content);
                            _OptionMap.Add(key, option);
                        }

                        return (T)_OptionMap[key];
                    })
                .AsSelf().AsImplementedInterfaces().SingleInstance();
            return container;
        }
    }
}