using KanojoWorks.Themes.Basic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace KanojoWorks.Tests.Visual.Themes.Basic
{
    public class TestSceneBasicMainMenu : KanojoWorksTestScene
    {
        [BackgroundDependencyLoader]
        private void load()
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
