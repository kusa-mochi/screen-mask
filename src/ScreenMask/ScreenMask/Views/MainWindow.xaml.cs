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

        private void EditorMenuThumb_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {

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

        private void EditorMenuThumb_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
        }
    }
}
