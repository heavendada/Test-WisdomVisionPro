using WH.WisdomVisionPro.NodeData.PropertyPresenters;

namespace WH.WisdomVisionPro.NodeData.Base;

public abstract class ShowPropertyNodeDataBase : VisionNodeDataBase
{
    public override object GetPropertyPresenter()
    {
        return new InvokeCommandsPropertyPresenter(this);
    }

}

