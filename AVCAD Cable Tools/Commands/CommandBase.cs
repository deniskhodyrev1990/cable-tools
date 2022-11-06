using System;
using System.Windows.Input;

namespace AVCAD.Commands
{
    /// <summary>
    /// Abstract class for commands that implements ICommand interface.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// I always permit this in the software for now.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Abstract method to overrid.
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object? parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
