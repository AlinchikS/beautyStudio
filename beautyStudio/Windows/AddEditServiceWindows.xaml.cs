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
    /// Логика взаимодействия для AddEditServiceWindows.xaml
    /// </summary>
    public partial class AddEditServiceWindows : Window
    {
        public AddEditServiceWindows(Service currentService)
        {
            InitializeComponent();
            try
            {
                this.currentService = currentService;
                tbName.Text = currentService.Title.ToString();
                tbCost.Text = currentService.Cost.ToString();
                tbDurationInSeconds.Text = currentService.DurationInSeconds.ToString();
                tbDescriptiont.Text = currentService.Description.ToString();
                tbDiscount.Text = currentService.Discount.ToString();
                tbMainImagePath.Text = currentService.MainImagePath.ToString();
            }
            catch { }
        }
        Service currentService;
        private void btnSaveService_Click(object sender, RoutedEventArgs e)
        {
            currentService.Title = tbName.Text;
            currentService.Cost = int.Parse(tbCost.Text);
            currentService.DurationInSeconds = int.Parse(tbDurationInSeconds.Text);
            currentService.Description = tbDescriptiont.Text;
            currentService.Discount = double.Parse(tbDiscount.Text);
            currentService.MainImagePath = tbMainImagePath.Text;
            if (currentService.ID == 0)
                App.DBbeautyStudio.Service.Add(currentService);
            App.DBbeautyStudio.SaveChanges();
            Close();
        }

        private void btnCancelService_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
