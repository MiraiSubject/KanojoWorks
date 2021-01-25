using osu.Framework.Platform;
using osu.Framework;
using ExampleNovel.Game;

namespace ExampleNovel.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"ExampleNovel"))
            using (osu.Framework.Game game = new ExampleNovelGame())
                host.Run(game);
        }
    }
}
