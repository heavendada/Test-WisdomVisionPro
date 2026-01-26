using H.Common.Attributes;
using H.Controls.Diagram.Datas;
using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Extensions.Common;
using H.Extensions.FontIcon;
using WH.NodeDatas.Zoo.NodeDatas;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WH.NodeDatas.Zoo;

[Icon(FontIcons.Photo2)]
[Display(Name = "系统数据源", Description = "包含系统自带的一些图片示例数据源", Order = 10001)]
public class ZooNodeDataGroup : NodeDataGroupBase, IZooNodeDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IZooSrcImageFilesNodeData>().OrderBy(x => x.Order);
    }
}
