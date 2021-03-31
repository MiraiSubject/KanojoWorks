using System;
using osu.Framework;
using osu.Framework.Platform;

namespace KanojoWorksEditor.Desktop
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using (GameHost host = Host.GetSuitableHost(@"KanojoWorksEditor"))
            using (Game game = new EditorDesktop())
                host.Run(game);
        }
    }
}
