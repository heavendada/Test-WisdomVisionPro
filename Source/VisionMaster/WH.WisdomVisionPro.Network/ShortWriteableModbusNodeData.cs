using H.Controls.Diagram.Presenter.DiagramDatas.Base;
using H.Controls.Diagram.Presenter.Flowables;
using WH.WisdomVisionPro.Network.Groups;

namespace WH.WisdomVisionPro.Network;

[Display(Name = "Modbus发送", GroupName = "网络通讯模块", Description = "配置数据采集并实时采集Modbus数据", Order = 10)]
public class ShortWriteableModbusNodeData : WriteableModbusNodeData<ushort>, INetwrokNodeData
{
    protected override void Write(IFlowableLinkData previors, IFlowableDiagramData diagram)
    {
        this.Master.WriteSingleRegister(this.SlaveAddress, this.StartAddress, this.Value);
    }
}

