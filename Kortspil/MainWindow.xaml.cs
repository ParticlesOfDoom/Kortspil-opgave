using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kortspil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Kortene er hentet fra https://acbl.mybigcommerce.com/52-playing-cards/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int kortnummer = Convert.ToInt32(Kort.Text);
            string filnavn = FindBillede(kortnummer);
            string url = $"/Billeder/{filnavn}";
            Uri uri = new(url, UriKind.Relative);
            BitmapImage image = new(uri);

            Billede.Source = image;

        }

        private string FindBillede(int kortnummer)
        {

            string kortType;
            int kortID;
            string kortNavn;

            if (kortnummer < 1 || kortnummer > 52)
            {
                return "Red_back.jpg";
            }
            else
            {
                if (kortnummer >= 1 && kortnummer <= 13)
                {
                    kortType = "Spar";
                }
                else if (kortnummer >= 14 && kortnummer <= 26)
                {
                    kortType = "Ruder";
                }
                else if (kortnummer >= 27 && kortnummer <= 39)
                {
                    kortType = "Klør";
                }
                else
                {
                    kortType = "Hjerter";
                }
                kortID = (kortnummer - 1) % 13 + 1;

                switch (kortID)
                {
                    case 1:
                        kortNavn = "Es";
                        break;
                    case 11:
                        kortNavn = "Knægt";
                        break;
                    case 12:
                        kortNavn = "Dame";
                        break;
                    case 13:
                        kortNavn = "Konge";
                        break;
                    default:
                        kortNavn = Convert.ToString(kortID);
                        break;
                }
                return kortNavn + "-" + kortType + ".jpg";
            }
        }
    }
}
