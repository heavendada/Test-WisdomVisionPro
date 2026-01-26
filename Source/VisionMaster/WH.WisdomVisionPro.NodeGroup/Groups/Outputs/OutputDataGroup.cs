using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.Outputs;

public interface IOutputGroupableNodeData : INodeData, IDisplayBindable
{

}

[Icon(FontIcons.Ethernet)]
[Display(Name = "结果输出模块", Description = "输出流程处理结果", Order = 10900)]
public class OutputDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IOutputGroupableNodeData>().OrderBy(x => x.Order);
    }
}

