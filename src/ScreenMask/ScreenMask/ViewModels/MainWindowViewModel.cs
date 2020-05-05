using System.Windows;
using System.Windows.Media;

using Prism.Mvvm;

namespace ScreenMask.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _IsEditingMode = true;
        public bool IsEditingMode
        {
            get { return _IsEditingMode; }
            set { SetProperty(ref _IsEditingMode, value); }
        }

        private DrawingBrush _MaskBrush;
        public DrawingBrush MaskBrush
        {
            get { return _MaskBrush; }
            set { SetProperty(ref _MaskBrush, value); }
        }

        public MainWindowViewModel()
        {
            SolidColorBrush drawingBrush = new SolidColorBrush();
            Pen drawingPen = new Pen(
                new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                0.1
                );
            RectangleGeometry drawingGeometry = new RectangleGeometry(
                new Rect(0.05, 0.05, 0.9, 0.9)
                );

            GeometryDrawing drawing = new GeometryDrawing(
                drawingBrush,
                drawingPen,
                drawingGeometry
                );

            MaskBrush = new DrawingBrush(drawing);
        }
    }
}
