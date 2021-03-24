using System;
using JetBrains.Annotations;
using KanojoWorks.Graphics;
using KanojoWorks.Graphics.UserInterface;
using KanojoWorks.Screens;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace KanojoWorks.Themes.Basic
{
    public class BasicMainMenu : MainMenu
    {
        private FillFlowContainer<MenuButton> buttonsContainer;

        /// <summary>
        /// The background color of the Main Menu of the aspect ratio is different.
        /// </summary>
        public Colour4 BackgroundColor = Colour4.Black;

        /// <summary>
        /// The background image of the Main Menu.
        /// </summary>
        public Texture BackgroundTexture;

        public FillMode BackgroundFillMode = FillMode.Fit;

        [Resolved(canBeNull:true)]
        [CanBeNull]
        private KanojoWorksGameBase gameBase { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = BackgroundColor
                },
                new Sprite
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = BackgroundFillMode,
                    Texture = BackgroundTexture,
                },
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding(30),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Anchor = Anchor.TopCentre,
                            Origin = Anchor.TopCentre,
                            Text = gameBase?.Name,
                            Colour = Colour4.White,
                            Font = KanojoWorksFont.GetFont(size: 40, weight: FontWeight.Bold)
                        },
                        buttonsContainer = new FillFlowContainer<MenuButton>
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Padding = new MarginPadding(100),
                            Anchor = Anchor.BottomCentre,
                            Origin = Anchor.BottomCentre,
                            Direction = FillDirection.Horizontal,
                            Spacing = new Vector2(5),
                            Children = new[]
                            {
                                new MenuButton
                                {
                                    Text = "New Game",
                                    Action = OnNewGame
                                },
                                new MenuButton
                                {
                                    Text = "Load",
                                    Action = OnLoadGame,
                                    ButtonColor = Colour4.Red
                                },
                                new MenuButton
                                {
                                    Text = "Config",
                                    Action = OnSettings
                                },
                                new MenuButton
                                {
                                    Text = "Gallery",
                                    Action = OnGallery
                                },
                                new MenuButton
                                {
                                    Text = "Exit",
                                    Action = OnExit
                                },
                            }
                        },
                    }
                },
            });
        }

        public override void OnEntering(IScreen last)
        {
            base.OnEntering(last);

            this.FadeInFromZero(500);
        }

        protected void AddButton(string name, Action action) =>
            buttonsContainer.Add(new MenuButton
            {
                Text = name,
                Action = action
            });

        private class MenuButton : KanojoWorksButton
        {
            public Color4 ButtonColor = Colour4.FromHex("#00000066");

            public MenuButton()
            {
                Size = new Vector2(150, 40);
                BackgroundColour = ButtonColor;
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
            }
        }
    }
}
