// Copyright (c) HeBianGu Authors. All Rights Reserved. 
// Author: HeBianGu 
// Github: https://github.com/HeBianGu/WPF-Control 
// Document: https://hebiangu.github.io/WPF-Control-Docs  
// QQ:908293466 Group:971261058 
// bilibili: https://space.bilibili.com/370266611 
// Licensed under the MIT License (the "License")

global using WH.WisdomVisionPro.NodeGroup.Groups.Detector;
using OpenCvSharp;
using System.Windows;
using System.Windows.Shapes;
using WH.WisdomVisionPro.ResultPresenter;
using WH.WisdomVisionPro.ResultPresenter.ResultPresenters;

using CvPoint = OpenCvSharp.Point;

namespace WH.WisdomVisionPro.OpenCV.NodeDatas.Detector;

/// <summary>
/// 检测图像中的矩形并计算各边长度
/// </summary>
[Icon(FontIcons.LargeErase)]
[Display(Name = "矩形边长检测", GroupName = "基础检测", Order = 30, Description = "检测图像中的矩形并计算各边长度(基于轮廓检测+多边形逼近)")]
public class RectangleEdgeDetection : OpenCVDetectorNodeDataBase, IDetectorGroupableNodeData
{
    #region 参数属性

    /// <summary>
    /// 最小轮廓面积阈值
    /// </summary>
    private double _minContourArea = 1000;
    [Range(0.0, 100000.0)]
    [PropertyItem(typeof(DoubleSliderTextPropertyItem))]
    [DefaultValue(1000.0)]
    [Display(Name = "最小轮廓面积", GroupName = VisionPropertyGroupNames.RunParameters, Description = "轮廓的最小面积（像素），小于此值的轮廓将被过滤掉")]
    public double MinContourArea
    {
        get { return _minContourArea; }
        set
        {
            _minContourArea = value;
            RaisePropertyChanged();
            this.UpdateInvokeCurrent();
        }
    }

    /// <summary>
    /// 多边形近似精度参数
    /// </summary>
    private double _approxPolyDPParameter = 0.02;
    [Range(0.001, 0.1)]
    [PropertyItem(typeof(DoubleSliderTextPropertyItem))]
    [DefaultValue(0.02)]
    [Display(Name = "多边形近似精度", GroupName = VisionPropertyGroupNames.RunParameters, Description = "多边形逼近的精度参数，值越小精度越高但计算量越大，建议范围0.01-0.05")]
    public double ApproxPolyDPParameter
    {
        get { return _approxPolyDPParameter; }
        set
        {
            _approxPolyDPParameter = value;
            RaisePropertyChanged();
            this.UpdateInvokeCurrent();
        }
    }

    /// <summary>
    /// Canny边缘检测下阈值
    /// </summary>
    private int _cannyThreshold1 = 50;
    [Range(0, 255)]
    [PropertyItem(typeof(Int32SliderTextPropertyItem))]
    [DefaultValue(50)]
    [Display(Name = "Canny下阈值", GroupName = VisionPropertyGroupNames.RunParameters, Description = "Canny边缘检测的低阈值")]
    public int CannyThreshold1
    {
        get { return _cannyThreshold1; }
        set
        {
            _cannyThreshold1 = value;
            RaisePropertyChanged();
            this.UpdateInvokeCurrent();
        }
    }

    /// <summary>
    /// Canny边缘检测上阈值
    /// </summary>
    private int _cannyThreshold2 = 150;
    [Range(0, 255)]
    [PropertyItem(typeof(Int32SliderTextPropertyItem))]
    [DefaultValue(150)]
    [Display(Name = "Canny上阈值", GroupName = VisionPropertyGroupNames.RunParameters, Description = "Canny边缘检测的高阈值，通常为下阈值的2-3倍")]
    public int CannyThreshold2
    {
        get { return _cannyThreshold2; }
        set
        {
            _cannyThreshold2 = value;
            RaisePropertyChanged();
            this.UpdateInvokeCurrent();
        }
    }

    #endregion

