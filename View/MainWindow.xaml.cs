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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // first column 

        private void Button_Click_Books_View(object sender, RoutedEventArgs e)
        {
            BookDetails bookDetailsWindow = new BookDetails();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = bookDetailsWindow;
        }

        private void Button_Click_Readers_View(object sender, RoutedEventArgs e)
        {
            ReadersDetails readersDetailsWindow = new ReadersDetails();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = readersDetailsWindow;
        }

        private void Button_Click_Employees_View(object sender, RoutedEventArgs e)
        {
            EmployeesDetails employeesDetailsWindow = new EmployeesDetails();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = employeesDetailsWindow;
        }

        private void Button_Click_Suppliers_View(object sender, RoutedEventArgs e)
        {
            SuppliersDetails suppliersDetailsWindow = new SuppliersDetails();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = suppliersDetailsWindow;
        }

        // second column - add / delete UserControls

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Book bookWindow = new Book();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = bookWindow;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Employees employeesWindow = new Employees();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = employeesWindow;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Readers readersWindow = new Readers();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = readersWindow;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Suppliers suppliersWindow = new Suppliers();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = suppliersWindow;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Rent rentWindow = new Rent();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = rentWindow;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Return returnWindow = new Return();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Content = returnWindow;
        }

        



    }
}
