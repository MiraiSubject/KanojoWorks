using KanojoWorksEditor.Components;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Testing;

namespace KanojoWorksEditor.Tests.Visual.Components
{
    public class TestSceneDrawableChoiceNode : TestScene
    {
        public TestSceneDrawableChoiceNode()
        {
            Child = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.LightBlue,
                    },
                    new DrawableChoiceNode()
                }
            };
        }
    }
}
