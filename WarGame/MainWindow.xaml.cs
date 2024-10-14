using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WarGame.Classes;
using WarGame.Interfaces;

namespace WarGameCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        private int _roundNumber;
        public MainWindow()
        {
            InitializeComponent();
            _game = new Game(new Deck(), new List<IPlayer>() { new Player("Mantas"), new Player("Vidmantas") }, new Rules());
            _roundNumber = 0;
            _game.DealingCards();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ++_roundNumber;
            if (_roundNumber <= 26)
            {
                var results = _game.PlayRound(_roundNumber);
                

                string fullRound = "";
                foreach (var item in results)
                {
                    fullRound += item + "\n";
                }
                TextBlock1.Text = fullRound;
                TextBlockHistory.Text = fullRound + "--------\n" + TextBlockHistory.Text ;
            }

            if(_roundNumber == 26)
            {
                for (int i = 5; i > 0; i--)
                {
                    TextBlockWinner.Text = "asdasdasd";//$"{i}...";
                    Thread.Sleep(700);
                }

                TextBlockWinner.Text = _game.WhoWin()[0];
                TextBlockWinner.Background = Brushes.Yellow;
                Button1.IsEnabled = false;
            }
        }
    }
}