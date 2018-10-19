using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinGradientButtonTest;
using XamarinGradientButtonTest.iOS;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]

namespace XamarinGradientButtonTest.iOS
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        CAGradientLayer gradient;
        CAShapeLayer shape;
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            gradient = new CAGradientLayer();
            gradient.Colors = new CGColor[] { ((GradientButton)Element).StartColor.ToCGColor(), Element.BorderColor.ToCGColor() };

            shape = new CAShapeLayer();
            shape.LineWidth = (nfloat)(Element.BorderWidth);
            shape.StrokeColor = UIColor.Black.CGColor;
            shape.FillColor = UIColor.Clear.CGColor;
            gradient.Mask = shape;

            Control.Layer.AddSublayer(gradient);
            Control.Layer.BorderColor = UIColor.Clear.CGColor;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            shape.Path = UIBezierPath.FromRect(rect).CGPath;
            gradient.Frame = rect;
        }
    }
}