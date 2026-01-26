using H.Controls.Form.PropertyItem.Attribute.SourcePropertyItem;
using H.Controls.Form.PropertyItem.ComboBoxPropertyItems;
using WH.WisdomVisionPro.NodeData.ResultImages;
using System.Text.Json.Serialization;

namespace WH.WisdomVisionPro.NodeData.Base;

public interface ISelectableResultImageNode<T> where T : IDisposable
{
    IVisionResultImage<T> SelectedResultImage { get; set; }
}

public abstract class SelectableResultImageNodeData<T> : ROINodeData<T>, ISelectableResultImageNode<T> where T : IDisposable
{
    private IVisionResultImage<T> _selectedResultImage;
    [JsonIgnore]
    [MethodNameSourcePropertyItem(typeof(ComboBoxPropertyItem), nameof(GetSelectableSrcNodeDatas))]
    [Display(Name = "输入图像源", GroupName = VisionPropertyGroupNames.BaseParameters, Order = -1)]
    public IVisionResultImage<T> SelectedResultImage
    {
        get { return _selectedResultImage; }
        set
        {
            _selectedResultImage = value;
            RaisePropertyChanged();
        }
    }

    public IEnumerable<IVisionResultImage<T>> GetSelectableSrcNodeDatas()
    {
        return this.AllFromNodeDatas.OfType<IVisionNodeData<T>>().SelectMany(x => x.ResultImages);
    }

}