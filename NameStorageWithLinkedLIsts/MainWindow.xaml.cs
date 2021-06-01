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

        //Method to handle the button click for the file reader.
        //The method takes in the file, reads through the entire file, stores it in a string, then sends it to splitUp.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                test = sr.ReadToEnd();
                splitUp(test);
                setLinkBox = openFileDialog.FileName;

            }

        }

        //Getter and setter for the link text box.
        public String setLinkBox
        {
            get => fileNameBox.Text;
            set
            {
                fileNameBox.Text = value;
            }
        }

        //Getter and setter for the output box.
        public String setOutputBox
        {
            get => outputBox.Text;
            set
            {
                outputBox.Text = value;
            }
        }

        //Method to split up the contents of the file.
        //Takes the large string in and goes through each character and builds a string until it finds a space.
        //The built string is then sent to the LinkedList class to be added.
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

        //Event handler for the alphabetical button click, calls the writeInOrder method and sends it to the output box's setter.
        private void alphabeticalButton_Click(object sender, RoutedEventArgs e)
        {
            setOutputBox = listOfNames.writeInOrder();
            //outputBox.Text = listOfNames.writeInOrder();
        }

        //Event handler for the reverse alphabetical button click, calls the writeInReverseOrder method and sends it to the output box's setter.
        private void reverseAlphabeticalButton_Click(object sender, RoutedEventArgs e)
        {
            setOutputBox = listOfNames.writeInReverseOrder();
            //outputBox.Text = listOfNames.writeInReverseOrder();
        }

    }
}
