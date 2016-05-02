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
            //UpdateMyincomingPayements();
        }
        private void UpdateMyincomingPayements()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AllegroChaosBuster", true);
                sessionHandler = (string)key.GetValue("sessionHandle");
                Class.MyIncomingPayments.GetMyIncomingPayments getMyIncomingPayments = new Class.MyIncomingPayments.GetMyIncomingPayments(sessionHandler);
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

            var dtg = new DataGrid();
            var dtc = new DataGridTextColumn();
            //MessageBox.Show(dataBaseOperations.GetPayTransDetailsForSpecyfiedID(item.PayTransID).ToList()[0]);
            foreach (var item in cos4)
            {
                if(item.ItemID == 0)
                {
                    dtgMyInconigPayments.Items.Add(new {
                        TransactionID = item.PayTransID,
                        ItemTitle = "Title is not avaliable",
                        BuyerNickName = "NULL",
                        ItemId = item.ItemID,
                        PaymentStatus = item.PayTransType
                    });
                }
                else
                {
                    dtgMyInconigPayments.Items.Add(new {
                        TransactionID = item.PayTransID,
                        ItemTitle = "Title is not avaliable",
                        BuyerNickName = "NULL",
                        itm = dataBaseOperations.GetPayTransDetailsForSpecyfiedID(item.PayTransID).ToList()
                    });
                }
                        
            }
            //dtTemplate.Resources.Add(new TextBlock { Text = "daawdawd" }, null);
            //dtg.Items.Add(dtTemplate);
            
            //dtgMyInconigPayments.Items.Add(dtg);
            

        }
    }
}
