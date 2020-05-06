using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

using Prism.Mvvm;

using ScreenMask.Drawing;

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
            Size screenSize = GetScreenVirtualResolution();
            RectangleGeometry rectGeometry = new RectangleGeometry(new Rect(0, 0, (int)screenSize.Width, (int)screenSize.Height));
            RectangleGeometry hole1 = new RectangleGeometry(new Rect(100, 50, 200, 200));
            RectangleGeometry hole2 = new RectangleGeometry(new Rect(400, 500, 100, 50));
            RectangleGeometry hole3 = new RectangleGeometry(new Rect(400, 300, 10, 400));
            RectangleGeometry block = new RectangleGeometry(new Rect(200, 150, 200, 200));

            Geometry maskGeometry = CombinedGeometryGenerator.Subtract(
                new List<Geometry> {
                    rectGeometry,
                    hole1,
                    hole2,
                    hole3
                }
                );
            maskGeometry = CombinedGeometryGenerator.Add(
                new List<Geometry> {
                    maskGeometry,
                    block
                }
                );

            GeometryDrawing drawing = new GeometryDrawing(
                new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
                new Pen(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)), 0),
                maskGeometry
                );
            MaskBrush = new DrawingBrush(drawing);
            MaskBrush.Stretch = Stretch.None;
        }

        private Size GetScreenVirtualResolution()
        {
            double width = SystemParameters.PrimaryScreenWidth;
            double height = SystemParameters.PrimaryScreenHeight;

            return new Size(width, height);
        }
    }
}
