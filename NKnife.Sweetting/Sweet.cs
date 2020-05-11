using System;
using System.Collections.Generic;
using System.Text;

namespace NKnife.Sweetting
{
    public class Sweet
    {
        public static string[] Profiles { get; set; }

        public static INiceProfilesBuilder Initializ(params string[] profiles)
        {
            if (profiles != null)
                Profiles = profiles;
            return null;
        }
    }
}
