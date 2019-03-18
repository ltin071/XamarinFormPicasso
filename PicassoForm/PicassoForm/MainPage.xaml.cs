using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PicassoForm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(3000), () =>
            {
                DependencyService.Get<IPicasso>().Get("TestImage", "http://i.imgur.com/DvpvklR.jpg");
                return false; // True = Repeat again, False = Stop the timer
            });

        }
    }
}
