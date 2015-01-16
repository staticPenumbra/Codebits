using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace OlsaLevelEditor1._0
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //Undo Redo List
        List<historyItem> history = new List<historyItem>();

        public Window1()
        {
            InitializeComponent();


        }

        private void menuFile_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void menuFileNew_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Hello");
            historyItem last = new historyItem();
            last.setCommand("New Map Clicked");
            history.Add(last);
        }
        private void menuEditUndo_Click(object sender, RoutedEventArgs e)
        {
            if (history.Count != 0)
            {
                System.Windows.Forms.MessageBox.Show("Undo " + history.ElementAt(0).getCommand());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("History is empty");
            }

        }
        private void menuEditRedo_Click(object sender, RoutedEventArgs e)
        {
            if (history.Count != 0)
            {
                System.Windows.Forms.MessageBox.Show("Redo " + history.ElementAt(0).getCommand());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("History is empty");
            }

        }

      
    }
    public class historyItem
    {
        //History Item contains information about a command
        //Variables here
        string command;

        //Functions here
        public historyItem()
        {
            //default constructor
            command = null;

        }
        public bool setCommand(string command)
        {
            if (command != null)
            {
                this.command = command;
                return(true);//indicates success
            }
            return (false);//was passed a null value so fail

        }

        public string getCommand()
        {
            return (this.command);
        }
    }
}
