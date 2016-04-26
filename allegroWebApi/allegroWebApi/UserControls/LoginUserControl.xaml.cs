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

namespace allegroWebApi.UserControls
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblError.Content = "";
                Class.LoginTo loginTo = new Class.LoginTo(txtLogin.Text, passwdboxPassword.Password);
                lblError.Content = "You have been succesfully loged in";
            }
            catch
            {
                lblError.Content = "Wrong login or password";
            }
        }
        public void DoLoginEncCompleted(object sender, doLoginEncCompletedEventArgs e)
        {
            MessageBox.Show("fff");
        }
    }
}
