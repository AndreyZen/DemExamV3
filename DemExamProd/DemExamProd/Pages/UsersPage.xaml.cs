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

namespace DemExamProd.Pages
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DgUsers.ItemsSource = App.Context.User.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.GoBack();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUsers.ItemsSource = null;
            DgUsers.ItemsSource = App.Context.User.Where(p=>p.FullName.ToLower().Trim().Contains(TbSearch.Text.ToLower().Trim()));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            App.Context.SaveChanges();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            //ToDo Добавить окно добавления пользователя
        }
    }
}
