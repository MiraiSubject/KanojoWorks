

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
        private KanojoWorksScreen nextScreen;
        protected virtual KanojoWorksScreen CreateLoadableScreen() => new EngineDisclaimer(nextScreen);

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
            
            // Artifical temporary delay to test out the loading screen. Will be removed once a proper test is created for this. 
            Scheduler.AddDelayed(() => LoadComponentAsync(loadableScreen = CreateLoadableScreen()), 2000);

            checkIfLoaded();
        }

        private void checkIfLoaded()
        {
            if (loadableScreen == null)
            {
                Schedule(checkIfLoaded);
                return;
            }

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
