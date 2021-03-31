using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using KanojoWorks.Screens;

namespace KanojoWorksEditor
{
    public class KanojoWorksEditor : KanojoWorksEditorBase
    {
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            Content.Child = screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both };
            screenStack.Push(new EngineLoader(new ExampleScreen()));

        }

        private class ExampleScreen : KanojoWorksScreen
        {
            public ExampleScreen()
            {
                AddRangeInternal(new Drawable[]
                {
                    new Container
                    {
                        RelativeSizeAxes = Axes.X,
                        Anchor = Anchor.BottomCentre,
                        Origin = Anchor.BottomCentre,
                        Height = 50,
                        Children = new Drawable[]
                        {
                            new Box
                            {
                                RelativeSizeAxes = Axes.Both,
                                Colour = Colour4.Red
                            },
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Anchor = Anchor.CentreLeft,
                                Origin = Anchor.CentreLeft,
                                Children = new Drawable[]
                                {
                                    new FillFlowContainer
                                    {
                                        Spacing = new osuTK.Vector2(10),
                                        
                                    }
                                }
                            }
                        }
                    }
                });
            }
        }
    }
}
