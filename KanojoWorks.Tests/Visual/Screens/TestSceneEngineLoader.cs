using System.Linq;
using System.Threading;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osu.Framework.Testing;
using KanojoWorks.Graphics.UserInterface;
using KanojoWorks.Screens;

namespace KanojoWorks.Tests.Visual.Screens
{
    public class TestSceneEngineLoader : KanojoWorksTestScene
    {
        private TestEngineLoader loader;
        private ScreenStack screenStack;
        public TestSceneEngineLoader()
        {
            Child = screenStack = new ScreenStack
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            };
        }

        [Test]
        public void TestDelayedLoad()
        {
            AddStep("begin loading", () => screenStack.Push(loader = new TestEngineLoader()));
            AddUntilStep("wait for indicator visible", () => loader.indicator?.Alpha > 0);
            AddStep("finish loading", () => loader.AllowLoad.Set());
            AddUntilStep("indicator gone", () => loader.indicator?.Alpha == 0);
            AddUntilStep("loaded", () => loader.ScreenLoaded);
            AddUntilStep("not current", () => !loader.IsCurrentScreen());
        }


        private class TestEngineLoader : EngineLoader
        {
            public readonly ManualResetEventSlim AllowLoad = new ManualResetEventSlim();
            private KanojoWorksScreen screen;
            public LoadingIndicator indicator => this.ChildrenOfType<LoadingIndicator>().FirstOrDefault();
            public bool ScreenLoaded => screen.IsCurrentScreen();
            protected override KanojoWorksScreen CreateLoadableScreen() => screen = new EngineDisclaimer(new TestScreen());
            protected override ShaderPrecompiler CreateShaderPrecompiler() => new TestShaderPrecompiler(AllowLoad);

            private class TestShaderPrecompiler : ShaderPrecompiler
            {
                private readonly ManualResetEventSlim allowLoad;
                public TestShaderPrecompiler(ManualResetEventSlim allowLoad)
                {
                    this.allowLoad = allowLoad;
                }

                protected override bool AllLoaded => allowLoad.IsSet;
            }

            private class TestScreen : KanojoWorksScreen
            {
                public TestScreen()
                {
                    InternalChild = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.FromHex("ea005e")
                    };
                }
            }
        }
    }
}
