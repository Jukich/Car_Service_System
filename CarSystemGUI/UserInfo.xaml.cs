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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;

namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page ,INotifyPropertyChanged
    {

        private CarServiceDBEntities1 context = new CarServiceDBEntities1();
        public static List<Car> CarList;
        User user;
        public int userID;

        public UserInfo(int currentUserID)
        {

            this.user = context.Users.Where(i => i.Id == currentUserID).First();
            this.userID = currentUserID;
            if (this.user.Gender == "Male")
            {
                this._Gender = true;
            }
            InitializeComponent();

            CarList = context.Cars.Where(i => i.UserID == this.user.Id).ToList();
            DataContext = this;
            this.PreviewKeyDown += new KeyEventHandler(EnterKeyPressed);
        }

        public IEnumerable<Car> _Cars
        {
            get
            {
                return CarList;
            }
        }

        public  string _Name
        {
            get
            {
                return this.user.Name;
            }
            set
            {
                this.user.Name = value;
                context.SaveChanges();
                OnPropertyChanged("_Name");
            }
        }

        public  string Surename
        {
            get

            {
                return this.user.Surename;
            }
            set
            {
                this.user.Surename = value;
                context.SaveChanges();
                OnPropertyChanged("Surename");
            }
        }

        public long IDCardNumber
        {
            get
            {
                return this.user.IdCardNumber;
            }
            set
            {
                
                this.user.IdCardNumber = long.Parse(value.ToString()); ;
                context.SaveChanges();
                OnPropertyChanged("IDCardNumber");

            }
        }

        public  long EGN
        {
            get
            {
                return this.user.EGN;
            }

            set
            {
                this.user.EGN = long.Parse(value.ToString());

                context.SaveChanges();
                OnPropertyChanged("EGN");


            }
        }

        public string Address
        {
            get

            {
                return user.Address;
            }
            set
            {
                this.user.Address = value;
                context.SaveChanges();
                OnPropertyChanged("Address");
            }
        }

        public  string Gender
        {
            get
            {
                return this.user.Gender;
            }
            
        }

        public bool _Gender
        {
            get;set;
        }
 
        public string Phone
        {
            get

            {
                return this.user.PhoneNumber;
            }
            set
            {
                this.user.PhoneNumber = value;
                context.SaveChanges();
                OnPropertyChanged("Phone");
            }
        }

        public  string Email
        {
            get
            {
                return user.Email;
            }
            set
            {
                this.user.Email = value;
                context.SaveChanges();
                OnPropertyChanged("Email");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void EnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            Keyboard.Focus(lblFocused);

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach(TextBox tx in gr.Children.OfType<TextBox>())
            {
                tx.IsReadOnly = false;
            }
            foreach (TextBox tx in gr2.Children.OfType<TextBox>())
            {
                tx.IsReadOnly = false;
            }
            txtGender.Visibility = Visibility.Hidden;
            btnMale.Visibility = Visibility.Visible;
            btnFemale.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Hidden;
            btnStopEdit.Visibility = Visibility.Visible;
            btnDeleteUser.Visibility = Visibility.Visible;

        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            AddUserCar us = new AddUserCar(user.Id);
            us.ShowDialog();
            CarList = context.Cars.Where(i => i.UserID == this.user.Id).ToList();
            OnPropertyChanged("_Cars");
        }

        private void BtnStopEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox tx in gr.Children.OfType<TextBox>())
            {
                tx.IsReadOnly = true;
            }
            foreach (TextBox tx in gr2.Children.OfType<TextBox>())
            {
                tx.IsReadOnly = true;
            }
            txtGender.Visibility = Visibility.Visible;
            btnMale.Visibility = Visibility.Hidden;
            btnFemale.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Visible;
            btnStopEdit.Visibility = Visibility.Hidden;
            btnDeleteUser.Visibility = Visibility.Hidden;
            OnPropertyChanged("_Name");
            OnPropertyChanged("Surename");
            OnPropertyChanged("EGN");
            OnPropertyChanged("IDCardNumber");
            OnPropertyChanged("Phone");
            OnPropertyChanged("Address");
            OnPropertyChanged("Gender");
            OnPropertyChanged("Email");



        }

        private void BtnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            var item = datagr.SelectedItem;
            var selecedRegNumber = (datagr.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;

            int selectedCarID = context.Cars.Where(i => i.RegNumber == selecedRegNumber).First().Id;
            CarInfo carInfo = new CarInfo(selectedCarID,this.user.Id);
            carInfo.ShowDialog();
            OnPropertyChanged("_Cars");
        }

        private void BtnMale_Checked(object sender, RoutedEventArgs e)
        {
            this.user.Gender = "Male";
            context.SaveChanges();
            this._Gender = true;
            OnPropertyChanged("Gender");

        }

        private void BtnFemale_Checked(object sender, RoutedEventArgs e)
        {
            this.user.Gender = "Female";
            this._Gender = false;
            context.SaveChanges();
            OnPropertyChanged("Gender");
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {

            foreach (Car c in context.Cars)
            {
                if (c.UserID == this.userID)
                {
                    foreach (Repair r in context.Repairs)
                    {
                        if (r.CarID == c.Id)
                        {
                            context.Repairs.Remove(r);
                        }
                    }
                    context.Cars.Remove(c);
                }
            }
            User u = context.Users.Where(i => i.Id == this.userID).First();
            context.Users.Remove(u);
            context.SaveChanges();
            MessageBox.Show("Done");
            this.NavigationService.Navigate(new Homepage());
        }


        ~UserInfo()
        {
            context.Dispose();
        }


    }

}
