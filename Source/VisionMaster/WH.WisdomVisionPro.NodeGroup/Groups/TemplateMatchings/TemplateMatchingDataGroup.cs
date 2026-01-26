using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.TemplateMatchings;

public interface ITemplateMatchingDataGroup : INodeDataGroup
{

}
[Icon(FontIcons.GotoToday)]
[Display(Name = "模板匹配模块", Description = "图像处理的基础检测", Order = 10600)]
public class TemplateMatchingDataGroup : NodeDataGroupBase, IImageDataGroup, ITemplateMatchingDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<ITemplateMatchingGroupableNodeData>().OrderBy(x => x.Order);
    }
}

public interface ITemplateMatchingGroupableNodeData : INodeData, IDisplayBindable
{

}
