using PrayerTimes.Library.Calculators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using PrayerTimes;


namespace PrayTimesApp
{
    public enum Prayer
    {
        Fajr,
        Sunrise,
        Dhuhr,
        Asr,
        Maghrib,
        Isha
    }


    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
           

            Title = "Prayer Times";
            // Configure the prayer times settings
            PrayerTimesCalculationMethod method = PrayerTimesCalculationMethod.Jafari;
            double latitude = 51.0447;
            double longitude = -114.0719;
            double timezone = 2; // Adjusted timezone value for Calgary (UTC-6)
            DateTime date = DateTime.Today;
            PrayerTimesCalculator calculator = new PrayerTimesCalculator(method, latitude, longitude, timezone);

            // Call the prayer times calculation method
            Dictionary<Prayer, DateTime> prayerTimes = calculator.GetDatePrayerTimes(date);

            // Create labels for each prayer time
            Label fajrLabel = new Label
            {
                Text = $"Fajr: {prayerTimes[Prayer.Fajr]:t}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label sunriseLabel = new Label
            {
                Text = $"Sunrise: {prayerTimes[Prayer.Sunrise]:t}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label dhuhrLabel = new Label
            {
                Text = $"Dhuhr: {prayerTimes[Prayer.Dhuhr]:t}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label asrLabel = new Label
            {
                Text = $"Asr: {prayerTimes[Prayer.Asr]:t}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label maghribLabel = new Label
            {
                Text = $"Maghrib: {prayerTimes[Prayer.Maghrib]:t}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label ishaLabel = new Label
            {
                Text = $"Isha: {prayerTimes[Prayer.Isha]:t}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Create label for current time
            Label currentTimeLabel = new Label
            {
                Text = $"Current time: {DateTime.Now:t}",
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };
            // Update the labels with prayer times and minutes
            TimeSpan fajrTime = prayerTimes[Prayer.Fajr].TimeOfDay;
            fajrLabel.Text = $"Fajr: {fajrTime:hh\\:mm} ({(fajrTime - DateTime.Now.TimeOfDay):hh\\:mm\\:ss} remaining)";

            TimeSpan sunriseTime = prayerTimes[Prayer.Sunrise].TimeOfDay;
            sunriseLabel.Text = $"Sunrise: {sunriseTime:hh\\:mm} ({(sunriseTime - DateTime.Now.TimeOfDay):hh\\:mm\\:ss} remaining)";

            TimeSpan dhuhrTime = prayerTimes[Prayer.Dhuhr].TimeOfDay;
            dhuhrLabel.Text = $"Dhuhr: {dhuhrTime:hh\\:mm} ({(dhuhrTime - DateTime.Now.TimeOfDay):hh\\:mm\\:ss} remaining)";

            TimeSpan asrTime = prayerTimes[Prayer.Asr].TimeOfDay;
            asrLabel.Text = $"Asr: {asrTime:hh\\:mm} ({(asrTime - DateTime.Now.TimeOfDay):hh\\:mm\\:ss} remaining)";

            TimeSpan maghribTime = prayerTimes[Prayer.Maghrib].TimeOfDay;
            maghribLabel.Text = $"Maghrib: {maghribTime:hh\\:mm} ({(maghribTime - DateTime.Now.TimeOfDay):hh\\:mm\\:ss} remaining)";

            TimeSpan ishaTime = prayerTimes[Prayer.Isha].TimeOfDay;
            ishaLabel.Text = $"Isha: {ishaTime:hh\\:mm} ({(ishaTime - DateTime.Now.TimeOfDay):hh\\:mm\\:ss} remaining)";


            // Add labels to stack layout
            StackLayout stackLayout = new StackLayout();
            stackLayout.Children.Add(currentTimeLabel);
            stackLayout.Children.Add(fajrLabel);
            stackLayout.Children.Add(sunriseLabel);
            stackLayout.Children.Add(dhuhrLabel);
            stackLayout.Children.Add(asrLabel);
            stackLayout.Children.Add(maghribLabel);
            stackLayout.Children.Add(ishaLabel);
            Content = stackLayout;
        }
    
      

        private void HomeClk(object sender, EventArgs e)
        {
            // Implement the functionality for the Home button click event
        }

        private async void OptionClk(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Options", "Cancel", null, "iOS", "Android", "Mobile", "Desktop");

            switch (action)
            {
                case "iOS":
                    // Code to handle iOS device
                    break;
                case "Android":
                    // Code to handle Android device
                    break;
                case "Mobile":
                    // Code to handle mobile devices
                    break;
                case "Desktop":
                    // Code to handle desktop devices
                    break;
                default:
                    break;
            }
        }


        private void HelpClk(object sender, EventArgs e)
        {
            // Implement the functionality for the Help button click event
        }

        
    }
}
