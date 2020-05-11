namespace NKnife.Sweetting.Interfaces
{
	/// <summary>
	///     扩展接口，可以读取DescriptionAttribute
	/// </summary>
	public interface IDescription
	{
		/// <summary>
		///     Return the description of the property
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns>the description, null if none</returns>
		string DescriptionFor(string propertyName);
	}
}