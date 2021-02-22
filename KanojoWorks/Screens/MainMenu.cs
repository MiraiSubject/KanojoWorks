using System;

namespace KanojoWorks.Screens
{
    public abstract class MainMenu : KanojoWorksScreen
    {
        public virtual Action OnNewGame { get; set; }
        public virtual Action OnLoadGame  { get; set; }
        public virtual Action OnSettings { get; set; }
        public virtual Action OnGallery { get; set; }
        public virtual Action OnExit { get; set; }
    }
}
