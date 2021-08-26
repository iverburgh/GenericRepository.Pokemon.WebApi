using System.ComponentModel;

namespace Pokemon.Business.Interfaces
{
    public enum Species
    {
        Undefined = 0,
        Seed = 1,
        Lizard = 2,
        Flame = 3,
        [Description("Tiny Turtle")]
        TinyTurtle = 4,
        Turtle = 5,
        Shellfish = 6,
        Worm = 7,
    }
}
