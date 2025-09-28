using Data_Access;
using Data_Access.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Dispatch_Screen
{
    /// <summary>
    /// Interaction logic for Drivers.xaml
    /// </summary>
    public partial class Drivers : Window
    {
        DriverRepository driverRepository { get; set; } 
        public Drivers()
        {
            InitializeComponent();
            driverRepository = new DriverRepository();
            DriversGrid.ItemsSource = driverRepository.GetDrivers();
        }
        private void RefreshDrivers(object sender, RoutedEventArgs e)
        {
            DriversGrid.ItemsSource = driverRepository.GetDrivers();
        }
        private void Drivers_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }

}
