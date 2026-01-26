using H.Controls.Diagram.Datas;
using WH.NodeDatas.Zoo;

namespace WH.App.WisdomVisionPro.OpenCV.NodeDatas.SrcImages;

public class OpenCVZooNodeDataGroup : ZooNodeDataGroup
{
    protected override IEnumerable<INodeData> CreateNodeDatas()
    {
        return this.GetType().Assembly.GetInstances<IZooSrcImageFilesNodeData>().OrderBy(x => x.Order);
    }
}
