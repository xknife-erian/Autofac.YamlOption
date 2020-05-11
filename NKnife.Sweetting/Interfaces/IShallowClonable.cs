namespace NKnife.Sweetting.Interfaces
{
    /// <summary>
    /// 通用的浅克隆方法的接口。
    /// </summary>
    public interface IShallowCloneable
    {
        /// <summary>
        /// Make a memberwise clone of the object, this is "shallow".
        /// </summary>
        /// <returns>"Shallow" Cloned instance</returns>
        object ShallowClone();
    }

    /// <summary>
    /// 通用的浅克隆方法的接口。
    /// </summary>
    /// <typeparam name="T">Type of the copy which is returned</typeparam>
    public interface IShallowCloneable<out T> where T : class
    {
        /// <summary>
        /// Make a memberwise clone of the object, this is "shallow".
        /// </summary>
        /// <returns>"Shallow" Cloned instance of type T</returns>
        T ShallowClone();
    }
}