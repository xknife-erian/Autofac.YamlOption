using System;

namespace NKnife.Sweetting
{
    public interface INiceProfiles<TSetting> where TSetting : class, new()
    {
        TSetting Value { get; }
    }
}
