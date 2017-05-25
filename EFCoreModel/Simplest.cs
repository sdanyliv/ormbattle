using System.ComponentModel.DataAnnotations.Schema;

namespace OrmBattle.EFCoreModel
{
    [Table("Simplests")]
    public partial class Simplest
    {
        public long Id { get; set; }
        public long Value { get; set; }
    }
}
