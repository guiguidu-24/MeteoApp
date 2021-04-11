using System;

namespace MeteoApp
{
    public class WeatherItem
    {
        
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }

        public int Temperature
        {
            get
            {
                return (MinTemperature + MaxTemperature) / 2;
            }
        }
        
        public string Place { get; set; }
        public int InseeNb { get; set; }
        
        public int WeatherType { get; set; }
        public DateTime Time { get; set; }
    }
}