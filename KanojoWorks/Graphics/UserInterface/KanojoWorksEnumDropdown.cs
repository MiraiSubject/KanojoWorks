using System;

namespace KanojoWorks.Graphics.UserInterface
{
    public class KanojoWorksEnumDropdown<T> : KanojoWorksDropdown<T>
        where T : struct, Enum
    {
        public KanojoWorksEnumDropdown()
        {
            Items = (T[])Enum.GetValues(typeof(T));
        }
    }
}
