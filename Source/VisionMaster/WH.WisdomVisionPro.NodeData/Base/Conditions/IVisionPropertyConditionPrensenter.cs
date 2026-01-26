using H.Controls.FilterBox;

namespace WH.WisdomVisionPro.NodeData.Base.Conditions;

public interface IVisionPropertyConditionPrensenter : IPropertyConditionPrensenter
{
    int SelectedInputIndex { get; set; }
    INodeData SelectedInputNodeData { get; set; }
    int SelectedOutputIndex { get; set; }
    INodeData SelectedOutputNodeData { get; set; }

    bool IsMatchInputNode();
    void UpdateProperties(INodeData value);
}

