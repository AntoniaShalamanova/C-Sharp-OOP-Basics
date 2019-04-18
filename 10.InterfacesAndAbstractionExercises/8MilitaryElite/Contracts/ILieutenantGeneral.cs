using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; }
    }
}
