#undef DEBUG

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;


namespace MeteoApp
{
    public class MeteoApplicationViewModel : INotifyPropertyChanged
    {
        #region private fields

        private MeteoControl meteoControl = new MeteoControl();

        private string city;
        private string currentTemperature;
        private string currentWeather = "chargement...";

        private BitmapImage currentWeatherIcon;

        #endregion

        #region public properties

        public RoutedEventHandler OnRequest { get; private set; }

        public string CurrentTemperature
        {
            get
            {
                return currentTemperature + "°C";
            }
            private set
            {
                if (value != currentTemperature)
                {
                    currentTemperature = value;
                    OnPropertyChanged();
                }
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            private set
            {
                if (value != city)
                {
                    city = value;
                    OnPropertyChanged();
                }
            }
        }
        public BitmapImage CurrentWeatherIcon
        {
            get
            {
                return currentWeatherIcon;
            }
            set
            {
                if (value != currentWeatherIcon)
                {
                    currentWeatherIcon = value;
                    OnPropertyChanged();

                }
            }
        }
        public string CurrentWeatherType
        {
            get
            {
                return currentWeather;
            }
            private set
            {
                if (value != currentWeather)
                {
                    currentWeather = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public HourlyWeatherViewModel[] HourlyWeatherList { get; } = new HourlyWeatherViewModel[5];
        public DailyWeatherViewModel[] DailyWeatherList { get; } = new DailyWeatherViewModel[7];

        public string InseeNb 
        {
            get
            {
                return meteoControl.InseeNb;
            }
            set
            {
                if (value != meteoControl.InseeNb)
                {
                    meteoControl.InseeNb = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructor

        public MeteoApplicationViewModel()
        {
            meteoControl.UpdateComplete += Refresh;
            OnRequest = meteoControl.RefreshAsync;

            for (int i = 0; i < 5; i++)
            {
                HourlyWeatherList[i] = new HourlyWeatherViewModel();
            }

            for (int i = 0; i < 7; i++)
            {
                DailyWeatherList[i] = new DailyWeatherViewModel();
            }
        }
        
        #endregion
        
        #region Methods
        
        private void Refresh(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        
        private void Refresh()
        {

            //current date
            City = meteoControl.DailyWeatherList[0].Place;
            CurrentTemperature = meteoControl.NextHoursWeatherList[0].Temperature.ToString();
            CurrentWeatherType = WeatherRessources.Weather[meteoControl.NextHoursWeatherList[0].WeatherType].Type;
            CurrentWeatherIcon = new BitmapImage(WeatherRessources.Weather[meteoControl.NextHoursWeatherList[0].WeatherType].LogoUri);
            //hourly data
            for (int i = 0; i < 5; i++)
            {
                HourlyWeatherList[i].Hour = meteoControl.NextHoursWeatherList[i + 1].Time.ToString("t");
                HourlyWeatherList[i].Icon = new BitmapImage(WeatherRessources.Weather[meteoControl.NextHoursWeatherList[i + 1].WeatherType].LogoUri);
            }
            
            //daily data
            for (int i = 0; i < 7; i++)
            {
                DailyWeatherList[i].Icon = new BitmapImage(WeatherRessources.Weather[meteoControl.DailyWeatherList[i + 1].WeatherType].LogoUri);
                DailyWeatherList[i].Day = meteoControl.DailyWeatherList[i + 1].Time.ToString("ddd");
                DailyWeatherList[i].MinTemperature = meteoControl.DailyWeatherList[i + 1].MinTemperature;
                DailyWeatherList[i].MaxTemperature = meteoControl.DailyWeatherList[i + 1].MaxTemperature;
            }
            
            InseeNb = meteoControl.InseeNb;

            #if DEBUG
            MessageBox.Show("refresh complete");
            #endif
        }
        
        #endregion
        
        #region Property changed helpers

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
        
    }
}