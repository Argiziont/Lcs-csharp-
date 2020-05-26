using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LCS_Desktop_
{
    class BorderCreate
    {
        private TextBox textBoxCreate(string text)
        {
            var tmpText = new TextBox();
            tmpText.TextWrapping = TextWrapping.NoWrap;
            tmpText.BorderThickness = new Thickness(0);
            tmpText.VerticalAlignment = VerticalAlignment.Center;
            tmpText.FontSize = 15;
            tmpText.FontFamily = new FontFamily("Century Gothic");
            tmpText.AcceptsReturn = false;
            tmpText.Text = text;
            tmpText.IsReadOnly = true;
            return tmpText;
        }

        public Border createUpperBorder(int row, string text, Grid grid)
        {
            var tmpBorder = new Border();
            tmpBorder.BorderBrush = Brushes.LightSlateGray;
            tmpBorder.BorderThickness = new Thickness(2, 2, 2, 0);
            tmpBorder.CornerRadius = new CornerRadius(5, 5, 0, 0);

            tmpBorder.Child = textBoxCreate(text);

            Grid.SetColumn(tmpBorder, 3);
            Grid.SetRow(tmpBorder, 1 + row);
            Grid.SetRowSpan(tmpBorder, 2);
            tmpBorder.Margin = new Thickness(6, 28 + row * 2, 6, 51 - row * 2);

            grid.Children.Add(tmpBorder);
            return tmpBorder;
        }
        public Border createBottomBorder(int row, string text, Grid grid)
        {
            var tmpBorder = new Border();
            tmpBorder.BorderBrush = Brushes.LightSlateGray;
            tmpBorder.BorderThickness = new Thickness(2, 0, 2, 2);
            tmpBorder.CornerRadius = new CornerRadius(0, 0, 5, 5);
            tmpBorder.Margin = new Thickness(6, 0 + row * 2, 6, 29 - row * 2);
            tmpBorder.Child = textBoxCreate(text);

            Grid.SetColumn(tmpBorder, 3);
            Grid.SetRow(tmpBorder, 2 + row);

            grid.Children.Add(tmpBorder);
            return tmpBorder;
        }
    }
}
