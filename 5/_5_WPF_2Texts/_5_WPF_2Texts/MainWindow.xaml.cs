using System;
using System.Collections.Generic;
using System.IO;
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

namespace _5_WPF_2Texts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void CommandBinding_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            if( textbox1.IsFocused == true )
            {
                textbox1.SelectedText = string.Empty;
            }
            else if (textbox2.IsFocused == true)
            {
                textbox2.SelectedText = string.Empty;
            }
            else
            {
                MessageBox.Show("Select textbox, please");
            }
        }


        private void CommandBinding_NewFile(object sender, ExecutedRoutedEventArgs e)
        {
            if (textbox1.IsFocused == true)
            {
                textbox1.Clear();
            }
            else if (textbox2.IsFocused == true)
            {
                textbox2.Clear();
            }
            else
            {
                MessageBox.Show("Select textbox, please");
            }
        }


        private void CommandBinding_OpenFile(object sender, ExecutedRoutedEventArgs e)
        {
            if (textbox1.IsFocused == true)
            {
                OpenFile(textbox1, tb1);
            }
            else if (textbox2.IsFocused == true)
            {
                OpenFile(textbox2, tb2);
            }
            else
            {
                MessageBox.Show("Select textbox, please");
            }
        }


        private void OpenFile(TextBox textbox, TextBlock tb)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            if (open.ShowDialog() == true)
            {
                using (StreamReader reader = File.OpenText(open.FileName))
                {
                    textbox.Text = reader.ReadToEnd();
                    tb.Text = open.FileName;
                }
            }
        }


        private void CommandBinding_SaveFile(object sender, ExecutedRoutedEventArgs e)
        {
            if (textbox1.IsFocused == true)
            {
                SaveFile(textbox1, tb1.Text);
            }
            else if (textbox2.IsFocused == true)
            {
                SaveFile(textbox2, tb2.Text);
            }
            else
            {
                MessageBox.Show("Select textbox, please");
            }
        }

        private void SaveFile(TextBox textbox, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(textbox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
