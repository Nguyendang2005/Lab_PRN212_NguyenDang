using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DemoWindowPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Func<Page>> _pages;

        public MainWindow()
        {
            InitializeComponent();

            _pages = new List<Func<Page>>
            {
                () => new Page1(),
                () => new Page2(),
                () => new Page3(),
                () => new Page4(),
                () => new Page5(),
                () => new Page7()
            };

            MainFrame.Navigated += MainFrame_Navigated;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NavigateToPage(0);
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is Page page)
            {
                CurrentPageTitle.Text = string.IsNullOrWhiteSpace(page.Title) ? "WPF Demo" : page.Title;
            }
        }

        private void NavigateToPage(int pageIndex)
        {
            MainFrame.Navigate(_pages[pageIndex]());
        }

        private void ToPage1_Click(object sender, RoutedEventArgs e) => NavigateToPage(0);
        private void ToPage2_Click(object sender, RoutedEventArgs e) => NavigateToPage(1);
        private void ToPage3_Click(object sender, RoutedEventArgs e) => NavigateToPage(2);
        private void ToPage4_Click(object sender, RoutedEventArgs e) => NavigateToPage(3);
        private void ToPage5_Click(object sender, RoutedEventArgs e) => NavigateToPage(4);
        private void ToPage7_Click(object sender, RoutedEventArgs e) => NavigateToPage(5);
    }
}