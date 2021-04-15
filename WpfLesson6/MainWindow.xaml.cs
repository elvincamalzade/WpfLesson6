using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfLesson6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public Car MyCar { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        private string sometext;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name=null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string SomeText
        {
            get { return sometext; }
            set
            {
                sometext = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            // SomeText = "Hakuna";

            Cars = new ObservableCollection<Car>
            {
                new Car
                {
                    Model="X5",
                    Vendor="BMW",
                    Year=2020
                },
                new Car
                {
                    Model="CLS",
                    Vendor="Mercedes",
                    Year=2020
                },
                new Car
                {
                    Model="Quadraporte",
                    Vendor="Maseratti",
                    Year=2021
                },
            };

            //MyCar = new Car
            //{
            //    Model = "X5",
            //    Vendor = "BMW",
            //    Year = 2011
            //};




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["PrimaryColor"] = Brushes.Goldenrod;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyCar.Model = "Best Model";
        }

   
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                Model="Cruze LTZ RS",
                Vendor="Chevrolet",
                Year=2014
            };
            Cars.Add(car);
        }

      
        private void listbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var info = new Info();
            info.InfoCar=(sender as ListBox).SelectedItem as Car;
            info.ShowDialog();
        }
    }


    public class Car : INotifyPropertyChanged
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged(); }
        }

        private string vendor;

        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; OnPropertyChanged(); }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
