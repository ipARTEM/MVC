using MVC01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace MVC01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
           
        }

        

        static int Fiban(int n)
        {
            if (n == 1 || n == 2) return 1;
            else return Fiban(n - 1) + Fiban(n - 2);
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            var intFib = int.Parse(tbFib.Text);
            string text = tbText.Text;
            int intTime = int.Parse(tbTime.Text);


            new Thread(() =>
            {
                //var res = Fib(intFib, text, intTime);
                for (int i = 1; i <= intFib; i++)
                {
                    int fb = Fiban(i);

                    text += $"Число №{i} = {fb}" + Environment.NewLine;

                    Thread.Sleep(intTime * 1000);
                    tbText.Dispatcher.BeginInvoke(
                        () =>
                        {
                            tbText.Text = text;
                        });
                }


                bStart.Dispatcher.BeginInvoke(
                    () =>
                    {
                        bStart.IsEnabled = true;
                    });
                bClear.Dispatcher.BeginInvoke(
                   () =>
                   {
                       bClear.IsEnabled = true;
                   });
               
            }).Start();
            bStart.IsEnabled = false;
            bClear.IsEnabled = false;
            
        }

        private string Fib(int intFib, string text, int intTime)
        {
                return text;
        }

        private void Clear()
        {
            tbText.Text = string.Empty;
        }

        private void bClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

       
    }
}
