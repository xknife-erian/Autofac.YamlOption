using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using ConsoleUi;
using ConsoleUi.Console;
using Dapplo.Config.Interfaces;
using NKnife.Sweetting;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NodeTypeResolvers;

namespace Example.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var container = new ContainerBuilder();
            container.RegisterType<ConsoleMenuRunner>();
            container.RegisterType<MainMenu>();
            container.RegisterType<GeneralNiceProfilesContainer>().As<INiceProfilesContainer>().SingleInstance();
            container.RegisterGeneric(typeof(GeneralNiceProfile<>)).As(typeof(INiceProfile<>)).SingleInstance();

            using var builder = container.Build();
            {
                // INiceProfilesBuilder profilesBuilder = Sweet.Initializ()
                //     .WithFileExtensionNames()
                //     .WithFileNames("myIniFile")
                //     .WithAutoSaveInterval(10)
                //     .WithFixedDirectory("")
                //     .WithoutWatchingChanges()
                //     .Build();
                // var profilesContainer = builder.Resolve<INiceProfilesContainer>();
                // await profilesContainer.LoadAsync(profilesBuilder);

                var runner = builder.Resolve<ConsoleMenuRunner>();
                var mainMenu = builder.Resolve<MainMenu>();
                await runner.Run(mainMenu);
            }
        }
    }
    
    public class MainMenu : SimpleMenu
    {
        private readonly INiceProfile<CoderSetting> _profile;

        public MainMenu(INiceProfilesContainer container)
        {
            //_profile = container.Take<CoderSetting>();
        }

        public void ReadCoderSetting(IMenuContext context)
        {
            var st = _profile.Value;
            Serializer ys = new Serializer();
            var yaml = ys.Serialize(st);
            context.UserInterface.Info(yaml);
        }

        public void WriteCoderSetting(IMenuContext context)
        {
            var st = new CoderSetting();
            Serializer ys = new Serializer();
            var yaml = ys.Serialize(st);
            //context.UserInterface.Info(yaml);
            Console.WriteLine(yaml);
        }
    }

    public class CoderSetting
    {
        public CoderSetting()
        {
            Guid = Guid.NewGuid();
            SqlSettings = new SqlSetting[3];
            for (int i = 0; i < SqlSettings.Length; i++)
            {
                SqlSettings[i] = new SqlSetting();
            }
            DatabaseSettings = new List<DatabaseSetting>();
            for (int i = 0; i < 3; i++)
            {
                DatabaseSettings.Add(new DatabaseSetting());
            }
            DatabaseSettingMap = new Dictionary<string, DatabaseSetting>();
            for (int i = 0; i < 5; i++)
            {
                DatabaseSettingMap.Add($"Map{i}", new DatabaseSetting());
            }
        }
        public Guid Guid { get; set; }
        public SqlSetting[] SqlSettings { get; set; }
        public List<DatabaseSetting> DatabaseSettings { get; set; }
        public Dictionary<string, DatabaseSetting> DatabaseSettingMap { get; set; }
    }

    public class SqlSetting : SettingBase
    {
    }

    public class DatabaseSetting : SettingBase
    {
    }

    public class BookSetting : SettingBase
    {
    }

    public abstract class SettingBase
    {
        private static readonly Random _Random = new Random((int) System.DateTime.Now.Ticks);

        protected SettingBase()
        {
            Type = this.GetType();
            Guid = Guid.NewGuid();
            AString = Guid.NewGuid().ToString("B");
            BString = Guid.NewGuid().ToString("B").ToUpper();
            DateTime = DateTime.Now.AddDays(-_Random.Next(1000, 9999)).AddSeconds(-_Random.Next(100000, 9999999));
            //IpAddress = new IPAddress(_Random.Next(1000, 9999) * _Random.Next(1000, 9999));
            Int = _Random.Next(100, 999);
            UInt = (uint)Math.Abs(_Random.Next(_Random.Next(10000, 99999)));
            Short = (short)_Random.Next(0, 255);
            UShort = (ushort)_Random.Next(0, 255);
            Double = _Random.NextDouble();
            Float = (float)_Random.NextDouble();
            Decimal = (decimal)_Random.NextDouble();
            Byte = Guid.NewGuid().ToByteArray()[0];
            Bytes = Guid.NewGuid().ToByteArray();
        }

        public Guid Guid { get; set; }
        public Type Type { get; set; }
        public string AString { get; set; }
        public string BString { get; set; }
        public DateTime DateTime { get; set; }
        //public IPAddress IpAddress { get; set; }
        public int Int { get; set; }
        public uint UInt { get; set; }
        public short Short { get; set; }
        public ushort UShort { get; set; }
        public float Float { get; set; }
        public decimal Decimal { get; set; }
        public double Double { get; set; }
        public byte Byte { get; set; }
        public byte[] Bytes { get; set; }
    }
}
