using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using KanojoWorks.Graphics;
using osuTK;

namespace KanojoWorks.Overlays.Settings
{
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

        protected Container Header;
        public SettingsSection()
        {
            RelativeSizeAxes = Axes.Y;
            AutoSizeAxes = Axes.X;
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
                        Header = new Container
                        {
                            AutoSizeAxes = Axes.Both,
                            Children = new Drawable[]
                            {
                                spriteText = new SpriteText
                                {
                                    Spacing = new osuTK.Vector2(2),
                                    Font = KanojoWorksFont.GetFont(size: 36, weight: FontWeight.Light)
                                },
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
            });
        }
    }
}
