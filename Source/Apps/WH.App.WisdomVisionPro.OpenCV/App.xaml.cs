using WH.App.WisdomVisionPro.OpenCV.Projects;
using H.Extensions.ApplicationBase;
using H.Themes.Colors;
using WH.WisdomVisionPro.NodeData;
using Microsoft.Extensions.DependencyInjection;

namespace WH.App.WisdomVisionPro.OpenCV;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : ApplicationBase
{
    //protected override void OnExcetion()
    //{
    //    //base.OnExcetion();
    //}
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddApplicationServices();
        services.AddProject<VisionProjectService>(x =>
        {
            x.Extenstion = ".json";
            x.JsonSerializerService = new NewtonsoftJsonSerializerService();
        });
    }

    protected override void Configure(IApplicationBuilder app)
    {
        base.Configure(app);
        //app.UseTheme(x => x.ColorResource = x.ColorResources.OfType<TechnologyBlueDarkColorResource>().FirstOrDefault());
        //app.UseAdorner();
        app.UseSplashScreenOptions(x =>
        {
            x.ProductFontSize = 55;
            x.Product = "WisdomVisionPro";
            x.Sub = "基于 WPF-Control 框架开发";
        });
        app.UseApplicationOptions(x =>
        x.UseThemeModuleOptions(x =>
        {
            x.UseColorThemeOptions(x =>
            {
                x.ColorResource = x.ColorResources.OfType<DarkColorResource>().FirstOrDefault();
            });
        }));

        app.UseSettingDataOptions(x =>
        {
            x.Add(VisionSettings.Instance);
        });
    }

    protected override System.Windows.Window CreateMainWindow(StartupEventArgs e)
    {
        return new MainWindow();
    }
}
