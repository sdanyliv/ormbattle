


using System;
using System.ComponentModel;
using System.Linq;

namespace OrmBattle.SubsonicModel.PerformanceTest
{
  /// <summary>
  /// A class which represents the Simplest table in the PerformanceTest Database.
  /// This class is queryable through PerformanceTestDB.Simplest 
  /// </summary>
  public partial class Simplest: INotifyPropertyChanging, INotifyPropertyChanged
  {
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
      
    public Simplest(){
      OnCreated();
    }
      
    #region Properties
      
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    
    private long _Id;
    public long Id { 
      get{
        return _Id;
      } 
      set{
        this.OnIdChanging(value);
          this.SendPropertyChanging();
          this._Id = value;
          this.SendPropertyChanged("Id");
          this.OnIdChanged();
        }
    }
    
    partial void OnValueChanging(long value);
    partial void OnValueChanged();
    
    private long _Value;
    public long Value { 
      get{
        return _Value;
      } 
      set{
        this.OnValueChanging(value);
          this.SendPropertyChanging();
          this._Value = value;
          this.SendPropertyChanged("Value");
          this.OnValueChanged();
        }
    }
    

    #endregion

    #region Foreign Keys
    #endregion


    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
    public event PropertyChangingEventHandler PropertyChanging;
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void SendPropertyChanging()
    {
        var handler = PropertyChanging;
        if (handler != null)
           handler(this, emptyChangingEventArgs);
    }

    protected virtual void SendPropertyChanged(String propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

  }
  
}