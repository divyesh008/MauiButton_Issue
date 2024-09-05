using Microsoft.Maui.Handlers;
using UIKit;

namespace MauiButtonBug.Platforms.iOS.Handlers
{
    public class CustomButtonHandler : ButtonHandler
    {
        public static IPropertyMapper<IButton, CustomButtonHandler> CustomMapper = new PropertyMapper<IButton, CustomButtonHandler>(Mapper)
        {
            [nameof(IView.IsEnabled)] = MapIsEnabled
        };

        public CustomButtonHandler() : base(CustomMapper) { }

        private static void MapIsEnabled(CustomButtonHandler handler, IButton button)
        {
            handler.PlatformView.Enabled = button.IsEnabled;
            UpdateButtonAppearance(handler.PlatformView, button.IsEnabled);
        }

        protected override void ConnectHandler(UIButton platformView)
        {
            base.ConnectHandler(platformView);
            UpdateButtonAppearance(platformView, VirtualView.IsEnabled);
        }

        private static void UpdateButtonAppearance(UIButton platformButton, bool isEnabled)
        {
            if (isEnabled)
            {
                platformButton.Alpha = 1;
            }
            else
            {
                platformButton.Alpha = 0.5F;
            }
        }
    }
}

