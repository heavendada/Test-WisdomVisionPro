// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Controls.Diagram.Presenter.Flowables;
using WH.WisdomVisionPro.Network.Groups;

namespace WH.WisdomVisionPro.Network;

[Display(Name = "Modbus采集", GroupName = "网络通讯模块", Description = "配置数据采集并实时采集Modbus数据", Order = 10)]
public class IntReadableModbusNodeData : ReadableModbusNodeData<int>, INetwrokNodeData
{
    protected override void Read(IFlowableLinkData previors, IFlowableDiagramData diagram)
    {
        ushort[] registers = this.Master.ReadHoldingRegisters(this.SlaveAddress, this.StartAddress, this.NumberOfPoints);
        ushort value = registers[0];
        this.Value = (int)value;
    }
}

