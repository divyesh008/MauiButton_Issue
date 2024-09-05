using Google.Android.Material.Button;
using Microsoft.Maui.Handlers;

namespace MauiButtonBug.Platforms.Android.Handlers
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

        protected override void ConnectHandler(MaterialButton platformView)
        {
            base.ConnectHandler(platformView);
            UpdateButtonAppearance(platformView, VirtualView.IsEnabled);
        }

        private static void UpdateButtonAppearance(MaterialButton platformView, bool isEnabled)
        {
            if (isEnabled)
            {
                platformView.Alpha = 1F;  
            }
            else
            {
                platformView.Alpha = 0.5F; 
            }
        }
    }
}

