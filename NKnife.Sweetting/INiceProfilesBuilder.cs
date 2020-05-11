namespace NKnife.Sweetting
{
    public interface INiceProfilesBuilder
    {
        /// <summary>
        /// 指定配置文件扩展名的集合
        /// </summary>
        /// <param name="names">配置文件扩展名的集合</param>
        INiceProfilesBuilder WithFileExtensionNames(params string[] names);
        /// <summary>
        /// 指定配置文件的集合
        /// </summary>
        /// <param name="fileNames">配置文件的集合</param>
        INiceProfilesBuilder WithFileNames(params string[] fileNames);
        /// <summary>
        /// 禁用配置文件变化监测
        /// </summary>
        /// <returns></returns>
        INiceProfilesBuilder WithoutWatchingChanges();
        /// <summary>
        /// 如果你想从一个特定的目录中读取和写入，指定一个目录，而不是使用默认的逻辑。
        /// </summary>
        /// <param name="directory">指定一个目录</param>
        INiceProfilesBuilder WithFixedDirectory(string directory);
        /// <summary>
        /// 指定自动保存时间间隔
        /// </summary>
        /// <param name="interval">指定自动保存时间间隔</param>
        INiceProfilesBuilder WithAutoSaveInterval(uint interval);

        INiceProfilesBuilder Build();
    }
}