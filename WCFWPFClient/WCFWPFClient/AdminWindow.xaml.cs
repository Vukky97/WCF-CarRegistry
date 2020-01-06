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
    public partial class AdminWindow : Window
    {
        MyServiceClient msc = new MyServiceClient();

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            try
            {
                dataGrid.ItemsSource = msc.GetAllUser().Select(userEntity => new
                {
                    Id = userEntity.Id,
                    Username = userEntity.Username,
                    Password = userEntity.Password
                }
                ).ToList();
            }
            catch (FaultException<UnsuccesfullSearchFault>)
            {
                MessageBox.Show("Unsuccessful Search!");
            }
            catch (FaultException<IncorrectDataFault>)
            {
                MessageBox.Show("Incorrect Data!");
            }
        }

        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TBOperationID.Text.ToString() != "")
            {
                try
                {
                    msc.DeleteUser(int.Parse(TBOperationID.Text));
                    Refresh();
                }
                catch (FaultException<IncorrectDataFault>)
                {
                    MessageBox.Show("Incorrect Data!");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Delete User Fault : " + exception.ToString());
                }
                TBOperationID.Text = "";
            }
            else
            {
                MessageBox.Show("Fill the Operation ID TextBox!");
            }
        }

        private void BTNGetID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TBOperationID.Text;
                Users userEntity = msc.GetUser(name);

                //       TBBrand.Text = carEntity.Brand.ToString();
                TBName.Text = userEntity.Username.ToString();
                TBPassword.Text = userEntity.Password.ToString();
                Refresh();
            }
            catch (FaultException<UnsuccesfullSearchFault>)
            {
                MessageBox.Show("Unsuccessful Search!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Get User Fault : " + exception.ToString());
            }
        }

        private void BTNChangePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                msc.ChangePassword(TBName.Text, TBPassword.Text, TBNewPassword.Text);

                Refresh();
            }
            catch (FaultException<IncorrectDataFault>)
            {
                MessageBox.Show("Incorrect Data!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Change CarEntity Fault : " + exception.ToString());
            }
        }

        //TODO: Admin can delete user, chenge users pw, get users pw, 
    }
}
