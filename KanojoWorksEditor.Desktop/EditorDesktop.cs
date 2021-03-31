using osu.Framework.Platform;

namespace KanojoWorksEditor.Desktop
{
    internal class EditorDesktop : KanojoWorksEditor
    {
        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            var window = (SDL2DesktopWindow)host.Window;
            window.Title = Name;
        }
    }
}
