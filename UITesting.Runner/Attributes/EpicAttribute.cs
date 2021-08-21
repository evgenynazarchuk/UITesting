using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITesting.Runner.Attributes
{
    public class EpicAttribute : Attribute
    {
        public readonly string Description;

        public EpicAttribute(string description)
        {
            Description = description;
        }
    }
}
