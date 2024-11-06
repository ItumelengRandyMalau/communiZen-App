using Microsoft.Maui.Controls;

namespace Zenfull.Behaviors
{
    public static class ZoomBehavior
    {
        public static readonly BindableProperty IsZoomedProperty =
            BindableProperty.CreateAttached(
                "IsZoomed",
                typeof(bool),
                typeof(ZoomBehavior),
                false,
                propertyChanged: OnIsZoomedChanged);

        public static bool GetIsZoomed(BindableObject view) => (bool)view.GetValue(IsZoomedProperty);
        public static void SetIsZoomed(BindableObject view, bool value) => view.SetValue(IsZoomedProperty, value);

        static void OnIsZoomedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is VisualElement view)
            {
                if ((bool)newValue)
                {
                    view.ScaleTo(1.1, 250);
                }
                else
                {
                    view.ScaleTo(1.0, 250);
                }
            }
        }
    }
}
