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

namespace jopka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Список квартир
        public List<Apartment> Apartments { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Заполнение списка квартир 
            Apartments = new List<Apartment>
            {
                new Apartment { ApartmentNumber = 1, Area = 100, Residents = 7 },
                new Apartment { ApartmentNumber = 2, Area = 60, Residents = 3 },
                new Apartment { ApartmentNumber = 3, Area = 70, Residents = 4 },
                new Apartment { ApartmentNumber = 4, Area = 80, Residents = 3 },
                new Apartment { ApartmentNumber = 5, Area = 90, Residents = 8 },
            };

            ApartmentsGrid.ItemsSource = Apartments;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Тарифы
            float phoneSeparate = 300;
            float phoneShared = 250;
            float gasNoColumn = 70;
            float gasWithColumn = 95;
            float utilitiesNoColumn = 50;
            float utilitiesWithColumn = utilitiesNoColumn * 0.9f;

            foreach (Apartment apartment in Apartments)
            {
                
                float phoneCost = apartment.HasSeparatePhone ? phoneSeparate : phoneShared;
                float gasCost = apartment.HasGasColumn ? gasWithColumn : gasNoColumn;
                float utilitiesCost = apartment.HasUtilities ? utilitiesWithColumn : utilitiesNoColumn;

                apartment.Total = phoneCost + gasCost + utilitiesCost;
            }

            ApartmentsGrid.Items.Refresh(); 
        }
        public static float CalculateTotal(float phoneCost, float gasCost, float utilitiesCost)
        {
            return phoneCost + gasCost + utilitiesCost;
        }
    }

    public class Apartment
    {
        public int ApartmentNumber { get; set; }
        public double Area { get; set; }
        public int Residents { get; set; }
        public bool HasSeparatePhone { get; set; }
        public bool HasGasColumn { get; set; }
        public bool HasUtilities { get; set; }
        public float Total { get; set; }
    }
}

