﻿using MudBlazor;

//#if (IsHosted)
namespace MudBlazor.Template.Client.Shared
//#else
namespace MudBlazor.Template.Shared
//#endif
{
    public class MudBlazorAdminDashboard : MudTheme
    {
        public MudBlazorAdminDashboard()
        {
            Palette = new Palette()
            {
                Primary = Colors.Blue.Darken1,
                Secondary = Colors.DeepPurple.Accent2,
                Background = Colors.Grey.Lighten5,
                AppbarBackground = Colors.Blue.Darken1,
                DrawerBackground = "#FFF",
                DrawerText = "rgba(0,0,0, 0.7)",
                Success = "#06d79c"
            };

            LayoutProperties = new LayoutProperties()
            {
                DefaultBorderRadius = "6px",
            };

            Typography = new Typography()
            {
                Default = new Default()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = ".875rem",
                    FontWeight = 400,
                    LineHeight = 1.43,
                    LetterSpacing = ".01071em"
                },
                H1 = new H1()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = "6rem",
                    FontWeight = 300,
                    LineHeight = 1.167,
                    LetterSpacing = "-.01562em"
                },
                H2 = new H2()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = "3.75rem",
                    FontWeight = 300,
                    LineHeight = 1.2,
                    LetterSpacing = "-.00833em"
                },
                H3 = new H3()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = "3rem",
                    FontWeight = 400,
                    LineHeight = 1.167,
                    LetterSpacing = "0"
                },
                H4 = new H4()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = "2.125rem",
                    FontWeight = 400,
                    LineHeight = 1.235,
                    LetterSpacing = ".00735em"
                },
                H5 = new H5()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = "1.5rem",
                    FontWeight = 400,
                    LineHeight = 1.334,
                    LetterSpacing = "0"
                },
                H6 = new H6()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = "1.25rem",
                    FontWeight = 400,
                    LineHeight = 1.6,
                    LetterSpacing = ".0075em"
                },
                Button = new Button()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = ".875rem",
                    FontWeight = 500,
                    LineHeight = 1.75,
                    LetterSpacing = ".02857em"
                },
                Body1 = new Body1()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = "1rem",
                    FontWeight = 400,
                    LineHeight = 1.5,
                    LetterSpacing = ".00938em"
                },
                Body2 = new Body2()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = ".875rem",
                    FontWeight = 400,
                    LineHeight = 1.43,
                    LetterSpacing = ".01071em"
                },
                Caption = new Caption()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = ".75rem",
                    FontWeight = 400,
                    LineHeight = 1.66,
                    LetterSpacing = ".03333em"
                },
                Subtitle2 = new Subtitle2()
                {
                    FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontSize = ".875rem",
                    FontWeight = 500,
                    LineHeight = 1.57,
                    LetterSpacing = ".00714em"
                }
            };
            Shadows = new Shadow();
            ZIndex = new ZIndex();
        }
    }
}
