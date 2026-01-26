
using WH.WisdomVisionPro.DiagramData;
using WH.WisdomVisionPro.Project;

namespace WH.App.WisdomVisionPro.OpenCV.Projects;
public class VisionProjectItem : VisionProjectItemBase
{
    /// <summary>
    /// 创建一个新的OpenCV图表数据实例。
    /// </summary>
    /// <returns>返回创建的OpenCV图表数据实例。</returns>
    protected override IVisionDiagramData CreateDiagramData()
    {
        return new OpenCVVisionDiagramData() { Width = 1000, Height = 1500 };
    }
}
