using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        // clienteknek wsdl cím: http://localhost:57079/MyService.svc?wsdl

        private MyDatabaseEntities mde = new MyDatabaseEntities();

        Dictionary<string, string> loggedInUsers = new Dictionary<string, string>();

        public bool Login(string username, string password)
        {
            try
            {
                Users user = mde.Users.FirstOrDefault(p => p.Username == username);
                if (user != null && !loggedInUsers.ContainsKey(username))
                {
                    if (user.Password == password)
                    {
                        string sessionId = Guid.NewGuid().ToString();
                        loggedInUsers.Add(username, sessionId);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("Login Fault : " + exception.Message);
                return false;
            }
        }

        public bool IsAdmin(string adminName)
        {
            
        }

        public void Logout(string username)
        {
            try
            {
                loggedInUsers.Remove(username);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("Logout Fault : " + exception.Message);
            }
        }

        public bool Register(string username, string password)
        {
            try
            {
                Users user = mde.Users.FirstOrDefault(p => p.Username == username);
                if (user == null)
                {
                    Users newUser = new Users();

                    newUser.Username = username;
                    newUser.Password = password;

                    mde.Users.Add(newUser);
                    mde.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(Login)Fault! : " + exception.Message);
                return false;
            }
        }


        public void Add(string brand, string model, int productionYear, string engine, string transmission, string condition, int distanceTraveled, int price, string licensePlateNumber, string location, string phoneNumber)
        {
            try
            {
                lock (mde.CarRegistry)
                {
                    CarRegistry cr = new CarRegistry();

                    cr.Brand = brand;
                    cr.Model = model;
                    cr.ProductionYear = productionYear;
                    cr.Engine = engine;
                    cr.Transmission = transmission;
                    cr.Condition = condition;
                    cr.DistanceTraveled = distanceTraveled;
                    cr.Price = price;
                    cr.LicensePlateNumber = licensePlateNumber;
                    cr.Location = location;
                    cr.PhoneNumber = phoneNumber;

                    mde.CarRegistry.Add(cr);
                    mde.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(GetUser)Fault! : " + exception.Message);
            }
        }

        public bool ChangePassword(string name, string oldPassword, string newPassword)
        {
            try
            {
                lock (mde.Users)
                {
                    Users currentUser = GetUser(name);
                    if (currentUser.Password == oldPassword)
                    {
                        currentUser.Password = newPassword;
                        mde.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(GetUser)Fault! : " + exception.Message);
                return false;
            }
        }

        public void Delete(int id)
        {
            try
            {
                lock (mde.CarRegistry)
                {
                    var carToDelete = mde.CarRegistry.FirstOrDefault(p => p.Id == id);
                    mde.CarRegistry.Remove(carToDelete);
                    mde.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(Delete)Fault! : " + exception.Message);
            }
        }

        public CarRegistry FindCarByLicensePlateNumber(string licensePlateNumber)
        {
            try
            {
                return mde.CarRegistry.Single(p => p.LicensePlateNumber == licensePlateNumber);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(GetCar)Fault! : " + exception.Message);
                return null;
            }
        }

        public List<Users> GetAllUser()
        {
            try
            {
                return mde.Users.ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(GetAllUser)Fault! : " + exception.Message);
                return null;
            }
        }

        public CarRegistry GetCar(int id)
        {
            try
            {
                return mde.CarRegistry.Single(p => p.Id == id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(GetCar)Fault! : " + exception.Message);
                return null;
            }
        }

        public List<CarRegistry> GetCarList()
        {
            try
            {
                return mde.CarRegistry.ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(GetCarlist)Fault! : " + exception.Message);
                return null;
            }
        }

        public Users GetUser(string username)
        {
            try
            {
                return mde.Users.Single(p => p.Username == username);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(GetUser)Fault! : " + exception.Message);
                return null;
            }
        }



        public void Update(int id, string brand, string model, int productionYear, string engine, string transmission, string condition, int distanceTraveled, int price, string licensePlateNumber, string location, string phoneNumber)
        {
            try
            {
                lock (mde.CarRegistry)
                {
                    CarRegistry cr = GetCar(id);
                    if (cr != null)
                    {
                        cr.Brand = brand;
                        cr.Model = model;
                        cr.ProductionYear = productionYear;
                        cr.Engine = engine;
                        cr.Transmission = transmission;
                        cr.Condition = condition;
                        cr.DistanceTraveled = distanceTraveled;
                        cr.Price = price;
                        cr.LicensePlateNumber = licensePlateNumber;
                        cr.Location = location;
                        cr.PhoneNumber = phoneNumber;

                        mde.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
                Console.WriteLine("(Login)Fault! : " + exception.Message);
            }
        }
    }
}
