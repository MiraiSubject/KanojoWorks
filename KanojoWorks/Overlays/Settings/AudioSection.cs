using KanojoWorks.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace KanojoWorks.Overlays.Settings
{
    public class AudioSection : SettingsSection
    {
        public AudioSection()
        {
            Padding = new MarginPadding { Right = 100 };
            SectionName = "AUDIO";
            Header.Add(new SpriteText
            {
                Text = "SELECT AUDIO DEVICE",
                X = 5,
                Anchor = Anchor.BottomRight,
                Font = KanojoWorksFont.GetFont(size: 16, weight: FontWeight.Bold)
            });

            Children = new Drawable[]
            {
                new SpriteText
                {
                    Text = "Master Volume",
                    Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light),
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
            };
        }
    }
}
