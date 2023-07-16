using System.ComponentModel;

namespace adstaskhub_api.Domain.Enums
{
    public enum StatusTask
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Concluído")]
        Concluido = 2,
        [Description("Atrasado")]
        Atrasado = 3
    }
}
