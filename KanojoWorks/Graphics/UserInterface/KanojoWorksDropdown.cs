using KanojoWorks.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;

namespace KanojoWorks.Graphics.UserInterface
{
    public class KanojoWorksDropdown<T> : Dropdown<T>
    {
        protected override DropdownMenu CreateMenu() => new KanojoWorksDropdownMenu();

        protected override DropdownHeader CreateHeader() => new KanojoWorksDropdownHeader();

        public class KanojoWorksDropdownHeader : DropdownHeader
        {
            private readonly SpriteText spriteText;

            protected override string Label
            {
                get => spriteText.Text;
                set => spriteText.Text = value;
            }

            public KanojoWorksDropdownHeader()
            {
                var font = KanojoWorksFont.GetFont(size: 20, weight: FontWeight.Bold);
                Foreground.Padding = new MarginPadding { Horizontal = 10, Vertical = 5 };

                Child = spriteText = new SpriteText
                {
                    AlwaysPresent = true,
                    Font = font,
                    Height = font.Size
                };
            }
        }

        protected class KanojoWorksDropdownMenu : DropdownMenu
        {
            protected override Menu CreateSubMenu() => new KanojoWorksMenu(Direction.Vertical);

            protected override DrawableDropdownMenuItem CreateDrawableDropdownMenuItem(MenuItem item) => new DrawableKanojoWorksDropdownMenuItem(item);

            protected override ScrollContainer<Drawable> CreateScrollContainer(Direction direction) => new KanojoWorksScrollContainer(direction);

            private class DrawableKanojoWorksDropdownMenuItem : DrawableDropdownMenuItem
            {
                public DrawableKanojoWorksDropdownMenuItem(MenuItem item)
                    : base(item)
                {
                    Foreground.Padding = new MarginPadding { Horizontal = 10, Vertical = 5 };
                }

                protected override Drawable CreateContent() => new SpriteText
                {
                    Font = KanojoWorksFont.GetFont(size: 20, weight: FontWeight.Bold)
                };
            }
        }
    }
}
