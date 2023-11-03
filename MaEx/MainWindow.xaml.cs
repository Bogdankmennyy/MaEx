using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;








namespace MaEx
{
    public partial class MainWindow : Window
{
    public ObservableCollection<Advertisement> Advertisements { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        // Инициализируем список объявлений и привязываем его к ListView
        Advertisements = new ObservableCollection<Advertisement>();
        AdList.ItemsSource = Advertisements;
    }

        private void CreateAdButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстовых полей
            string title = CreateAdForm.Children[0].ToString();
            string price = CreateAdForm.Children[1].ToString();
            string description = CreateAdForm.Children[2].ToString();

            // Создаем новое объявление
            Advertisements newAd = new Advertisements
            {
                Title = title,
                //Price = price,
                Description = description,
                PostedDate = DateTime.Now
            };

            // Добавляем объявление в базу данных
            var context = new MarketExchangeDBEntities();
            context.Advertisements.Add(newAd);
            context.SaveChanges();

            // Очищаем текстовые поля
            foreach (var element in CreateAdForm.Children)
            {
                if (element is TextBox textBox)
                {
                    textBox.Clear();
                }
            }

            // Обновляем список объявлений в ListView
            AdList.ItemsSource = context.Advertisements.ToList();
        }






        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Navigate(new Uri("registration.xaml", UriKind.Relative));
        }

    }

    public class Advertisement
{
    public string Title { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
    public DateTime PostedDate { get; set; }
}


    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }





}
