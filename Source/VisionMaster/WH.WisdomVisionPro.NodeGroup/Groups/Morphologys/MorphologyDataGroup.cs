using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.Morphologys;

public interface IMorphologyGroupableNodeData : INodeData, IDisplayBindable
{

}

[Icon(FontIcons.HomeGroup)]
[Display(Name = "形态学模块", Description = "对图像进行腐蚀、膨胀、开运算和闭运算", Order = 10400)]
public class MorphologyDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IMorphologyGroupableNodeData>().OrderBy(x => x.Order);
    }
}

