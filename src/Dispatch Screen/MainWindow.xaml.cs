using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Data_Access;
using Data_Access.Model;
using static Data_Access.EnumeratedProperties.OrderPriorityCode;

namespace Dispatch_Screen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrderRepository OrderRepository { get; set; }
        ObservableCollection<OrderView> Orders { get; set; }    
        Drivers DriversWindow { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OrderRepository = new OrderRepository();
            Orders = Task.Run(async () => await GetOrdersAsync()).GetAwaiter().GetResult();
            OrdersGrid.ItemsSource = Orders;
            DriversWindow = new Drivers();
        }
        private async Task<ObservableCollection<OrderView>> GetOrdersAsync(bool isAllorders = false)
        {
            return new ObservableCollection<OrderView>((await OrderRepository.GetOrdersAsync(isAllorders)).Select(item => new OrderView(item)));
        }
        private async void RefreshOrders(object sender, RoutedEventArgs e)
        {
            Orders = await GetOrdersAsync();
            OrdersGrid.ItemsSource = Orders;
        }
        private void DataGridRow_MouseClick(object sender, MouseButtonEventArgs e)
        {
            EnableButton();
        }
        private void EnableButton()
        {
            OrderView row = (OrderView)OrdersGrid.SelectedItem;
            if (row == null)
                return;
            foreach (Button btn in PriorityCodeButtons.Children)
            {
                PlaceButton.IsEnabled = false;
                AssignButton.IsEnabled = false;
                ArriveButton.IsEnabled = false;
                DepartButton.IsEnabled = false;
                CompleteButton.IsEnabled = false;
                switch (row.PriorityCode)
                {
                    case Status.Accepted:
                        AssignButton.IsEnabled = true;
                        break;
                    case Status.Assigned:
                        ArriveButton.IsEnabled = true;
                        break;
                    case Status.Arrived:
                        DepartButton.IsEnabled = true;
                        break;
                    case Status.Departed:
                        CompleteButton.IsEnabled = true;
                        break;
                    case Status.Completed:
                        break;
                    default:
                        PlaceButton.IsEnabled = true;
                        break;
                }
            }
        }
        private void OpenDriversPage(object sender, RoutedEventArgs e)
        {
            DriversWindow.Left = 1280;
            DriversWindow.Top = 100;
            DriversWindow.Show();
            DriversWindow.Owner = this;
        }
        private async void ChangeOrderStatus(object sender, RoutedEventArgs e)
        {
            OrderView row = (OrderView)OrdersGrid.SelectedItem;
            if (row == null)
                return;
            Button button = (Button)sender;
            int TagValue = Convert.ToInt32(button.Tag);
            Status OrderStatus = (Status)TagValue;
            if (TagValue == 1)
            {
                Driver DriverRow = (Driver)DriversWindow.DriversGrid.SelectedItem;
                Orders[Orders.IndexOf(row)] = new OrderView(await OrderRepository.UpdateStatusAsync(row.Id, (int)OrderStatus, DriverRow.Id));
            }
            else
                Orders[Orders.IndexOf(row)] = new OrderView(await OrderRepository.UpdateStatusAsync(row.Id, (int)OrderStatus, null));
        }
        private async void GetAllOrders(object sender, RoutedEventArgs e)
        {
            if (AllOrdersButton.IsChecked == true)
                Orders = await GetOrdersAsync(true);
            else
                Orders = await GetOrdersAsync(false);
            OrdersGrid.ItemsSource = Orders;
        }
        protected void MainWindow_Load(object sender, EventArgs e)
        {
            DateTime dNow = DateTime.Now;
            OrdersCount.Text = Orders.Count.ToString() + " " + "Orders";
        }
    }
}