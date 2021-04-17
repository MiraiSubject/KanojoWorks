using KanojoWorks.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osuTK;

namespace KanojoWorksEditor.Overlays
{
    public class AddDecisionOverlay : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(new Container
            {
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.Black,
                        Alpha = 0.5f
                    },
                    new Container
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Padding = new MarginPadding { Horizontal = 50 },
                        Child = new FillFlowContainer
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Direction = FillDirection.Vertical,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Children = new Drawable[]
                            {
                                new OverlayDropdownContainer
                                {
                                    Title = "Name",
                                    Child = new KanojoWorksDropdown<string>
                                    {
                                        RelativeSizeAxes = Axes.X,
                                        Items = new string[] { "yeet" }
                                    }
                                },
                                new OverlayDropdownContainer
                                {
                                    Title = "Target",
                                    Child = new KanojoWorksDropdown<string>
                                    {
                                        RelativeSizeAxes = Axes.X,
                                        Items = new string[] { "XD" }
                                    }
                                }
                            }
                        }
                    },
                    new Container
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Origin = Anchor.BottomCentre,
                        Anchor = Anchor.BottomCentre,
                        Padding = new MarginPadding { Bottom = 50 },
                        Child = new FillFlowContainer
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Direction = FillDirection.Horizontal,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Spacing = new Vector2(5),
                            Children = new Drawable[]
                            {
                                new SpriteText
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Text = "Hello"
                                },
                                new SpriteText
                                {
                                    Anchor = Anchor.Centre,
                                    Origin = Anchor.Centre,
                                    Text = "World"
                                }
                            }
                        }
                    }
                }
            });
        }

        private class OverlayDropdownContainer : Container
        {
            private SpriteText titleSprite;

            public LocalisableString Title
            {
                get => titleSprite?.Text ?? default;
                set
                {
                    if (titleSprite != null)
                        titleSprite.Text = value;
                }
            }

            private Container container;
            protected override Container<Drawable> Content => container;

            public OverlayDropdownContainer()
            {
                RelativeSizeAxes = Axes.X;
                AutoSizeAxes = Axes.Y;
                Padding = new MarginPadding { Vertical = 10 };
                InternalChild = new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Y,
                    RelativeSizeAxes = Axes.X,
                    Spacing = new Vector2(5),
                    Children = new Drawable[]
                    {
                        titleSprite = new SpriteText
                        {
                            Text = "null"
                        },
                        container = new Container
                        {
                            AutoSizeAxes = Axes.Y,
                            RelativeSizeAxes = Axes.X
                        }
                    }
                };
            }
        }
    }
}
