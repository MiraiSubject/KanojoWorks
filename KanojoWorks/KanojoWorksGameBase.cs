using System;
using System.Drawing;
using KanojoWorks.Graphics.Containers;
using KanojoWorks.Configuration;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using osuTK;

namespace KanojoWorks
{
    public class KanojoWorksGameBase : Game
    {
        private DependencyContainer dependencies;
        protected override Container<Drawable> Content { get; }
        protected Container<Drawable> nonScalingContent { get; private set; }
        protected Storage Storage { get; set; }
        protected KanojoWorksConfigManager ConfigManager;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        protected KanojoWorksGameBase()
        {
            // Container for UI Screens like Menu's or background screens. 
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = new Vector2(1280, 720)
            });
        }

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager frameworkConfig)
        {
            var kwResources = new NamespacedResourceStore<byte[]>(new DllResourceStore(typeof(KanojoWorksGameBase).Assembly), @"Resources");
            Resources.AddStore(kwResources);

            dependencies.CacheAs(this);
            Storage ??= Host.Storage;
            dependencies.CacheAs(Storage);
            dependencies.CacheAs(ConfigManager = new KanojoWorksConfigManager(Storage));

            base.Content.AddRange(new Drawable[]
            {
                // Pixel based scaling container for the visual novel/other content in-game.
                nonScalingContent = new FixedResContainer
                {
                    Size = new Vector2(1280, 720),
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
            });
        }
    }
}
