using KanojoWorks.Themes.Basic;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace KanojoWorks.Tests.Visual.Themes.Screens
{
    public class TestSceneBasicMainMenu : KanojoWorksTestScene
    {
        public TestSceneBasicMainMenu()
        {
            ScreenStack screenStack;
            Child = screenStack = new ScreenStack
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            };

            screenStack.Push(new BasicMainMenu());
        }
    }
}
