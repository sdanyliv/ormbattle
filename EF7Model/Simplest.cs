using System.ComponentModel.DataAnnotations.Schema;

namespace OrmBattle.EF7Model
{
    [Table("Simplests")]
    public partial class Simplest
    {
        public long Id { get; set; }
        public long Value { get; set; }
    }
}
