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

namespace allegroWebApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserControls.LoginUserControl loginObj = new UserControls.LoginUserControl();
            Content.Children.Clear();
            Content.Children.Add(loginObj);
        }

        private void btnSoldItems_Click(object sender, RoutedEventArgs e)
        {
            UserControls.SoldItemsUserControl soldItemsObj = new UserControls.SoldItemsUserControl();
            Content.Children.Clear();
            Content.Children.Add(soldItemsObj);

        }

        private void btnFeedbaks_Click(object sender, RoutedEventArgs e)
        {
            UserControls.ShowFeedbackControl showFeedbackObj = new UserControls.ShowFeedbackControl();
            Content.Children.Clear();
            Content.Children.Add(showFeedbackObj);
        }

        private void btnIncomingPayment_Click(object sender, RoutedEventArgs e)
        {
            UserControls.IncomingPayementsControl showIncomingPaymentsObj = new UserControls.IncomingPayementsControl();
            Content.Children.Clear();
            Content.Children.Add(showIncomingPaymentsObj);
        }        
    }
    
}
