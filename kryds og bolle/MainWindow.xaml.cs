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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kryds_og_bolle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void rck_btn_Click(object sender, RoutedEventArgs e)
        {
            Ai("rock", 0);
        }

        private void sks_btn_Click(object sender, RoutedEventArgs e)
        {
            Ai("scissors", 3);
        }

        private void ppr_btn_Click(object sender, RoutedEventArgs e)
        {
            Ai("paper", 4);
        }

        private void lzrd_btn_Click(object sender, RoutedEventArgs e)
        {
            Ai("lizard", 1);
        }

        private void spk_btn_Click(object sender, RoutedEventArgs e)
        {
            Ai("spock", 2);
        }
        public void Ai(string img, int playerplay)
        {
            play_img.Source = new BitmapImage(new Uri(@"imgs/" + @img + @".png", UriKind.Relative));
            string aiimg = "";
            int aiplay = new Random().Next(0, 5);
            switch (aiplay)
            {
                case 0:
                    aiimg = "rock";
                    break;
                case 3:
                    aiimg = "scissors";
                    break;
                case 4:
                    aiimg = "paper";
                    break;
                case 1:
                    aiimg = "lizard";
                    break;
                case 2:
                    aiimg = "spock";
                    break;
            }
            ai_img.Source = new BitmapImage(new Uri(@"imgs/" + @aiimg + @".png", UriKind.Relative));
            if (playerplay == 0 && (aiplay == 1 || aiplay == 3))
            {
                // add point
                score++;
            }
            else if (playerplay == 1 && (aiplay == 2 || aiplay == 4))
            {
                // add point
                score++;
            }
            else if (playerplay == 2 && (aiplay == 3 || aiplay == 0))
            {
                // add point
                score++;
            }
            else if (playerplay == 3 && (aiplay == 4 || aiplay == 1))
            {
                // add point
                score++;
            }
            else if (playerplay == 4 && (aiplay == 0 || aiplay == 2))
            {
                // add point
                score++;
            }
            else
            {
                // delete point
                score = 0;
            }
            point.Content = point.Content.ToString().Split(' ')[0] + " " + score;
        }
    }
}
