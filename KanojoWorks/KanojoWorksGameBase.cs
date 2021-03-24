using KanojoWorks.Configuration;
using KanojoWorks.Graphics.Containers;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using osuTK;

namespace KanojoWorks
{
    public class KanojoWorksGameBase : Game
    {
        public FixedResContainer NovelContent { get; private set; }

        /// <summary>
        /// The name of your visual novel.
        /// This automatically sets the window title and relevant headers to the name of your game.
        /// </summary>
        public string GameName
        {
            get => Name;
            set => Name = value;
        }

        protected DrawSizePreservingFillContainer DrawSizePreservingFillContent { get; private set; }
        protected Storage Storage { get; set; }
        protected KanojoWorksConfigManager ConfigManager;
        protected override Container<Drawable> Content { get; }

        /// <summary>
        /// The desired target resolution for the visual novel.
        /// </summary>
        protected virtual Vector2 TargetResolution => new Vector2(1280, 720);

        /// <summary>
        /// Whether a drawable can be displayed behind the Novel Content Container.
        /// </summary>
        public readonly BindableBool CanDisplayBackgroundDrawable = new BindableBool();

        private DependencyContainer dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        protected KanojoWorksGameBase()
        {
            // Set up a default title as a visual reminder for a consumer to change it.
            GameName = "My new visual novel";

            // Container for UI Screens like Menu's or background screens.
            base.Content.Add(Content = new DrawSizePreservingFillContainer());
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            var kwResources = new NamespacedResourceStore<byte[]>(new DllResourceStore(typeof(KanojoWorksGameBase).Assembly), @"Resources");
            Resources.AddStore(kwResources);

            AddFont(Resources, @"Fonts/OpenSans/OpenSans-Regular");
            AddFont(Resources, @"Fonts/OpenSans/OpenSans-Light");

            dependencies.CacheAs(this);
            dependencies.CacheAs(Storage);
            dependencies.CacheAs(ConfigManager = new KanojoWorksConfigManager(Storage));

            DrawSizePreservingFillContent = (DrawSizePreservingFillContainer)Content;

            base.Content.AddRange(new Drawable[]
            {
                // Resolution based scaling container for the visual novel/other content in-game.
                NovelContent = new FixedResContainer
                {
                    Size = TargetResolution,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
            });

            CanDisplayBackgroundDrawable.BindTo(NovelContent.CanDisplayBackgroundDrawable);
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            Storage ??= Host.Storage;
        }
    }
}
