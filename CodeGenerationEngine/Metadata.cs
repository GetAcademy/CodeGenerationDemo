using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerationEngine
{
    public class Metadata
    {
        public Entity[] entities { get; set; }
    }

    public class Entity
    {
        public string name { get; set; }
        public string template { get; set; }
    }


}
