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

namespace MicroErp_01
{
    /// <summary>
    /// Interaction logic for EditContact.xaml
    /// </summary>
    public partial class EditContact : Window
    {
        public EditContact()
        {
            InitializeComponent();
            //this.DataContext = new MicroErp_01.ViewModels.ContactEditViewModel();
        }
    }
}
