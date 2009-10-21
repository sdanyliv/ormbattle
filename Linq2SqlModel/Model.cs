using System;
using System.Data.Linq;

namespace Linq2SqlModel
{
	partial class NorthwindDataContext
	{
		public Table<ActiveProduct>       ActiveProducts       { get { return GetTable<ActiveProduct>();       } }
		public Table<DiscontinuedProduct> DiscontinuedProducts { get { return GetTable<DiscontinuedProduct>(); } }
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
