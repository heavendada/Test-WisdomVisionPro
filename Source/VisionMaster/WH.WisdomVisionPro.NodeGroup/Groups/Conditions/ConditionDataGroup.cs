using H.Common.Attributes;
using H.Common.Interfaces;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.Conditions;

public interface IConditionGroupableNodeData : INodeData, IOrderable
{

}

[Icon(FontIcons.Dial6)]
[Display(Name = "逻辑模块", Description = "对图像进行条件判断选择执行对应路径", Order = 10500)]
public class ConditionDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IConditionGroupableNodeData>().OrderBy(x => x.Order);
    }
}

