using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace LCS_Desktop_.Logic
{
    public static class DesktopLogic
    {
        public static bool checkAcception(TextBox tb1, TextBox tb2)//If both of texboxes are not empty and changed
        {
            if (tb1.Text.Length > 0 && tb1.Text != "Some text"
                && tb2.Text.Length > 0 && tb2.Text != "Some text")
            {
                return true;
            }
            return false;
        }
        public static void clearBorders(List<Border> borders,Grid grid)//Clears Dynamic borderboxes to avoid layer overlaing 
        {
            foreach (var border in borders)
            {
                grid.Children.Remove(border);
            }
            borders.Clear();
        }
    }
}
