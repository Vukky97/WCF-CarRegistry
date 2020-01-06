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
    /// <summary>
    /// Interaction logic for CarRegistryWindow.xaml
    /// </summary>
    public partial class CarRegistryWindow : Window
    {
        public CarRegistryWindow(string name)
        {
            loggedInPersonName = name;
            InitializeComponent();
        }

        private static string loggedInPersonName;
        private bool loggedInAsAdmin = false;
        MyServiceClient msc = new MyServiceClient();

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            try
            {
                // Warning: bedore this that msc is refered like: LoginWindow.msc.GetCarList()
                dataGrid.ItemsSource = msc.GetCarList().Select(carEntity => new
                {
                    Id = carEntity.Id,
                    Brand = carEntity.Brand,
                    Model = carEntity.Model,
                    ProductionYear = carEntity.ProductionYear,
                    Engine = carEntity.Engine,
                    Transmission = carEntity.Transmission,
                    Condition = carEntity.Condition,
                    DistanceTraveled = carEntity.DistanceTraveled,
                    Price = carEntity.Price,
                    LicensePlateNumber = carEntity.LicensePlateNumber,
                    Location = carEntity.Location,
                    PhoneNumber = carEntity.PhoneNumber
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

        //TODO: 
        // Id alapjan ad vissza egy rekodot
        // rendszamra atirni inkabb?
        private void BTNGet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(TBID.Text);
                CarRegistry carEntity = msc.GetCar(id);

                TBBrand.Text = carEntity.Brand.ToString();
                TBModel.Text = carEntity.Model.ToString();
                TBProductionYear.Text = carEntity.ProductionYear.ToString();
                TBEngine.Text = carEntity.Engine.ToString();
                TBTransmission.Text = carEntity.Transmission.ToString();
                TBCondition.Text = carEntity.Condition.ToString();
                TBDistanceTraveled.Text = carEntity.DistanceTraveled.ToString();
                TBPrice.Text = carEntity.Price.ToString();
                TBLicensePlateNumber.Text = carEntity.LicensePlateNumber.ToString();
                TBLocation.Text = carEntity.Location.ToString();
                TBPhoneNumber.Text = carEntity.PhoneNumber.ToString();

                Refresh();
            }
            catch (FaultException<UnsuccesfullSearchFault>)
            {
                MessageBox.Show("Unsuccessful Search!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("(Get CarEntity) Fault! : " + exception.ToString());
            }
        }


        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {

            if (TBBrand.Text != "" && TBModel.Text != "" && TBProductionYear.Text != "" && TBEngine.Text != "" && TBTransmission.Text != "" &&
                TBCondition.Text != "" && TBDistanceTraveled.Text != "" && TBPrice.Text != "" && TBLicensePlateNumber.Text != "" && TBLocation.Text != "" &&
                TBPhoneNumber.Text != "")
            {
                try
                {
                    msc.Add(TBBrand.Text, TBModel.Text, int.Parse(TBProductionYear.Text), TBEngine.Text, TBTransmission.Text, TBCondition.Text,
                        int.Parse(TBDistanceTraveled.Text), int.Parse(TBPrice.Text), TBLicensePlateNumber.Text, TBLocation.Text, TBPhoneNumber.Text);

                    ClearAllTextBox();
                    Refresh();
                }
                catch (FaultException<IncorrectDataFault>)
                {
                    MessageBox.Show("Incorrect Data!");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("(Add Car to Registry) Fault! : " + exception.ToString());
                }
            }
            else
            {
                MessageBox.Show("Fill in all text boxes (Id box fill is optional)!");
            }
        }

        //TODO:  elotte check h adminkent leptel e be server oldalon, egy uj method, csak admin torolgethessen
        // uj formot csin neki? v csak kiegeszito ablakot enablelni , v egyszeruen csak a gombot enablelni.. ha adminkent van belepve
        // bool isASdmin 
        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TBID.Text.ToString() != "")
            {
                try
                {
                    msc.Delete(int.Parse(TBID.Text));
                    Refresh();
                }
                catch (FaultException<IncorrectDataFault>)
                {
                    MessageBox.Show("Incorrect Data!");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("(Delete Car) Fault! : " + exception.ToString());
                }
                TBID.Text = "";
            }
            else
            {
                MessageBox.Show("Fill the ID TextBox!");
            }
        }

        private void BTNReset_Click(object sender, RoutedEventArgs e)
        {
            ClearAllTextBox();
        }

        private void ClearAllTextBox()
        {
            TBBrand.Text = "";
            TBModel.Text = "";
            TBProductionYear.Text = "";
            TBEngine.Text = "";
            TBTransmission.Text = "";
            TBCondition.Text = "";
            TBDistanceTraveled.Text = "";
            TBPrice.Text = "";
            TBLicensePlateNumber.Text = "";
            TBLocation.Text = "";
            TBPhoneNumber.Text = "";
        }

        //TODO: ez is csak adminoknak?
        private void BTNChange_Click(object sender, RoutedEventArgs e)
        {
            //TODO: jelezni vhogy , akar showdialogboxxal h itt az ID-t is meg kell adni, v ki kell venni a serivcenel az Updatebol
            // vhogy jelezni ha tul angy ID-t ad meg az user lekerdezeskor, ha nem letezot ad meg, server, service oldalon check?
            try
            {
                msc.Update(int.Parse(TBID.Text), TBBrand.Text, TBModel.Text, int.Parse(TBProductionYear.Text), TBEngine.Text, TBTransmission.Text, TBCondition.Text,
                int.Parse(TBDistanceTraveled.Text), int.Parse(TBPrice.Text), TBLicensePlateNumber.Text, TBLocation.Text, TBPhoneNumber.Text);

                Refresh();
            }
            catch (FaultException<IncorrectDataFault>)
            {
                MessageBox.Show("Incorrect Data!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("(Change CarEntity) Fault! : " + exception.ToString());
            }
        }

        private void BTNLogOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                msc.Logout(loggedInPersonName);
                StartWindow window = new StartWindow();
                window.Show();
                this.Close();
                MessageBox.Show("You have successfully logged out!");
            }
            catch (FaultException<InvalidLogoutFault>)
            {
                MessageBox.Show("Incorrect logout!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("(Logout) Fault! : " + exception.ToString());
            }
        }

        private void BTNRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
