using System;
using osu.Framework.Graphics;
using osu.Framework.Screens;

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
