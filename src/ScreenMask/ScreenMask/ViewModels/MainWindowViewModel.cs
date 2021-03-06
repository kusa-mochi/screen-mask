﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

using Prism.Commands;
using Prism.Mvvm;

using ScreenMask.Drawing;
using ScreenMask.Enums;

namespace ScreenMask.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _IsEditing = true;
        public bool IsEditing
        {
            get { return _IsEditing; }
            set { SetProperty(ref _IsEditing, value); }
        }

        private DrawingBrush _MaskBrush;
        public DrawingBrush MaskBrush
        {
            get
            {
                return _MaskBrush;
            }
            set { SetProperty(ref _MaskBrush, value); }
        }

        private EditType _EditType = EditType.None;
        public EditType EditType
        {
            get { return _EditType; }
            set { SetProperty(ref _EditType, value); }
        }

        private ObservableCollection<Geometry> _HoleGeometries = new ObservableCollection<Geometry>();
        public ObservableCollection<Geometry> HoleGeometries
        {
            get { return _HoleGeometries; }
            set { SetProperty(ref _HoleGeometries, value); }
        }

        private ObservableCollection<Geometry> _BlockGeometries = new ObservableCollection<Geometry>();
        public ObservableCollection<Geometry> BlockGeometries
        {
            get { return _BlockGeometries; }
            set { SetProperty(ref _BlockGeometries, value); }
        }

        private DelegateCommand<EditType?> _SwitchEditTypeCommand;
        public DelegateCommand<EditType?> SwitchEditTypeCommand =>
            _SwitchEditTypeCommand ?? (_SwitchEditTypeCommand = new DelegateCommand<EditType?>(editType =>
            {
                EditType = editType ?? EditType.None;
            }));

        public MainWindowViewModel()
        {
            Size screenSize = GetScreenVirtualResolution();
            RectangleGeometry rectGeometry = new RectangleGeometry(new Rect(0, 0, (int)screenSize.Width, (int)screenSize.Height));
            RectangleGeometry hole1 = new RectangleGeometry(new Rect(100, 50, 200, 200));
            EllipseGeometry hole2 = new EllipseGeometry(new Rect(400, 500, 100, 50));
            RectangleGeometry hole3 = new RectangleGeometry(new Rect(400, 300, 10, 400));
            RectangleGeometry block = new RectangleGeometry(new Rect(200, 150, 200, 200));

            Geometry maskGeometry = CombinedGeometryGenerator.Subtract(
                rectGeometry,
                new List<Geometry> {
                    hole1,
                    hole2,
                    hole3
                }
                );
            maskGeometry = CombinedGeometryGenerator.Add(
                maskGeometry,
                new List<Geometry> {
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
