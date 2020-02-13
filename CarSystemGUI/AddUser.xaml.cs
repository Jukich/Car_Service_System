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
using System.Data.Entity.Validation;

namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {

        public static int propNum=9;
        public AddUser()
        {
            InitializeComponent();
            DataContext = this;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtSurename.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtIdNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtEGN.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtCountry.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtCity.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtStreet.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPhone.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtEmail.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            int result = 0;
            foreach (TextBox txt in gr.Children.OfType<TextBox>())
            {
                result+= System.Windows.Controls.Validation.GetErrors(txt).Count;
            }

            if (result == 0)
            {
                using (var context = new CarServiceDBEntities1())
                {
                    foreach(User user in context.Users)
                    {
                        if (user.EGN == long.Parse(txtEGN.Text))
                        {
                            MessageBox.Show("User with this EGN already exists!");
                            return;
                        }
                        if (user.IdCardNumber == long.Parse(txtIdNumber.Text))
                        {
                            MessageBox.Show("User with this ID card already exists!");
                            return;
                        }
                    }

                    User u = new User();
                    u.Name = txtName.Text;
                    u.Surename = txtSurename.Text;
                    u.IdCardNumber = long.Parse(txtIdNumber.Text);
                    u.EGN = long.Parse(txtEGN.Text);
                    u.Address = txtCountry.Text + ", " + txtCity.Text + ", " + txtStreet.Text;
                    if (btnMale.IsChecked == true)
                        u.Gender = btnMale.Content.ToString();
                    if (btnFemale.IsChecked == true)
                        u.Gender = btnMale.Content.ToString();
                    u.PhoneNumber = txtPhone.Text;
                    u.Email = txtEmail.Text;

                    context.Users.Add(u);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var errors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in errors.ValidationErrors)
                            {

                                string errorMessage = validationError.ErrorMessage;
                                MessageBox.Show(errorMessage);

                            }
                        }
                    }
                }
                MessageBox.Show("Done");
                this.Close();
            }

        }

        public virtual string _Name { get; set; }

        public virtual string Surename { get; set; }

        public virtual long? IDCardNumber { get; set; }

        public virtual long? EGN { get; set; }

        public virtual string Country { get; set; }

        public virtual string City { get; set; }

        public virtual string Street { get; set; }

        public virtual string Gender { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Email { get; set; }

        private void TxtIdNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
