using KanojoWorks.Configuration;
using KanojoWorks.Graphics.Containers;
using NUnit.Framework;
using osu.Framework.Allocation;
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

        [BackgroundDependencyLoader]
        private void load()
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
                    content.Show();
                else
                    content.Hide();
            });
        }

        [Test]
        public void TestMaintainAspectRatio()
        {
            AddStep("Change scaling mode to maintain aspect ratio", () => ConfigManager.Set(KanojoWorksSetting.ScalingMode, ScalingMode.MaintainAspectRatio));
        }

        [Test]
        public void TestStretch()
        {
            AddStep("Change scaling mode to stretch", () => ConfigManager.Set(KanojoWorksSetting.ScalingMode, ScalingMode.Stretch));
        }

        [Test]
        public void NoScaling()
        {
            AddStep("Change scaling mode to no scaling", () => ConfigManager.Set(KanojoWorksSetting.ScalingMode, ScalingMode.NoScaling));
        }
    }
}
