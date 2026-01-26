using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.Blurs;

public interface IBlurGroupableNodeData : INodeData, IDisplayBindable
{

}

[Icon(FontIcons.InPrivate)]
[Display(Name = "滤波模块", Description = "对图像进行滤波，降噪，模糊处理", Order = 10200)]
public class BlurDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IBlurGroupableNodeData>().OrderBy(x => x.Order);
    }
}

