using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;

namespace KanojoWorks.Graphics.UserInterface
{
    public class KanojoWorksButton : ControllableButton
    {
        protected override Container<Drawable> Content { get; }
        protected Box HoverArea;
        protected Box Background;
        private readonly SpriteText spriteText;

        public LocalisableString Text
        {
            get => spriteText?.Text ?? default;
            set
            {
                if (spriteText != null)
                    spriteText.Text = value;
            }
        }

        private Colour4 backgroundColour;

        public Colour4 BackgroundColour
        {
            get => backgroundColour;
            set
            {
                backgroundColour = value;
                Background.FadeColour(value);
            }
        }

        public Colour4 TextColour
        {
            get => spriteText?.Colour ?? Colour4.Black;
            set
            {
                if (spriteText != null)
                    spriteText.Colour = value;
            }
        }

        public KanojoWorksButton()
        {
            Height = 40;

            AddInternal(Content = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    Background = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    HoverArea = new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Alpha = 0,
                        Colour = Colour4.White.Opacity(.1f),
                        Blending = BlendingParameters.Additive
                    },
                    spriteText = new SpriteText
                    {
                        Depth = -1,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Font = KanojoWorksFont.GetFont()
                    }
                }
            });

            Enabled.BindValueChanged(enabledChanged, true);
            Enabled.ValueChanged += enabledChanged;

            Selected.ValueChanged += selectionChanged;
        }

        private void selectionChanged(ValueChangedEvent<bool> value)
        {
            if (value.NewValue)
                HoverArea.FadeIn(200, Easing.OutQuint);
            else
                HoverArea.FadeOut(200, Easing.Out);
        }

        protected override bool OnClick(ClickEvent e)
        {
            Content.ScaleTo(0.95f, 100, Easing.OutQuint).Then().ScaleTo(1, 1000, Easing.OutElastic);
            return base.OnClick(e);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            Content.ScaleTo(0.95f, 4000, Easing.OutQuint);
            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            if (Selected.Value)
                Content.ScaleTo(1, 1000, Easing.OutElastic);

            base.OnMouseUp(e);
        }

        private void enabledChanged(ValueChangedEvent<bool> e)
        {
            this.FadeColour(e.NewValue ? Colour4.White : Colour4.Gray, 200, Easing.OutQuint);
        }
    }
}
