using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibePanel
{
    public class VibePanel : Panel
    {
        public static readonly AttachedProperty<double> XProperty =
            AvaloniaProperty.RegisterAttached<VibePanel, StyledElement, double>("X", default);
        public static void SetX(StyledElement element, double value) =>
            element.SetValue(XProperty, value);
        public static double GetX(StyledElement element) =>
            element.GetValue(XProperty);

        public static readonly AttachedProperty<double> YProperty =
            AvaloniaProperty.RegisterAttached<VibePanel, StyledElement, double>("Y", default);
        public static void SetY(StyledElement element, double value) =>
            element.SetValue(YProperty, value);
        public static double GetY(StyledElement element) =>
            element.GetValue(YProperty);


        static VibePanel()
        {
            AffectsParentArrange<VibePanel>(XProperty);
            AffectsParentArrange<VibePanel>(YProperty);
        }

        public VibePanel()
        {

        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (Control child in Children)
            {
                child.Measure(availableSize);
            }

            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (Control child in Children)
            {
                ArrangeChild(child, finalSize);
            }

            return finalSize;
        }

        private void ArrangeChild(Control child, Size size)
        {
            double xIsh = GetX(child);
            double yIsh = GetY(child);

            double x = 0;
            double y = 0;

            // Calculate X position
            if (xIsh <= -2.0d)
            {
                // element is outside of the bounds on the left
                x = -child.DesiredSize.Width;
            }
            else if (xIsh <= -1.0d)
            {
                // element is partially outside of the bounds on the left
                // Linear interpolation between fully-out (-2) and left-edge (-1)
                x = (xIsh + 2.0) * child.DesiredSize.Width - child.DesiredSize.Width;
            }
            else if (xIsh <= 1.0d)
            {
                // element is within the bounds
                // Map -1 to 1 range to 0 to panel width

                x = size.Width / 2 + (xIsh * (size.Width - child.DesiredSize.Width) / 2) - child.DesiredSize.Width / 2;
            }
            else if (xIsh < 2.0d)
            {
                // element is partially outside of the bounds on the right
                // Linear interpolation between right-edge (1) and fully-out (2)
                x = size.Width + ((xIsh - 1.0) * child.DesiredSize.Width) - child.DesiredSize.Width;
            }
            else
            {
                // element is outside of the bounds on the right
                x = size.Width;
            }

            // Calculate Y position (same logic, just with height)
            if (yIsh <= -2.0d)
            {
                // element is outside of the bounds on the top
                y = -child.DesiredSize.Height;
            }
            else if (yIsh <= -1.0d)
            {
                // element is partially outside of the bounds on the top
                y = (yIsh + 2.0) * child.DesiredSize.Height - child.DesiredSize.Height;
            }
            else if (yIsh <= 1.0d)
            {
                // element is within the bounds
                y = size.Height / 2 + yIsh * ((size.Height - child.DesiredSize.Height) / 2) - child.DesiredSize.Height / 2;
            }
            else if (yIsh < 2.0d)
            {
                // element is partially outside of the bounds on the bottom
                y = size.Height + ((yIsh - 1.0) * child.DesiredSize.Height) - child.DesiredSize.Height;
            }
            else
            {
                // element is outside of the bounds on the bottom
                y = size.Height;
            }

            child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
        }
    }
}