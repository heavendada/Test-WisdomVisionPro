using WH.WisdomVisionPro.OpenCV.Base;

namespace WH.App.WisdomVisionPro.OpenCV.NodeDatas.SrcImages;
[Display(Name = "药丸袋图像源", GroupName = "数据源", Order = 0)]
public class OpenCVPillbagSrcImageFilesNodeData : OpenCVSrcFilesNodeDataBase, IZooSrcImageFilesNodeData
{
    public override void LoadDefault()
    {
        base.LoadDefault();
        this.SrcFilePaths = this.SrcFilePaths.Where(x => x.Contains("pill_bag")).ToObservable();
    }
}
