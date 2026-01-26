using H.Extensions.TypeConverter;
using H.Mvvm.Commands;
using H.Services.Message;
using System.Text.Json.Serialization;

namespace WH.WisdomVisionPro.NodeData.ROIPresenters;

[Display(Name = "绘制")]
public class DrawROI : ROIBase, IROI
{
    private Rect _rect = Rect.Empty;
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

    private ImageSource _ImageSource;
    [JsonIgnore]
    public ImageSource ImageSource
    {
        get { return _ImageSource; }
        set
        {
            _ImageSource = value;
            RaisePropertyChanged();
        }
    }

    private bool _isFullScreen;
    [JsonIgnore]
    public bool IsFullScreen
    {
        get { return _isFullScreen; }
        set
        {
            _isFullScreen = value;
            RaisePropertyChanged();
        }
    }

    protected override void Loaded(object obj)
    {
        base.Loaded(obj);
    }

    public RelayCommand ResetCommand => new RelayCommand(x =>
    {
        this.Rect = Rect.Empty;
    });

    public RelayCommand ShowFullScreenCommand => new RelayCommand(async x =>
    {
        this.IsFullScreen = true;
        await IocMessage.Dialog.Show(this);
        this.IsFullScreen = false;
    });
}