using MudBlazor.Utilities;
using MudBlazor;

namespace SomosSolar.WebApp
{
    public class Configuration
    {
        public const string HttpClientName = "somossolar";
        public static string BackendUrl { get; set; } = "http://localhost:5086";

        public static MudTheme Theme = new()
        {
            Typography = new Typography
            {
                Default = new Default
                {
                    FontFamily = ["Releway", "sans-serif"]
                }
            },
            PaletteLight = new PaletteLight
            {
                Primary = new MudColor("#80CBC4"),
                PrimaryContrastText = new MudColor("#000000"),
                Secondary = Colors.Shades.Black,
                Background = Colors.Gray.Lighten4,
                AppbarBackground = new MudColor("#80CBC4"),
                AppbarText = Colors.Shades.Black,
                //Texto Principal
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.White,
                DrawerBackground = Colors.Teal.Darken2
                
                
                
            },
            PaletteDark = new PaletteDark
            {
                Primary = Colors.Teal.Accent2,
                Secondary = Colors.Teal.Darken3,
                AppbarBackground = Colors.Teal.Accent3,
                AppbarText = Colors.Shades.Black,
                PrimaryContrastText = new MudColor("#000000")
            }
        };
    }
}
