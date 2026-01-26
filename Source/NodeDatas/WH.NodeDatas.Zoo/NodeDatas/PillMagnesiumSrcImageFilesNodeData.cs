using H.Extensions.Common;
using WH.WisdomVisionPro.NodeData.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WH.NodeDatas.Zoo.NodeDatas;

[Display(Name = "药丸破裂数据源", GroupName = "数据源", Order = 0)]
public abstract class PillMagnesiumSrcImageFilesNodeData<T> : SrcFilesVisionNodeData<T>, IZooSrcImageFilesNodeData where T : IDisposable
{
    public override void LoadDefault()
    {
        base.LoadDefault();
        this.SrcFilePaths = this.SrcFilePaths.Where(x => x.Contains("pill_magnesium_crack")).ToObservable();
    }
}

