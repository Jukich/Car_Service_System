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
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for CarInfo.xaml
    /// </summary>
    public partial class CarInfo : Window,INotifyPropertyChanged
    {
        Car car;
        int carID, userID;
        List<string> BrandsList;
        static List<string> ModelsList;
        static List<string> ColoursList;
        public static List<Repair> RepairsList = new List<Repair>();

        private CarServiceDBEntities1 context = new CarServiceDBEntities1();

        public CarInfo(int carID, int userID)
        {
            this.carID = carID;
            this.userID = userID;
            this.car = context.Cars.Where(i => i.Id == carID).First();
            this.VINNumber = car.WINnumber;
            this.RegNumber = car.RegNumber;

            RepairsList = context.Repairs.Where(i => i.CarID == this.carID).OrderByDescending(i => i.DayOfRepair).ToList();

            InitializeComponent();
            DataContext = this;
        }

        public void Add()
        {
            Repair c = new Repair();
            c.DayOfRepair = DateTime.Now;
            c.Description = "Engine";
            c.PriceOfRepair = 120.50;
            c.CarID = carID;
            context.Repairs.Add(c);
            context.SaveChanges();
        }

        public IEnumerable<string> Brand
        {
            get
            {
                return BrandsList;
            }
        }
        public string SelectedBrand
        {
            get
            {
                return context.Brands.Where(i => i.Id == car.BrandID).Select(i => i.Name).FirstOrDefault();
            }
            set
            {
                car.BrandID = context.Brands.Where(i => i.Name == value).Select(i => i.Id).First();
                ModelsList = context.Models.Where(i => i.BrandID == car.BrandID).Select(i => i.Name).ToList();
                OnPropertyChanged("Model");
            }
        }

        public IEnumerable<string> Model
        {
            get
            {
                return ModelsList;
            }
        }
        public string SelectedModel
        {
            get
            {
                return context.Models.Where(i => i.Id == car.ModelID).Select(i=>i.Name).FirstOrDefault();
            }
            set
            {
                try
                {
                    int id = context.Models.Where(i => i.Name == value).Select(i => i.Id).First();
                    this.car.ModelID = id;
                    OnPropertyChanged("SelectedModel");
                }
                catch (Exception ex)
                {

                }
              
            }
        }

        public IEnumerable<string> Colour
        {
            get
            {
                return ColoursList;
            }
        }
        public string SelectedColour
        {
            get
            {
                return this.car.Colour;
            }
            set
            {
                if (this.car.Colour == value) return;
                this.car.Colour = value;
                OnPropertyChanged("SelectedColour");
            }

        }

        public IEnumerable<Repair> Repairs { get { return RepairsList; } }

        public string VINNumber { get; set; }

        public string RegNumber { get; set; }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtBrand.Visibility = Visibility.Hidden;
            txtModel.Visibility = Visibility.Hidden;
            txtColour.Visibility = Visibility.Hidden;
            txtRegNumber.IsReadOnly = false;
            txtVinNumber.IsReadOnly = false;
            cmbBrand.Visibility = Visibility.Visible;
            cmbModel.Visibility = Visibility.Visible;
            cmbColour.Visibility = Visibility.Visible;
            btnStopEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Hidden;
            btnDeleteCar.Visibility = Visibility.Visible;

            BrandsList = context.Brands.Select(i => i.Name).ToList();
           // br = context.Brands.Where(i => i.Id == car.BrandID).FirstOrDefault();
            ModelsList = context.Models.Where(i => i.BrandID == car.BrandID).Select(i => i.Name).ToList();

            ColoursList = new List<string>();
            foreach (System.Reflection.PropertyInfo prop in typeof(Colors).GetProperties())
            {
                ColoursList.Add(prop.Name);
            }

            OnPropertyChanged("Brand");
            OnPropertyChanged("Model");
            OnPropertyChanged("Colour");
            OnPropertyChanged("SelectedModel");

        }

        private void BtnStopEdit_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            txtVinNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtRegNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            foreach (TextBox txt in gr.Children.OfType<TextBox>())
            {
                result += System.Windows.Controls.Validation.GetErrors(txt).Count;
            }
            if (result == 0)
            {
                foreach (Car car in context.Cars)
                {
                    if (car.Id == this.car.Id)
                        continue;

                    if (car.WINnumber == this.VINNumber)
                    {
                        MessageBox.Show("Car with this VIN number already exists");
                        return;
                    }

                    if (car.RegNumber == this.RegNumber)
                    {
                        MessageBox.Show("Car with this registration number already exists");
                        return;
                    }
                }

                //car.BrandID = context.Brands.Where(i => i.Name == SelectedBrand).Select(i => i.Id).First();
                //car.ModelID = context.Models.Where(i => i.Name == SelectedModel).Select(i => i.Id).First();
                //car.Colour = SelectedColour;

                car.WINnumber = VINNumber;
                car.RegNumber = RegNumber;
                context.SaveChanges();
                UserInfo.CarList = context.Cars.Where(i => i.UserID == this.userID).ToList();
                MessageBox.Show("Done");

                OnPropertyChanged("SelectedBrand");
                OnPropertyChanged("SelectedModel");
                OnPropertyChanged("SslectedColour");

                txtBrand.Visibility = Visibility.Visible;
                txtModel.Visibility = Visibility.Visible;
                txtColour.Visibility = Visibility.Visible;
                txtRegNumber.IsReadOnly = true;
                txtVinNumber.IsReadOnly = true;
                cmbBrand.Visibility = Visibility.Hidden;
                cmbModel.Visibility = Visibility.Hidden;
                cmbColour.Visibility = Visibility.Hidden;
                btnStopEdit.Visibility = Visibility.Hidden;
                btnCancel.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Visible;
                btnDeleteCar.Visibility = Visibility.Hidden;

            }


        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtBrand.Visibility = Visibility.Visible;
            txtModel.Visibility = Visibility.Visible;
            txtColour.Visibility = Visibility.Visible;
            txtRegNumber.IsReadOnly = true;
            txtVinNumber.IsReadOnly = true;
            cmbBrand.Visibility = Visibility.Hidden;
            cmbModel.Visibility = Visibility.Hidden;
            cmbColour.Visibility = Visibility.Hidden;
            btnStopEdit.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Visible;
            btnDeleteCar.Visibility = Visibility.Hidden;

            context.Entry(this.car).Reload();
            this.RegNumber = this.car.RegNumber;
            this.VINNumber = this.car.WINnumber;
            OnPropertyChanged("Brand");
            OnPropertyChanged("Model");
            OnPropertyChanged("SelectedColour");
            OnPropertyChanged("SelectedModel");
            OnPropertyChanged("SelectedBrand");
            OnPropertyChanged("RegNumber");
            OnPropertyChanged("VINNumber");
        }

        private void BtnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            var item = datagr.SelectedItem;
            var selectedRepairID = int.Parse((datagr.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            RepairInfo repairInfo = new RepairInfo(selectedRepairID);
            repairInfo.ShowDialog();
            OnPropertyChanged("Repairs");
        }

        public DateTime? DateOfRepair{ get; set; }

        public double? Price { get; set; }

        private void BtnAddRepair_Click(object sender, RoutedEventArgs e)
        {
            txtAddPrice.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (DateOfRepair == null)
            {
                MessageBox.Show("Select date");
                return;
            }
            if (DateOfRepair > DateTime.Now)
            {
                MessageBox.Show("Invalid Date");
                return;
            }
            if (System.Windows.Controls.Validation.GetErrors(txtAddPrice).Count == 0)
            {
                Repair r = new Repair();
                r.CarID = this.carID;
                r.DayOfRepair = DateOfRepair;
                r.PriceOfRepair = Price;
                context.Repairs.Add(r);
                context.SaveChanges();
                MessageBox.Show("Done");
                RepairsList = context.Repairs.Where(i => i.CarID == this.carID).OrderBy(i => i.DayOfRepair).ToList();
                OnPropertyChanged("Repairs");
                
            }

        }

        private void BtnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            foreach(Repair r in context.Repairs)
            {
                if (r.CarID == this.carID)
                {
                    context.Repairs.Remove(r);
                }
            }
            Car c = context.Cars.Where(i => i.Id == this.carID).First();
            context.Cars.Remove(c);
            context.SaveChanges();
            UserInfo.CarList = context.Cars.Where(i => i.UserID == this.userID).ToList();
            MessageBox.Show("Done");
            
        }

        ~CarInfo()
        {
            context.Dispose();
        }
    }
}

