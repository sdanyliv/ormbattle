using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Linq2SqlModel
{
	partial class NorthwindDataContext
	{
		public Table<ActiveProduct>       ActiveProducts       { get { return GetTable<ActiveProduct>();       } }
		public Table<DiscontinuedProduct> DiscontinuedProducts { get { return GetTable<DiscontinuedProduct>(); } }
	}

	[Table(Name="dbo.Products")]
	public partial class ActiveProduct
	{
	}

	[Table(Name="dbo.Products")]
	public partial class DiscontinuedProduct
	{
	}

	public abstract class ComparableEntity
	{
		public override bool Equals(object obj)
		{
			return obj != null && GetType() == obj.GetType() && GetKey().Equals(((ComparableEntity)obj).GetKey());
		}

		protected abstract object GetKey();

		public override int GetHashCode()
		{
			return GetKey().GetHashCode();
		}
	}

	//partial class Order : ComparableEntity
	//{
	//    protected override object GetKey()
	//    {
	//        return Id;
	//    }
	//}
}