    /// <summary>
    /// 执行矩形边长检测
    /// </summary>
    protected override FlowableResult<Mat> Invoke(ISrcVisionNodeData<Mat> srcImageNodeData, IVisionNodeData<Mat> from, IFlowableDiagramData diagram)
    {
        // 转换为灰度图
        using Mat gray = new Mat();
        Cv2.CvtColor(from.Mat, gray, ColorConversionCodes.BGR2GRAY);

        // 二值化
        Mat binary = new Mat();
        Cv2.Threshold(gray, binary, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);

        // Canny边缘检测
        using Mat edges = new Mat();
        Cv2.Canny(binary, edges, this.CannyThreshold1, this.CannyThreshold2);

        // 霍夫直线检测
        LineSegmentPoint[] lines = Cv2.HoughLinesP(edges, 1, Math.PI / 180, 80, 30, 10);

        // 找矩形候选（这里简单用凸包+长宽比过滤）
        CvPoint[] allPoints = new CvPoint[lines.Length * 2];

        // 找到的边
        var edgeLengths = new List<EdgeInfo>();

        int idx = 0;
        foreach (var line in lines)
        {
            allPoints[idx++] = line.P1;
            allPoints[idx++] = line.P2;  
        }

        // 取凸包
        OpenCvSharp.Point[] hull = Cv2.ConvexHull(allPoints);

        // 最小外接矩形
        RotatedRect rect = Cv2.MinAreaRect(hull);
        Point2f[] pts = rect.Points();

        // 准备输出图像
        Mat result = this.GetPrviewMat(srcImageNodeData, from.Mat, edges);

        // 画出矩形的四条边线
        for (int i = 0; i < 4; i++)
        {
            // 在结果图像上绘制边
            result.Line((int)pts[i].X, (int)pts[i].Y,(int)pts[(i+1)%4].X, (int)pts[(i+1)%4].Y, VisionSettings.Instance.OutputColor.ToScalar(), from.Mat.ToThickness(), LineTypes.AntiAlias);

            // 计算边长
            double length = Math.Sqrt(Math.Pow(pts[(i+1)%4].X - pts[i].X, 2) + Math.Pow(pts[(i+1)%4].Y - pts[i].Y, 2));

            /*
            // 像素转毫米
            double pixelToMM = 0.02; // todo
            double widthMM = rect.Size.Width * pixelToMM;
            double heightMM = rect.Size.Height * pixelToMM;
            */

            edgeLengths.Add(new EdgeInfo
            {
                EdgeIndex = idx / 2,
                StartPoint = new CvPoint((int)pts[i].X, (int)pts[i].Y).ToString(),
                EndPoint = new CvPoint((int)pts[(i+1)%4].X, (int)pts[(i+1)%4].Y).ToString(),
                Length = length
            });
        }
       
        

        // 存储检测到的矩形边长信息
        var rectangleEdges = new List<RectangleEdge>();

        if (edgeLengths.Count < 4)
        {
            MessageBox.Show("检测到不足4条边");  // todo
            // 更新匹配结果
            this.MatchingCountResult = 0;
        }
        else
        {
            rectangleEdges.Add(new RectangleEdge
            {
                Edges = edgeLengths,
                MinEdgeLength = edgeLengths.Min(e => e.Length),
                MaxEdgeLength = edgeLengths.Max(e => e.Length)
            });
            this.MatchingCountResult = 1;
        }

        // 创建结果展示器
        var resultPresenter = rectangleEdges.ToDataGridValueResultPresenter(
            x => $"最短边={x.MinEdgeLength:F2}, " +
                 $"最长边={x.MaxEdgeLength:F2}",
            x => "矩形边长数据");

        return this.OK(result, resultPresenter,
            $"检测到 {this.MatchingCountResult} 个矩形" +
            (rectangleEdges.Count > 0 ? $", 两边长分别为: {(int)rectangleEdges[0].MinEdgeLength},{(int)rectangleEdges[0].MaxEdgeLength}" : ""));
    }

    #region 辅助数据类

    /// <summary>
    /// 矩形边长信息
    /// </summary>
    public class RectangleEdge
    {
        
        
        public List<EdgeInfo> Edges { get; set; }
        
        public double MinEdgeLength { get; set; }
        public double MaxEdgeLength { get; set; }
    }

    /// <summary>
    /// 单条边的信息
    /// </summary>
    public class EdgeInfo
    {
        public int EdgeIndex { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public double Length { get; set; }
    }

    #endregion
}
