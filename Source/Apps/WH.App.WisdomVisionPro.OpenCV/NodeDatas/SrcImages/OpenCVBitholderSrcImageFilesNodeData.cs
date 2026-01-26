using WH.WisdomVisionPro.OpenCV.Base;

namespace WH.App.WisdomVisionPro.OpenCV.NodeDatas.SrcImages;

[Display(Name = "夹具数据源", GroupName = "数据源", Order = 0)]
public class OpenCVBitholderSrcImageFilesNodeData : OpenCVSrcFilesNodeDataBase, IZooSrcImageFilesNodeData
{
    public override void LoadDefault()
    {
        base.LoadDefault();
        this.SrcFilePaths = this.SrcFilePaths.Where(x => x.Contains("multi_view_bitholder_cam")).ToObservable();
    }
}

