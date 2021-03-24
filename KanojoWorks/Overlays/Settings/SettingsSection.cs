using KanojoWorks.Graphics;
using KanojoWorks.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osuTK;

namespace KanojoWorks.Overlays.Settings
{
    public class SettingsSection : Container
    {
        protected override Container<Drawable> Content => flowContent;
        protected Container Header;
        private readonly FillFlowContainer flowContent;
        private readonly SpriteText spriteText;

        public LocalisableString SectionName
        {
            get => spriteText?.Text ?? default;
            set
            {
                if (spriteText != null)
                    spriteText.Text = value;
            }
        }

        public SettingsSection()
        {
            RelativeSizeAxes = Axes.Y;

            int headerFontSize = 36;
            AddRangeInternal(new Drawable[]
            {
                new KanojoWorksScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Child = new FillFlowContainer
                    {
                        AutoSizeAxes = Axes.Both,
                        Direction = FillDirection.Vertical,
                        Spacing = new Vector2(10),
                        Children = new Drawable[]
                        {
                            Header = new Container
                            {
                                AutoSizeAxes = Axes.Y,
                                RelativeSizeAxes = Axes.X,
                                Masking = true,
                                Child = spriteText = new SpriteText
                                {
                                    Spacing = new Vector2(2),
                                    Height = headerFontSize,
                                    Font = KanojoWorksFont.GetFont(size: headerFontSize, weight: FontWeight.Light)
                                }
                            },
                            flowContent = new FillFlowContainer
                            {
                                AutoSizeAxes = Axes.Both,
                                Direction = FillDirection.Vertical,
                                Spacing = new Vector2(30),
                            }
                        }
                    }
                }
            });
        }

        protected class SettingsName : SpriteText
        {
            public SettingsName()
            {
                Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light);
            }
        }
    }
}
