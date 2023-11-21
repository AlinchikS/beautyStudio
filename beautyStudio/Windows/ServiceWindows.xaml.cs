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
        public ServiceWindows()
        {
            InitializeComponent();
            dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
        }
        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEditServiceWindows addEditService = new Windows.AddEditServiceWindows(new Service());
            addEditService.ShowDialog();
            dgService.ItemsSource = null;
            dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
            this.Close();
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = dgService.SelectedItem as Service;
                Windows.AddEditServiceWindows addEditService = new Windows.AddEditServiceWindows(service);
                addEditService.ShowDialog();
                this.Close();
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

        }

        private void cmbSortingService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*try
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
            catch { }*/

        }

        private void cmbFilterService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*try
            {
                List<Service> services = App.DBbeautyStudio.Service.ToList();
                if (cmbFilterService.SelectedIndex == 0)
                {
                    dgService.ItemsSource = null;
                    dgService.ItemsSource = App.DBbeautyStudio.Service.ToList();
                }
                else
                {
                    string selectedServices = ((RadioButton)cmbFilterService.SelectedItem).Content.ToString();
                    List<Service> filteredServices = new List<Service>();
                    foreach (Service service in services)
                    {
                        if (service.Discount.ToString() == selectedServices)
                            filteredServices.Add(service);
                    }
                    dgService.ItemsSource = null;
                    dgService.ItemsSource = filteredServices;

                }
            }
            catch
            { }*/
        }
    }
}
