using System.ComponentModel;

namespace adstaskhub_api.Enums
{
    public enum Pronoun
    {
        [Description("Ele/dele")]
        Ele = 1,
        [Description("Ela/dela")]
        Ela = 2,
        [Description("Outro")]
        Outro = 3
    }
}
