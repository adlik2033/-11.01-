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
using Проект.auth;

namespace Проект.windows
{
    /// <summary>
    /// Логика взаимодействия для FarmsW.xaml
    /// </summary>
    public partial class FarmsW : Window
    {
        Yacenko_12Entities4 db;
        public FarmsW()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities4();
            dgF.ItemsSource = db.Farms.ToList();
        }
        private void Action1(object sender, RoutedEventArgs e)
        {
            try
            {
                Farms f = new Farms();
                f.id = Convert.ToInt32(tbId.Text);
                f.locationWH = tblWH.Text;
                f.Capacity = Convert.ToInt32(tbC.Text);
                f.AnimalsID = Convert.ToInt32(tbAID.Text);
                f.EmployesID = Convert.ToInt32(tbEID.Text);
                db.Farms.Add(f);
                db.SaveChanges();
                dgF.ItemsSource = db.Farms.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Action2(object sender, RoutedEventArgs e)
        {
            try
            {
                Farms f = (Farms)dgF.SelectedItem;
                db.Farms.Remove(f);
                db.SaveChanges();
                dgF.ItemsSource = db.Farms.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Action3(object sender, RoutedEventArgs e)
        {
            try
            {
                Farms wh = (Farms)dgF.SelectedItem;
                int sUpId = wh.id;
                var selecUptId = db.Farms.Where(w => w.id == sUpId).FirstOrDefault();
                if (selecUptId == null)
                {
                    MessageBox.Show("Такого ID в таблице не существует!");
                }
                else
                {
                    selecUptId = wh;
                    MessageBox.Show("Изменения внесены успешно!");
                    db.SaveChanges();
                    dgF.ItemsSource = db.Farms.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ComboboxW_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxW.SelectedIndex == 0)
            {
                TransactionsWindow transactionsWindow = new TransactionsWindow();
                transactionsWindow.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 1)
            {
                AnimalsW animalsW = new AnimalsW();
                animalsW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 2)
            {
                AutosW autosW = new AutosW();
                autosW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 3)
            {
                ByuerW byuerW = new ByuerW();
                byuerW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 4)
            {
                CultureW cultureW = new CultureW();
                cultureW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 5)
            {
                EmployesW employesW = new EmployesW();
                employesW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 6)
            {
                FarmsW farmsW = new FarmsW();
                farmsW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 7)
            {
                PostW postW = new PostW();
                postW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 8)
            {
                WareHouseW arehouseW = new WareHouseW();
                arehouseW.Show();
                this.Close();
            }
        }
    }
}
