using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using KanojoWorks.Graphics;

namespace KanojoWorks.Overlays.Settings
{
    public class DebugSection : SettingsSection
    {
        public DebugSection()
        {
            SectionName = "DEBUG";
            Children = new Drawable[]
            {
                new SpriteText
                {
                    Text = "Log Overlay",
                    Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                },
            };

        }
    }
}
