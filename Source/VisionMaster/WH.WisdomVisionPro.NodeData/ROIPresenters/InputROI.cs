using H.Extensions.TypeConverter;

namespace WH.WisdomVisionPro.NodeData.ROIPresenters;

[Display(Name = "输入")]
public class InputROI : ROIBase, IROI
{
    private Rect _rect;
    [TypeConverter(typeof(IntRectConverter))]
    public Rect Rect
    {
        get { return _rect; }
        set
        {
            _rect = value;
            RaisePropertyChanged();
        }
    }
}

