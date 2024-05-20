using DemExamProd.Pages;
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
using System.Windows.Shapes;

namespace DemExamProd.Windows
{
    /// <summary>
    /// Interaction logic for RealtorWindow.xaml
    /// </summary>
    public partial class RealtorWindow : Window
    {
        public RealtorWindow()
        {
            InitializeComponent();
            App.MainFrame = RealtorFrame;
            App.MainFrame.Navigate(new RealtorDocumentPage());
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
