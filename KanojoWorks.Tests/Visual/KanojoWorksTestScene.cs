using osu.Framework.Testing;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace KanojoWorks.Tests.Visual
{
    public abstract class KanojoWorksTestScene : TestScene
    {
        protected override Container<Drawable> Content => content ?? base.Content;
        private Container content;

        protected KanojoWorksTestScene()
        {
            base.Content.Add(content = new DrawSizePreservingFillContainer());
        }
    }
}
