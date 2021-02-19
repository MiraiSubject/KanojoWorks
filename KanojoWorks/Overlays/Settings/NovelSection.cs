using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using KanojoWorks.Novel.UserInterface;
using KanojoWorks.Graphics;
using osuTK;

namespace KanojoWorks.Overlays.Settings
{
    public class NovelSection : SettingsSection
    {
        public NovelSection()
        {
            SectionName = "NOVEL";
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
                    Text = "Change character volumes...",
                    Size = new Vector2(250, 40),
                    BackgroundColour = Colour4.FromHex("#00000066"),
                }
            };
        }
    }
}
