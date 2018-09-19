using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinGradientButtonTest
{
    public class GradientButton : Button
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
    propertyName: "StartColor",
    returnType: typeof(Color),
    declaringType: typeof(GradientButton),
    defaultValue: default(Color));

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

    }
}
