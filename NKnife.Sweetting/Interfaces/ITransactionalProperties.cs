namespace NKnife.Sweetting.Interfaces
{
	/// <summary>
	///     �ô���չ���Խӿڣ�������������֧��
	/// </summary>
	public interface ITransactionalProperties
	{
		/// <summary>
		///     ���洢�ĸ��Ĵӻ�����Ӧ�õ����Զ����ϡ�
		/// </summary>
		void CommitTransaction();

		/// <summary>
		///     ����Ƿ��и���
		/// </summary>
		/// <returns>true when there are changes</returns>
		bool IsTransactionDirty();

		/// <summary>
		///     ȡ�������⽫����洢�ĸ��ġ�
		/// </summary>
		void RollbackTransaction();

		/// <summary>
		///     �÷����������������еĸ��Ľ����洢�ڵ����Ļ����С�
		/// </summary>
		void StartTransaction();
	}
}