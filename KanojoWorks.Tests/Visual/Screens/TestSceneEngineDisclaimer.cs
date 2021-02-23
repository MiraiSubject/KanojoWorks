using KanojoWorks.Screens;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace KanojoWorks.Tests.Visual.Screens
{
    public class TestSceneEngineDisclaimer : KanojoWorksTestScene
    {
        public TestSceneEngineDisclaimer()
        {
            ScreenStack screenStack;
            Child = screenStack = new ScreenStack
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            };

            screenStack.Push(new EngineLoader());
        }
    }
}
