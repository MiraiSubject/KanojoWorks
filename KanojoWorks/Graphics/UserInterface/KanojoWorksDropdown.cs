using KanojoWorks.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;

namespace KanojoWorks.Graphics.UserInterface
{
    public class KanojoWorksDropdown<T> : Dropdown<T>
    {
        protected override DropdownMenu CreateMenu() => new KanojoWorksDropdownMenu();

        protected override DropdownHeader CreateHeader() => new KanojoWorksDropdownHeader();

        public class KanojoWorksDropdownHeader : DropdownHeader
        {
            private readonly SpriteText spriteText;

            protected override LocalisableString Label
            {
                get => spriteText.Text;
                set => spriteText.Text = value;
            }

            public KanojoWorksDropdownHeader()
            {
                var font = KanojoWorksFont.GetFont(size: 18, weight: FontWeight.Bold);
                Foreground.Padding = new MarginPadding { Horizontal = 12, Vertical = 5 };
                BorderColour = Colour4.White;
                BorderThickness = 2f;
                Masking = true;

                Child = spriteText = new SpriteText
                {
                    AlwaysPresent = true,
                    Font = font,
                    Colour = Colour4.Black
                };
            }
        }

        protected class KanojoWorksDropdownMenu : DropdownMenu
        {
            protected override Menu CreateSubMenu() => new KanojoWorksMenu(Direction.Vertical);

            protected override DrawableDropdownMenuItem CreateDrawableDropdownMenuItem(MenuItem item) => new DrawableKanojoWorksDropdownMenuItem(item);

            protected override ScrollContainer<Drawable> CreateScrollContainer(Direction direction) => new KanojoWorksScrollContainer(direction);

            internal static FontUsage Font => KanojoWorksFont.GetFont(size: 18, weight: FontWeight.Light);

            public KanojoWorksDropdownMenu()
            {
                MaxHeight = 200;
            }

            private class DrawableKanojoWorksDropdownMenuItem : DrawableDropdownMenuItem
            {
                public DrawableKanojoWorksDropdownMenuItem(MenuItem item)
                    : base(item)
                {
                    BackgroundColour = Colour4.FromHex("D9D9D9");
                    BackgroundColourHover = Colour4.FromHex("E5E5E5").Opacity(0.8f);
                    BackgroundColourSelected = Colour4.FromHex("E5E5E5");
                    Foreground.Padding = new MarginPadding { Horizontal = 8, Vertical = 5 };
                }

                protected override Drawable CreateContent() => new Content();

                protected new class Content : Container, IHasText
                {
                    public LocalisableString Text
                    {
                        get => Label.Text;
                        set => Label.Text = value;
                    }

                    public readonly SpriteText Label;

                    public Content()
                    {
                        RelativeSizeAxes = Axes.X;
                        Height = 15;

                        Children = new Drawable[]
                        {
                            Label = new SpriteText
                            {
                                Colour = Colour4.Black,
                                Font = Font
                            }
                        };
                    }
                }
            }
        }
    }
}
