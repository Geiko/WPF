/*
     Создать приложение для управления списком котов.
 
    1. Все коты попадают в dataGridView с основными тремя колонками 
       для отображения клички кота, его возраста и породы
 
    2. С помощью combobox предоставить пользователю возможность выбора породы 
       для просмотра в datagridview только котов конкретной породы
 
    3. С помощью двух слайдеров реализовать фильтрацию котов по возрасту
       (два слайдера от и до)
 
    4. В datagridview добавить контекстное меню с одним пунктом "Удалить",
       который будет удалять выбранного кота в datagridview 
 
    5. В основное меню программы добавить поле поиска по имени кота.
 
    6. В основное меню программы добавить пункт File -> Save As -> Txt или XML
       То есть предоставить возможность сохранить данные из datagridview или 
       в xml файл или в txt/
*/


using System;
using System.Collections;
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
using System.Xml;

namespace _3_WPF_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int breedIndex;
        private double ageFrom;
        private double ageTo;
        private string catName;
        private ArrayList catCollection = null;
        private CatDB catBasa = null;

        public const string ANY = "***";
        public const string TXTFilePATH = "txtCatList.txt";
        public const string XMLFilePATH = "xmlCatList.xml";

        public MainWindow ( )
        {
            InitializeComponent ( );

            combobox.ItemsSource = Enum.GetValues ( typeof ( CatBreeds ) );

            breedIndex = combobox.SelectedIndex;
            ageFrom = slider1.Value;
            ageTo = slider2.Value;
            catName = ANY;
            catCollection = ( ArrayList ) datagrid.Resources [ "cats" ];
            catBasa = new CatDB ( );
            catBasa.catDB = new ArrayList ( );
            catBasa.CopyCats ( catCollection, catBasa.catDB );
        }
             


        #region Handlers

        private void Button_Click ( object sender, RoutedEventArgs e )
        {
            catName = ANY;

            slider1.Value = slider1.Minimum;
            slider2.Value = slider2.Maximum;

            combobox.SelectedValue = DBNull.Value;
            combobox.Text = "Breed";

            catBasa.CopyCats ( catBasa.catDB, catCollection );
            datagrid.Items.Refresh ( );
        }

        private void combobox_SelectionChanged ( object sender, SelectionChangedEventArgs e )
        {
            breedIndex = ( sender as ComboBox ).SelectedIndex;
            catBasa.CopyCats ( catBasa.catDB, catCollection );
            catBasa.SelectCats ( catCollection, breedIndex, ageFrom, ageTo, catName, ANY );
            datagrid.Items.Refresh ( );
        }

        private void slider1_ValueChanged ( object sender, RoutedPropertyChangedEventArgs<double> e )
        {
            ageFrom = ( sender as Slider ).Value;
            catBasa.CopyCats ( catBasa.catDB, catCollection );
            catBasa.SelectCats ( catCollection, breedIndex, ageFrom, ageTo, catName, ANY );
            datagrid.Items.Refresh ( );
        }
        
        private void slider2_ValueChanged ( object sender, RoutedPropertyChangedEventArgs<double> e )
        {
            if ( catCollection == null )
                return;
            ageTo = ( sender as Slider ).Value;
            catBasa.CopyCats ( catBasa.catDB, catCollection );
            catBasa.SelectCats ( catCollection, breedIndex, ageFrom, ageTo, catName, ANY );
            datagrid.Items.Refresh ( );
        }

        private void GridContextMenuItem_Click ( object sender, RoutedEventArgs e )
        {
            int selectedIndex = datagrid.SelectedIndex;
            if ( selectedIndex >= catCollection.Count || selectedIndex < 0 )
                return;
            catCollection.RemoveAt ( selectedIndex );
            datagrid.Items.Refresh ( );
        }

        private void MenuInputName_Click_1 ( object sender, RoutedEventArgs e )
        {
            TextBox textBox1 = new TextBox ( );
            textBox1.Name = "textBox1";
            textBox1.Text = ANY;
            textBox1.SelectAll ( );
            textBox1.Margin = new Thickness ( 20, 20, 300, 270 );

            textBox1.KeyDown += textBox1_KeyDown;

            grid.Children.Add ( textBox1 );
            textBox1.Focus ( );
        }

        private void textBox1_KeyDown ( Object sender, KeyEventArgs e )
        {
            if ( e.Key == Key.Enter )
            {
                catName = ( sender as TextBox ).Text;
                catBasa.CopyCats ( catBasa.catDB, catCollection );
                catBasa.SelectCats ( catCollection, breedIndex, ageFrom, ageTo, catName, ANY );
                datagrid.Items.Refresh ( );
                grid.Children.Remove ( sender as TextBox );
            }
        }       
        
        private void XmlSave_Click ( object sender, RoutedEventArgs e )
        {
            XmlDocument xmlDoc = new XmlDocument ( );
            xmlDoc.LoadXml ( "<Cats></Cats>" );

            foreach ( Cat cat in catCollection )
            {
                XmlNode catNode = xmlDoc.CreateElement ( "Cat" );
                xmlDoc.DocumentElement.AppendChild ( catNode );

                createNode ( xmlDoc, catNode, cat.Name, "Name" );
                createNode ( xmlDoc, catNode, cat.Breed.ToString(), "Breed" );
                createNode ( xmlDoc, catNode, cat.Age.ToString(), "Age" );
            }
            
            try
            {
                xmlDoc.Save ( XMLFilePATH );
            }
            catch ( DirectoryNotFoundException ex )
            {
                Console.WriteLine ( ex.Message );
            }
        }
        
        private void createNode ( XmlDocument xmlDoc, XmlNode catNode, string text, string nodeName )
        {
            XmlNode node = xmlDoc.CreateElement ( nodeName );
            node.InnerText = text;
            catNode.AppendChild ( node );
        }
        
        private void TxtSave_Click ( object sender, RoutedEventArgs e )
        {
            string catList = string.Format( "\n     List of Cats\n\n");
            int i = 0;
            foreach(Cat cat in catCollection)
            {
                i++;
                catList += string.Format ( "{0,3}. {1,10}, {2,10}, {3,5} years old. \n",
                    i, cat.Name, cat.Breed, cat.Age );
            }
            try
            {
                File.WriteAllText ( TXTFilePATH, catList );
            }
            catch ( SystemException ex )
            {
                MessageBox.Show ( ex.Message );
            }
        }

        #endregion


    }
}
