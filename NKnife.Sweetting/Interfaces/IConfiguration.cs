using System.Collections.Generic;
using System.ComponentModel;

namespace NKnife.Sweetting.Interfaces
{
    /// <summary>
    /// 描述一个配置
    /// </summary>
    public interface IConfiguration
    {

    }

    /// <summary>
    /// 描述一个配置
    /// </summary>
    public interface IConfiguration<T> : IConfiguration, IDescription, 
        IWriteProtectProperties, IHasChanges, IDefaultValue, 
        INotifyPropertyChanged, INotifyPropertyChanging, 
        ITransactionalProperties, ITagging, IShallowCloneable
    {
        /// <summary>
        /// Return all properties with their current value
        /// </summary>
        IEnumerable<KeyValuePair<string, T>> Properties();

        /// <summary>
        /// Returns all the property names
        /// </summary>
        /// <returns>IEnumerable with string</returns>
        IEnumerable<string> PropertyNames();
    }
}
