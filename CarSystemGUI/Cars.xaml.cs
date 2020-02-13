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
using System.Diagnostics;


namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {

        const int left = 30, right = 620, top = 80, bottom = 250;
        int horizontal = 0;
        int vertical = 0;
        private object downSender;

        public Cars()
        {
            ShowsNavigationUI = true;
            InitializeComponent();
            OrderPage();
        }

        
        /*public void Fill()
        {
            List<Hyperlink> hplCar = new List<Hyperlink>();
            List<TextBlock> txtCar = new List<TextBlock>();
            CarServiceDBEntities1 context = new CarServiceDBEntities1();
            Brand br;


            txtCar.Add(new TextBlock());
            hplCar.Add(new Hyperlink());
            br = context.Brands.FirstOrDefault();

            hplCar[0].Inlines.Add(br.Name);
            hplCar[0].Foreground = Brushes.Black;
            hplCar[0].FontWeight = FontWeights.Bold;
            hplCar[0].TextDecorations = null;
            txtCar[0].Inlines.Add(hplCar[0]);

            Border border = new Border();
            border.Width = 100;
            border.Height = 100;
            Grid grid = new Grid();
            border.Child = grid;
            Image im = new Image();
            RenderOptions.SetBitmapScalingMode(im, BitmapScalingMode.Fant);
            BorderContent(grid, im, br.imageUrl, txtCar[0]);
            gr.Children.Add(border);


            DataGridRow dhr = new DataGridRow();
            var item = datagr.SelectedItem;
            int row = 0;
            int col = 0;
            DataGridRow r = (DataGridRow)datagr.ItemContainerGenerator.ContainerFromIndex(row);
            DataGridCell RowColumn = datagr.Columns[col].GetCellContent(r).Parent as DataGridCell;
            RowColumn.Content = border;
        }
        */

        public void OrderPage()
        {

            List<Brand> CarList = null;
            using (var context = new CarServiceDBEntities1())
            {
                CarList = context.Brands.ToList();
            }
            
            gr.Height = 450;
            int i = 1;
            List<Hyperlink> hplCar = new List<Hyperlink>();
            List<TextBlock> txtCar = new List<TextBlock>();


            foreach(Brand br in CarList)
            { 

                txtCar.Add(new TextBlock());
                hplCar.Add(new Hyperlink());

                hplCar[i - 1].Inlines.Add(br.Name);
                hplCar[i - 1].Foreground = Brushes.Black;
                hplCar[i - 1].FontWeight = FontWeights.Bold;
                hplCar[i - 1].TextDecorations = null;
                txtCar[i - 1].Inlines.Add(hplCar[i - 1]);

                Border border = new Border();
                BorderMargin(border, i);

                Grid grid = new Grid();
                border.Child = grid;
                Image im = new Image();
                RenderOptions.SetBitmapScalingMode(im, BitmapScalingMode.Fant);
                BorderContent(grid, im, br.imageUrl, txtCar[i - 1]);

                gr.Children.Add(border);

                hplCar[i - 1].Click += new RoutedEventHandler((sender, e) => hlclick(sender, e, br.Id));

                im.IsMouseDirectlyOverChanged += new DependencyPropertyChangedEventHandler((sender, e) => MousePosition(sender, e, im));
                im.MouseDown += new MouseButtonEventHandler(MousePressed);
                im.MouseUp += new MouseButtonEventHandler((sender, e) => MouseReleased(sender, e, br.Id));


                i++;

            }           


        }

        public void BorderMargin(Border border, int i)
        {
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1);
            border.Width = 110;
            border.Height = 130;
            border.Margin = new Thickness(left + horizontal, top + vertical, right - horizontal, bottom - vertical);
            horizontal += 200;
            if (i % 4 == 0)
            {
                horizontal = 0;
                vertical += 190;
                gr.Height += 170;
            }
        }

        public void BorderContent(Grid grid, Image im, byte[] imageURL, TextBlock brandname)
        {
            im.Source = ToImage(imageURL);
            RowDefinition r1 = new RowDefinition();
            r1.Height = new GridLength(5, GridUnitType.Star);
            grid.RowDefinitions.Add(r1);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(im);
            grid.Children.Add(brandname);
            im.SetValue(Grid.RowProperty, 0);
            brandname.SetValue(Grid.RowProperty, 1);
            brandname.HorizontalAlignment = HorizontalAlignment.Center;
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void MousePosition (object sender, DependencyPropertyChangedEventArgs e,Image im)
        {
            if (im.IsMouseOver == true)
                Mouse.OverrideCursor = Cursors.Hand;
            else
                Mouse.OverrideCursor = null;
        }

        private void MousePressed(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
            }
        }

        private void MouseReleased(object sender, MouseButtonEventArgs e, int brandID)
        {
            if (e.LeftButton == MouseButtonState.Released &&
                sender == this.downSender)
            {
 
                    hlclick(sender, e, brandID);
               
            }

        }

        private void hlclick(object sender, RoutedEventArgs e, int brandID)
        {
            Models mod = new Models(brandID);
            this.NavigationService.Navigate(mod);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBrand addbrand = new AddBrand();
            addbrand.ShowDialog();
            this.NavigationService.Refresh();
        }


    }
}
