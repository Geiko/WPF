/*
         Взять код программы текстового редактора, написаную в классе
        и добавить к нему следующий функционал:
 
        Были реализованы: Открыть и Сохранить как
 
        Реализовать: 
         - Создать новый документы
         - опции выбора шрифта и цвета текста
         - опции курсива, подчеркнутого, жирного начертания и т.д.
         - функции редактирования: вырезать, скопировать, вставить, удалить, выделить все.
 */

using Microsoft.Win32;
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

using System.Windows.Forms;
using System.Drawing;


namespace _4_Redactor_WPF
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


        #region File



        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Filter = "RTF files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (open.ShowDialog() == true)
            {
                TextRange doc = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                using (FileStream fs = new FileStream(open.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(open.FileName).ToLower() == ".rtf")
                    {
                        doc.Load(fs, System.Windows.DataFormats.Rtf);
                    }
                    else if (System.IO.Path.GetExtension(open.FileName).ToLower() == ".txt")
                    {
                        doc.Load(fs, System.Windows.DataFormats.Text);
                    }
                    else
                    {
                        doc.Load(fs, System.Windows.DataFormats.Xaml);
                    }
                }
            }
        }



        private void MenuItem_Click_SaveAs(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.Filter = "RTF files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (save.ShowDialog() == true)
            {
                TextRange doc = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                using (FileStream fs = File.Create(save.FileName))
                {
                    if (System.IO.Path.GetExtension(save.FileName).ToLower() == ".rtf")
                    {
                        doc.Save(fs, System.Windows.DataFormats.Rtf);
                    }
                    else if (System.IO.Path.GetExtension(save.FileName).ToLower() == ".txt")
                    {
                        doc.Save(fs, System.Windows.DataFormats.Text);
                    }
                    else
                    {
                        doc.Save(fs, System.Windows.DataFormats.Xaml);
                    }
                }
            }
        }



        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            rtb.Document.Blocks.Clear();
        }



        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }


        #endregion



        #region Fonts

        private void MenuItem_Click_Font(object sender, RoutedEventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();

            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextRange selectionTextRange = new TextRange(rtb.Selection.Start, rtb.Selection.End);

                selectionTextRange.ApplyPropertyValue(TextElement.FontFamilyProperty, fontDialog1.Font.Name);
                selectionTextRange.ApplyPropertyValue(TextElement.FontSizeProperty, (double)fontDialog1.Font.Size);
                inclinationSet(selectionTextRange, fontDialog1);
                fatnessSet(selectionTextRange, fontDialog1);
                underlineSet(selectionTextRange, fontDialog1);
                strikeoutSet(selectionTextRange, fontDialog1);
            }
        }



        private void underlineSet(TextRange selectionTextRange, FontDialog fontDialog1)
        {
            Object isUnderline;
            if (fontDialog1.Font.Underline == true)
            {
                isUnderline = TextDecorations.Underline;
            }
            else
            {
                isUnderline = null;
            }
            selectionTextRange.ApplyPropertyValue(Inline.TextDecorationsProperty, isUnderline);
        }



        private void strikeoutSet(TextRange selectionTextRange, FontDialog fontDialog1)
        {
            Object isStrikeout;
            if (fontDialog1.Font.Strikeout == true)
            {
                isStrikeout = TextDecorations.Strikethrough;
            }
            if (fontDialog1.Font.Strikeout == false && fontDialog1.Font.Underline == false)
            {
                isStrikeout = null;
            }
            else
            {
                isStrikeout = TextDecorations.Underline;
            }
            selectionTextRange.ApplyPropertyValue(Inline.TextDecorationsProperty, isStrikeout);
        }



        private void fatnessSet(TextRange selectionTextRange, FontDialog fontDialog1)
        {
            Object isFat;
            if (fontDialog1.Font.Bold == true)
            {
                isFat = FontWeights.DemiBold;
            }
            else
            {
                isFat = FontWeights.Regular;
            }
            selectionTextRange.ApplyPropertyValue(TextElement.FontWeightProperty, isFat);
        }



        private void inclinationSet(TextRange selectionTextRange, FontDialog fontDialog1)
        {
            Object isItalic;
            if (fontDialog1.Font.Italic == true)
            {
                isItalic = FontStyles.Italic;
            }
            else
            {
                isItalic = FontStyles.Normal;
            }
            selectionTextRange.ApplyPropertyValue(TextElement.FontStyleProperty, isItalic);
        }

        #endregion 



        #region Colors



        private void MenuItem_Click_ForeColor(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            TextRange selectionTextRange = new TextRange(rtb.Selection.Start, rtb.Selection.End);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    selectionTextRange.ApplyPropertyValue(TextElement.ForegroundProperty, colorDialog1.Color.Name);
                }
                catch (FormatException ex)
                {
                    System.Windows.MessageBox.Show("Unknown color." + colorDialog1.Color.Name.ToString() + ex.Message);
                }
            }
        }



        private void MenuItem_Click_BackColor(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            TextRange selectionTextRange = new TextRange(rtb.Selection.Start, rtb.Selection.End);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    selectionTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, colorDialog1.Color.Name);
                }
                catch (FormatException ex)
                {
                    System.Windows.MessageBox.Show("Unknown color." + colorDialog1.Color.Name.ToString() + ex.Message);
                }
            }
        }



        #endregion



        #region Edit



        private void MenuItem_Click_Cut(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(rtb.Selection.Text) == false)
            {
                System.Windows.Clipboard.SetText(rtb.Selection.Text);
                rtb.Selection.Text = string.Empty;
            }
            else
            {
                System.Windows.MessageBox.Show("No text selected in textBox1");
            }
        }



        private void MenuItem_Click_Copy(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(rtb.Selection.Text);
        }



        private void MenuItem_Click_Paste(object sender, RoutedEventArgs e)
        {
            if (rtb.Selection.Text != string.Empty)
            {
                rtb.Selection.Text = string.Empty;
            }

            rtb.CaretPosition.InsertTextInRun(System.Windows.Clipboard.GetText());
        }



        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            rtb.Selection.Text = string.Empty;
        }



        private void MenuItem_Click_SelectAll(object sender, RoutedEventArgs e)
        {
            rtb.SelectAll();
        }



        #endregion
    }
}
