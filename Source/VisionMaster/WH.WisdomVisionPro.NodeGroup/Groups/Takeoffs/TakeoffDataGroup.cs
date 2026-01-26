using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.Takeoffs;

public interface ITakeoffGroupableNodeData : INodeData, IDisplayBindable
{

}

[Icon(FontIcons.Annotation)]
[Display(Name = "图像分割提取模块", Description = "对图像进行预处理操作", Order = 10300)]
public class TakeoffDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<ITakeoffGroupableNodeData>().OrderBy(x => x.Order);
    }
}

