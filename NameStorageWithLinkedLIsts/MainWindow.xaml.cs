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
using System.IO;
using Microsoft.Win32;

namespace NameStorageWithLinkedLIsts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String test;
        LinkedList listOfNames = new LinkedList();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                test = sr.ReadToEnd();
                splitUp(test);
                fileNameBox.Text = openFileDialog.FileName;

                //listOfNames.add(test);
                //MessageBox.Show(listOfNames.writeInOrder());
            }

        }

        public void splitUp(String bigString)
        {
            String wordToAdd = "";
            for (int i = 0; i < bigString.Length; i++)
            {
                if (bigString[i] == ' ')
                {
                    listOfNames.add(wordToAdd);
                    wordToAdd = "";
                }
                else
                {
                    wordToAdd += bigString[i];
                }
            }
            listOfNames.add(wordToAdd);

        }

        private void alphabeticalButton_Click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = listOfNames.writeInOrder();
        }

        private void reverseAlphabeticalButton_Click(object sender, RoutedEventArgs e)
        {
            outputBox.Text = listOfNames.writeInReverseOrder();
        }

    }
}
