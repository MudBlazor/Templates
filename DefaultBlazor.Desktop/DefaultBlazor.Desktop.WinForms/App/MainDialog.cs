using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using System.Windows.Forms;

namespace DefaultBlazor.Desktop.WinForms.App {
    public partial class MainDialog : Form
    {
        public MainDialog()
        {
            InitializeComponent();
            var blazor = new BlazorWebView() {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = Program.ServicesProvider
            };
            blazor.RootComponents.Add<AppRoot>("#app");
            Controls.Add(blazor);
        }

    }
}
