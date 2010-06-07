using System;
using Devart.Data.Linq;

namespace LinqConnectModel
{
	partial class NorthwindDataContext
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
