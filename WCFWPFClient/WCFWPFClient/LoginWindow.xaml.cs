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
using System.ServiceModel;
using WCFWPFClient.MyServiceReference;

namespace WCFWPFClient
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private static MyServiceClient msc = new MyServiceClient();
        private static bool loggedIn = false;
        private string userName;

        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {
            StartWindow window = new StartWindow();
            window.Show();
            this.Close();
        }

        private void BTNLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TBUserName.Text != "" && PBPassword.Password != "")
            {
                try
                {
                    if (msc.Login(TBUserName.Text, PBPassword.Password))
                    {
                        loggedIn = true;
                        userName = TBUserName.Text;
                        CarRegistryWindow crw = new CarRegistryWindow(userName);
                        crw.Show();
                        this.Close();
                        MessageBox.Show("Successful login!");
                    }
                    else
                    {
                        MessageBox.Show("Unable to find this username, password pair!");
                    }
                }
                catch (FaultException<InvalidLoginFault>)
                {
                    MessageBox.Show("Invalid login!");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Login fail! : " + exception.ToString());
                }
            }
            else
            {
                MessageBox.Show("Fill the whole form, please!");
            }
        }
    }
}
