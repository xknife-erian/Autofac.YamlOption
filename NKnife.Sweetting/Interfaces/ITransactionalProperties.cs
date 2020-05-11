namespace NKnife.Sweetting.Interfaces
{
	/// <summary>
	///     用此扩展属性接口，增加了事务性支持
	/// </summary>
	public interface ITransactionalProperties
	{
		/// <summary>
		///     将存储的更改从缓存中应用到属性对象上。
		/// </summary>
		void CommitTransaction();

		/// <summary>
		///     检查是否有更改
		/// </summary>
		/// <returns>true when there are changes</returns>
		bool IsTransactionDirty();

		/// <summary>
		///     取消事务，这将清除存储的更改。
		/// </summary>
		void RollbackTransaction();

		/// <summary>
		///     该方法将启动事务，所有的更改将被存储在单独的缓存中。
		/// </summary>
		void StartTransaction();
	}
}