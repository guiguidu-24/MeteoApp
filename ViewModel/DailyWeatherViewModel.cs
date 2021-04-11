using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace MeteoApp
{
    public class DailyWeatherViewModel : INotifyPropertyChanged
    {
        #region private fields

        private BitmapImage icon;
        private int minTemperature;
        private int maxTemperature;
        private string day;

        #endregion

        #region public properties

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

        public int MinTemperature 
        {
            set
            {
                if (value != minTemperature)
                {
                    minTemperature = value;
                    OnPropertyChanged(nameof(MinMaxTemperature));
                }
            } 
        }
        public int MaxTemperature 
        {
            set
            {
                if (value != maxTemperature)
                {
                    maxTemperature = value;
                    OnPropertyChanged(nameof(MinMaxTemperature));
                }
            }
        }

        public string MinMaxTemperature
        {
            get
            {
                return $"{minTemperature}-{maxTemperature}°C";
            }
        }

        public string Day
        {
            get
            {
                return day;
            }

            set
            {
                if (value != day)
                {
                    day = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region property changed helpers

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
