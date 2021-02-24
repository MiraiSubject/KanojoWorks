using KanojoWorks.Configuration;
using KanojoWorks.Graphics.Containers;
using NUnit.Framework;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;

namespace KanojoWorks.Tests.Visual.Containers
{
    // This visual test might not look as expected considering the FixedResContainer relies on window size.
    // The test container != window size so horizontally resizing will look weird.
    public class TestSceneFixedResContainer : KanojoWorksTestScene
    {
        protected override Container<Drawable> Content => content ?? base.Content;
        private Container content;
        private FixedResContainer fixedResContainer;
        private readonly BindableBool canDisplayBackground = new BindableBool();

        [SetUp]
        public void Setup() => Schedule(() =>
        {
            base.Content.AddRange(new Drawable[]
            {
                content = new DrawSizePreservingFillContainer
                {
                    TargetDrawSize = new Vector2(1280, 720),
                    Alpha = 0,
                    Child = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = Colour4.Gray
                    }
                },
                fixedResContainer = new FixedResContainer
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(640, 480),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = Colour4.DarkSlateBlue
                        },
                        new SpriteText
                        {
                            Text = "KanojoWorks",
                            Font = new FontUsage(size: 72),
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre
                        }
                    }
                }
            });

            canDisplayBackground.BindTo(fixedResContainer.CanDisplayBackgroundDrawable);

            canDisplayBackground.BindValueChanged(t =>
            {
                if (t.NewValue)
                    content.FadeIn(5000, Easing.In);
                else
                    content.FadeOut(5000, Easing.Out);
            });
        });

        [Test]
        public void TestMaintainAspectRatio()
        {
            AddStep("Change scaling mode to maintain aspect ratio", () => ConfigManager.Set(KanojoWorksSetting.ScalingMode, ScalingMode.MaintainAspectRatio));
        }

        [Test]
        public void TestStretch()
        {
            AddStep("Change scaling mode to stretch", () => ConfigManager.Set(KanojoWorksSetting.ScalingMode, ScalingMode.Stretch));
            AddAssert("Background bindable is off", () => !canDisplayBackground.Value);
        }

        [Test]
        public void NoScaling()
        {
            AddStep("Change scaling mode to no scaling", () => ConfigManager.Set(KanojoWorksSetting.ScalingMode, ScalingMode.NoScaling));
            AddStep("Force background display off", () => canDisplayBackground.Value = false);
            AddAssert("Background bindable is off", () => !canDisplayBackground.Value);

            AddStep("Force background display on", () => canDisplayBackground.Value = true);
            AddAssert("Background bindable is on", () => canDisplayBackground.Value);
        }
    }
}
