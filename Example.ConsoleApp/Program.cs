using System;
using Autofac;
using ConsoleUi;
using ConsoleUi.Console;
using NKnife.Sweetting;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeTypeResolvers;

namespace Example.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new ContainerBuilder();
            container.RegisterType<ConsoleMenuRunner>();
            container.RegisterType<MainMenu>();
            container.RegisterGeneric(typeof(GeneralNiceProfiles<>)).As(typeof(INiceProfiles<>)).SingleInstance();

            using (var builder = container.Build())
            {
                var runner = builder.Resolve<ConsoleMenuRunner>();
                var mainMenu = builder.Resolve<MainMenu>();
                runner.Run(mainMenu);
            }
        }
    }
    
    public class MainMenu : SimpleMenu
    {
        private readonly INiceProfiles<DatabaseSetting> _dbSettingProfiles;
        private readonly INiceProfiles<SqlSetting> _sqlSettingProfiles;
        private readonly INiceProfiles<CoderSetting> _coderSettingProfiles;

        public MainMenu(INiceProfiles<DatabaseSetting> dbSettingProfiles,
            INiceProfiles<SqlSetting> sqlSettingProfiles, 
            INiceProfiles<CoderSetting> coderSettingProfiles)
        {
            _dbSettingProfiles = dbSettingProfiles;
            _sqlSettingProfiles = sqlSettingProfiles;
            _coderSettingProfiles = coderSettingProfiles;
        }

        public void ReadDatabaseSetting(IMenuContext context)
        {
            var st =_dbSettingProfiles.Value;
            Serializer ys = new Serializer();
            var yaml = ys.Serialize(st);
            context.UserInterface.Info(yaml);
        }

        public void ReadSqlSetting(IMenuContext context)
        {
            var st = _sqlSettingProfiles.Value;
            Serializer ys = new Serializer();
            var yaml = ys.Serialize(st);
            context.UserInterface.Info(yaml);
        }

        public void ReadCoderSetting(IMenuContext context)
        {
            var st = _coderSettingProfiles.Value;
            Serializer ys = new Serializer();
            var yaml = ys.Serialize(st);
            context.UserInterface.Info(yaml);
        }
    }

    public class CoderSetting
    {
    }

    public class SqlSetting
    {
    }

    public class DatabaseSetting
    {
    }
}
