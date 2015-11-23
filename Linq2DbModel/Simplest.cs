using LinqToDB.Mapping;

namespace OrmBattle.Linq2DbModel
{
	public class Simplests
	{
		[PrimaryKey] public long Id;
		             public long Value;
	}
}
