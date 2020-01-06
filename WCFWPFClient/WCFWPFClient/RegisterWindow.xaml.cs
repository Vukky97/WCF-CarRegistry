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
    public partial class RegisterWindow : Window
    {
        MyServiceClient msc = new MyServiceClient();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void BTNRegister_Click(object sender, RoutedEventArgs e)
        {
            if (TBUserName.Text != "" && PBPassword.Password != "")
            {
                try
                {
                    if (msc.Register(TBUserName.Text, PBPassword.Password))
                    {
                        StartStartWindow();
                        MessageBox.Show("Successful register!");
                    }
                    else
                    {
                        // TODO: fault 
                        ClearTextBoxes();
                        MessageBox.Show("Registration fail!");
                    }
                }
                catch (Exception exception)
                {
                    ClearTextBoxes();
                    MessageBox.Show("Registration fail! : " + exception.ToString());
                }
            }
            else
            {
                ClearTextBoxes();
                MessageBox.Show("Fill all the options above!");
            }
        }


        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {
            StartStartWindow();
        }


        public void ClearTextBoxes()
        {
            TBUserName.Text = "";
            PBPassword.Password = "";
        }

        public void StartStartWindow()
        {
            StartWindow window = new StartWindow();
            window.Show();
            this.Close();
        }

    }
}
