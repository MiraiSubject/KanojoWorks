using osu.Framework;
using osu.Framework.Platform;

namespace KanojoWorksEditor.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost("visual-tests"))
            using (var game = new KanojoWorksEditorTestBrowser())
                host.Run(game);
        }
    }
}
