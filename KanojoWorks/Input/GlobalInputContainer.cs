using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using osu.Framework.Input.Bindings;

namespace KanojoWorks.Input
{
    public class GlobalInputContainer : KeyBindingContainer<InputAction>
    {
        public GlobalInputContainer()
            : base(matchingMode: KeyCombinationMatchingMode.Modifiers)
        {
        }

        public override IEnumerable<IKeyBinding> DefaultKeyBindings => ControllerKeyBindings.Concat(KeyboardKeyBindings);

        public IEnumerable<KeyBinding> ControllerKeyBindings => new[]
        {
            // A button on Xbox / Cross on PS
            new KeyBinding(InputKey.Joystick2, InputAction.Select),

            // B button on Xbox / Circle on PS
            new KeyBinding(InputKey.Joystick3, InputAction.Back),

            // X button on Xbox / Square on PS
            new KeyBinding(InputKey.Joystick1, InputAction.AutoPlay),

            // Y button on Xbox / Triangle on PS
            new KeyBinding(InputKey.Joystick4, InputAction.ContextMenu),

            // Left Bumper
            new KeyBinding(InputKey.Joystick5, InputAction.HideDialoguePanel),

            // Right Bumper
            new KeyBinding(InputKey.Joystick6, InputAction.HoldSkip),

            // Left Trigger
            new KeyBinding(InputKey.JoystickAxis3Positive, InputAction.ToggleSkip),

            // Right trigger
            new KeyBinding(InputKey.JoystickAxis6Positive, InputAction.ToggleSkip),

            // Dpads
            new KeyBinding(InputKey.JoystickHat1Up, InputAction.Up),
            new KeyBinding(InputKey.JoystickHat1Down, InputAction.Down),
            new KeyBinding(InputKey.JoystickHat1Left, InputAction.Left),
            new KeyBinding(InputKey.JoystickHat1Right, InputAction.Right),

            // Left stick
            new KeyBinding(InputKey.JoystickAxis2Negative, InputAction.Up),
            new KeyBinding(InputKey.JoystickAxis2Positive, InputAction.Down),
            new KeyBinding(InputKey.JoystickAxis1Positive, InputAction.Left),
            new KeyBinding(InputKey.JoystickAxis1Negative, InputAction.Right),
        };

        public IEnumerable<KeyBinding> KeyboardKeyBindings => new[]
        {
            new KeyBinding(InputKey.Enter , InputAction.Select),
            new KeyBinding(InputKey.Space, InputAction.Select),
            new KeyBinding(InputKey.BackSpace, InputAction.HideDialoguePanel),
            new KeyBinding(InputKey.Control, InputAction.HoldSkip),
            new KeyBinding(InputKey.Escape, InputAction.Back),
            new KeyBinding(InputKey.F4, InputAction.QuickSave),
            new KeyBinding(InputKey.F5, InputAction.QuickLoad),
            new KeyBinding(InputKey.Up, InputAction.Up),
            new KeyBinding(InputKey.Down, InputAction.Down),
            new KeyBinding(InputKey.Left, InputAction.Left),
            new KeyBinding(InputKey.Right, InputAction.Right),
        };
    }

    public enum InputAction
    {
        [Description("Up")]
        Up,

        [Description("Down")]
        Down,

        [Description("Left")]
        Left,

        [Description("Right")]
        Right,

        [Description("Primary Input")]
        Select,

        [Description("Back")]
        Back,

        [Description("Auto Play")]
        AutoPlay,

        [Description("Hold Skip")]
        HoldSkip,

        [Description("Toggle Skip")]
        ToggleSkip,

        [Description("Context Menu")]
        ContextMenu,

        [Description("Hide Text")]
        HideDialoguePanel,

        [Description("Quick Load Menu")]
        QuickLoad,

        [Description("Quick Save Menu")]
        QuickSave,

        [Description("Backlog screen")]
        Backlog,

        [Description("Skip to next scene")]
        NextScene,

        [Description("Go back to previous choice")]
        PreviousChoice,

        [Description("Save Menu")]
        SaveMenu,

        [Description("Load Menu")]
        LoadMenu,
    }
}
