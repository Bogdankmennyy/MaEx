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
using System.Collections.ObjectModel;
using System.Collections;



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
        Advertisement newAd = new Advertisement
        {
            Title = title,
            Price = price,
            Description = description,
            PostedDate = DateTime.Now
        };

        // Добавляем объявление в список
        Advertisements.Add(newAd);

        // Очищаем текстовые поля
        foreach (var element in CreateAdForm.Children)
        {
            if (element is TextBox textBox)
            {
                textBox.Clear();
            }
        }
    }
}

public class Advertisement
{
    public string Title { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
    public DateTime PostedDate { get; set; }
}




    
}
