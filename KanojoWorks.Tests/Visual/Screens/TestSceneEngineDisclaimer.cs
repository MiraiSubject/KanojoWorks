using osu.Framework.Graphics;
using osu.Framework.Screens;
using KanojoWorks.Screens;

namespace KanojoWorks.Tests.Visual.Screens
{
    public class TestSceneEngineDisclaimer : KanojoWorksTestScene
    {
        private ScreenStack screenStack;
        public TestSceneEngineDisclaimer()
        {
            Child = screenStack = new ScreenStack()
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };

            screenStack.Push(new EngineLoader());
        }
    }
}
