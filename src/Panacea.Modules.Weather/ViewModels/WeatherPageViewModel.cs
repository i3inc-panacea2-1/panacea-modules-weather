using Panacea.Modules.Weather.Models;
using Panacea.Modules.Weather.Views;
using Panacea.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Panacea.Modules.Weather.ViewModels
{
    [View(typeof(WeatherPage))]
    class WeatherPageViewModel : ViewModelBase
    {
        private WeatherResponse _weatherResponse;
        public WeatherResponse WeatherResponse
        {
            get => _weatherResponse;
            set
            {
                _weatherResponse = value;
                OnPropertyChanged();
            }
        }

        private ForecastResponse _forecastResponse;
        public ForecastResponse ForecastResponse
        {
            get => _forecastResponse;
            set
            {
                _forecastResponse = value;
                OnPropertyChanged();
            }
        }

        private GetSettingsResponse _settingsResponse;
        public GetSettingsResponse SettingsResponse
        {
            get => _settingsResponse;
            set
            {
                _settingsResponse = value;
                OnPropertyChanged();
            }
        }

        Visibility _layoutRootVisibility = Visibility.Collapsed;

        public WeatherPageViewModel()
        {
        }

        public Visibility LayoutRootVisibility {
            get => _layoutRootVisibility;
            private set
            {
                _layoutRootVisibility = value;
                OnPropertyChanged();
            }
        }

        public void Done()
        {
            LayoutRootVisibility = Visibility.Visible;
        }
    }
}
