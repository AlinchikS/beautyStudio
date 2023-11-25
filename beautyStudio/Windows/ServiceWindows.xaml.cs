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

namespace beautyStudio.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindows.xaml
    /// </summary>
    public partial class ServiceWindows : Window
    {
        int rowCountAll;
        int rowCount;
        public ServiceWindows()
        {
            InitializeComponent();
            dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
            rowCountAll = dgService.Items.Count;
            lbCountRow.Content = rowCountAll - 1;
        }
        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEditServiceWindows waService = new Windows.AddEditServiceWindows(new Service());
            waService.ShowDialog();
            dgService.ItemsSource = null;
            dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = dgService.SelectedItem as Service;
                Windows.AddEditServiceWindows waService = new Windows.AddEditServiceWindows(service);
                waService.ShowDialog();
                dgService.ItemsSource = null;
                dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
            }
            catch
            {
                MessageBox.Show("Выберите объект для редактирования");
            }
        }

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = dgService.SelectedItem as Service;
                App.DBbeautyStudio.Service.Remove(service);
                App.DBbeautyStudio.SaveChanges();
                dgService.ItemsSource = null;
                dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
            }
            catch
            {
                MessageBox.Show("Выберите объект для удаления");
            }
        }

        private void tbSearchService_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string serviceSearch = tbSearchService.Text;
                List<Service> services = App.DBbeautyStudio.Service.Where(service => service.Title.Contains(serviceSearch) ||
                service.Description.Contains(serviceSearch)).ToList();

                dgService.ItemsSource = null;
                dgService.ItemsSource = services;

                rowCount = dgService.Items.Count;
                lbCountRow.Content = $"{rowCount - 1} из {rowCountAll - 1}";

            }
            catch { }
        }

        private void cmbSortingService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int ind = cmbSortingService.SelectedIndex;
                List<Service> services = App.DBbeautyStudio.Service.ToList();
                if (ind == 0)
                    services = App.DBbeautyStudio.Service.OrderBy(service => service.Cost).ToList();
                if (ind == 1)
                    services = App.DBbeautyStudio.Service.OrderByDescending(service => service.Cost).ToList();
                if (ind == 2)
                {
                    dgService.ItemsSource = null;
                    dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
                }
                dgService.ItemsSource = null;
                dgService.ItemsSource = services;
            }
            catch { }

        }

        private void cmbFilterService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<Service> services = App.DBbeautyStudio.Service.ToList();
                if (cmbFilterService.SelectedIndex == 0)
                {
                    dgService.ItemsSource = null;
                    dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
                }
                else
                {
                    if (cmbFilterService.SelectedIndex == 1)

                        services = App.DBbeautyStudio.Service.Where(service => service.Discount >= 0 && service.Discount <= 5).ToList();

                    if (cmbFilterService.SelectedIndex == 2)

                        services = App.DBbeautyStudio.Service.Where(service => service.Discount >= 6 && service.Discount <= 15).ToList();

                    if (cmbFilterService.SelectedIndex == 3)

                        services = App.DBbeautyStudio.Service.Where(service => service.Discount >= 16 && service.Discount <= 30).ToList();

                    if (cmbFilterService.SelectedIndex == 4)

                        services = App.DBbeautyStudio.Service.Where(service => service.Discount >= 31 && service.Discount <= 70).ToList();

                    if (cmbFilterService.SelectedIndex == 5)

                        services = App.DBbeautyStudio.Service.Where(service => service.Discount >= 71 && service.Discount <= 100).ToList();

                    dgService.ItemsSource = null;
                    dgService.ItemsSource = services;

                    rowCount = dgService.Items.Count;
                    lbCountRow.Content = $"{rowCount - 1} из {rowCountAll - 1}";
                }                
            }
            catch
            { }
        }

        private void btnSignUpService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
