using System;
using System.Linq;
using KanojoWorks.Graphics.UserInterface;
using KanojoWorks.Input;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Bindings;

namespace KanojoWorks.Graphics.Containers
{
    /// <summary>
    /// A <see cref="osu.Framework.Graphics.Containers.FillFlowContainer{T}"/> that has built-in selection
    /// and control support for keyboard and controller.
    /// </summary>
    public class ControllableFillFlowContainer<T> : FillFlowContainer<T>, IKeyBindingHandler<InputAction>
        where T : ControllableButton
    {
        private int selectionIndex = -1;

        /// <summary>
        /// Whether <see cref="KanojoWorks.Graphics.Containers.ControllableFillFlowContainer{T}"/> should highlight the first button by default.
        /// </summary>
        public bool FirstIsHighlighted = false;

        private bool wrapsButtons = true;

        /// <summary>
        /// Whether <see cref="KanojoWorks.Graphics.Containers.ControllableFillFlowContainer{T}"/> should wrap the buttons for selection.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public bool WrapsButtons
        {
            get => wrapsButtons;
            set
            {
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse - Reason: Incorrect analysis
                if (!FirstIsHighlighted && !value)
                    throw new InvalidOperationException($"Cannot disable wrapping if {nameof(FirstIsHighlighted)} is {value}");

                wrapsButtons = value;
            }
        }

        /// <summary>
        /// Action that is invoked when <see cref="InputAction.Select"/> is triggered.
        /// </summary>
        protected Action SelectAction => () => Children.FirstOrDefault(s => s.Selected.Value)?.Click();

        private void setSelected(int value)
        {
            if (selectionIndex == value)
                return;

            if (selectionIndex != -1)
                this[selectionIndex].Selected.Value = false;

            selectionIndex = value;

            if (selectionIndex != -1)
                this[selectionIndex].Selected.Value = true;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            if (FirstIsHighlighted)
                setSelected(0);
        }

        /// <summary>
        /// Deselect all <see cref="KanojoWorks.Graphics.UserInterface.ControllableButton"/>
        /// in a <see cref="KanojoWorks.Graphics.Containers.ControllableFillFlowContainer{T}"/>
        /// </summary>
        public void Deselect() => setSelected(-1);

        /// <summary>
        /// Select a <see cref="KanojoWorks.Graphics.UserInterface.ControllableButton"/>
        /// in a <see cref="KanojoWorks.Graphics.Containers.ControllableFillFlowContainer{T}"/>
        /// </summary>
        public void Select(T selected) => setSelected(IndexOf(selected));

        private bool horizontalSelect(InputAction action)
        {
            // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
            switch (action)
            {
                case InputAction.Left:
                    selectPrevious();
                    return true;

                case InputAction.Right:
                    selectNext();
                    return true;

                case InputAction.Select:
                    SelectAction.Invoke();
                    return true;
            }

            return false;
        }

        private bool verticalSelect(InputAction action)
        {
            switch (action)
            {
                case InputAction.Up:
                    selectPrevious();
                    return true;

                case InputAction.Down:
                    selectNext();
                    return true;

                case InputAction.Select:
                    SelectAction.Invoke();
                    return true;
            }

            return false;
        }

        private void selectNext()
        {
            if ((selectionIndex == -1 || selectionIndex == Count - 1))
            {
                if (wrapsButtons)
                    setSelected(0);
            }
            else
                setSelected(selectionIndex + 1);
        }

        private void selectPrevious()
        {
            if (selectionIndex == -1 || selectionIndex == 0)
            {
                if (wrapsButtons)
                    setSelected(Count - 1);
            }
            else
                setSelected(selectionIndex - 1);
        }

        public bool OnPressed(InputAction action)
        {
            switch (Direction)
            {
                case FillDirection.Horizontal:
                    return horizontalSelect(action);

                case FillDirection.Vertical:
                    return verticalSelect(action);

                default:
                    return false;
            }
        }

        public void OnReleased(InputAction action)
        {
        }

        /// <summary>
        /// Select/Deselect buttons using <see cref="KanojoWorks.Graphics.UserInterface.ControllableButton.Selected"/> of <see cref="KanojoWorks.Graphics.UserInterface.ControllableButton"/>
        /// </summary>
        /// <param name="selection"> The <see cref="KanojoWorks.Graphics.UserInterface.ControllableButton"/>' that will be selected and deselected </param>
        /// <param name="isSelected">The selected boolean of the <see cref="KanojoWorks.Graphics.UserInterface.ControllableButton"/></param>
        /// <remarks>
        /// Use this only to bind to the <see cref="osu.Framework.Bindables.Bindable{T}.ValueChanged" />
        /// of a <see cref="KanojoWorks.Graphics.UserInterface.ControllableButton"/>
        /// </remarks>
        public void ButtonSelectionChanged(T selection, bool isSelected)
        {
            if (!isSelected)
                Deselect();
            else
                Select(selection);
        }
    }
}
