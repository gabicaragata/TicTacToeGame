using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace TicTacGame.WindowsApp.ViewModels
{
    public class InputPlayerNameDialogViewModel : ViewModelBase
    {
        private string _playerName;

        public string PlayerName
        {
            get => _playerName;
            set => SetProperty(ref _playerName, value);
        }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public Action<bool?> CloseDialog { get; set; }

        public InputPlayerNameDialogViewModel()
        {
            OkCommand = new RelayCommand(OkButtonClicked);
            CancelCommand = new RelayCommand(CancelButtonClicked);
        }

        private void OkButtonClicked(object obj)
        {
            // Add your logic for handling the "OK" button click event here

            // Close the dialog and set the DialogResult to true
            CloseDialog?.Invoke(true);
        }

        private void CancelButtonClicked(object obj)
        {
            // Add your logic for handling the "Cancel" button click event here

            // Close the dialog and set the DialogResult to false
            CloseDialog?.Invoke(false);
        }
    }
}
