using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    interface IConsumable : IItem
    {
        int Quantity { get; set; }

    }
}
