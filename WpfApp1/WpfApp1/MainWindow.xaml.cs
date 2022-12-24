using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using WpfApp1;

namespace WpfApp1
{
    abstract class Figure
    {
        public abstract double Area();
        public abstract double Perimeter();
        public double a { get { return a; } set { a = value; } }
        public double b { get { return b; } set { b = value; } }
        public double c { get { return c; } set { c = value; } }

    }

class krug : Figure
{
       public double r;
    public double radik{ get { return r; } set { r = value; } }

    public krug(double rad)
    {
         r = rad;
    }
    public override double Perimeter()
    {
        double h = (2 * 3.14 * r);
        return h;
    }

    public override double Area()
    {
        return (3.14 * r * r);
    }
}
    class trap : Figure
    {
        public double a;
        public double b;
        public double c;
        public double aa { get { return a; } set { a = value; } }
        public double bb { get { return b; } set { b = value; } }
        public double cc { get { return c; } set { c = value; } }

        public trap(double aa, double bb, double cc)
        {
            a = aa;
            b = bb;
            c = cc;
        }

        public override double Perimeter()
        {
            return a + b + c;
        }

        public override double Area()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p-b) * (p-c));
        }
    }
    class prym : Figure
    {
        public double a;
        public double b;
        public double aa { get { return a; } set { a = value; } }
        public double bb { get { return b; } set { b = value; } }
        public prym(double aa, double bb)
        {
            a = aa;
            b = bb;
        }
        public override double Perimeter()
        {
            return 2 * a + 2 * b;
        }

        public override double Area()
        {
            return a * b;
        }
    }
    // Для остальных фигур - аналогично

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(rb1.IsChecked == true)
            {
                tb1.Visibility = Visibility.Collapsed;
                tb2.Visibility = Visibility.Collapsed;
                tbb3.Visibility = Visibility.Collapsed;
                tbb1.Visibility = Visibility.Collapsed;
                tbb2.Visibility = Visibility.Collapsed;
                tbbb3.Visibility = Visibility.Collapsed;
                tb1.Visibility = Visibility.Visible;
                tbb1.Visibility = Visibility.Visible;
                tbb1.Text = "Радиус";
            }
        }

        private void rb2_Checked(object sender, RoutedEventArgs e)
        {
            if (rb2.IsChecked == true)
            {
                tb1.Visibility = Visibility.Collapsed;
                tb2.Visibility = Visibility.Collapsed;
                tbb3.Visibility = Visibility.Collapsed;
                tbb1.Visibility = Visibility.Collapsed;
                tbb2.Visibility = Visibility.Collapsed;
                tbbb3.Visibility = Visibility.Collapsed;
                tb1.Visibility = Visibility.Visible;
                tb2.Visibility = Visibility.Visible;
                tbb3.Visibility = Visibility.Visible;
                tbb1.Visibility = Visibility.Visible;
                tbb2.Visibility = Visibility.Visible;
                tbbb3.Visibility = Visibility.Visible;
                tbb1.Text = "Сторона 1";
                tbb2.Text = "Сторона 2";
                tbbb3.Text = "Сторона 3";
            }
        }

        private void rb3_Checked(object sender, RoutedEventArgs e)
        {
            if (rb3.IsChecked == true)
            {
                tb1.Visibility = Visibility.Collapsed;
                tb2.Visibility = Visibility.Collapsed;
                tbb3.Visibility = Visibility.Collapsed;
                tbb1.Visibility = Visibility.Collapsed;
                tbb2.Visibility = Visibility.Collapsed;
                tbbb3.Visibility = Visibility.Collapsed;
                tb1.Visibility = Visibility.Visible;
                tb2.Visibility = Visibility.Visible;
                tbb1.Visibility = Visibility.Visible;
                tbb2.Visibility = Visibility.Visible;
                tbb1.Text = "Ширина";
                tbb2.Text = "Высота";
            }
        }

        krug[] krugs = new krug[3];
        trap[] traps = new trap[3];
        prym[] pryms = new prym[3];
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = 0, j = 0, k = 0;
            string aa = "";
            string pp = "";
            if (rb1.IsChecked == true)
            {
                
                if (double.TryParse(tb1.Text, out double r) == true)
                {
                    r = double.Parse(tb1.Text);
                    krugs[i] = new krug(r);
                    //MessageBox.Show(string.Format("{0}", krugs.Perimeter()));
                    tb3.Text = String.Format("{0}", krugs[i].Perimeter());
                    tb4.Text = String.Format("{0}", krugs[i].Area());
                    pp = tb3.Text;
                    aa = tb4.Text;
                    i++;
                   
                    lb.Items.Add( "Круг с радиусом " + r.ToString() + " периметром: " + pp + " площадью: " + aa);
                }
            }
            if (rb2.IsChecked == true)
            {
                    double a = double.Parse(tb1.Text);
                double b = double.Parse(tb2.Text);
                double c = double.Parse(tbb3.Text);
                traps[j] = new trap(a,b,c);
                    tb3.Text = String.Format("{0}", traps[j].Perimeter());
                    tb4.Text = String.Format("{0}", traps[j].Area());
                pp = tb3.Text;
                aa = tb4.Text;
                j++;

                lb.Items.Add("Треугольник с параметрами: " + a.ToString() + " " + b.ToString() + " " + c.ToString() + " периметр: " + pp + " площадью: " + aa);

            }
            if (rb3.IsChecked == true)
            {
                if (double.TryParse(tb1.Text, out double r) == true)
                {
                    double a = double.Parse(tb1.Text);
                    double b = double.Parse(tb2.Text);
                    pryms[k] = new prym(a,b);
                    tb3.Text = String.Format("{0}", pryms[k].Perimeter());
                    tb4.Text = String.Format("{0}", pryms[k].Area());
                    pp = tb3.Text;
                    aa = tb4.Text;
                    k++;

                    lb.Items.Add("Прямоугольник с параметрами " + a.ToString() + " " + b.ToString() + " периметр: " + pp + " площадью: " + aa);
                }
            }
            tb1.Visibility = Visibility.Collapsed;
            tb2.Visibility = Visibility.Collapsed;
            tbb3.Visibility = Visibility.Collapsed;
            tbb1.Visibility = Visibility.Collapsed;
            tbb2.Visibility = Visibility.Collapsed;
            tbbb3.Visibility = Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lb.SelectedIndex != -1)
                lb.Items.RemoveAt(lb.SelectedIndex);
            else
                MessageBox.Show("Ошибка удаления. Выберите что-то.");
        }
    }
}
