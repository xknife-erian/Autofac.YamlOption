namespace NKnife.Sweetting.Interfaces
{

	/// <summary>
	///     通过实现这个接口，以便能够查看一个属性是否被标记。
	/// </summary>
	public interface ITagging
	{
		/// <summary>
		///     Retrieve the value for tag
		/// </summary>
		/// <param name="propertyName">Name of the property to get the tag value</param>
		/// <param name="tag">The tag value to get</param>
		/// <returns>Tagged value or null</returns>
		object GetTagValue(string propertyName, object tag);

		/// <summary>
		///     Checks if the supplied expression resolves to a property which has the expert attribute
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="tag">Tag to check if the property is tagged with</param>
		/// <returns>true if the property has the expert attribute, else false</returns>
		bool IsTaggedWith(string propertyName, object tag);
	}
}