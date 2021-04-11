#undef DEBUG

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;


namespace MeteoApp
{
    public class MeteoControl
    {
        /// <summary>
        /// Fired When an update is finished
        /// </summary>
        public event Action UpdateComplete;
        
        #region private fields
        
        //insee paris: 75 056

        
        //private dynamic dailyWeather;
        //private dynamic nextHoursWeather;
        private readonly ApiClient meteoClient = new ApiClient();

        #endregion

        #region public properties
        public string InseeNb { get; set; } = "24322";

        public WeatherItem[] DailyWeatherList { get; } = new WeatherItem[14];
        public WeatherItem[] NextHoursWeatherList { get; } = new WeatherItem[12];
        
        #endregion
        
        #region Constructor
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MeteoControl()
        {
            #if DEBUG
            UpdateComplete += () => MessageBox.Show("update complete");
            #endif
            meteoClient.Token = ConfigurationManager.AppSettings["meteoToken"];
            RefreshAsync();
        }
        
        #endregion

        #region public Methods

        
        /// <summary>
        /// Refresh the weather data and update <see cref="DailyWeatherList"/> and  <see cref="NextHoursWeatherList"/> lists
        /// </summary>
        /// <returns>Task</returns>
        public async Task RefreshAsync()
        {
            dynamic dailyWeather = await meteoClient.GetJsonAsync(new Uri($"https://api.meteo-concept.com/api/forecast/daily?insee={InseeNb}"));

            dynamic nextHoursWeather = await meteoClient.GetJsonAsync(new Uri($"https://api.meteo-concept.com/api/forecast/nextHours?insee={InseeNb}&hourly=true"));

            
            UpdateWeatherLists(dailyWeather, nextHoursWeather);

            UpdateComplete?.Invoke();
        }
        
        /// <summary>
        /// Refresh the weather data and update <see cref="DailyWeatherList"/> and  <see cref="NextHoursWeatherList"/> lists
        /// Can be used by a button for example
        /// </summary>
        /// <returns>Task</returns>
        public async void RefreshAsync(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }
        
        #endregion
        
        #region helpers

        private void UpdateWeatherLists(dynamic dailyWeather, dynamic nextHoursWeather)
        {
            // days
            for (var iJour = 0; iJour < 14; iJour++)
            {
                var weather = new WeatherItem()
                {
                    InseeNb = (int) dailyWeather["forecast"][iJour]["insee"],
                    MaxTemperature = (int) dailyWeather["forecast"][iJour]["tmax"],
                    MinTemperature = (int) dailyWeather["forecast"][iJour]["tmin"],
                    Place = (string) dailyWeather["city"]["name"],
                    Time = (DateTime) dailyWeather["forecast"][iJour]["datetime"],
                    WeatherType = (int) dailyWeather["forecast"][iJour]["weather"]
                };
                
                DailyWeatherList[iJour] = weather;
            }
            
            // hours
            for (var iHeure = 0; iHeure < 12; iHeure++)
            {
                var weather = new WeatherItem()
                {
                    InseeNb = (int) nextHoursWeather["forecast"][iHeure]["insee"],
                    MinTemperature = (int) nextHoursWeather["forecast"][iHeure]["temp2m"],
                    MaxTemperature = (int) nextHoursWeather["forecast"][iHeure]["temp2m"],
                    Place = (string) nextHoursWeather["city"]["name"],
                    Time = (DateTime) nextHoursWeather["forecast"][iHeure]["datetime"],
                    WeatherType = (int) nextHoursWeather["forecast"][iHeure]["weather"]
                };
                
                NextHoursWeatherList[iHeure] = weather;
            }
        }
        
        #endregion
        
    }
}