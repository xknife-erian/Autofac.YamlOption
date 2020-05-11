using System.Threading.Tasks;

namespace NKnife.Sweetting
{
    public interface INiceProfilesContainer
    {
        Task LoadAsync(INiceProfilesBuilder builder);
        INiceProfile<T> Take<T>() where T : class, new();
    }
}