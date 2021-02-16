using System;

namespace KanojoWorks.Screens
{
    public abstract class MainMenu : KanojoWorksScreen
    {
        public virtual Action OnNewGame { get; protected set; }
        public virtual Action OnLoadGame  { get; protected set; }
        public virtual Action OnSettings { get; protected set; }
        public virtual Action OnGallery { get; protected set; }
        public virtual Action OnExit { get; protected set; }
    }
}
