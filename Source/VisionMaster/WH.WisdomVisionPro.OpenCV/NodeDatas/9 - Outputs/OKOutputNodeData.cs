// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using WH.WisdomVisionPro.NodeGroup.Groups.Outputs;

namespace WH.WisdomVisionPro.OpenCV.NodeDatas.Other;

[Icon(FontIcons.Ethernet)]
[Display(Name = "OK", Description = "输出流程处理OK结果", Order = 10400)]
public class OKOutputNodeData : OpenCVNodeDataBase, IOutputGroupableNodeData
{
    protected override FlowableResult<Mat> Invoke(ISrcVisionNodeData<Mat> srcImageNodeData, IVisionNodeData<Mat> from, IFlowableDiagramData diagram)
    {
        return this.OK(from.Mat, "OK");
    }
}

