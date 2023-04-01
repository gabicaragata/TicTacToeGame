using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TicTacGame.WindowsApp.Views
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            SetAboutInfo();
        }

        private void SetAboutInfo()
        {
            txtStudentName.Text = "Gabriel Caragata";
            txtEmail.Text = "gabriel.caragata@student.unitbv.ro";
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtProjectDescription.Text = "This project is a simple Tic Tac Toe game developed in C# WPF using the MVVM pattern.";
        }
    }
}
