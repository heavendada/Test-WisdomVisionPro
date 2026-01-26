// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using WH.WisdomVisionPro.NodeGroup.Groups.TemplateMatchings;

namespace WH.WisdomVisionPro.OpenCV.NodeDatas.Detector;

[Icon(FontIcons.Color)]
[Display(Name = "色相匹配", GroupName = "基础检测", Description = "色相匹配", Order = 0)]
public class HSVInRangeRenderBlobMatchingNodeData : RenderBlobs, ITemplateMatchingGroupableNodeData
{
    public override void LoadDefault()
    {
        base.LoadDefault();
        this.UseRenderBlobs = false;
    }
    private ImageColorPickerPresenter _ImageColorPickerPresenter = new ImageColorPickerPresenter();
    [Display(Name = "设置色相", GroupName = VisionPropertyGroupNames.RunParameters, Description = "从图片提取颜色或手动设置色相")]
    public ImageColorPickerPresenter ImageColorPickerPresenter
    {
        get { return _ImageColorPickerPresenter; }
        set
        {
            _ImageColorPickerPresenter = value;
            RaisePropertyChanged();
        }
    }

    private int _hRange;
    [PropertyItem(typeof(Int32SliderTextPropertyItem))]
    [Display(Name = "H色相生成范围", GroupName = VisionPropertyGroupNames.RunParameters, Description = "用于控制吸管工具生成上下限参数")]
    [DefaultValue(35)]
    [Range(0, 85)]
    public int hRange
    {
        get { return _hRange; }
        set
        {
            _hRange = value;
            RaisePropertyChanged();
            this.UpdateInvokeCurrent();
        }
    }

    private int _sRange;
    [PropertyItem(typeof(Int32SliderTextPropertyItem))]
    [Display(Name = "S饱和度生成范围", GroupName = VisionPropertyGroupNames.RunParameters, Description = "用于控制吸管工具生成上下限参数")]
    [DefaultValue(30)]
    [Range(0, 255)]
    public int sRange
    {
        get { return _sRange; }
        set
        {
            _sRange = value;
            RaisePropertyChanged();
            this.UpdateInvokeCurrent();
        }
    }

    private int _vRange;
    [PropertyItem(typeof(Int32SliderTextPropertyItem))]
    [Display(Name = "V明度生成范围", GroupName = VisionPropertyGroupNames.RunParameters, Description = "用于控制吸管工具生成上下限参数")]
    [DefaultValue(30)]
    [Range(0, 255)]
    public int vRange
    {
        get { return _vRange; }
        set
        {
            _vRange = value;
            RaisePropertyChanged();
            this.UpdateInvokeCurrent();
        }
    }

    protected override FlowableResult<Mat> Invoke(ISrcVisionNodeData<Mat> srcImageNodeData, IVisionNodeData<Mat> from, IFlowableDiagramData diagram)
    {
        Mat src = from.Mat;
        Mat hsv = from.Mat.CvtColor(ColorConversionCodes.BGR2HSV);
        Mat mask = new Mat();
        Tuple<Scalar, Scalar> range = this.ImageColorPickerPresenter.Color.GetHSVRange(this.hRange, this.sRange, this.vRange);
        Scalar lowerScalar = range.Item1;
        Scalar upperScalar = range.Item2;
        // 需要前序流程颜色处理 ColorConversionCodes.BGR2HSV)
        Cv2.InRange(hsv, lowerScalar, upperScalar, mask);
        ////  Do ：反转黑白
        //Cv2.BitwiseNot(mask, mask);
        this.ImageColorPickerPresenter.ImageSource = from.Mat?.ToImageSource();
        return base.InvokeMat(srcImageNodeData, from.Mat, mask, diagram);
    }

}

