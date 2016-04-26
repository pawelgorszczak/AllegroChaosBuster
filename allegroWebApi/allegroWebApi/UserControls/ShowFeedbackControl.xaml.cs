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
using System.Data;

namespace allegroWebApi.UserControls
{
    /// <summary>
    /// Interaction logic for ShowFeedbackControl.xaml
    /// </summary>
    public partial class ShowFeedbackControl : UserControl
    {        
        public ShowFeedbackControl()
        {
            InitializeComponent();
        }
        

        private void btnLoadFeedbacks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AllegroChaosBuster", true);
                Class.ShowFeedback Showfeedbacks = new Class.ShowFeedback((string)key.GetValue("sessionHandle"), Convert.ToInt64(key.GetValue("userId")));                
                key.Close();

                dtgFeedbackData.Items.Clear();
                for (int i = 0; i < Showfeedbacks.ReturnFeedbackCount(); i++)
                {
                    dtgFeedbackData.Items.Add(new
                    {
                        Id = Showfeedbacks.ReturnFeedbackList()[i].fid,
                        From = Showfeedbacks.ReturnFeedbackList()[i].fuserlogin,
                        Desc = Showfeedbacks.ReturnFeedbackList()[i].fdesc

                    });
                }
                
            }
            catch
            {
                MessageBox.Show("trlololo");
            }
        }
    }
}
