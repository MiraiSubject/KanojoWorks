using KanojoWorks.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osuTK;

namespace KanojoWorks.Screens
{
    public class EngineDisclaimer : KanojoWorksScreen
    {
        private readonly KanojoWorksScreen nextScreen;
        private readonly TextFlowContainer textFlow;

        public EngineDisclaimer(KanojoWorksScreen nextScreen = null)
        {
            this.nextScreen = nextScreen;
            ValidForResume = false;

            InternalChildren = new Drawable[]
            {
                textFlow = new TextFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    TextAnchor = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Spacing = new Vector2(0, 10),
                    Alpha = 0
                }
            };

            textFlow.AddText("This game runs on the KanojoWorks engine built on osu!framework.", t => t.Font = KanojoWorksFont.GetFont(size: 30));
            textFlow.NewParagraph();
            textFlow.AddText("KanojoWorks is still a work in progress, so weirdness and bugs may occur.", t => t.Font = KanojoWorksFont.GetFont(size: 30));
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            if (nextScreen != null)
                LoadComponentAsync(nextScreen);
        }

        public override void OnEntering(IScreen last)
        {
            base.OnEntering(last);

            using (BeginDelayedSequence(5000))
                textFlow.MoveToOffset(new Vector2(0, 250), 1000, Easing.Out);

            textFlow.FadeInFromZero(500).Then(4500).FadeOut(250);
            this.FadeInFromZero(500).Then(5000).FadeOut(250)
                .Finally(d =>
                {
                    if (nextScreen != null)
                        this.Push(nextScreen);
                });
        }
    }
}
