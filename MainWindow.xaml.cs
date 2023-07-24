using Microsoft.Win32;
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

namespace Nearby
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtInfo.Text = "Contacts can share with you when they're nearby.";
            cmb1.SelectedIndex = 0;

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txtfilename.Text = System.IO.Path.GetFileName(openFileDialog.FileName);

        }

        private void cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb1.SelectedIndex == 1)
                txtInfo.Text = "Anyone can temporarily share with you when they're nearby. You'll be asked to approve these requests.";
            else if (cmb1.SelectedIndex == 2)
                txtInfo.Text = "Only devices that are signed into example@gmail.com can share with the device.";

        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filename = System.IO.Path.GetFileName(files[0]);
                txtfilename.Text = filename;
            }

        }
    }
}
