using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NKnife.Sweetting
{
    public class GeneralNiceProfilesContainer : INiceProfilesContainer
    {
        #region Implementation of INiceProfilesContainer

        public Task LoadAsync(INiceProfilesBuilder builder)
        {
            throw new NotImplementedException();
        }

        public INiceProfile<T> Take<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
