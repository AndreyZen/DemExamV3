using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace DemExamProd.Pages
{
    /// <summary>
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйсти из системы?", "Выход", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes) 
                App.MainFrame.Navigate(new AuthPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TbUserName.Text = App.CurrentUser.FullName;
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new UsersPage());
        }
    }
}
