using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;

namespace KanojoWorks
{
    public class TestBox : TestScene
    {
        public TestBox()
        {
            Add(new Container
            {
                RelativeSizeAxes = Axes.Both,
                Child = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colour4.Aqua
                }
            });
        }
    }
}
