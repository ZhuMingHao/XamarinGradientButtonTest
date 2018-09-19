using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinGradientButtonTest.UWP;
using XamarinGradientButtonTest;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace XamarinGradientButtonTest.UWP
{
  
    public class GradientButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element.IsSet(Button.BorderColorProperty) && Element.BorderColor != (Color)Button.BorderColorProperty.DefaultValue)
                {
                    UpdateBorderColor();
                }

            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Button.BorderColorProperty.PropertyName)
            {
                UpdateBorderColor();
            }
        }
        void UpdateBorderColor()
        {
            var gradientButton = Element as GradientButton;
            Control.BorderBrush = gradientButton.BorderColor != Color.Default ? Element.BorderColor.ToGradientBrush(gradientButton.StartColor) : (Brush)Windows.UI.Xaml.Application.Current.Resources["ButtonBorderThemeBrush"];
        }

    }
    internal static class ConvertExtensions
    {
        public static Brush ToGradientBrush(this Color color, Color StartColor)
        {
            var GradientBrush = new LinearGradientBrush();
            GradientBrush.StartPoint = new Windows.Foundation.Point(0.5, 0);
            GradientBrush.EndPoint = new Windows.Foundation.Point(0.5, 1);
            GradientBrush.GradientStops.Add(new GradientStop() { Color = StartColor.ToWindowsColor(), Offset = 0.0 });
            GradientBrush.GradientStops.Add(new GradientStop() { Color = color.ToWindowsColor(), Offset = 1.0 });
            return GradientBrush;
        }

        public static Windows.UI.Color ToWindowsColor(this Color color)
        {
            return Windows.UI.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }

    }
}
