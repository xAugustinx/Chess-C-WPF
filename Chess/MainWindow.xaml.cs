using System.Collections;
using System.Media;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
using Microsoft.Win32;

namespace Chees
{
    public partial class MainWindow : Window
    {

        public static int poprzedniPionek;
        public static List<int> poprzedniInt = new List<int> { 0, 0 };
        public static List<int> polozeniePoprzedniego = new List<int>();
        public static int powtorki;
        public static bool miusic = true;
        public static string runda = "white";
        public static int[,] numbers =
            {
                {11,12,13,14,15,13,12,11 },
                {10,10,10,10,10,10,10,10 },
                {99,99,99,99,99,99,99,99 },
                {99,99,99,99,99,99,99,99 },
                {99,99,99,99,99,99,99,99 },
                {99,99,99,99,99,99,99,99 },
                {00,00,00,00,00,00,00,00 },
                {01,02,03,04,05,03,02,01 }


            };
        private MediaPlayer MMplayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            

            render();
            this.Loaded += MainWindow_Loaded;
            List<Button> buttons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64 };
            foreach (Button button in buttons)
            {
                button.Margin = new Thickness(15);
            }

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MMplayer.Open(new System.Uri("2.mp3", System.UriKind.Relative));
            MMplayer.Volume = 0.04; // 3% głośności
            MMplayer.MediaEnded += MMplayer_MediaEnded;
            MMplayer.Play();
        }
        private void MMplayer_MediaEnded(object sender, EventArgs e)
        {
            MMplayer.Position = TimeSpan.Zero;
            MMplayer.Play();
        }
        private void meow(object sender, RoutedEventArgs e)
        {
            render();



            Button kliknietyPrzycisk = sender as Button;
            if (powtorki == 0)
            {
                clickChecker(kliknietyPrzycisk);
                string meow = numbers[poprzedniInt[0], poprzedniInt[1]].ToString();
                if (meow.Length == 1)
                {
                    meow = "0" + meow;
                }
                if (runda == "white" && meow[0] == '1' || runda == "black" && meow[0] == '0' || meow[0] == '9')
                {
                    MessageBox.Show("Narpiew Wybierz swoją figurę do ruchu");
                }
                else
                {
                    powtorki++;
                    polozeniePoprzedniego.Clear();
                    polozeniePoprzedniego.Add(poprzedniInt[0]);
                    polozeniePoprzedniego.Add(poprzedniInt[1]);
                    poprzedniPionek = numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]];

                }
            }
            else if (powtorki == 1)
            {
                clickChecker(kliknietyPrzycisk);
                string meow = numbers[poprzedniInt[0], poprzedniInt[1]].ToString();
                if (runda == "white" && meow[0] == '0' || runda == "black" && meow[0] == '1')
                {
                    powtorki = 0;
                }
                else
                {
                    int meow3 = numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]];
                    string meow2 = meow3.ToString();
                    if (meow2.Length == 1)
                    {
                        meow2 = "0" + meow2;
                    }

                    if (meow2[1] == '0')
                    {


                        if (polozeniePoprzedniego[0] == poprzedniInt[0] + 1 && runda == "white" || polozeniePoprzedniego[0] == poprzedniInt[0] - 1 && runda == "black")
                        {
                            if (polozeniePoprzedniego[1] == poprzedniInt[1])
                            {
                                if (numbers[poprzedniInt[0], polozeniePoprzedniego[1]] == 99)
                                {
                                    numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                    numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                    powtorki = 0;
                                    side2();
                                }
                                else
                                {
                                    powtorki = 0;
                                }

                            }
                            else if (polozeniePoprzedniego[1] != poprzedniInt[1])
                            {
                                if (numbers[poprzedniInt[0], poprzedniInt[1]] != 99)
                                {
                                    numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                    numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                    powtorki = 0;
                                    side2();
                                }


                            }

                        }
                        else if (runda == "white" && polozeniePoprzedniego[0] == 6)
                        {
                            if (polozeniePoprzedniego[0] == poprzedniInt[0] + 2 && polozeniePoprzedniego[1] == poprzedniInt[1])
                            {
                                numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                powtorki = 0;
                                side2();
                            }
                        }
                        else if (runda == "black" && polozeniePoprzedniego[0] == 1)
                        {
                            if (polozeniePoprzedniego[0] == poprzedniInt[0] - 2 && polozeniePoprzedniego[1] == poprzedniInt[1])
                            {
                                numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                powtorki = 0;
                                side2();
                            }
                        }
                    }
                    else if (meow2[1] == '1')
                    {
                        int licznikLokalnyuwu = 0;
                        int jedenUwU;
                        int dwaUwU;
                        int meowmeowUwUdebian = 0;
                        if (polozeniePoprzedniego[1] == poprzedniInt[1])
                        {
                            if (polozeniePoprzedniego[0] > poprzedniInt[0])
                            {
                                jedenUwU = poprzedniInt[0];
                                dwaUwU = polozeniePoprzedniego[0];
                            }
                            else
                            {
                                jedenUwU = polozeniePoprzedniego[0];
                                dwaUwU = poprzedniInt[0];

                            }
                            //licznikLokalnyuwu = dwaUwU = jedenUwU;
                            while (true)
                            {
                                jedenUwU++;
                                if (jedenUwU == dwaUwU)
                                {
                                    break;
                                }
                                if (numbers[jedenUwU, polozeniePoprzedniego[1]] != 99)
                                {
                                    licznikLokalnyuwu++;
                                }

                            }

                            if (licznikLokalnyuwu == 0)
                            {
                                numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                powtorki = 0;
                                side2();
                            }
                            else
                            {
                                meowmeowUwUdebian++;
                            }
                        }



                        licznikLokalnyuwu = 0;
                        jedenUwU = 0;
                        dwaUwU = 0;

                        if (polozeniePoprzedniego[0] == poprzedniInt[0])
                        {
                            if (polozeniePoprzedniego[1] > poprzedniInt[1])
                            {
                                jedenUwU = poprzedniInt[1];
                                dwaUwU = polozeniePoprzedniego[1];
                            }
                            else
                            {
                                jedenUwU = polozeniePoprzedniego[1];
                                dwaUwU = poprzedniInt[1];

                            }
                            //licznikLokalnyuwu = dwaUwU = jedenUwU;
                            while (true)
                            {
                                jedenUwU++;
                                if (jedenUwU == dwaUwU)
                                {
                                    break;
                                }
                                if (numbers[polozeniePoprzedniego[0], jedenUwU] != 99)
                                {
                                    licznikLokalnyuwu++;
                                }

                            }

                            if (licznikLokalnyuwu == 0)
                            {
                                numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                powtorki = 0;
                                side2();
                            }
                            else
                            {
                                meowmeowUwUdebian++;
                            }
                        }







                        if (meowmeowUwUdebian == 2)
                        {
                            powtorki = 0;
                        }
                    }

                    else if (meow2[1] == '2')
                    {
                        int[,] numbersMeow =
                        {
                            {-2, -1},
                            {2, 1},
                            {-2, 1},
                            {2, -1},
                            //meow
                            {-1,-2 },
                            {1,2 },
                            {1, -2},
                            {-1, 2 }
                        };

                        foreach (int i in new int[] { 0, 1, 2, 3, 4, 5, 6, 7 })
                        {
                            if (polozeniePoprzedniego[0] == poprzedniInt[0] + numbersMeow[i, 0] && polozeniePoprzedniego[1] == poprzedniInt[1] + numbersMeow[i, 1])
                            {
                                numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                powtorki = 0;
                                side2();
                            }
                        }

                    }
                    else if (meow2[1] == '3')
                    {
                        int jeden = polozeniePoprzedniego[0] - poprzedniInt[0];
                        int dwa = polozeniePoprzedniego[1] - poprzedniInt[1];

                        if (jeden < 0)
                        {
                            jeden = jeden - (jeden * 2);
                        }
                        if (dwa < 0)
                        {
                            dwa = dwa - (dwa * 2);
                        }

                        if (jeden == dwa)
                        {
                            int wybrany = 0;
                            int dodatkowyLicznik = 0;
                            int[,] meowNumbers9 =
                            {
                            {1,1},
                            {-1,-1},
                            {1,-1},
                            {-1, 1}
                            };
                            if (poprzedniInt[0] < polozeniePoprzedniego[0] && poprzedniInt[1] < polozeniePoprzedniego[1])
                            {
                                wybrany = 0;
                            }
                            else if (poprzedniInt[0] > polozeniePoprzedniego[0] && poprzedniInt[1] > polozeniePoprzedniego[1])
                            {
                                wybrany = 1;
                            }
                            else if (poprzedniInt[0] < polozeniePoprzedniego[0] && poprzedniInt[1] > polozeniePoprzedniego[1])
                            {
                                wybrany = 2;
                            }
                            else if (poprzedniInt[0] > polozeniePoprzedniego[0] && poprzedniInt[1] < polozeniePoprzedniego[1])
                            {
                                wybrany = 3;
                            }

                            int pierwszyWybrany = poprzedniInt[0];
                            int drugiWybrany = poprzedniInt[1];


                            while (true)
                            {
                                if (pierwszyWybrany == polozeniePoprzedniego[0])
                                {
                                    break;
                                }
                                pierwszyWybrany = pierwszyWybrany + meowNumbers9[wybrany, 0];
                                drugiWybrany = drugiWybrany + meowNumbers9[wybrany, 1];

                                if (numbers[pierwszyWybrany, drugiWybrany] != 99)
                                {
                                    if (pierwszyWybrany != polozeniePoprzedniego[0] && drugiWybrany != polozeniePoprzedniego[1])
                                    {
                                        dodatkowyLicznik++;
                                    }

                                }
                            }

                            if (dodatkowyLicznik == 0)
                            {
                                numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                side2();
                            }
                            else if (dodatkowyLicznik > 0)
                            {
                                powtorki = 0;
                            }






                        }

                    }
                    else if (meow2[1] == '4')
                    {
                        int fsdf = poprzedniInt[0] - polozeniePoprzedniego[0];
                        int licznikEEE = 0;
                        foreach (int i in new int[] { -1, 0, 1 })
                        {
                            foreach (int ii in new int[] { -1, 0, 1 })
                            {
                                if (polozeniePoprzedniego[0] == poprzedniInt[0] + i && polozeniePoprzedniego[1] == poprzedniInt[1] + ii)
                                {

                                    numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                    numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                    powtorki = 0;
                                    side2();
                                    if (numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] != 99)
                                    {
                                        side2();
                                    }

                                }
                            }
                        }


                    }
                    else if (meow2[1] == '5')
                    {
                        if (polozeniePoprzedniego[1] == poprzedniInt[1] || polozeniePoprzedniego[0] == poprzedniInt[0])
                        {
                            int licznikLokalnyuwu = 0;
                            int jedenUwU;
                            int dwaUwU;
                            int meowmeowUwUdebian = 0;
                            if (polozeniePoprzedniego[1] == poprzedniInt[1])
                            {
                                if (polozeniePoprzedniego[0] > poprzedniInt[0])
                                {
                                    jedenUwU = poprzedniInt[0];
                                    dwaUwU = polozeniePoprzedniego[0];
                                }
                                else
                                {
                                    jedenUwU = polozeniePoprzedniego[0];
                                    dwaUwU = poprzedniInt[0];

                                }
                                //licznikLokalnyuwu = dwaUwU = jedenUwU;
                                while (true)
                                {
                                    jedenUwU++;
                                    if (jedenUwU == dwaUwU)
                                    {
                                        break;
                                    }
                                    if (numbers[jedenUwU, polozeniePoprzedniego[1]] != 99)
                                    {
                                        licznikLokalnyuwu++;
                                    }

                                }

                                if (licznikLokalnyuwu == 0)
                                {
                                    numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                    numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                    powtorki = 0;
                                    side2();
                                }
                                else
                                {
                                    meowmeowUwUdebian++;
                                }
                            }



                            licznikLokalnyuwu = 0;
                            jedenUwU = 0;
                            dwaUwU = 0;

                            if (polozeniePoprzedniego[0] == poprzedniInt[0])
                            {
                                if (polozeniePoprzedniego[1] > poprzedniInt[1])
                                {
                                    jedenUwU = poprzedniInt[1];
                                    dwaUwU = polozeniePoprzedniego[1];
                                }
                                else
                                {
                                    jedenUwU = polozeniePoprzedniego[1];
                                    dwaUwU = poprzedniInt[1];

                                }
                                //licznikLokalnyuwu = dwaUwU = jedenUwU;
                                while (true)
                                {
                                    jedenUwU++;
                                    if (jedenUwU == dwaUwU)
                                    {
                                        break;
                                    }
                                    if (numbers[polozeniePoprzedniego[0], jedenUwU] != 99)
                                    {
                                        licznikLokalnyuwu++;
                                    }

                                }

                                if (licznikLokalnyuwu == 0)
                                {
                                    numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                    numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                    powtorki = 0;
                                    side2();
                                }
                                else
                                {
                                    meowmeowUwUdebian++;
                                }
                            }



                            if (meowmeowUwUdebian == 2)
                            {
                                powtorki = 0;
                            }
                        }
                        else
                        {
                            int jeden = polozeniePoprzedniego[0] - poprzedniInt[0];
                            int dwa = polozeniePoprzedniego[1] - poprzedniInt[1];

                            if (jeden < 0)
                            {
                                jeden = jeden - (jeden * 2);
                            }
                            if (dwa < 0)
                            {
                                dwa = dwa - (dwa * 2);
                            }

                            if (jeden == dwa)
                            {
                                int wybrany = 0;
                                int dodatkowyLicznik = 0;
                                int[,] meowNumbers9 =
                                {
                            {1,1},
                            {-1,-1},
                            {1,-1},
                            {-1, 1}
                            };
                                if (poprzedniInt[0] < polozeniePoprzedniego[0] && poprzedniInt[1] < polozeniePoprzedniego[1])
                                {
                                    wybrany = 0;
                                }
                                else if (poprzedniInt[0] > polozeniePoprzedniego[0] && poprzedniInt[1] > polozeniePoprzedniego[1])
                                {
                                    wybrany = 1;
                                }
                                else if (poprzedniInt[0] < polozeniePoprzedniego[0] && poprzedniInt[1] > polozeniePoprzedniego[1])
                                {
                                    wybrany = 2;
                                }
                                else if (poprzedniInt[0] > polozeniePoprzedniego[0] && poprzedniInt[1] < polozeniePoprzedniego[1])
                                {
                                    wybrany = 3;
                                }

                                int pierwszyWybrany = poprzedniInt[0];
                                int drugiWybrany = poprzedniInt[1];


                                while (true)
                                {
                                    if (pierwszyWybrany == polozeniePoprzedniego[0])
                                    {
                                        break;
                                    }
                                    pierwszyWybrany = pierwszyWybrany + meowNumbers9[wybrany, 0];
                                    drugiWybrany = drugiWybrany + meowNumbers9[wybrany, 1];

                                    if (numbers[pierwszyWybrany, drugiWybrany] != 99)
                                    {
                                        if (pierwszyWybrany != polozeniePoprzedniego[0] && drugiWybrany != polozeniePoprzedniego[1])
                                        {
                                            dodatkowyLicznik++;
                                        }

                                    }
                                }

                                if (dodatkowyLicznik == 0)
                                {
                                    numbers[polozeniePoprzedniego[0], polozeniePoprzedniego[1]] = 99;
                                    numbers[poprzedniInt[0], poprzedniInt[1]] = poprzedniPionek;
                                    side2();
                                }
                                else if (dodatkowyLicznik > 0)
                                {
                                    powtorki = 0;
                                }
                            }
                            else
                            {
                                powtorki = 0;
                            }
                        }
                    }






                }

            }
            render();
        }

        void side2()
        {
            if (runda == "white")
            {
                runda = "black";
            }
            else
            {
                runda = "white";
            }
        }

        void render()
        {
            bool niga = false;
            bool bialy = false;
            foreach (int i in numbers)
            {
                if (i == 4)
                {
                    bialy = true;
                }
                else if (i == 14)
                {
                    niga = true;
                }
            }
            if (bialy == false)
            {
                logo.Visibility = Visibility.Visible;
                Start.Visibility = Visibility.Visible;
                startButton.Visibility = Visibility.Visible;
                Audio.Visibility = Visibility.Visible;
                resetButton.Visibility = Visibility.Visible;
                MessageBox.Show("Gej ower biały");
                bialy = true;
            }
            else if (niga == false)
            {
                logo.Visibility = Visibility.Visible;
                Start.Visibility = Visibility.Visible;
                startButton.Visibility = Visibility.Visible;
                Audio.Visibility = Visibility.Visible;
                resetButton.Visibility = Visibility.Visible;
                MessageBox.Show("Gej ower niga");
                niga = true;
                
            }
            

                
            

            


            




            rundaT.Text = "Rudna: " + runda;
            powtorkiT.Text = "Powtórka: " + powtorki;
            int licznikLokalny = 0;
            List<Button> buttons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64 };
            foreach (int przycisk in numbers)
            {
                buttons[licznikLokalny].Content = przycisk;

                int licznikLokalny2 = 0;
                List<Uri> imageUris = new List<Uri>
                {
                    new Uri("pack://application:,,,/Chess;component/txt/99.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/black/0.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/black/1.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/black/2.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/black/3.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/black/4.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/black/5.png"),

                    new Uri("pack://application:,,,/Chess;component/txt/white/0.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/white/1.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/white/2.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/white/3.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/white/4.png"),
                    new Uri("pack://application:,,,/Chess;component/txt/white/5.png"),



                };
                List<int> meowMeow = new List<int> { 99, 10, 11, 12, 13, 14, 15, 0, 01, 02, 03, 04, 05 };

                foreach (int meow in meowMeow)
                {
                    if (meow == przycisk)
                    {
                        Uri uri = imageUris[licznikLokalny2];

                        // Tworzymy BitmapImage i przypisujemy go jako źródło dla ImageBrush
                        System.Windows.Media.ImageBrush imageBrush = new System.Windows.Media.ImageBrush();

                        imageBrush.ImageSource = new BitmapImage(uri);

                        // Przypisujemy pędzel do tła przycisku
                        buttons[licznikLokalny].Background = imageBrush;
                    }
                    licznikLokalny2++;
                }

                if (przycisk == 99)
                {
                    Uri uri = new Uri("pack://application:,,,/Chess;component/txt/99.png");

                    // Tworzymy BitmapImage i przypisujemy go jako źródło dla ImageBrush
                    System.Windows.Media.ImageBrush imageBrush = new System.Windows.Media.ImageBrush();

                    imageBrush.ImageSource = new BitmapImage(uri);

                    // Przypisujemy pędzel do tła przycisku
                    buttons[licznikLokalny].Background = imageBrush;

                }
                foreach (Button button in buttons)
                {
                    button.Content = "";
                }





                licznikLokalny++;

            }
        }

        void clickChecker(Button meow3)
        {

            List<Button> buttons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64 };
            poprzedniInt[0] = 0;
            poprzedniInt[1] = 0;
            int licznikLokalny = 0;
            while (true)
            {
                if (buttons[licznikLokalny] == meow3)
                {
                    //int fajny = poprzedniInt[0];
                    //int fajny2 = poprzedniInt[1];
                    //string fajny11 = fajny.ToString();
                    //string fajny22 = fajny2.ToString();

                    //                                 |
                    //Mesage Box pokazujący które pole \/

                    //MessageBox.Show(fajny11 + " " + fajny22);

                    break;
                }
                if (poprzedniInt[1] == 7)
                {
                    poprzedniInt[1] = 0;
                    poprzedniInt[0] = poprzedniInt[0] + 1;
                }
                else
                {
                    poprzedniInt[1]++;
                }

                licznikLokalny++;

            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            logo.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Hidden;
            startButton.Visibility = Visibility.Hidden;
            Audio.Visibility = Visibility.Hidden;
            startBox.Visibility = Visibility.Hidden;
            startText.Visibility = Visibility.Hidden;
            textButton.Visibility = Visibility.Hidden;
            resetButton.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (miusic == true)
            {
                MMplayer.Stop();
                miusic = false;
                Audio.Content = "OFF";
            }
            else if (miusic == false)
            {
                MMplayer.Play();
                miusic = true;
                Audio.Content = "ON";
            }
        }

        private void startText1(object sender, RoutedEventArgs e)
        {
            startBox.Visibility = Visibility.Hidden;
            startText.Visibility = Visibility.Hidden;
            textButton.Visibility = Visibility.Hidden;
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            render();
            runda = "white";
            int szerokosc = 0;
            int wysokosc = 0;
            int licznik = 0;
            int[,] numbersd =
        {
            {11, 12, 13, 14, 15, 13, 12, 11},
            {10, 10, 10, 10, 10, 10, 10, 10},
            {99, 99, 99, 99, 99, 99, 99, 99},
            {99, 99, 99, 99, 99, 99, 99, 99},
            {99, 99, 99, 99, 99, 99, 99, 99},
            {99, 99, 99, 99, 99, 99, 99, 99},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {1, 2, 3, 4, 5, 3, 2, 1}
        };

            List<int> meow = new List<int>();
            foreach (int item in numbersd)
            {
                meow.Add(item);
            }
            while (true)
            {
                numbers[wysokosc,szerokosc] = meow[licznik];

                licznik++;
                szerokosc++;
                if (szerokosc == 8)
                {
                    szerokosc = 0;
                    wysokosc++;
                }
                if (wysokosc == 7 && szerokosc == 7)
                {
                    break;
                }

                
            }
        }
    }
}