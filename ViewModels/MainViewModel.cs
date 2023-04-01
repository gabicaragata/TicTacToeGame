using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TicTacGame.WindowsApp.Models;
using TicTacGame.WindowsApp.Views;

namespace TicTacGame.WindowsApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Game _game;
        public Game Game
        {
            get => _game;
            set => Set(ref _game, value);
        }

        public ICommand StartGameCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand AboutCommand { get; private set; }
        public ICommand CellClickCommand { get; private set; }

        public MainViewModel()
        {
            StartGameCommand = new RelayCommand(StartGame);
            ExitCommand = new RelayCommand(Exit);
            AboutCommand = new RelayCommand(ShowAbout);
            CellClickCommand = new RelayCommand<string>(CellClick);
            Game = new Game();
        }

        private void StartGame()
        {
            var playerNameDialog = new InputPlayerNameDialog();
            if (playerNameDialog.ShowDialog() == true)
            {
                Game.PlayerName = playerNameDialog.PlayerName;
                Game.PlayerSymbol = playerNameDialog.PlayerSymbol;
                Game.ComputerSymbol = Game.PlayerSymbol == "X" ? "O" : "X";
                //Game.InitializeBoard();
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void ShowAbout()
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
        private void ShowInputPlayerNameDialog()
        {
            var inputPlayerNameDialog = new InputPlayerNameDialog();
            if (inputPlayerNameDialog.ShowDialog() == true)
            {
                // Retrieve the entered player name from the dialog's ViewModel
                var playerName = (inputPlayerNameDialog.DataContext as InputPlayerNameDialogViewModel).PlayerName;

                // Use the player name as needed, e.g., initialize the game or update the UI
            }
        }

        private async void CellClick(object parameter)
        {
            if (parameter is string cellCoordinates)
            {
                var splitCoordinates = cellCoordinates.Split(' ');
                if (splitCoordinates.Length == 2 &&
                    int.TryParse(splitCoordinates[0], out int row) &&
                    int.TryParse(splitCoordinates[1], out int column))
                {
                    if (Game.MakeMove(row, column, Game.PlayerSymbol))
                    {
                        if (Game.CheckWin())
                        {
                            MessageBox.Show($"{Game.PlayerName}, you won!");
                            StartGame();
                            return;
                        }

                        if (Game.CheckDraw())
                        {
                            MessageBox.Show("It's a tie!");
                            StartGame();
                            return;
                        }

                        await Task.Delay(1000);
                        var computerMove = Game.GetComputerMove();
                        Game.MakeMove(computerMove.Item1, computerMove.Item2, Game.ComputerSymbol);

                        if (Game.CheckWin())
                        {
                            MessageBox.Show("You lost!");
                            StartGame();
                            return;
                        }

                        if (Game.CheckDraw())
                        {
                            MessageBox.Show("It's a tie!");
                            StartGame();
                        }
                    }
                }
            }
        }
    }
}
