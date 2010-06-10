using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace LightSpeedModel
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [Table("Simplests", IdColumnName="Id")]
  [System.ComponentModel.DataObject]
  public partial class Simplest : Entity<long>
  {
    #region Fields
  
    private long _value;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Value entity attribute.</summary>
    public const string ValueField = "Value";


    #endregion
    
    #region Properties



    public long Value
    {
      get { return Get(ref _value, "Value"); }
      set { Set(ref _value, value, "Value"); }
    }

    #endregion
  }


  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class PerformanceTestUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public PerformanceTestUnitOfWork()
    {
    }
    

    public System.Linq.IQueryable<Simplest> Simplests
    {
      get { return this.Query<Simplest>(); }
    }
    
  }

}
