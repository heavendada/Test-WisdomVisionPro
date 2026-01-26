using H.Extensions.Common;
using WH.WisdomVisionPro.NodeData.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WH.NodeDatas.Zoo.NodeDatas;

[Display(Name = "车门图像源", GroupName = "数据源", Order = 0)]
public abstract class CardoorSrcImageFilesNodeData<T> : SrcFilesVisionNodeData<T>, IZooSrcImageFilesNodeData where T : IDisposable
{
    public override void LoadDefault()
    {
        base.LoadDefault();
        this.SrcFilePaths = this.SrcFilePaths.Where(x => x.Contains("car_door")).ToObservable();
    }
}

