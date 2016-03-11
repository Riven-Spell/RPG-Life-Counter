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

namespace RPGLife_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MouseDown += Window_MouseDown;
            InitializeComponent();
            HPAtBox.TextChanged += new TextChangedEventHandler(HPAtBox_TextChanged);
            HPMaxBox.TextChanged += new TextChangedEventHandler(HPMaxBox_TextChanged);
            MPAtBox.TextChanged += new TextChangedEventHandler(MPAtBox_TextChanged);
            MPMaxBox.TextChanged += new TextChangedEventHandler(MPMaxBox_TextChanged);
            Close.Click += new RoutedEventHandler(Close_Clicked);
            LevelBox.TextChanged += new TextChangedEventHandler(LevelBox_TextChanged);
        }

        private void UpdateHPSlider()
        {
            double x;
            try
            {
                x = double.Parse(HPMaxBox.Text);
            }
            catch
            {
                x = 1;
            }
            double y = double.Parse(HPAtBox.Text);
            Thickness newM = HPSlider.Margin;
            newM.Right = 831 - (831 * (y/x));
            if (double.IsNaN(newM.Right))
            {
                newM.Right = 1;
            }
            HPSlider.Margin = newM;
            HPSlider.UpdateLayout();
        }
        private void UpdateMPSlider()
        {
            double x;
            try
            {
                x = double.Parse(MPMaxBox.Text);
            }
            catch
            {
                x = 1;
            }
            double y = double.Parse(MPAtBox.Text);
            Thickness newM = MPSlider.Margin;
            newM.Right = 831 - (831 * (y / x));
            MPSlider.Margin = newM;
            MPSlider.UpdateLayout();
        }

        private void LevelBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(LevelBox.Text) <= 0)
                    LevelBox.Text = "1";
            }
            catch
            {
                LevelBox.Text = "1";
            }
            LevelLabel.Content = "Lv. " + LevelBox.Text;
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void HPAtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(HPAtBox.Text) > int.Parse(HPMaxBox.Text))
                {
                    HPAtBox.Text = HPMaxBox.Text;
                }
                else if (int.Parse(HPAtBox.Text) < 0)
                {
                    HPAtBox.Text = "0";
                }
            }
            catch
            {
                HPAtBox.Text = "0";
            }

            HPStat.Content = HPAtBox.Text + "/" + HPMaxBox.Text;
            UpdateHPSlider();
        }

        private void HPMaxBox_TextChanged(object sender, EventArgs e)
        {
            try {
                 if (int.Parse(HPAtBox.Text) > int.Parse(HPMaxBox.Text))
                 {
                     HPAtBox.Text = HPMaxBox.Text;
                 }
                 else if (int.Parse(HPAtBox.Text) < 0)
                 {
                     HPAtBox.Text = "0";
                 }

                if (int.Parse(HPMaxBox.Text) <= 0)
                {
                    HPMaxBox.Text = "1";
                }
            }
            catch
            {
                HPAtBox.Text = "0";
                HPMaxBox.Text = "1";
            }
            HPStat.Content = HPAtBox.Text + "/" + HPMaxBox.Text;
            UpdateHPSlider();
        }

        private void MPAtBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(MPAtBox.Text) > int.Parse(MPMaxBox.Text))
                {
                    MPAtBox.Text = MPMaxBox.Text;
                }
                else if (int.Parse(MPAtBox.Text) < 0)
                {
                    MPAtBox.Text = "0";
                }
            }
            catch
            {
                MPAtBox.Text = "0";
            }

            MPStat.Content = MPAtBox.Text + "/" + MPMaxBox.Text;
            UpdateMPSlider();
        }

        private void MPMaxBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(MPAtBox.Text) > int.Parse(MPMaxBox.Text))
                {
                    MPAtBox.Text = MPMaxBox.Text;
                }
                else if (int.Parse(MPAtBox.Text) < 0)
                {
                    MPAtBox.Text = "0";
                }
                if (int.Parse(MPMaxBox.Text) <= 0)
                {
                    MPMaxBox.Text = "1";
                }
            }
            catch
            {
                MPAtBox.Text = "1";
                MPMaxBox.Text = "1";
            }

            MPStat.Content = MPAtBox.Text + "/" + MPMaxBox.Text;
            UpdateMPSlider();
        }
    }
}
