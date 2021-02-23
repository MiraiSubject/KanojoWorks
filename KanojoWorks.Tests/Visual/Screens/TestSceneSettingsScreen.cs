using KanojoWorks.Overlays.Settings;
using KanojoWorks.Themes.Basic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;

namespace KanojoWorks.Tests.Visual.Screens
{
    public class TestSceneSettingsScreen : KanojoWorksTestScene
    {
        private BufferedContainer buffered;
        private VisibilityContainer settingsContainer;

        [BackgroundDependencyLoader]
        private void load()
        {
            Children = new Drawable[]
            {
                buffered = new BufferedContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Child = new ScreenStack(new BasicMainMenu()),
                },
                settingsContainer = new SettingsContainer
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    RelativeSizeAxes = Axes.X,
                    Height = 360,
                    Y = 360,
                    Children = new Drawable[]
                    {
                        new BufferedContainer
                        {
                            RelativeSizeAxes = Axes.Both,
                            BlurSigma = new Vector2(5),
                            Children = new Drawable[]
                            {
                                buffered.CreateView().With(d =>
                                {
                                    d.RelativeSizeAxes = Axes.Both;
                                    d.SynchronisedDrawQuad = true;
                                }),
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Colour4.FromHex("8E8E8E"),
                                    Alpha = 0.5f
                                },
                            }
                        },
                        new FillFlowContainer
                        {
                            Padding = new MarginPadding { Bottom = 0, Top = 15, Left = 15, Right = 15 },
                            Direction = FillDirection.Horizontal,
                            Spacing = new Vector2(20),
                            Children = new Drawable[]
                            {
                                new VideoSection(),
                                new AudioSection(),
                                new NovelSection(),
                                new DebugSection()
                            }
                        }
                    }
                }
            };

            settingsContainer.Show();
        }
    }
}
