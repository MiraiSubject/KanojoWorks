using System;
using System.IO;
using KanojoWorks.Configuration;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace KanojoWorks.Tests.Visual
{
    public abstract class KanojoWorksTestScene : TestScene
    {
        protected override Container<Drawable> Content => content ?? base.Content;
        private readonly Container content;
        private Lazy<Storage> localStorage;
        protected Storage LocalStorage => localStorage.Value;
        protected KanojoWorksConfigManager ConfigManager;
        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        {
            RecycleLocalStorage();
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
            dependencies.CacheAs(ConfigManager = new KanojoWorksConfigManager(LocalStorage));
            return dependencies;
        }

        protected KanojoWorksTestScene()
        {
            base.Content.Add(content = new DrawSizePreservingFillContainer());
        }

        public void RecycleLocalStorage()
        {
            if (localStorage?.IsValueCreated == true)
            {
                try
                {
                    localStorage.Value.DeleteDirectory(".");
                }
                catch
                {
                    // we don't really care if this fails; it will just leave folders lying around from test runs.
                }
            }

            localStorage =
                new Lazy<Storage>(() => new NativeStorage(Path.Combine(RuntimeInfo.StartupDirectory, $"{GetType().Name}-{Guid.NewGuid()}")));
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            RecycleLocalStorage();
        }
    }
}
