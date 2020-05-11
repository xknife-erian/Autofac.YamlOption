namespace NKnife.Sweetting.Interfaces
{
	/// <summary>
	///     扩展属性接口，所有用defaultValueAttribute指定的默认值都会被应用。
	/// </summary>
	public interface IDefaultValue
	{
		/// <summary>
		///     Return the default value of the property
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns>the default value, null if none</returns>
		object DefaultValueFor(string propertyName);

		/// <summary>
		///     Restore the property value back to its default
		/// </summary>
		/// <param name="propertyName"></param>
		void RestoreToDefault(string propertyName);
    }
}