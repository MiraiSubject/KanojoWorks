using osu.Framework.Graphics;
using osu.Framework.Screens;
using KanojoWorks.Themes.Basic;

namespace KanojoWorks.Tests.Visual.Screens
{
    public class TestSceneBasicMainMenu : KanojoWorksTestScene
    {
        private ScreenStack screenStack;
        public TestSceneBasicMainMenu()
        {
            Child = screenStack = new ScreenStack()
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            };

            screenStack.Push(new BasicMainMenu());
        }
    }
}
