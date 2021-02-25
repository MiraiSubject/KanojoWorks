using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;

namespace KanojoWorks.Graphics.UserInterface
{
    public class DrawableKanojoWorksMenuItem : Menu.DrawableMenuItem
    {
        public DrawableKanojoWorksMenuItem(MenuItem item)
            : base(item)
        {
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            BackgroundColour = Colour4.Gray.Opacity(0.7f);
            BackgroundColourHover = Colour4.White.Opacity(0.1f);
        }

        protected sealed override Drawable CreateContent() => CreateTextContainer();
        protected virtual TextContainer CreateTextContainer() => new TextContainer();

        protected class TextContainer : Container, IHasText
        {
            public LocalisableString Text
            {
                get => NormalText.Text;
                set => NormalText.Text = value;
            }

            public readonly SpriteText NormalText;

            public TextContainer()
            {
                // CentreRight to include the possibility of icons on the left side of the resulting Item drawable.
                Anchor = Anchor.CentreRight;
                Origin = Anchor.CentreRight;
                AutoSizeAxes = Axes.Both;

                Child = NormalText = new SpriteText
                {
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreRight,
                    Font = KanojoWorksFont.GetFont(size: 17, weight: FontWeight.Bold),
                    Colour = Colour4.White.Darken(0.1f),
                    Margin = new MarginPadding { Horizontal = 10, Vertical = 5 }
                };
            }
        }
    }
}
