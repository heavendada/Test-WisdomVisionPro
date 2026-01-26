using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;

namespace WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

[Icon(FontIcons.Camera)]
[Display(Name = "图像数据源", Description = "设置输入图像", Order = 10000)]
public class SrcImageDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<ISrcImageGroupableNodeData>().OrderBy(x => x.Order); ;
    }
}

public interface ISrcImageGroupableNodeData : INodeData, IDisplayBindable
{

}
