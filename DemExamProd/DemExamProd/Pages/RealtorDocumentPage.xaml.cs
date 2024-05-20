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
    /// Interaction logic for RealtorDocumentPage.xaml
    /// </summary>
    public partial class RealtorDocumentPage : Page
    {
        List<Order>  _orders = App.Context.Order.ToList();
        public RealtorDocumentPage()
        {
            InitializeComponent();
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void UpdateListView()
        {
            _orders = App.Context.Order.ToList();   

            if (tbxSearch.Text != "")
                _orders = _orders.Where(p => p.ClientfullName.ToLower().Trim().Contains(tbxSearch.Text.ToLower().Trim())).ToList();

            if (cmbStatus.SelectedIndex > 0)
                _orders = _orders.Where(p => p.PaymentMethodId == (cmbStatus.SelectedItem as PaymentMethod).Id).ToList();

            lvDocument.ItemsSource = null;
            lvDocument.ItemsSource = _orders;
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            ((sender as Button).DataContext as Order).PaymentStatusId = 2;
            App.Context.SaveChanges();
            UpdateListView();
        }

        private void btnAddDocument_Click(object sender, RoutedEventArgs e)
        {
            App.MainFrame.Navigate(new AddDocumentPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lvDocument.ItemsSource = null;
            lvDocument.ItemsSource = _orders;
            List<PaymentMethod> paymentMethods = App.Context.PaymentMethod.ToList();
            paymentMethods.Insert(0, new PaymentMethod()
            {
                Id = 0,
                Name = "Способ оплаты"
            });
            cmbStatus.ItemsSource = paymentMethods;
            cmbStatus.SelectedIndex = 0;
        }
    }
}
