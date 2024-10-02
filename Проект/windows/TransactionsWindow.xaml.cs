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
    /// Логика взаимодействия для TransactionsWindow.xaml
    /// </summary>
    public partial class TransactionsWindow : Window
    {
        Yacenko_12Entities4 db;
        public TransactionsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities4();
            dgTransactions.ItemsSource = db.Transactions.ToList();
        }
        private void Action1(object sender, RoutedEventArgs e)
        {
            try
            {
                Transactions tr = new Transactions();
                tr.id = Convert.ToInt32(tbId.Text);
                tr.Amount = Convert.ToInt32(tbA.Text);
                tr.BuyerID = Convert.ToInt32(tbBID.Text);
                tr.SubjectSale = tbSs.Text;
                tr.IDFarms = Convert.ToInt32(tbIDF.Text);
                tr.QuantityAnimals = Convert.ToInt32(tbQA.Text);
                tr.IdWH = Convert.ToInt32(tbIDWH.Text);
                tr.QuantityCulture = Convert.ToInt32(tbQC.Text);
                db.Transactions.Add(tr);
                db.SaveChanges();
                dgTransactions.ItemsSource = db.Transactions.ToList();
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
                Transactions tr = (Transactions)dgTransactions.SelectedItem;
                db.Transactions.Remove(tr);
                db.SaveChanges();
                dgTransactions.ItemsSource = db.Transactions.ToList();
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
                Transactions tr = (Transactions)dgTransactions.SelectedItem;
                int sUpId = tr.id;
                var selecUptId = db.Transactions.Where(w => w.id == sUpId).FirstOrDefault();
                if (selecUptId == null)
                {
                    MessageBox.Show("Такого ID в таблице не существует!");
                }
                else
                {
                    selecUptId = tr;
                    MessageBox.Show("Изменения внесены успешно!");
                    db.SaveChanges();
                    dgTransactions.ItemsSource = db.Transactions.ToList();
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

