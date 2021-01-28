using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;

namespace KanojoWorks.Screens
{
    public class SimpleBackgroundScreen : BackgroundScreen
    {
        public SimpleBackgroundScreen()
        {
            AddInternal(new Container
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.Black
                    },
                    new SpriteText
                    {
                        Text = "Simple background",
                        Anchor = Anchor.BottomRight,
                        Origin = Anchor.BottomRight
                    },
                    new SpriteText
                    {
                        Text = "KanojoWorks",
                        Anchor = Anchor.BottomLeft,
                        Origin = Anchor.BottomLeft
                    }
                }
            });
        }
    }
}
