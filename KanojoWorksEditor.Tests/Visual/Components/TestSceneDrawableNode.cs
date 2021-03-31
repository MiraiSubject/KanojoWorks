using KanojoWorksEditor.Components;
using osu.Framework.Testing;

namespace KanojoWorksEditor.Tests.Visual.Components
{
    public class TestSceneDrawableNode : TestScene
    {
        public TestSceneDrawableNode()
        {
            Child = new DrawableNode();
        }
    }
}
