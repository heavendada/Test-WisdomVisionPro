using H.Common.Attributes;
using H.Controls.ImageColorPicker;
using H.Extensions.FontIcon;
using H.Extensions.Mvvm.Commands;
using H.Mvvm.ViewModels.Base;
using H.Services.Message;
using System.Text.Json.Serialization;

namespace WH.WisdomVisionPro.NodeData;
public class ImageColorPickerPresenter : BindableBase
{
    private ImageSource _ImageSource;
    [Browsable(false)]
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

    private Color _Color = Colors.Green;
    public Color Color
    {
        get { return _Color; }
        set
        {
            _Color = value;
            RaisePropertyChanged();
        }
    }

    [Icon(FontIcons.Eyedropper)]
    [Display(Name = "吸管工具", GroupName = VisionPropertyGroupNames.RunParameters, Description = "从图片提取颜色设置HSV上下限")]
    public DisplayCommand ShowImagePickerCommand => new DisplayCommand(async e =>
    {
        if (this.ImageSource == null)
        {
            await IocMessage.ShowDialogMessage("请先连接图像源并运行节点");
            return;
        }
        ImageColorPickerBoxPresenter presenter = new ImageColorPickerBoxPresenter();
        presenter.ImageSource = this.ImageSource;
        bool? r = await IocMessage.ShowDialog(presenter);
        if (r != true)
            return;
        Color? color = presenter.Color;
        if (color == null)
            return;
        this.Color = presenter.Color.Value;
    });

}
