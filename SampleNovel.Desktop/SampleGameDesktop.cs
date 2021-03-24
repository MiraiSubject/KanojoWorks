using osu.Framework.Platform;

namespace SampleNovel.Desktop
{
    internal class SampleGameDesktop : SampleNovelGame
    {
        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            var window = (SDL2DesktopWindow)host.Window;
            window.Title = Name;
        }
    }
}
