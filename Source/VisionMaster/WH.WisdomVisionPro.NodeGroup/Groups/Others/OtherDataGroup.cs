using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.Others;

public interface IOtherGroupableNodeData : INodeData, IDisplayBindable
{

}

[Icon(FontIcons.More)]
[Display(Name = "其他模块", Description = "图像处理的其他算法", Order = 10900)]
public class OtherDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IOtherGroupableNodeData>().OrderBy(x => x.Order);
    }
}

