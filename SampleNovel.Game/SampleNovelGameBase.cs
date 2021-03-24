using KanojoWorks;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;

namespace SampleNovel
{
    public class SampleNovelGameBase : KanojoWorksGameBase
    {
        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        // A large texture store is required for textures that exceed the 1024x1024 atlas.
        // Examples are background images, CG and high resolution character sprites.
        protected LargeTextureStore LargeTextureStore;

        public SampleNovelGameBase()
        {
            GameName = "SampleNovel";
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            var r = new NamespacedResourceStore<byte[]>(new DllResourceStore(typeof(SampleNovelGameBase).Assembly), @"Resources");
            Resources.AddStore(r);

            LargeTextureStore = new LargeTextureStore(Host.CreateTextureLoaderStore(new NamespacedResourceStore<byte[]>(Resources, @"Textures")));
            dependencies.Cache(LargeTextureStore);
        }
    }
}
