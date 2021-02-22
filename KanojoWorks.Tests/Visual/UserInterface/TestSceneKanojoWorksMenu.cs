using NUnit.Framework;
using osu.Framework.Graphics;
using KanojoWorks.Graphics.UserInterface;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics.Containers;

namespace KanojoWorks.Tests.Visual.UserInterface
{
    public class TestSceneKanojoWorksMenu : KanojoWorksManualInputManagerTestScene
    {
        private KanojoWorksMenu menu;
        private bool actionPerformed;

        [SetUp]
        public void SetUp() => Schedule(() =>
        {
            Child = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new osuTK.Vector2(500),
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.DarkGray
                    },
                    menu = new KanojoWorksMenu(Direction.Vertical, true)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Items = new[]
                        {
                            new MenuItem("option 1", performAction),
                            new MenuItem("option 2", performAction),
                            new MenuItem("option 3", performAction),
                        }
                    }
                }
            };
        });

        private void performAction() => actionPerformed = true;
    }
}
