using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtSearch.Text;
            if(!String.IsNullOrEmpty(name))
            {
                ContactsList list;
                Proxy proxy = new Proxy();
                list = proxy.Search(name);
                foreach (Contact value in list.Contact)
                {
                    Suche.Items.Add(value.Vorname + value.Nachname);
                }
            }
         }
    }
}
