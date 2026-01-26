using H.Controls.Diagram.Presenter.Flowables;
using H.Controls.Diagram.Presenter.NodeDatas.Base;
using WH.WisdomVisionPro.NodeData.ResultImages;

namespace WH.WisdomVisionPro.NodeData.Base;

public interface IVisionNodeData : IFlowableNodeData, IResultPresenterNodeData, IResultImageSourceNodeData, IHelpNodeData
{
    bool UseInvokedPart { get; set; }
}

public interface IVideoCaptureNodeData : IVisionNodeData
{

}

public interface IVisionNodeData<T> : IVisionNodeData
{
    public List<IVisionResultImage<T>> ResultImages { get; }

    public T Mat { get; }
}
