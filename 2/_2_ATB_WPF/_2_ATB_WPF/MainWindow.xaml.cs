/*
    Создать приложение wpf для отображения информации о сотрудниках АТБ.
  
    Все сотрудники появляются в listBox с отображением фотографии и имени сотрудника.
  
    По клику на сотрудника в listBox - происходит запполнение полей имени, фамилии и т.д.
    в соответствующие textBox.
 
    Обратите внимание на то, что часть информации о сотруднике (его должность, зарплата), 
    должны быть скрыты элементом управления expander.
 
    Очень рекомендую для более правильной реализации задачи, создать класс сотрудника, и 
    в коду работать с объектами этого класса.
*/

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


namespace _2_ATB_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Emploee> staff;

        public MainWindow ( )
        {
            InitializeComponent ( );

            staff = new List<Emploee>();
            staff.Add ( new Emploee ( "Sara", "Pupkinovich", "image1.jpg", Positions.CASHIER, 3000, "1010101" ) );
            staff.Add ( new Emploee ( "Abram", "Pupkinovich", "image2.jpg", Positions.PORTER, 4000, "2020202" ) );
            staff.Add ( new Emploee ( "Pesya", "Pupkinyavichus", "image3.jpg", Positions.ACCOUNTER, 8000, "3030303" ) );
            staff.Add ( new Emploee ( "Moysha", "Pupkinyavichus", "image4.jpg", Positions.GUARD, 5000, "4040404" ) );
            staff.Add ( new Emploee ( "Isya", "Pupkin", "image5.jpg", Positions.KEEPER, 6000, "5050505" ) );
            staff.Add ( new Emploee ( "Sofa", "Pupkina", "image6.jpg", Positions.LOGISTIC, 7000, "6060606" ) );
            staff.Add ( new Emploee ( "Uriel", "unknown", "indefinite.jpg", Positions.INDEFINITE, 0, "unknown" ) );

            for ( int i=0; i<staff.Count; i++ )
            {
                string path = System.IO.Directory.GetCurrentDirectory ( ) + "\\..\\..\\Images\\" + staff [ i ].ImgFileName;

                BitmapImage myBitmapImage = new BitmapImage ( );
                myBitmapImage.BeginInit ( );
                myBitmapImage.UriSource = new Uri ( path );
                myBitmapImage.EndInit ( );

                Image image = new Image ( );     
                image.Source = myBitmapImage;
                StackPanel stackPanel = new StackPanel ( ) { Orientation = Orientation.Horizontal };
                stackPanel.Children.Add ( image );

                TextBlock textBlock = new TextBlock ( );
                textBlock.Text = staff [ i ].FirstName;
                stackPanel.Children.Add ( textBlock );

                ListBoxEmploee.Items.Add ( stackPanel );
            }

            ListBoxEmploee.MouseLeftButtonUp += ListBoxEmploee_MouseLeftButtonUp;
        }



        private void ListBoxEmploee_MouseLeftButtonUp ( object sender, MouseButtonEventArgs e )
        {
            int selectedIndex = ( ( ListBox ) sender ).SelectedIndex;

            if ( selectedIndex >= 0 )
            {
                var person = staff [ selectedIndex ];

                tBoxFirstName.Text = person.FirstName;
                tBoxLastName.Text = person.LastName;

                stPanel.Children.Clear ( );
                stPanel.Children.Add ( new TextBlock { Text = "Position : " + person.Position } );
                stPanel.Children.Add ( new TextBlock { Text = "Salary : "   + person.Salary + " $" } );
                stPanel.Children.Add ( new TextBlock { Text = "Phoine : "   + person.Phone } );
            }            
        }



    }
}
