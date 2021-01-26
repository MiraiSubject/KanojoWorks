
using osu.Framework;
using osu.Framework.Graphics.Containers;
using osuTK;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace KanojoWorks
{
    public class KanojoWorksGameBase : Game
    {
        protected override Container<Drawable> Content { get; }

        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        protected KanojoWorksGameBase()
        {
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
                TargetDrawSize = new Vector2(1366, 768)
            });
        }
    }
}
