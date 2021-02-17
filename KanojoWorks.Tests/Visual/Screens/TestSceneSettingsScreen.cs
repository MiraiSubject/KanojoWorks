using osu.Framework.Input.Events;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using KanojoWorks.Graphics;
using KanojoWorks.Screens;
using KanojoWorks.Themes.Basic;
using KanojoWorks.Novel.UserInterface;
using osuTK;

namespace KanojoWorks.Tests.Visual.Screens
{
    public class TestSceneSettingsScreen : KanojoWorksTestScene
    {
        private BufferedContainer buffered;
        private VisibilityContainer settingsContainer;
        private MainMenu mainMenu;
        public TestSceneSettingsScreen()
        {
            Children = new Drawable[]
            {
                buffered = new BufferedContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Child = new ScreenStack(mainMenu = new BasicMainMenu()),
                    Depth = float.MaxValue
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
                            BlurSigma = new osuTK.Vector2(5),
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
                                    Alpha = 0.5f,
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
                                new SettingsSection
                                {
                                    SectionName = "VIDEO",
                                    Children = new Drawable[]
                                    {
                                        new SpriteText
                                        {
                                            Text = "Resolution",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Window Mode",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Scaling Mode",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Frame Limiter",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Threading Mode",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                    }
                                },
                                new SettingsSection
                                {
                                    SectionName = "AUDIO",
                                    Children = new Drawable[]
                                    {
                                        new SpriteText
                                        {
                                            Text = "Master Volume",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Music Volume",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "SFX Volume",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                    }
                                },
                                new SettingsSection
                                {
                                    SectionName = "NOVEL",
                                    Children = new Drawable[]
                                    {
                                        new SpriteText
                                        {
                                            Text = "Text Display Speed",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Auto Play Speed",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Skip Unread Text",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new SpriteText
                                        {
                                            Text = "Mark Read Text",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                        new KanojoWorksButton
                                        {
                                            //Width = 1000,
                                            Text = "Change character volumes...",
                                            Size = new Vector2(250, 40),
                                            BackgroundColour = Colour4.FromHex("#00000066"),
                                        }
                                    }
                                },
                                new SettingsSection
                                {
                                    SectionName = "DEBUG",
                                    Children = new Drawable[]
                                    {
                                        new SpriteText
                                        {
                                            Text = "Log Overlay",
                                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                                        },
                                    }
                                }
                            },
                        },
                    }
                },
            };

            settingsContainer.Show();
        }

        public class SettingsContainer : OverlayContainer
        {

            /// <summary>
            /// Whether mouse input should be blocked screen-wide while this overlay is visible.
            /// Performing mouse actions outside of the valid extents will hide the overlay.
            /// </summary>
            public virtual bool BlockScreenWideMouse => BlockPositionalInput;

            // receive input outside our bounds so we can trigger a close event on ourselves.
            public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => BlockScreenWideMouse || base.ReceivePositionalInputAt(screenSpacePos);

            protected override void PopIn()
            {
                this.MoveToY(0, 600, Easing.OutQuint);
                this.FadeInFromZero(300, Easing.In);
            }

            protected override void PopOut()
            {
                this.MoveToY(360, 600, Easing.OutQuint);
                this.FadeOut(300, Easing.Out);
            }

            private bool closeOnMouseUp;

            protected override bool OnMouseDown(MouseDownEvent e)
            {
                closeOnMouseUp = !base.ReceivePositionalInputAt(e.ScreenSpaceMousePosition);

                return base.OnMouseDown(e);
            }

            protected override void OnMouseUp(MouseUpEvent e)
            {
                if (closeOnMouseUp && !base.ReceivePositionalInputAt(e.ScreenSpaceMousePosition))
                    Hide();

                base.OnMouseUp(e);
            }

        }

        public class SettingsSection : Container
        {
            protected override Container<Drawable> Content => flowContent;
            private FillFlowContainer flowContent;
            private SpriteText spriteText;
            public string SectionName
            {
                get => spriteText?.Text;
                set
                {
                    if (spriteText != null)
                        spriteText.Text = value;
                }
            }
            public SettingsSection()
            {
                AutoSizeAxes = Axes.Both;
                AddRangeInternal(new Drawable[]
                {
                    new FillFlowContainer
                    {
                        RelativeSizeAxes = Axes.Y,
                        AutoSizeAxes = Axes.X,
                        Direction = FillDirection.Vertical,
                        Spacing = new Vector2(30),
                        Children = new Drawable[]
                        {
                            spriteText = new SpriteText
                            {
                                Spacing = new osuTK.Vector2(2),
                                Font = KanojoWorksFont.GetFont(size: 36, weight: FontWeight.Light)
                            },
                            flowContent = new FillFlowContainer
                            {
                                AutoSizeAxes = Axes.Both,
                                Direction = FillDirection.Vertical,
                                Spacing = new Vector2(30),
                            }
                        }
                    }
                });
            }
        }
    }
}
