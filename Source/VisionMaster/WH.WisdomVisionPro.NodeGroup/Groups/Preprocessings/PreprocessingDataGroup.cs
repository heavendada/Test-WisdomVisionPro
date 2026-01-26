using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.NodeGroup.Groups.Preprocessings;

public interface IPreprocessingGroupableNodeData : INodeData, IDisplayBindable
{

}

[Icon(FontIcons.Color)]
[Display(Name = "图像预处理模块", Description = "对图像进行预处理操作", Order = 10100)]
public class PreprocessingDataGroup : NodeDataGroupBase, IImageDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IPreprocessingGroupableNodeData>().OrderBy(x => x.Order);
    }
}

