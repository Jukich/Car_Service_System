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

namespace CarSystemGUI
{
    /// <summary>
    /// Interaction logic for RepairInfo.xaml
    /// </summary>
    public partial class RepairInfo : Window
    {
        private int repairID;
        Repair repair;
        public RepairInfo(int repairID)
        {
            CarServiceDBEntities1 context = new CarServiceDBEntities1();
            this.repairID = repairID;
            repair = context.Repairs.Where(i => i.Id == this.repairID).First();
            DataContext = this;

            
            InitializeComponent();
        }

        public DateTime? DateOfRepair
        {
            get
            {
                return repair.DayOfRepair;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    MessageBox.Show("Invalid date!");
                    return;
                }
                using (CarServiceDBEntities1 context = new CarServiceDBEntities1())
                {
                    repair = context.Repairs.Where(i => i.Id == this.repairID).First();
                    repair.DayOfRepair = value;
                    context.SaveChanges();
                    CarInfo.RepairsList = context.Repairs.Where(i => i.CarID == this.repair.CarID).OrderByDescending(i => i.DayOfRepair).ToList();

                }
            }
           
        }

        public string Description
        {
            get
            {
                return repair.Description;
            }
            set
            {
                using (CarServiceDBEntities1 context = new CarServiceDBEntities1())
                {
                    repair = context.Repairs.Where(i => i.Id == this.repairID).First();
                    repair.Description = value;
                    context.SaveChanges();

                }
            }
        }

        public double? Price
        {
            get
            {
                return repair.PriceOfRepair;
            }
            set
            {
                using (CarServiceDBEntities1 context = new CarServiceDBEntities1())
                {
                    repair = context.Repairs.Where(i => i.Id == this.repairID).First();
                    this.repair.PriceOfRepair = value;
                    context.SaveChanges();
                    CarInfo.RepairsList = context.Repairs.Where(i => i.CarID == this.repair.CarID).OrderByDescending(i => i.DayOfRepair).ToList();
                }
            }
        }
    }
}
