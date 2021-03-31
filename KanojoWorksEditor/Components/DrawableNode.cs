using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;

namespace KanojoWorksEditor.Components
{
    public class DrawableNode : CompositeDrawable
    {
        public string NodeTitle
        {
            get => nodeTitle.Text.ToString();
            set => nodeTitle.Text = value;
        }

        private SpriteText nodeTitle;

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new Container
                {
                    AutoSizeAxes = Axes.Y,
                    Width = 100,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = Colour4.Gray
                        },
                        new Container
                        {
                            Padding = new MarginPadding(10),
                            Children = new Drawable[]
                            {
                                nodeTitle = new SpriteText
                                {
                                    Anchor = Anchor.TopLeft,
                                    Origin = Anchor.TopLeft,
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}
