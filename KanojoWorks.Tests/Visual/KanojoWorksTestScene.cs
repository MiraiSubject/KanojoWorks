using System;
using System.IO;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Testing;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;
using KanojoWorks.Configuration;

namespace KanojoWorks.Tests.Visual
{
    public abstract class KanojoWorksTestScene : TestScene
    {
        protected override Container<Drawable> Content => content ?? base.Content;
        private Container content;
        private Lazy<Storage> localStorage;
        protected Storage LocalStorage => localStorage.Value;
        protected KanojoWorksConfigManager configManager;
        private DependencyContainer dependencies;
        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        {
            RecycleLocalStorage();
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
            dependencies.CacheAs<KanojoWorksConfigManager>(configManager = new KanojoWorksConfigManager(LocalStorage));
            return dependencies;
        }

        protected KanojoWorksTestScene()
        {
            base.Content.Add(content = new DrawSizePreservingFillContainer());
        }

        [BackgroundDependencyLoader]
        private void load()
        {
        }

        public virtual void RecycleLocalStorage()
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
