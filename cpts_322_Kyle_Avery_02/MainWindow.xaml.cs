/// Created By: Kyle Avery 
/// Student ID: 11237105
/// Created On: 1/30/2014
/// Edited By: N/A
/// Edited On: N/A
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
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;

namespace cpts_322_Kyle_Avery_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Created By: Kyle Avery
        /// Created On: 1/30/2014
        /// Edited By: N/A
        /// Edited On: N/A
        /// Function Name: b_click
        /// Relies On: The main wpf file being initialized correctly in order to be linked to the buttons created in the main xaml
        /// Purpose: Handles all of the opening and saving of files
        /// </summary>
        /// <param name="sender"> The button who called this function </param>
        /// <param name="e"> The event data that triggered this function </param>
        private void b_click(object sender, EventArgs e)
        {
            Button temp = sender as Button;
            
            switch(temp.Name)
            {
                case "b_open":
                    Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                    ofd.Filter = "Text Files|*.txt|All Files|*.*";
                    if(ofd.ShowDialog().Value)
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                        load_text(sr);
                        sr.Dispose();
                        sr.Close();
                        
                    }
                    break;
                case "b_save":
                    Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
                    sfd.Filter = "Text Files|*.txt|All Files|*.*";
                    if(sfd.ShowDialog().Value)
                    {
                        System.IO.File.WriteAllText(sfd.FileName, l_output.Text);
                    }
                    break;
            }
        }
        /// <summary>
        /// Created By: Kyle Avery
        /// Created On: 1/30/2014
        /// Edited By: N/A
        /// Edited On: N/A
        /// Function Name: b_clear_click
        /// Relies On: The main wpf file being initialized correctly in order to be linked to the buttons created in the main xaml
        /// Purpose: clears the text box
        /// </summary>
        /// <param name="sender"> The button who called this function </param>
        /// <param name="e"> The event data that triggered this function </param>
        private void b_clear_Click(object sender, RoutedEventArgs e)
        {
            l_output.Text = "";
        }
        /// <summary>
        /// Created By: Kyle Avery
        /// Created On: 1/30/2014
        /// Edited By: N/A
        /// Edited On: N/A
        /// Function Name: load_text
        /// Relies On: A proper TextReader to be passed in
        /// Purpose: puts the text into the text box
        /// </summary>
        /// <param name="sr"> The Text Reader to be passed in </param>
        private void load_text(TextReader sr)
        {
            l_output.Text = "";
            int line = 0;
            while (sr.Peek() != -1)
            {
                l_output.Text += String.Format("{0}:\t", line);
                l_output.Text += sr.ReadLine();
                l_output.Text += System.Environment.NewLine;
                ++line;
            }
        }

        private void b_fib_50_Click(object sender, RoutedEventArgs e)
        {
            FibTextReader temp = new FibTextReader(50);
            load_text(temp);
        }

        private void b_fib_100_Click(object sender, RoutedEventArgs e)
        {
            FibTextReader temp = new FibTextReader(100); ;
            load_text(temp);
        }
    }
    
}
