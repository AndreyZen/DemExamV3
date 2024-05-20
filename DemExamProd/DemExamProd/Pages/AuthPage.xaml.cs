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
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.Context.User.FirstOrDefault(p => p.Login == TbLogin.Text);
            if (user != null)
            {
                if (user.Password != PbPassword.Password)
                    MessageBox.Show("Не верный пароль пользователя", "Ошибка атворизации", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    if (!user.Status)
                    {
                        App.CurrentUser = user;
                        switch (user.RoleId)
                        {
                            case 1:
                                App.MainFrame.Navigate(new AdminMenuPage());
                                break;
                        }
                    }
                    else
                        MessageBox.Show("Учетная запись пользователя не активна!", "Ошибка атворизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Пользователь не найден!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
