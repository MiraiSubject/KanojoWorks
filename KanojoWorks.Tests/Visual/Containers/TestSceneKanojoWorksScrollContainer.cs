using KanojoWorks.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace KanojoWorks.Tests.Visual.Containers
{
    public class TestSceneKanojoWorksScrollContainer : KanojoWorksTestScene
    {
        public TestSceneKanojoWorksScrollContainer()
        {
            Child = new KanojoWorksScrollContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(100),
                Child = new Box { Size = new Vector2(100, 500), Colour = Colour4.Beige }
            };
        }
    }
}
