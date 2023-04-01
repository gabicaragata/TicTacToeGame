using System;
using System.Windows;
using TicTacGame.WindowsApp.ViewModels;

namespace TicTacGame.WindowsApp.Views
{
    public partial class InputPlayerNameDialog : Window
    {
        public InputPlayerNameDialog()
        {
            InitializeComponent();
            var viewModel = DataContext as InputPlayerNameDialogViewModel;
            viewModel.CloseDialog = new Action(() => Close());
        }
    }
}