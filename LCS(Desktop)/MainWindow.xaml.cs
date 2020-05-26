using DataBaseAndLogic.DBlogic;
using DataBaseAndLogic.Logic;
using LCS_Desktop_.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace LCS_Desktop_
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
        private List<Border> borders = new List<Border>();//List of dynamic created borderboxes

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (DesktopLogic.checkAcception(Str1TextBox, Str2TextBox))//if we typed smth
            {
                var border = new BorderCreate();
                DesktopLogic.clearBorders(borders, MainGrid);
                DBLogic.DBSetter(Str1TextBox.Text, Str2TextBox.Text);
                var lcslist = DBLogic.DBGetter();//Sending data to DB and making answer Borderbox visible
                AnswerBox.Visibility = Visibility.Visible;
                AnswerText.Text = $"Answer:  \"{lcslist.FirstOrDefault().AnswerString}\" ";
                for (int i = 0; i < lcslist.Count(); i++)
                { 
                    borders.Add(border.createUpperBorder(i, $"Strings: \"{lcslist[i].FirstString}\" + \"{lcslist[i].SecondString}\"", MainGrid));
                    borders.Add(border.createBottomBorder(i, $"Answer: \"{lcslist[i].AnswerString}\"", MainGrid));
                }
            }
            else
            {
                MessageBox.Show("Please enter correct values", "Error");//If we don't enter anything
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {//Default list of 5 last requests on load
            var lcslist = DBLogic.DBGetter();
            var border = new BorderCreate();
            for (int i = 0; i < lcslist.Count(); i++)
            {

                borders.Add(border.createUpperBorder(i, $"Strings: \"{lcslist[i].FirstString}\" + \"{lcslist[i].SecondString}\"", MainGrid));
                borders.Add(border.createBottomBorder(i, $"Answer: \"{lcslist[i].AnswerString}\"", MainGrid));
            }
        }
    }
}
