using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pokemon.Business.Interfaces
{
    public enum EggGroup
    {
        Undefined = 0,
        Monster = 1,
        Grass = 2,
        Dragon = 3,
        [Display(Name = "Water 1")]
        [Description("Water 1")]
        Water1 = 4,
        Bug = 5,
    }
}
