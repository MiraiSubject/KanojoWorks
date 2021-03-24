using System.Collections.Generic;
using System.Linq;
using KanojoWorks.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shaders;
using osu.Framework.Screens;
using osu.Framework.Threading;

namespace KanojoWorks.Screens
{
    public class EngineLoader : KanojoWorksScreen
    {
        private LoadingIndicator loadingIndicator;
        private KanojoWorksScreen loadableScreen;
        private ScheduledDelegate indicatorShow;
        private readonly KanojoWorksScreen nextScreen;
        private ShaderPrecompiler precompiler;
        protected virtual KanojoWorksScreen CreateLoadableScreen() => new EngineDisclaimer(nextScreen);
        protected virtual ShaderPrecompiler CreateShaderPrecompiler() => new ShaderPrecompiler();

        public EngineLoader(KanojoWorksScreen next = null)
        {
            ValidForResume = false;

            if (next != null)
                nextScreen = next;
        }

        public override void OnEntering(IScreen last)
        {
            base.OnEntering(last);
            LoadComponentAsync(loadingIndicator = new LoadingIndicator
            {
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding(20)
            }, _ =>
            {
                AddInternal(loadingIndicator);
                indicatorShow = Scheduler.AddDelayed(loadingIndicator.Show, 200);
            });

            LoadComponentAsync(precompiler = CreateShaderPrecompiler(), AddInternal);
            LoadComponentAsync(loadableScreen = CreateLoadableScreen());

            checkIfLoaded();
        }

        private void checkIfLoaded()
        {
            if (loadableScreen == null || !precompiler.FinishedCompiling)
            {
                Schedule(checkIfLoaded);
                return;
            }

            indicatorShow?.Cancel();

            if (loadingIndicator.State.Value == Visibility.Visible)
            {
                loadingIndicator.Hide();
                Scheduler.AddDelayed(() => this.Push(loadableScreen), LoadingIndicator.TRANSITION_DURATION);
            }
            else
                this.Push(loadableScreen);
        }

        public class ShaderPrecompiler : Drawable
        {
            private readonly List<IShader> loadTargets = new List<IShader>();

            public bool FinishedCompiling { get; private set; }

            [BackgroundDependencyLoader]
            private void load(ShaderManager manager)
            {
                loadTargets.Add(manager.Load(VertexShaderDescriptor.TEXTURE_2, FragmentShaderDescriptor.BLUR));
                loadTargets.Add(manager.Load(VertexShaderDescriptor.TEXTURE_2, FragmentShaderDescriptor.TEXTURE));
            }

            protected virtual bool AllLoaded => loadTargets.All(s => s.IsLoaded);

            protected override void Update()
            {
                base.Update();

                // if our target is null we are done.
                if (AllLoaded)
                {
                    FinishedCompiling = true;
                    Expire();
                }
            }
        }
    }
}
