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

namespace View
{
    /// <summary>
    /// Interaction logic for BookDetails.xaml
    /// </summary>
    public partial class BookDetails : UserControl
    {
        public BookDetails()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Window currentWindow = Window.GetWindow(this);
            currentWindow.Content = mainWindow;
        }
        private void Button_Click_Books_View(object sender, RoutedEventArgs e)
        {
            // Handle button click event

        }
    }
}