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

namespace LoungerTest1
{
    public partial class MainWindow : Window
    {
        private LoungerEngine loungerEngine = new LoungerEngine();

        public MainWindow()
        {
            InitializeComponent();
            producesListBox.ItemsSource = loungerEngine.ProducesCollection;
            requestTextBox.Focus();
        }

        private void requestTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (requestTextBox.Text.Equals(string.Empty))
            {
                loungerEngine.DropProduces();
                return;
            }

            loungerEngine.ProcessRequest(requestTextBox.Text);
        }
    }
}
