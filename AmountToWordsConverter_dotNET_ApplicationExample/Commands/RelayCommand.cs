using System.Windows.Input;

namespace NumberToWordsConverter_ApplicationExample.Commands
{
    public sealed class RelayCommand : ICommand
    {
        private readonly Action execute;

        public RelayCommand(Action execute)
        {
            ArgumentNullException.ThrowIfNull(execute);
            this.execute = execute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => execute();
    }
}
