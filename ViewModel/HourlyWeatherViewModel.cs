using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace MeteoApp
{
    public class HourlyWeatherViewModel : INotifyPropertyChanged
    {
        #region private fields

        private BitmapImage icon;
        private string hour;

        #endregion

        public BitmapImage Icon
        {
            get
            {
                return icon;
            }
            set
            {
                if (value != icon)
                {
                    icon = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value != hour)
                {
                    hour = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Property changed helpers

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
