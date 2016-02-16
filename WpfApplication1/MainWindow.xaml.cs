using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication1
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
        public List<string> Searchs { get; set; } = new List<string>();

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                WebBrowser.Navigate("http://" + Search + TextBox1.Text);
            }
        }
        
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string correct = TextBox.Text.Replace("www.", "");
                correct = TextBox.Text.Replace("http://", "");
                correct = correct.Insert(0, "http://");
                WebBrowser.Navigate(correct);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Searchs.Add(TextBox2.Text);
                ComboBox.ItemsSource = Searchs;
                TextBox2.Text = "";
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

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate("http://"+ComboBox.Text+TextBox1.Text);
        }
    }
}