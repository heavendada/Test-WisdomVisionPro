using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.ViewModels;
using WH.WisdomVisionPro.NodeGroup.Groups.SrcImages;

namespace WH.WisdomVisionPro.Network.Groups;

public interface INetwrokDataGroup : INodeDataGroup
{

}
[Icon(FontIcons.NarratorForward)]
[Display(Name = "网络通讯模块", Description = "网络通讯模块", Order = 10700)]
public class NetworkDataGroup : NodeDataGroupBase, IImageDataGroup, INetwrokDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return typeof(INetwrokNodeData).Assembly.GetInstances<INetwrokNodeData>().OrderBy(x => x.Order);
    }
}

public interface INetwrokNodeData : INodeData, IDisplayBindable
{

}
