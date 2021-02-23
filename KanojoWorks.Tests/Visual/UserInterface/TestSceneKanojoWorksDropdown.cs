using KanojoWorks.Graphics.UserInterface;

namespace KanojoWorks.Tests.Visual.UserInterface
{
    public class TestSceneKanojoWorksDropdown : KanojoWorksTestScene
    {
        public TestSceneKanojoWorksDropdown()
        {
            const int items_to_add = 10;
            var testItems = new string[items_to_add];
            int i = 0;
            while (i < items_to_add)
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
