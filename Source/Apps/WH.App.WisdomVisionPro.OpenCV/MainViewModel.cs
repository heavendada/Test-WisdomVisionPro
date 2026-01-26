global using H.Services.Project;

namespace WH.App.WisdomVisionPro.OpenCV;

//  ToDo：样例项目-汽车行驶路线识别

/// <summary>
/// 主视图模型类。
/// </summary>
public class MainViewModel : BindableBase
{
    /// <summary>
    /// 初始化 <see cref="MainViewModel"/> 类的新实例。
    /// </summary>
    public MainViewModel()
    {
        IocProject.Instance.CurrentChanged = (s, e) =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Project = e;
            });

        };
    }

    private IProjectItem _project;

    /// <summary>
    /// 获取或设置当前项目。
    /// </summary>
    public IProjectItem Project
    {
        get { return _project; }
        set
        {
            _project = value;
            RaisePropertyChanged();
        }
    }
}
