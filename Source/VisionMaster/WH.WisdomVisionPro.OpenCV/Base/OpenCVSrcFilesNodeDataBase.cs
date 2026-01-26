// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")
namespace WH.WisdomVisionPro.OpenCV.Base;

public abstract class OpenCVSrcFilesNodeDataBase : SrcFilesVisionNodeData<Mat>
{
    protected override FlowableResult<Mat> Invoke(ISrcVisionNodeData<Mat> srcImageNodeData, IVisionNodeData<Mat> from, IFlowableDiagramData diagram)
    {
        Mat mat = new Mat(this.SrcFilePath, ImreadModes.Color);
        this.PixelWidth = mat.Width;
        this.PixelHeight = mat.Height;
        this.ImageColorType = mat.Type();
        return this.OK(mat);
    }

    protected override void UpdateResultImageSource()
    {
        this.ResultImageSource = this.Mat.ToImageSource();
    }
    protected override bool IsValid(Mat t)
    {
        return t.IsValid();
    }
}
