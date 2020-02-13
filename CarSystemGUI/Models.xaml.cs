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
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;



namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for Models.xaml
    /// </summary>
    public partial class Models : Page, INotifyPropertyChanged
    {
        CarServiceDBEntities1 context = new CarServiceDBEntities1();
        private string selectedModel;
        static List<Model> ModelList;
        private int BrandID;

        public Models(int Brandid)
        {
            this.BrandID = Brandid;
            ModelList = context.Models.Where(i => i.Brand.Id == this.BrandID).ToList();
            this.DataContext = this;
            InitializeComponent();

            var brandname = context.Brands.Where(i => i.Id == this.BrandID).Select(i => i.Name).First();
            lblBrand.Content = brandname + " models";
            this.PreviewKeyDown += new KeyEventHandler(DeleteKeyPressed);
            this.datagr.CellEditEnding += new EventHandler<DataGridCellEditEndingEventArgs>(OnCellEditEnding);

        }

        protected  void OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridRow r = (DataGridRow)datagr.ItemContainerGenerator.ContainerFromIndex(datagr.SelectedIndex);
            DataGridCell RowColumn = datagr.Columns[0].GetCellContent(r).Parent as DataGridCell;
            string modelName = ((TextBox)RowColumn.Content).Text;

            ((TextBox)RowColumn.Content).GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (System.Windows.Controls.Validation.GetErrors(((TextBox)RowColumn.Content)).Count != 0)
                return;

            var model = context.Models.Where(i => i.Name == selectedModel).First();

            if (!Regex.Match(modelName, @"^[A-Z]{1}[a-z]*$").Success)
            {
                MessageBox.Show("Model name can contain only letters and must start with upper case!");
                return;
            }
            if (modelName == "" || modelName.Equals(selectedModel))
            {
                return;
            }
            foreach(Model m in context.Models)
            {
                if (m.Name.Equals(modelName,StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("Brand with this name already exists");
                    return;
                }
            }
            
            model.Name = modelName;
            context.SaveChanges();
            selectedModel = modelName;
            ModelList = context.Models.Where(i => i.Brand.Id == this.BrandID).ToList();
            OnPropertyChanged("_Models");
        }

        public IEnumerable<Model> _Models
        {
            get
            {
                return ModelList;
            }
            set
            { 
                
            }
        }

        public string ModelName { get; set; }

        public string BrandName { get; set; }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            txtModelName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (System.Windows.Controls.Validation.GetErrors(txtModelName).Count != 0)
                return;


            if (txtModelName.Text == "")
            {
                MessageBox.Show("Field empty");
                return;
            }

            var modelList = context.Models.Where(i => i.Brand.Id == this.BrandID).ToList();

            foreach (Model model in modelList)
            {
                if (model.Name.Equals(txtModelName.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("This model already exists");
                    return;
                }
            }

            Model mod = new Model();
            mod.Name = txtModelName.Text;
            mod.BrandID = BrandID;

            context.Models.Add(mod);
            context.SaveChanges();

            ModelList = context.Models.Where(i => i.Brand.Id == BrandID).ToList();
            OnPropertyChanged("_Models");

        }

        private void btnChangeName_Click(object sender, RoutedEventArgs e)
        {
            txtChangeName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (System.Windows.Controls.Validation.GetErrors(txtChangeName).Count != 0)
                return;

            foreach (var br in context.Brands)
            {
                if (br.Name.Equals(txtChangeName.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("Brand with this name already exists");
                    return;
                }
            }
            if (txtChangeName.Text == "")
            {
                MessageBox.Show("Enter brand name");
                return;
            }

            var brand = context.Brands.First(i => i.Id == BrandID);
            brand.Name = txtChangeName.Text;
            context.SaveChanges();
            lblBrand.Content = brand.Name + " models";
            MessageBox.Show("Done");
            
        }

        private void btnCnageIMG_Click(object sender, RoutedEventArgs e)
        {

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

            var brand = context.Brands.First(i => i.Id == BrandID);
            brand.imageUrl = binaryImage;
            context.SaveChanges();
            MessageBox.Show("Done!");

        }

        private void btnRemoveModel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this model?", "Are you sure?",
                   MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                try
                {
                    var item = datagr.SelectedItem;
                    string modelName = (datagr.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    var model = context.Models.Where(i => (i.Name == modelName && i.Brand.Id == this.BrandID)).First();
                    context.Models.Remove(model);
                    context.SaveChanges();
                    ModelList = context.Models.Where(i => i.Brand.Id == BrandID).ToList();
                    OnPropertyChanged("_Models");

                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Choose model to delete");
                }
                catch (Exception ex)
                {

                }
            }

        }

        private void btnRemoveBrand_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this brand?", "Are you sure?",
                   MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {

                var modelList = context.Models.Where(i => i.Brand.Id == this.BrandID).ToList();
                foreach (Model mod in modelList)
                {
                    context.Models.Remove(mod);
                }
                context.SaveChanges();
                var brand = context.Brands.First(i => i.Id == this.BrandID);
                context.Brands.Remove(brand);
                context.SaveChanges();
                this.NavigationService.Navigate(new Homepage());
                MessageBox.Show("Done!");

            }
        }
        
        private void Datagr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = datagr.SelectedItem;
                selectedModel = (datagr.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch(NullReferenceException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch(ArgumentOutOfRangeException)
            {

            }
            
        }

        private void CellValueChanged(object sender, EventArgs e)
        {
            /*
            DataGridRow r = (DataGridRow)datagr.ItemContainerGenerator.ContainerFromIndex(datagr.SelectedIndex);
            DataGridCell RowColumn = datagr.Columns[0].GetCellContent(r).Parent as DataGridCell;
            string modelName = ((TextBox)RowColumn.Content).Text;

            ((TextBox)RowColumn.Content).GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (System.Windows.Controls.Validation.GetErrors(((TextBox)RowColumn.Content)).Count != 0)
                return;

            var model = context.Models.Where(i => i.Name == selectedModel).First();
            if (modelName == "" || modelName==selectedModel)
            {
                return;
            }

            model.Name = modelName;
            context.SaveChanges();
            selectedModel = modelName;
            */
        }

        private void BtnStartEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach(Control c in gr.Children)
            {
                c.Visibility = Visibility.Visible;
            }
            btnStartEdit.Visibility = Visibility.Hidden;
            datagrCol.IsReadOnly = false;

        }

        private void BtnStopEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control c in gr.Children)
            {
                if(c is TextBox || c is Button)
                c.Visibility = Visibility.Hidden;
            }
            btnStartEdit.Visibility = Visibility.Visible;
            datagrCol.IsReadOnly = true ;
        }

        private void DeleteKeyPressed(object sender, KeyEventArgs e)
        {
            if (btnStopEdit.Visibility == Visibility.Hidden)
            {
                MessageBox.Show("Enter edit mode first");
                ModelList = context.Models.Where(i => i.Brand.Id == BrandID).ToList();
                OnPropertyChanged("_Models");
                return;
            }
            if (e.Key == Key.Delete)
            {

                if (MessageBox.Show("Are you sure you want to delete this model?", "Are you sure?",
                       MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    OnPropertyChanged("_Models");
                }
                else
                {
                    try
                    {
                        var item = datagr.SelectedItem;
                        string modelName = (datagr.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        var model = context.Models.Where(i => (i.Name == modelName && i.Brand.Id == this.BrandID)).First();
                        context.Models.Remove(model);
                        context.SaveChanges();
                        ModelList = context.Models.Where(i => i.Brand.Id == BrandID).ToList();
                        OnPropertyChanged("_Models");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("Choose model to delete");
                    }
                }
            }
        }

        private void PageModels_Unloaded(object sender, RoutedEventArgs e)
        {
            context.Dispose();
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Datagr_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("dd");

        }

        private void Datagr_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("source");

        }

        ~Models()
        {
            context.Dispose();
        }
    }
}
