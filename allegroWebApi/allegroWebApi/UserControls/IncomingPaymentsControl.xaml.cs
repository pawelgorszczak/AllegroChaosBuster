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
using allegroWebApi.pl.allegro.webapi;
using System.Web.Services.Protocols;
using System.Data.Entity.Migrations;

namespace allegroWebApi.UserControls
{
    /// <summary>
    /// Interaction logic for IncomingPayementsControl.xaml
    /// </summary>
    public partial class IncomingPayementsControl : UserControl
    {
        private string sessionHandler {get; set; }
        private UserIncomingPaymentStruct[] userIncomingPaymentStruct { get; set; }
        public IncomingPayementsControl()
        {
            InitializeComponent();
            //ShowSomeDateInDtg();
        }
        private void ShowSomeDateInDtg()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AllegroChaosBuster", true);
                sessionHandler = (string)key.GetValue("sessionHandle");
                Class.MyIncomingPayments.GetMyIncomingPayments getMyIncomingPayments = new Class.MyIncomingPayments.GetMyIncomingPayments(sessionHandler);
                
                         
                Class.MyIncomingPayments.DataBaseOperations dataBaseOperations = new Class.MyIncomingPayments.DataBaseOperations();
                //dataBaseOperations.ConnectionOpen();
                dataBaseOperations.SaveDataToDataBase(getMyIncomingPayments.ReturnMyIncomingPayementStruct());
                //dataBaseOperations.ConnectionClose();               
            }
            catch(SoapException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnShowData_Click(object sender, RoutedEventArgs e)
        {
            ShowSoldItemsFromCategoryEqualedNull();
        }
        private void ShowSoldItemsFromCategoryEqualedNull()
        {
            Class.MyIncomingPayments.DataBaseOperations dataBaseOperations = new Class.MyIncomingPayments.DataBaseOperations();
            
            AllegroChaosBusterDBContext myDB = new AllegroChaosBusterDBContext();
            
            int i = 0;
            var cos4 = dataBaseOperations.GetDataFromDataBase();
            var cos5 = dataBaseOperations.GetDataFromDataBaseWithDeclaredCategory("");
            foreach (var myInc in cos5)
            {
                i++;
            }
            MessageBox.Show(i.ToString());

            
        }
    }
}
