using DemExamProd.Models;
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
    /// Interaction logic for AddDocumentPage.xaml
    /// </summary>
    public partial class AddDocumentPage : Page
    {
        public AddDocumentPage()
        {
            InitializeComponent();
        }

        private void btnAddDocument_Click(object sender, RoutedEventArgs e)
        {
            var error = "";

            if (string.IsNullOrWhiteSpace(tbxAddress.Text) || string.IsNullOrWhiteSpace(tbxFIO.Text)
                || cmbPaymentType.SelectedIndex == -1)
                error += "Введите все данные";

            if (error == "")
            {
                App.Context.Order.Add(new Models.Order()
                {
                    CreationDate = dpCreationDate.SelectedDate.Value,
                    ClientfullName = tbxFIO.Text,
                    Address = tbxAddress.Text,
                    PaymentMethodId = (cmbPaymentType.SelectedItem as PaymentMethod).Id,
                    OrderStatusId = 3,
                    PaymentStatusId = 1
                });
                App.Context.SaveChanges();
                App.MainFrame.GoBack();
            }
            else
                MessageBox.Show(error, "Упс", MessageBoxButton.OK);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPaymentType.ItemsSource = App.Context.PaymentMethod.ToList();
            dpCreationDate.SelectedDate = DateTime.Now.Date;
        }
    }
}
