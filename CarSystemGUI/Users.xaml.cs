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

namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page,INotifyPropertyChanged
    {
        public static List<User> UserLIst;

        public Users()
        {
            ShowsNavigationUI = true;

            using (var context = new CarServiceDBEntities1())
            {
                
                UserLIst = context.Users.OrderBy(x => x.Name).ToList();

            }
            DataContext = this;
            InitializeComponent();
        }

        public IEnumerable<User> _User { get { return UserLIst; } }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new CarServiceDBEntities1())
            {
                var item = datagr.SelectedItem;
                var selectedEmail = (datagr.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                int selectedUserID = context.Users.Where(i => i.Email == selectedEmail).First().Id;
                UserInfo usInfo = new UserInfo(selectedUserID);
                this.NavigationService.Navigate(usInfo);
            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUser adduser = new AddUser();
            adduser.ShowDialog();
            using (var context = new CarServiceDBEntities1())
            {
                UserLIst = context.Users.OrderBy(x => x.Name).ToList();
                User u = new User();
            }
            OnPropertyChanged("_User");
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
