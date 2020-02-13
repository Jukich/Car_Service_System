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
using System.IO;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for AddBrand.xaml
    /// </summary>
    public partial class AddBrand : Window, INotifyPropertyChanged
    {
        public AddBrand()
        {
            InitializeComponent();
        }
        Brand br;

        public string _Name { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            using (CarServiceDBEntities1 context = new CarServiceDBEntities1())
            {
                foreach (var brand in context.Brands)
                {
                    if (brand.Name.Equals(txtRead.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        MessageBox.Show("Brand with this name already exists");
                        return;
                    }
                }

                Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
                fileDialog.Filter = "Image File (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                fileDialog.ShowDialog();

                if (fileDialog.FileName == null || fileDialog.FileName == "")
                {
                    return;
                }
                byte[] binaryImage;
                using (Stream stream = File.OpenRead(fileDialog.FileName))
                {
                    binaryImage = new byte[stream.Length];
                    stream.Read(binaryImage, 0, (int)stream.Length);
                }
                br = new Brand();
                br.Name = txtRead.Text.ToString();
                br.imageUrl = binaryImage;
                btnAdd.IsEnabled = true;


            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.Match(txtRead.Text, @"^[A-Z]{1}[a-z]*$").Success)
            {
                MessageBox.Show("Brand name can contain only letters and must start with upper case!");
                return;
            }

            else
            {
                using (CarServiceDBEntities1 context = new CarServiceDBEntities1())
                {

                    br.Name = txtRead.Text.ToString();
                    context.Brands.Add(br);
                    context.SaveChanges();
                    MessageBox.Show("Done!");
                    this.Close();
                }
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
