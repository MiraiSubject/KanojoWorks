using KanojoWorks.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;
using osuTK;

namespace KanojoWorks.Overlays.Settings
{
    public class SettingsContainer : FocusedOverlayContainer
    {
        protected override void PopIn()
        {
            this.MoveToY(0, 600, Easing.OutQuint);
            this.FadeInFromZero(300, Easing.In);
        }

        protected override void PopOut()
        {
            this.MoveToY(360, 600, Easing.OutQuint);
            this.FadeOut(300, Easing.Out);
        }

        // Source: https://github.com/ppy/osu/blob/335af0476427c3992d37f16b106c1c364d298b33/osu.Game/Graphics/Containers/OsuFocusedOverlayContainer.cs#L74
        // See also FocusedOverlayContainer.
        // This logic was put here because consumers might want to control the overlay focus differently in a Novel context.
        private bool closeOnMouseUp;

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            closeOnMouseUp = !base.ReceivePositionalInputAt(e.ScreenSpaceMousePosition);

            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            if (closeOnMouseUp && !base.ReceivePositionalInputAt(e.ScreenSpaceMousePosition))
                Hide();

            base.OnMouseUp(e);
        }

        // Source: https://github.com/ppy/osu/blob/335af0476427c3992d37f16b106c1c364d298b33/osu.Game/Graphics/Containers/OsuFocusedOverlayContainer.cs#L67

        /// <summary>
        /// Whether mouse input should be blocked screen-wide while this overlay is visible.
        /// Performing mouse actions outside of the valid extents will hide the overlay.
        /// </summary>
        public virtual bool BlockScreenWideMouse => BlockPositionalInput;

        // receive input outside our bounds so we can trigger a close event on ourselves.
        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => BlockScreenWideMouse || base.ReceivePositionalInputAt(screenSpacePos);
    }
}
