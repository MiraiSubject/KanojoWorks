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
        public FixedResContainer NovelContent { get; private set; }
        protected Storage Storage { get; set; }
        protected KanojoWorksConfigManager ConfigManager;

        /// <summary>
        /// The desired target resolution for the visual novel.
        /// </summary>
        protected virtual Vector2 TargetResolution => new Vector2(1280, 720);

        /// <summary>
        /// Whether a drawable can be displayed behind the Novel Content Container.
        /// </summary>
        public readonly BindableBool CanDisplayBackgroundDrawable = new BindableBool();

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        protected KanojoWorksGameBase()
        {
            // Container for UI Screens like Menu's or background screens. 
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = TargetResolution
            });
        }

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager frameworkConfig)
        {
            var kwResources = new NamespacedResourceStore<byte[]>(new DllResourceStore(typeof(KanojoWorksGameBase).Assembly), @"Resources");
            Resources.AddStore(kwResources);

            AddFont(Resources, @"Fonts/OpenSans/OpenSans-Regular");
            AddFont(Resources, @"Fonts/OpenSans/OpenSans-Light");

            dependencies.CacheAs(this);
            Storage ??= Host.Storage;
            dependencies.CacheAs(Storage);
            dependencies.CacheAs(ConfigManager = new KanojoWorksConfigManager(Storage));

            base.Content.AddRange(new Drawable[]
            {
                // Pixel based scaling container for the visual novel/other content in-game.
                NovelContent = new FixedResContainer
                {
                    Size = TargetResolution,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
            });

            CanDisplayBackgroundDrawable.BindTo(NovelContent.CanDisplayBackgroundDrawable);
        }
    }
}
