using H.Controls.Diagram.Presenter.Extensions;
using H.Extensions.TypeConverter;
using WH.WisdomVisionPro.NodeData.Base;
using System.Text.Json.Serialization;

namespace WH.WisdomVisionPro.NodeData.ROIPresenters;

[Display(Name = "继承")]
public class FromROI : ROIBase, IROI
{
    [JsonIgnore]
    public IROINodeData ROINodeData { get; set; }

    [JsonIgnore]
    [TypeConverter(typeof(IntRectConverter))]
    public Rect Rect
    {
        get
        {
            IROINodeData from = this.ROINodeData.GetFromNodeDatas().OfType<IROINodeData>().FirstOrDefault();
            return from == null ? Rect.Empty : from.ROI.Rect;
        }
    }

}

