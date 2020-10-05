using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFEAccelerometerSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs args)
        {
            xResult.Text = $"X: {args.Reading.Acceleration.X}";
            yResult.Text = $"Y: {args.Reading.Acceleration.Y}";
            zResult.Text = $"Z: {args.Reading.Acceleration.Z}";
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(SensorSpeed.UI);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Not supported on device
            }
            catch (Exception ex)
            {
                // Something else went wrong
            }
        }
    }
}