


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace OrmBattle.SubsonicModel.PerformanceTest {
	
        /// <summary>
        /// Table: Simplests
        /// Primary Key: Id
        /// </summary>

        public class SimplestsTable: DatabaseTable {
            
            public SimplestsTable(IDataProvider provider):base("Simplests",provider){
                ClassName = "Simplest";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Value", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
            				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
           
            public IColumn Value{
                get{
                    return this.GetColumn("Value");
                }
            }
            				
   			public static string ValueColumn{
			      get{
        			return "Value";
      			}
		    }
           
                    
        }
        
}