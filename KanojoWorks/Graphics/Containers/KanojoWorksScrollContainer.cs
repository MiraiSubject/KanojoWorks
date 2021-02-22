using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace KanojoWorks.Graphics.Containers
{
    public class KanojoWorksScrollContainer : KanojoWorksScrollContainer<Drawable>
    {
        public KanojoWorksScrollContainer()
        {
        }

        public KanojoWorksScrollContainer(Direction direction)
            : base(direction)
        {
        }
    }

    public class KanojoWorksScrollContainer<T> : ScrollContainer<T> where T : Drawable
    {
        protected override ScrollbarContainer CreateScrollbar(Direction direction) => new KanojoWorksScrollBar(direction);

        public const float SCROLL_BAR_HEIGHT = 10;

        public KanojoWorksScrollContainer(Direction scrollDirection = Direction.Vertical)
            : base(scrollDirection)
        {
            ClampExtension = 5;
        }

        protected class KanojoWorksScrollBar : ScrollbarContainer
        {
            public KanojoWorksScrollBar(Direction scrollDirection)
                : base(scrollDirection)
            {
                Size = new Vector2(SCROLL_BAR_HEIGHT);

                const float margin = 5;
                const float shorten = 3;

                switch (scrollDirection)
                {
                    case Direction.Vertical:
                        Margin = new MarginPadding
                        {
                            Left = margin,
                            Right = margin,
                            Top = shorten,
                            Bottom = shorten,
                        };
                        break;

                    case Direction.Horizontal:
                        Margin = new MarginPadding
                        {
                            Left = shorten,
                            Right = shorten,
                            Top = margin,
                            Bottom = margin,
                        };
                        break;
                }

                Masking = true;
                CornerRadius = 5f;
                Child = new Box { RelativeSizeAxes = Axes.Both, Colour = Colour4.Black.Opacity(0.7f) };
            }

            public override void ResizeTo(float val, int duration = 0, Easing easing = Easing.None)
            {
                Vector2 size = new Vector2(SCROLL_BAR_HEIGHT)
                {
                    [(int)ScrollDirection] = val
                };
                this.ResizeTo(size, duration, easing);
            }
        }
    }
}
