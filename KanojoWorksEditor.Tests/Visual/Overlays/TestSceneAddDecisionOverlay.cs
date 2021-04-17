using KanojoWorksEditor.Overlays;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;

namespace KanojoWorksEditor.Tests.Visual.Overlays
{
    public class TestSceneAddDecisionOverlay : TestScene
    {
        public TestSceneAddDecisionOverlay()
        {
            Child = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.LightGray
                    },
                    new AddDecisionOverlay
                    {
                        RelativeSizeAxes = Axes.Both
                    }
                }
            };
        }
    }
}
