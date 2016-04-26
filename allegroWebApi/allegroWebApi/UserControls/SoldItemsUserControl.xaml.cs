using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using allegroWebApi.pl.allegro.webapi;


namespace allegroWebApi.UserControls
{
    /// <summary>
    /// Interaction logic for SoldItemsUserControl.xaml
    /// </summary>
    public partial class SoldItemsUserControl : UserControl
    {
        private SoldItemStruct[] soldItemsList;
        private int soldItemsCounter;
        public SoldItemsUserControl()
        {
            InitializeComponent();
            try
            {
                Class.SoldItems.LoadSoldItemsFromDBToDtg loadSoldItemsFromDBToDtg = new Class.SoldItems.LoadSoldItemsFromDBToDtg(dtgSoldItems);
            }
            catch
            { }
        }        
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Getting solditem list from allegro webApi server
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AllegroChaosBuster", true);
                Class.SoldItems.GetMySoldItems GetMySoldItemsClass = new Class.SoldItems.GetMySoldItems((string)key.GetValue("sessionHandle"));

                //test
                soldItemsList = GetMySoldItemsClass.ReturnSoldItemList();
                soldItemsCounter = GetMySoldItemsClass.ReturnsoldItemsCounter();
                lblError.Content = "Great Success";
            }
            catch
            {
                lblError.Content = "Error" ;
            }
        }

        private void btnSaveSoldItemsToDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.SoldItems.SaveSoldItemsToDB saveSoldIemsToDB = new Class.SoldItems.SaveSoldItemsToDB(soldItemsList);
                lblError2.Content = "Great Success";
            }
            catch(InvalidCastException ex)
            {
                lblError2.Content = "Error";
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Class.SoldItems.LoadSoldItemsFromDBToDtg loadSoldItemsFromDBToDtg = new Class.SoldItems.LoadSoldItemsFromDBToDtg(dtgSoldItems);
        }
    }
}
