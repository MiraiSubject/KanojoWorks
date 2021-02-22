using System;
using KanojoWorks.Graphics.UserInterface;
using KanojoWorks.Screens;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace KanojoWorks.Themes.Basic
{
    public class BasicMainMenu : MainMenu
    {
        private FillFlowContainer<MenuButton> buttonsContainer;

        [BackgroundDependencyLoader]
        private void load()
        {
            AddRangeInternal(new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Colour4.FromHex("#3F0222")
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
                            Text = "KanojoWorks",
                            Font = new FontUsage(size: 50)
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
                                    Action = OnLoadGame
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
            public MenuButton()
            {
                Size = new Vector2(150, 40);
                BackgroundColour = Colour4.FromHex("#00000066");
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
            }
        }
    }
}
