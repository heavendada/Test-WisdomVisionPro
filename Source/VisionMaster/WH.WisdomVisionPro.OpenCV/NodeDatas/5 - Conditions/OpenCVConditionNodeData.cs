// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using WH.WisdomVisionPro.NodeData.Base.Conditions;
using WH.WisdomVisionPro.NodeGroup.Groups.Conditions;

namespace WH.WisdomVisionPro.OpenCV.NodeDatas.Image;
[Icon(FontIcons.Dial6)]
[Display(Name = "条件分支", GroupName = "判断条件", Description = "设置像素阈值，根据阈值执行不同路径逻辑", Order = 20)]
public class OpenCVConditionNodeData : ConditionNodeData<Mat>, IOnDiagramDeserialized, IConditionGroupableNodeData
{
    protected override FlowableResult<Mat> Invoke(ISrcVisionNodeData<Mat> srcImageNodeData, IVisionNodeData<Mat> from, IFlowableDiagramData diagram)
    {
        return new FlowableResult<Mat>(from?.Mat) { State = FlowableResultState.OK };
    }

    protected override void UpdateResultImageSource()
    {
        this.UpdateResultImageSource(this.Mat);
    }

    protected void UpdateResultImageSource(Mat mat)
    {
        this.ResultImageSource = mat.ToImageSource();
    }
    protected override bool IsValid(Mat t)
    {
        return t.IsValid();
    }
}

