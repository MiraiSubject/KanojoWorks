using osu.Framework.Platform;

namespace SampleNovel.Desktop
{
    internal class SampleGameDesktop : SampleNovelGame
    {
        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            switch (host.Window)
            {
                case OsuTKDesktopWindow desktopGameWindow:
                    desktopGameWindow.Title = Name;
                    break;

                case SDL2DesktopWindow desktopWindow:
                    desktopWindow.Title = Name;
                    break;
            }
        }
    }
}