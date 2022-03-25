using MVC02List;
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

namespace MVC02List
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

        Wrapper wrapper = new Wrapper();


        static int Fiban(int n)
        {
            if (n == 1 || n == 2) return 1;
            else return Fiban(n - 1) + Fiban(n - 2);
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                int i = wrapper.list.Count+1;
                int fb = Fiban(i);

                string li = $"Число №{i} = {fb}" + Environment.NewLine;
                wrapper.list.Add(li);

                tbText.Dispatcher.BeginInvoke(
                () =>
                {

                    tbText.Text += wrapper.list[i-1];
                });

                bAdd.Dispatcher.BeginInvoke(
                    () =>
                    {
                        bAdd.IsEnabled = true;
                    });
                bDelete.Dispatcher.BeginInvoke(
                   () =>
                   {
                       bDelete.IsEnabled = true;
                   });

            }).Start();
            bAdd.IsEnabled =false;
            bDelete.IsEnabled =false;
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                

                tbText.Dispatcher.BeginInvoke(
                () =>
                {
                    if (wrapper.list.Count>0)
                    {
                        wrapper.list.RemoveAt(wrapper.list.Count - 1);

                        tbText.Text = string.Empty;

                        for (int i = 0; i < wrapper.list.Count; i++)
                        {
                            tbText.Text += wrapper.list[i];
                        }
                    }
             
                });
            }).Start();
        }
    }
}
