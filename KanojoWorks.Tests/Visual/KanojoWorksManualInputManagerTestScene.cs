using KanojoWorks.Graphics.UserInterface;
using KanojoWorks.Input;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing.Input;
using osuTK;

namespace KanojoWorks.Tests.Visual
{
    public abstract class KanojoWorksManualInputManagerTestScene : KanojoWorksTestScene
    {
        protected override Container<Drawable> Content => content;
        private readonly Container content;
        protected readonly ManualInputManager InputManager;

        private readonly KanojoWorksButton buttonTest;
        private readonly KanojoWorksButton buttonLocal;

        protected KanojoWorksManualInputManagerTestScene()
        {
            base.Content.AddRange(new Drawable[]
            {
                InputManager = new ManualInputManager
                {
                    UseParentInput = true,
                    Child = new GlobalInputContainer()
                        .WithChild(content = new DrawSizePreservingFillContainer())
                },
                new Container
                {
                    AutoSizeAxes = Axes.Both,
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    Margin = new MarginPadding(10),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Colour = Colour4.Black,
                            RelativeSizeAxes = Axes.Both,
                            Alpha = 0.5f
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Vertical,
                            Margin = new MarginPadding(5),
                            Spacing = new Vector2(5),
                            Children = new Drawable[]
                            {
                                new SpriteText
                                {
                                    Anchor = Anchor.TopCentre,
                                    Origin = Anchor.TopCentre,
                                    Text = "Input Priority"
                                },
                                new FillFlowContainer
                                {
                                    AutoSizeAxes = Axes.Both,
                                    Anchor = Anchor.TopCentre,
                                    Origin = Anchor.TopCentre,
                                    Margin = new MarginPadding(5),
                                    Spacing = new Vector2(5),
                                    Direction = FillDirection.Horizontal,
                                    Children = new Drawable[]
                                    {
                                        buttonLocal = new KanojoWorksButton
                                        {
                                            Text = "local",
                                            Size = new Vector2(50, 30),
                                            Masking = true,
                                            CornerRadius = 5,
                                            BackgroundColour = Colour4.BlueViolet,
                                            Action = returnUserInput
                                        },
                                        buttonTest = new KanojoWorksButton
                                        {
                                            Text = "test",
                                            Size = new Vector2(50, 30),
                                            Masking = true,
                                            CornerRadius = 5,
                                            BackgroundColour = Colour4.BlueViolet,
                                            Action = returnTestInput
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        protected override void Update()
        {
            base.Update();

            buttonTest.Enabled.Value = InputManager.UseParentInput;
            buttonLocal.Enabled.Value = !InputManager.UseParentInput;
        }

        private void returnUserInput() => InputManager.UseParentInput = true;

        private void returnTestInput() => InputManager.UseParentInput = false;
    }
}
