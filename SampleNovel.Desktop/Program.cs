using System;
using osu.Framework;
using osu.Framework.Platform;

namespace SampleNovel.Desktop
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using (GameHost host = Host.GetSuitableHost(@"SampleNovel"))
            using (Game game = new SampleGameDesktop())
                host.Run(game);
        }
    }
}
