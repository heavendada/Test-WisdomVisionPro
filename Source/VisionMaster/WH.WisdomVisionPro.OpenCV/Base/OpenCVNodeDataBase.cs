// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

namespace WH.WisdomVisionPro.OpenCV.Base;

public abstract class OpenCVNodeDataBase : SelectableResultImageNodeData<Mat>, IOpenCVNodeData
{
    //protected void UpdateResultImageSource(Mat mat)
    //{
    //    if (this.Mat != mat)
    //        this.Mat?.Dispose();
    //    this.Mat = mat;
    //    this.ResultImageSource = mat.ToImageSource();
    //    //if (this.ResultImageSource == null)
    //    //{
    //    //    System.Windows.Application.Current.Dispatcher.Invoke(() =>
    //    //    {
    //    //        this.ResultImageSource = mat.Empty() ? null : mat?.ToWriteableBitmap();
    //    //    });
    //    //}
    //    //else
    //    //{
    //    //    if (this.ResultImageSource.CheckAccess())
    //    //    {
    //    //        this.ResultImageSource = mat?.ToWriteableBitmap();
    //    //    }
    //    //    else
    //    //    {
    //    //        System.Windows.Application.Current.Dispatcher.Invoke(() =>
    //    //        {
    //    //            this.ResultImageSource = mat.Empty() ? null : mat?.ToWriteableBitmap();
    //    //        });
    //    //    }
    //    //}
    //}

    protected override bool IsValid(Mat t)
    {
        return t.IsValid();
    }
    protected override void UpdateResultImageSource()
    {
        this.UpdateResultImageSource(this.Mat);
    }

    protected virtual void UpdateResultImageSource(Mat mat)
    {
        //this.UpdateResultImageSource(this.Mat);
        this.ResultImageSource = mat.ToImageSource();
    }
}

