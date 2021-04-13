using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osuTK;

namespace KanojoWorksEditor.Components
{
    public class DrawableNode : CompositeDrawable
    {
        public string NodeTitle
        {
            get => nodeTitle.Text.ToString();
            set => nodeTitle.Text = $"{value} ({ToString()})";
        }

        protected Container Content { get; private set; }

        protected Container Header { get; private set; }

        private SpriteText nodeTitle;

        [BackgroundDependencyLoader]
        private void load()
        {
            Width = 300;
            AutoSizeAxes = Axes.Y;
            AddRangeInternal(new Drawable[]
            {
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Direction = FillDirection.Vertical,
                    Children = new Drawable[]
                    {
                        Header = new HeaderContainer
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            DragEvent = (e) => this.MoveToOffset(e.Delta),
                            Children = new Drawable[]
                            {
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Colour4.Gray
                                },
                                new Container
                                {
                                    RelativeSizeAxes = Axes.X,
                                    AutoSizeAxes = Axes.Y,
                                    Padding = new MarginPadding(10),
                                    Children = new Drawable[]
                                    {
                                        nodeTitle = new SpriteText
                                        {
                                            Anchor = Anchor.CentreLeft,
                                            Origin = Anchor.CentreLeft,
                                        },
                                        new Box
                                        {
                                            Size = new Vector2(10),
                                            Anchor = Anchor.CentreRight,
                                            Origin = Anchor.CentreRight
                                        }
                                    }
                                }
                            }
                        },
                        Content = new Container
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Children = new Drawable[]
                            {
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Colour4.DarkSlateBlue,
                                }
                            }
                        }
                    }
                }
            });
        }

        private class HeaderContainer : Container
        {
            public Action<DragEvent> DragEvent;
            protected override bool OnDragStart(DragStartEvent e) => true;

            protected override void OnDrag(DragEvent e)
            {
                base.OnDrag(e);
                DragEvent?.Invoke(e);
            }
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            NodeTitle = "Node Name";
        }
    }
}
