using osu.Framework.Graphics.Containers;
using osuTK;

namespace KanojoWorks.Graphics.Containers
{
    public abstract class FocusedOverlayContainer : OverlayContainer
    {
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
