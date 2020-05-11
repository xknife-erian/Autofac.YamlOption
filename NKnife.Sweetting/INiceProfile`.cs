using System;

namespace NKnife.Sweetting
{
    public interface INiceProfile<TSetting> where TSetting : class, new()
    {
        TSetting Value { get; }
    }
}
