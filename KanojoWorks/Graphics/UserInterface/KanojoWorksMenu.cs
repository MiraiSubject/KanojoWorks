using KanojoWorks.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;

namespace KanojoWorks.Graphics.UserInterface
{
    public class KanojoWorksMenu : Menu
    {
        public KanojoWorksMenu(Direction direction, bool topLevelMenu = false)
            : base(direction, topLevelMenu)
        {
            BackgroundColour = Colour4.FromHex("C4C4C4");
            ItemsContainer.Padding = new MarginPadding(0);
        }

        protected override void AnimateOpen() => this.FadeIn(300, Easing.OutQuint);
        protected override void AnimateClose() => this.FadeOut(300, Easing.OutQuint);
        protected override DrawableMenuItem CreateDrawableMenuItem(MenuItem item) => new DrawableKanojoWorksMenuItem(item);
        protected override ScrollContainer<Drawable> CreateScrollContainer(Direction direction) => new KanojoWorksScrollContainer(direction);
        protected override Menu CreateSubMenu() => new KanojoWorksMenu(Direction.Vertical);
    }
}
