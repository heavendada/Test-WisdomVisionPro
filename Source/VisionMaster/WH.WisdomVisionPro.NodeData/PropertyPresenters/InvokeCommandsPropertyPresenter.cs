using H.Common.Attributes;
using H.Controls.Diagram.Presenter;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Controls.Diagram.Presenter.Flowables;
using H.Controls.Diagram.Presenter.NodeDatas.Base;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.Commands;
using System.Reflection;

namespace WH.WisdomVisionPro.NodeData.PropertyPresenters;

public class InvokeCommandsPropertyPresenter : CommandsPropertyPresenter
{
    public InvokeCommandsPropertyPresenter(IDiagramableNodeData nodeData) : base(nodeData)
    {
        string[] names = this.GetUseGroupNames().ToArray();
        this.Presenter.UseGroupNames = string.Join(',', names);
        this.Presenter.UpdateTabNames();
    }

    public IEnumerable<string> GetUseGroupNames()
    {
        return typeof(VisionPropertyGroupNames).GetFields(BindingFlags.Public | BindingFlags.Static)
               .Where(x => x.FieldType == typeof(string))
               .Select(x => x.GetValue(null)?.ToString())
               .Where(x => !string.IsNullOrEmpty(x));
    }

    [Icon(FontIcons.Delete)]
    [Display(Name = "执行", GroupName = "操作")]
    public DisplayCommand InvokeCommand => new DisplayCommand(async x =>
    {
        //var srcs = this.NodeData.GetSelectedFromNodeDatas(this.NodeData.DiagramData).OfType<ISrcImageNodeData>();
        if (this.NodeData.DiagramData is IFlowableDiagramData flowableDiagramData)
            await flowableDiagramData.Start();
    }, x =>
    {
        if (this.NodeData.DiagramData is IFlowableDiagramData flowableDiagramData)
            return flowableDiagramData.State.CanStart();
        return false;
    });
}

