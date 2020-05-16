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
                var start = fileName.LastIndexOf(Path.DirectorySeparatorChar) + 1;
                if (start < 0)
                    start = 0;
                var end = fileName.LastIndexOf('.');
                var optionName = fileName.Substring(start, end - start);
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