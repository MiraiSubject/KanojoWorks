using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Input.Handlers.Mouse;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace KanojoWorksEditor.Tests
{
    public class KanojoWorksEditorTestBrowser : KanojoWorksEditorBase
    {
        protected override void LoadComplete()
        {
            base.LoadComplete();

            AddRange(new Drawable[]
            {
                new TestBrowser("KanojoWorksEditor"),
                new CursorContainer()
            });
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);

            var mouseHandler = host.AvailableInputHandlers.OfType<MouseHandler>().FirstOrDefault();

            if (mouseHandler != null)
                mouseHandler.UseRelativeMode.Value = false;

            //host.Window.CursorState |= CursorState.Hidden;
        }
    }
}