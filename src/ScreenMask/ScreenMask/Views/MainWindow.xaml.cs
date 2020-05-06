using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ScreenMask.Views
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

        private void EditorMenuThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Thumb thumb = sender as Thumb;
            if (thumb == null) return;

            double x = Canvas.GetLeft(EditorMenu) + e.HorizontalChange;
            double y = Canvas.GetTop(EditorMenu) + e.VerticalChange;

            x = Math.Max(x, 0);
            y = Math.Max(y, 0);
            x = Math.Min(x, EditorMenuDragArea.ActualWidth - EditorMenu.ActualWidth);
            y = Math.Min(y, EditorMenuDragArea.ActualHeight - EditorMenu.ActualHeight);

            Canvas.SetLeft(EditorMenu, x);
            Canvas.SetTop(EditorMenu, y);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Minimized:
                    break;
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
                default:
                    break;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
