using osu.Framework.Graphics;
using KanojoWorks.Graphics.UserInterface;

namespace KanojoWorks.Tests.Visual.UserInterface
{
    public class TestSceneKanojoWorksDropdown : KanojoWorksTestScene
    {
        public TestSceneKanojoWorksDropdown()
        {
            var itemsToAdd = 10;
            var testItems = new string[itemsToAdd];
            int i = 0;
            while (i < itemsToAdd)
                testItems[i] = @"test " + i++;

            Child = new KanojoWorksDropdown<string>
            {
                Width = 150,
                Position = new osuTK.Vector2(50, 50),
                Items = testItems
            };
        }
    }
}
