namespace WH.WisdomVisionPro.NodeData.ResultImages;

public class VisionResultImage<T> : VisionResultImageBase, IVisionResultImage<T>
{
    public T Image { get; set; }
}

