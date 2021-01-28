using System;
using osu.Framework.Screens;
using osu.Framework.Graphics;

namespace KanojoWorks.Screens
{
    public abstract class BackgroundScreen : Screen, IEquatable<BackgroundScreen>
    {
        public virtual bool Equals(BackgroundScreen other)
        {
            return other?.GetType() == GetType();
        }

        protected BackgroundScreen()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }
    }
}
