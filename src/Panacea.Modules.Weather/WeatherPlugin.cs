using Panacea.Core;
using Panacea.Modularity;
using Panacea.Modularity.UiManager;
using Panacea.Modules.Weather.Models;
using Panacea.Modules.Weather.ViewModels;
using Panacea.Multilinguality;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modules.Weather
{
    public class WeatherPlugin : ICallablePlugin
    {
        private WeatherPageViewModel _main;
        private GetSettingsResponse _settingsResponse;
        private WeatherResponse _weatherResponse;
        private ForecastResponse _forecastResponse;
        private MyWebClient _webClient;
        private DateTime _lastUpdate = new DateTime(1970, 1, 1);

        public WeatherPlugin(PanaceaServices core)
        {
            _core = core;
            _webClient = new MyWebClient();
        }

        public Task BeginInit()
        {
            return Task.CompletedTask;
        }

        public async void Call()
        {
            if (_core.TryGetUiManager(out IUiManager ui))
            {
                try
                {
                    if (_loading) return;
                    _main = new WeatherPageViewModel();

                    ui.Navigate(_main);
                    if (DateTime.Now.Subtract(_lastUpdate).TotalHours < 3)
                    {
                        await Task.Delay(500);
                        if (_main == null) return;
                        FinishLoading();
                        return;
                    }
                    await Update();
                    //todo _websocket.PopularNotifyPage("Weather");
                }
                catch
                {
                    if (ui.CurrentPage == _main)
                    {
                        ui.Toast(new Translator("Weather").Translate("Failed to get information from weather service. Try again later."));
                        ui.GoBack();
                    }
                }
                finally
                {
                    _loading = false;
                }
            }
        }


        public void Dispose()
        {

        }

        public Task EndInit()
        {
            return Task.CompletedTask;
        }

        public Task Shutdown()
        {
            return Task.CompletedTask;
        }

        bool _loading = false;
        private readonly PanaceaServices _core;

        async Task Update()
        {
            
            var response = await _core.HttpClient.GetObjectAsync<GetSettingsResponse>(
                   "weather/get_settings/");
            if (!response.Success) return;
            _settingsResponse = response.Result;
            var str = await _webClient.DownloadStringTaskAsync(
                6000,
                    new Uri(Path.Combine(response.Result.ServerUrl,
                        "data/2.5/weather?APPID=cb06e603ea812500b61bb43b2e6e9e13&q=" +
                        _settingsResponse.Location[0].City + "," +
                        _settingsResponse.Location[0].Country + "&units=" + _settingsResponse.Unit)));
            _weatherResponse = JsonSerializer.DeserializeFromString<WeatherResponse>(str);
            var str2 = await _webClient.DownloadStringTaskAsync(
                6000,
                new Uri(Path.Combine(response.Result.ServerUrl,
                   "data/2.5/forecast?APPID=cb06e603ea812500b61bb43b2e6e9e13&q=" +
                    _settingsResponse.Location[0].City + "," +
                   _settingsResponse.Location[0].Country + "&units=" + _settingsResponse.Unit)));
            _forecastResponse = JsonSerializer.DeserializeFromString<ForecastResponse>(str2);
            _lastUpdate = DateTime.Now;
            if (_main == null) return;
            FinishLoading();

            //todo CreateTiles();
        }

        void FinishLoading()
        {
            _main.WeatherResponse = _weatherResponse;
            _main.ForecastResponse = _forecastResponse;
            _main.SettingsResponse = _settingsResponse;
            _main.Done();
        }
    }
}
