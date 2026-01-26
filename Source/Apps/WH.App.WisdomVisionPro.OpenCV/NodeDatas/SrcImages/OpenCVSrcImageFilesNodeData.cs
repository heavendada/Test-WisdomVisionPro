using WH.WisdomVisionPro.OpenCV.Base;

namespace WH.App.WisdomVisionPro.OpenCV.NodeDatas.SrcImages;
[Display(Name = "OpenCV图像源", GroupName = "数据源", Order = 0)]
public class OpenCVSrcImageFilesNodeData : OpenCVSrcFilesNodeDataBase, IZooSrcImageFilesNodeData
{
    public override void LoadDefault()
    {
        base.LoadDefault();
        this.SrcFilePaths = this.SrcFilePaths.Where(x => x.Contains("OpenCV")).ToObservable();
    }
}
