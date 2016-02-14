using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox2.Text = WpfApplication1.Properties.Settings.Default.Directory;
            ComboBox.ItemsSource = Searchs;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate("http://" + TextBox.Text);
        }

        public string Search { get; set; }
        public List<string> Searchs { get; set; } = new List<string>()
        {
            "test"
        };

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                WebBrowser.Navigate("http://" + Search + TextBox1.Text);
            }
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            Searchs.Add(TextBox2.Text);
            ComboBox.ItemsSource = Searchs;
            TextBox2.Text = "";

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search = ComboBox.SelectedValue.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WpfApplication1.Properties.Settings.Default.Directory = TextBox2.Text;
            WpfApplication1.Properties.Settings.Default.Save();
        }
    }
}