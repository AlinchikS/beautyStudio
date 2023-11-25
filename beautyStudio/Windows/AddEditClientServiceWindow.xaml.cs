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
    /// Логика взаимодействия для AddEditClientServiceWindow.xaml
    /// </summary>
    public partial class AddEditClientServiceWindow : Window
    {
        public AddEditClientServiceWindow(Service currentService)
        {
            InitializeComponent();
            this.currentService = currentService;
        }
        Service currentService;
    }
}
