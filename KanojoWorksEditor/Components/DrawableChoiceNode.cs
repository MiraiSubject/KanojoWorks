using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace KanojoWorksEditor.Components
{
    public class DrawableChoiceNode : DrawableNode
    {
        private FillFlowContainer choiceContent;

        [BackgroundDependencyLoader]
        private void load()
        {
            Content.AddRange(new Drawable[]
            {
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    Direction = FillDirection.Vertical,
                    Children = new Drawable[]
                    {
                        choiceContent = new FillFlowContainer
                        {
                            Direction = FillDirection.Vertical,
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Padding = new MarginPadding(10),
                            Spacing = new Vector2(5),
                            Children = new Drawable[]
                            {
                                new DecisionEntry(),
                                new DecisionEntry(),
                                new DecisionEntry(),
                                new DecisionEntry()
                            }
                        },
                        new Container
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Child = new AddDecisionContainer
                            {
                                Action = () => choiceContent.Add(new DecisionEntry())
                            }
                        }
                    }
                }
            });
        }

        private class AddDecisionContainer : ClickableContainer
        {
            public AddDecisionContainer()
            {
                RelativeSizeAxes = Axes.X;
                Height = 30;
                Child = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = Colour4.Red
                        },
                        new SpriteIcon
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Size = new Vector2(20),
                            Icon = FontAwesome.Solid.Plus
                        }
                    }
                };
            }
        }

        private class DecisionEntry : Container
        {
            public DecisionEntry()
            {
                RelativeSizeAxes = Axes.X;
                AutoSizeAxes = Axes.Y;
                Children = new Drawable[]
                {
                    new SpriteText
                    {
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Text = "Decision Name"
                    },
                    new Box
                    {
                        Anchor = Anchor.CentreRight,
                        Origin = Anchor.CentreRight,
                        Size = new Vector2(10),
                        Colour = Colour4.White
                    }
                };
            }
        }
    }
}
