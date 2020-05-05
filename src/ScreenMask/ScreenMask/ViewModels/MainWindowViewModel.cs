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

        public MainWindowViewModel()
        {

        }
    }
}
