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
namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for AddUserCar.xaml
    /// </summary>
    public partial class AddUserCar : Window, INotifyPropertyChanged
    {
        public int id;
        static List<string> BrandsList = new List<string>();
        static List<string> ModelsList = new List<string>();
        static List<string> Colours = new List<string>();
        Brand br;

        static AddUserCar()
        {
            using (CarServiceDBEntities1 context = new CarServiceDBEntities1())
            {
                BrandsList = context.Brands.Select(i => i.Name).ToList();
            }

            foreach (System.Reflection.PropertyInfo prop in typeof(Colors).GetProperties())
            {
                Colours.Add(prop.Name);
            }

        }

        public AddUserCar(int id)
        {
            this.id = id;
            //delete();
            this.DataContext = this;
            InitializeComponent();

        }

        public IEnumerable<string> Brand
        {
            get
            {
                return BrandsList;
            }
        }

        private string selectedBrand;
        public string SelectedBrand
        {
            get
            {
                return selectedBrand;
            }
            set
            {
                if (selectedBrand == value) return;
                    selectedBrand = value;
                using (var context = new CarServiceDBEntities1())
                {
                    br = context.Brands.Where(i => i.Name == selectedBrand).FirstOrDefault();
                    ModelsList = context.Models.Where(i => i.BrandID == br.Id).Select(i => i.Name).ToList();
                }
                OnPropertyChanged("Model");
            }
        }

        public IEnumerable<string> Model
        {
            get
            {
                return ModelsList;
            }
            set
            {
                ModelsList = value.ToList() ;
            }
        }

        private string selectedModel;
        public string SelectedModel
        {
            get
            {
                return this.selectedModel;
            }
            set
            {
                if (this.selectedModel == value) return;
                    this.selectedModel = value;
                OnPropertyChanged("SelectedModel");
            }
        }

        public string VINNumber { get; set; }

        public string RegNumber { get; set; }

        public IEnumerable<string> Colour
        {
            get
            {
                return Colours;
            }
        }

        private string selectedColour;
        public string SelectedColour
        {
            get
            {
                return this.selectedColour;
            }
            set
            {
                if (this.selectedColour == value) return;
                this.selectedColour = value;
                OnPropertyChanged("SelectedColour");
            }
           
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
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
                using (CarServiceDBEntities1 context = new CarServiceDBEntities1())
                {

                    foreach (Car car in context.Cars)
                    {
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

                    Car c = new Car();
                    c.BrandID = br.Id;
                    c.ModelID = context.Models.Where(i => i.Name == SelectedModel).Select(i => i.Id).First();
                    c.WINnumber = VINNumber;
                    c.RegNumber = RegNumber;
                    c.Colour = SelectedColour;
                    c.UserID = this.id;
                    context.Cars.Add(c);
                    context.SaveChanges();
                    MessageBox.Show("Done");
                    this.Close();

                }
            }
        }

        public void delete()
        {
            using (var contex = new CarServiceDBEntities1())
            {
                foreach (Car c in contex.Cars)
                {
                    contex.Cars.Remove(c);
                }
                contex.SaveChanges();
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
    }
}
