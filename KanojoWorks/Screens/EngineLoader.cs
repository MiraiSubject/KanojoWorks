

using JetBrains.Annotations;
using KanojoWorks.Graphics.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osu.Framework.Threading;

namespace KanojoWorks.Screens
{
    public class EngineLoader : KanojoWorksScreen
    {
        private LoadingIndicator loadingIndicator;
        private KanojoWorksScreen loadableScreen;
        private ScheduledDelegate indicatorShow;
        protected virtual KanojoWorksScreen CreateLoadableScreen() => new EngineDisclaimer();

        public EngineLoader()
        {
            ValidForResume = false;
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

            LoadComponentAsync(loadableScreen = CreateLoadableScreen());
            checkIfLoaded();
        }

        private void checkIfLoaded()
        {
            if (loadableScreen.LoadState != LoadState.Ready)
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
    }
}
