using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace proect01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ZeroValue();
        }
        int[,] gamePlace = new int[40, 17];
        Dictionary<string, int> ArrIndex = new Dictionary<string, int>();
        List<Xamarin.Forms.Color> clors = new List<Xamarin.Forms.Color>() {Xamarin.Forms.Color.Red, Xamarin.Forms.Color.Blue,Xamarin.Forms.Color.DarkViolet,Xamarin.Forms.Color.Orange,Xamarin.Forms.Color.Green,Xamarin.Forms.Color.Pink,Xamarin.Forms.Color.Purple};
        Random rnd = new Random();
        double tim = 0.1;
        void ZeroValue()
        {
            for (int i = 0; i < 40; i++)
            {
                for(int j = 0; j < 17; j++)
                {
                    gamePlace[i, j] = 0;
                }
            }
        }

        void lowRyad()
        {
            bool flagAll = false;
            for (int i = 39; i > -1; i--)
            {
                bool fl = false;
                for (int j = 0; j < 17; j++)
                {
                    if (gamePlace[i, j] == 0)
                    {
                        fl = true;
                    }
                }
                if (!fl)
                {
                    flagAll = true;
                    Console.WriteLine(i + " Удалить эту строку");
                    DeleteRow(i);
                    
     
                }

                
            }
        }

        private int[] ArrForDel(int i)
        {
            int[] arr = new int[17];
            for (int j = 16; j >= 0; j--)
            {
                string hel = i.ToString() + "," + j.ToString();
                int del = ArrIndex[hel];
                arr[j] = del;
            }
            Array.Sort(arr);
            return arr;
        }

        void DeleteRow(int i)
        {
            int[] arr = ArrForDel(i);
            /*await DisplayAlert(i.ToString(), Grid.GetRow(grd.Children[0]).ToString(), "OK");*/
            for (int j = 16;  j >= 0; j--)
            {
                string hel = i.ToString() + "," + j.ToString();
                int del = arr[j];
                var bx = grd.Children[del];
                grd.Children.Remove(bx);
                ArrIndex.Remove(hel);
            }
            for (int j = 0; j < 17; j++)
            {
                gamePlace[i, j] = 0;
            }
            Get_Down(i);
        }

        void Get_Down(int hightRow)
        {
            tim = 2;
            ArrIndex.Clear();
            for (int i = 0;i<grd.Children.Count; i++)
            {
                var bx = grd.Children[i];
                int row = Grid.GetRow(bx);
                if (row < hightRow)
                {
                    int col = Grid.GetColumn(bx);
                    row+=1;
                    string hel = row.ToString() + "," + col.ToString();
                    ArrIndex.Add(hel, i);
                    Grid.SetRow(bx, Grid.GetRow(bx) + 1);
                    gamePlace[row-1, col] = 0;
                    gamePlace[row, col] = 1;
                }
                else
                {
                    int col = Grid.GetColumn(bx);
                    string hel = row.ToString() + "," + col.ToString();
                    ArrIndex.Add(hel, i);
                }
            }
        }

        void Create_Box(int i)
        {
            
            Xamarin.Forms.Color colr = clors[rnd.Next(0, 7)];
            switch (i)
            {
                case 1:
                    BoxView bxviw1 = new BoxView
                    {
                        Color = colr

                    };
                    BoxView bxviw2 = new BoxView
                    {
                        Color = colr

                    };
                    BoxView bxviw3 = new BoxView
                    {
                        Color = colr

                    };
                    BoxView bxviw4 = new BoxView
                    {
                        Color = colr

                    };
                    grd.Children.Add(bxviw1, 8, 0);
                    grd.Children.Add(bxviw2, 8, 1);
                    grd.Children.Add(bxviw3, 8, 2);
                    grd.Children.Add(bxviw4, 8, 3);
                    break;

                case 2:
                    BoxView bxviwsqr1= new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwsqr2 = new BoxView
                    {
                        Color = colr
                    }; BoxView bxviwsqr3 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwsqr4 = new BoxView
                    {
                        Color = colr
                    }; grd.Children.Add(bxviwsqr1, 8, 0);
                    grd.Children.Add(bxviwsqr2, 9, 0); 
                    grd.Children.Add(bxviwsqr3, 8, 1);
                    grd.Children.Add(bxviwsqr4, 9, 1);
                    break;

                case 3:
                    BoxView bxviwz1 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwz2 = new BoxView
                    {
                        Color = colr
                    }; BoxView bxviwz3 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwz4 = new BoxView
                    {
                        Color = colr
                    }; grd.Children.Add(bxviwz1, 8, 0);
                    grd.Children.Add(bxviwz2, 7, 0); 
                    grd.Children.Add(bxviwz3, 7, 1);
                    grd.Children.Add(bxviwz4, 6, 1);
                    break;

                case 4:
                    BoxView bxviwBackz1 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwBackz2 = new BoxView
                    {
                        Color = colr
                    }; BoxView bxviwBackz3 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwBackz4 = new BoxView
                    {
                        Color = colr
                    }; grd.Children.Add(bxviwBackz1, 8, 0);
                    grd.Children.Add(bxviwBackz2, 9, 0); 
                    grd.Children.Add(bxviwBackz3, 9, 1);
                    grd.Children.Add(bxviwBackz4, 10, 1);
                    break;

                case 5:
                    BoxView bxviwl1 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwl2 = new BoxView
                    {
                        Color = colr
                    }; BoxView bxviwl3 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwl4 = new BoxView
                    {
                        Color = colr
                    }; grd.Children.Add(bxviwl1, 8, 0);
                    grd.Children.Add(bxviwl2, 9, 0); 
                    grd.Children.Add(bxviwl3, 9, 1);
                    grd.Children.Add(bxviwl4, 9, 2);
                    break;


                case 6:
                    BoxView bxviwj1 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwj2 = new BoxView
                    {
                        Color = colr
                    }; BoxView bxviwj3 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwj4 = new BoxView
                    {
                        Color = colr
                    }; grd.Children.Add(bxviwj1, 8, 0);
                    grd.Children.Add(bxviwj2, 9, 0); 
                    grd.Children.Add(bxviwj3, 9, 1);
                    grd.Children.Add(bxviwj4, 8, 2);
                    break;

                case 7:
                    BoxView bxviwt1 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwt2 = new BoxView
                    {
                        Color = colr
                    }; BoxView bxviwt3 = new BoxView
                    {
                        Color = colr
                    };
                    BoxView bxviwt4 = new BoxView
                    {
                        Color = colr
                    }; grd.Children.Add(bxviwt1, 8, 0);
                    grd.Children.Add(bxviwt2, 7, 0); 
                    grd.Children.Add(bxviwt3, 6, 0);
                    grd.Children.Add(bxviwt4, 8, 1);
                    break;
            }
            
        }

        private void FutyreSwtch(object sender, ToggledEventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            
        }
 

        bool lowRow(int row,int col)
        {
            if (gamePlace[row, col] == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool Move_Down()
        {
            bool flag = false;
            for (int j = 1; j < 5; j++)
            {
                var bxUp = grd.Children[grd.Children.Count - j];
                int colTry = Grid.GetColumn(bxUp);
                int rowTry = Grid.GetRow(bxUp) + 1;
                if (Grid.GetRow(bxUp) != 37 & lowRow(rowTry, colTry))
                {

                }
                else
                {
                    flag = true;
                }
                
                    
            }
            return !flag;
        }

        private bool OnTimerTick()
        {
            lowRyad();
            if (grd.Children.Count == 0)
            {
                Create_Box(rnd.Next(0,8));
                
            }
            if (Move_Down())
            {

                for (int j = 1; j < 5; j++)
                {
                    var bxUp = grd.Children[grd.Children.Count - j];
                    Grid.SetRow(bxUp, Grid.GetRow(bxUp) + 1);
                }
            }
            else
            {
                for (int j = 1; j <= 4; j++)
                {
                    var bxUp = grd.Children[grd.Children.Count - j];
                    gamePlace[Grid.GetRow(bxUp), Grid.GetColumn(bxUp)] = 1;
                    string hel = Grid.GetRow(bxUp).ToString() + "," + Grid.GetColumn(bxUp).ToString();
                    ArrIndex.Add(hel, grd.Children.IndexOf(bxUp));
                }
                lowRyad();
                
                Create_Box(1);
            }
            return swthc.IsToggled;

        }
        void btnRightSite(object sender, EventArgs args)
        {
            lowRyad();
            bool flag = true;

            for (int j = 1; j < 5; j++)
            {
                var bxNext = grd.Children[grd.Children.Count - j];
                if (Grid.GetColumn(bxNext) == 16 )
                {
                    flag = false;
                }
                else if(gamePlace[Grid.GetRow(bxNext), Grid.GetColumn(bxNext) + 1] == 1)
                {
                    flag = false;
                }
            }

            if (flag) {
                for (int j = 1; j < 5; j++)
                {
                    var bxNext = grd.Children[grd.Children.Count - j];
                   
                    Grid.SetColumn(bxNext, Grid.GetColumn(bxNext) + 1);
                  
                }
            }
        }
        void btnLeftSite(object sender, EventArgs args)
        {
            lowRyad();
            bool flag = true;

            for (int j = 1; j < 5; j++)
            {
                var bxNext = grd.Children[grd.Children.Count - j];
                if (Grid.GetColumn(bxNext) == 0)
                {
                    flag = false;
                }
                else if(gamePlace[Grid.GetRow(bxNext), Grid.GetColumn(bxNext) - 1] == 1)
                {
                    flag = false;
                }
            }

            if (flag)
            {
                for (int j = 1; j < 5; j++)
                {
                    var bxNext = grd.Children[grd.Children.Count - j];

                        Grid.SetColumn(bxNext, Grid.GetColumn(bxNext) - 1);
                }
            }
        }
        void btnLowSite(object sender, EventArgs args)
        {
            lowRyad();
            bool flag = true;

            for (int j = 1; j < 5; j++)
            {
                var bxNext = grd.Children[grd.Children.Count - j];
                if (Grid.GetRow(bxNext)==37)
                {
                    flag = false;
                }
                else if(gamePlace[Grid.GetRow(bxNext) + 1, Grid.GetColumn(bxNext)] == 1)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                for (int j = 1; j < 5; j++)
                {
                    var bxNext = grd.Children[grd.Children.Count - j];
                    Grid.SetRow(bxNext, Grid.GetRow(bxNext) + 1);
                }
            }
        }
    }
}
