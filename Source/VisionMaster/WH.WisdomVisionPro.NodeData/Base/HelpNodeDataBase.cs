using WH.WisdomVisionPro.NodeData.HelpPresenters;
using System.Text.Json.Serialization;

namespace WH.WisdomVisionPro.NodeData.Base;

public interface IHelpNodeData
{
    IHelpPresenter HelpPresenter { get; set; }
}

public abstract class HelpNodeDataBase : ShowPropertyNodeDataBase, IHelpNodeData
{
    protected HelpNodeDataBase()
    {
        this.HelpPresenter = this.CreateHelpPresenter();
    }
    private IHelpPresenter _helpPresenter;
    [JsonIgnore]
    [Browsable(false)]
    public IHelpPresenter HelpPresenter
    {
        get { return _helpPresenter; }
        set
        {
            _helpPresenter = value;
            RaisePropertyChanged();
        }
    }
    public virtual IHelpPresenter CreateHelpPresenter()
    {
        //https://hebiangu.github.io/WPF-Control-Docs/api/H.Controls.Diagram.Presenters.OpenCV.NodeDatas.Basic.AddSutract.html
        string fullName = this.GetType().FullName;
        return new HelpPresenter()
        {
            Url = "https://hebiangu.github.io/WPF-Control-Docs/api/" + fullName + ".html"
        };
    }
}

