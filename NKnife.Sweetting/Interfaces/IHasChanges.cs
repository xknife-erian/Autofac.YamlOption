using System.Collections.Generic;

namespace NKnife.Sweetting.Interfaces
{
    /// <summary>
    ///     ��չ���Խӿڣ�������һ��֪���ϴ�����ʱ�Ƿ��б仯�ķ�������IConfig�ڲ�ʹ�ã��Լ���Ƿ���Ҫд��
    /// </summary>
    public interface IHasChanges
	{
        /// <summary>
        /// This can be used to turn on change tracking
        /// </summary>
        void TrackChanges();

        /// <summary>
        /// This can be used to stop change tracking
        /// </summary>
        void DoNotTrackChanges();

        /// <summary>
        ///     Check if there are changes pending
        /// </summary>
        /// <returns>true when there are changes</returns>
        bool HasChanges();

		/// <summary>
		///     Reset the has changes flag
		/// </summary>
		void ResetHasChanges();

		/// <summary>
		/// Retrieve all changes, 
		/// </summary>
		/// <returns>ISet with the property values</returns>
		ISet<string> Changes();

		/// <summary>
		/// Test if a property has been changed since the last reset
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns>bool</returns>
		bool IsChanged(string propertyName);
	}
}