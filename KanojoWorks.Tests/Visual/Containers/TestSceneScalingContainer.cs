using KanojoWorks.Configuration;
using KanojoWorks.Graphics.Containers;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osuTK;

namespace KanojoWorks.Tests.Visual.Containers
{
    public class TestSceneScalingContainer : KanojoWorksTestScene
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            Children = new Drawable[]
            {
                new ScalingContainer(ScalingMode.NoScaling)
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Child = new ScalingContainer(ScalingMode.MaintainAspectRatio)
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Child = new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = Colour4.Red
                        }
                    }
                },
                new Container
                {
                    Width = 300,
                    Height = 400,
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Padding = new MarginPadding(10),
                    Children = new Drawable[]
                    {
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Y,
                            RelativeSizeAxes = Axes.X,
                            Anchor = Anchor.TopCentre,
                            Origin = Anchor.TopCentre,
                            Spacing = new Vector2(10),
                            Direction = FillDirection.Vertical,
                            Children = new Drawable[]
                            {
                                new BasicSliderBar<float>
                                {
                                    Height = 12,
                                    RelativeSizeAxes = Axes.X,
                                    BackgroundColour = Colour4.Pink,
                                    SelectionColour = Colour4.DeepPink,
                                    Current = ConfigManager.GetBindable<float>(KanojoWorksSetting.Scale)
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
