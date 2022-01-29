using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlXsdHW
{
    [Serializable]
    public class Zoo
    {
        public Zoo()
        {
            animals = new List<Animals>();
        }
        public List<Animals> animals { get; set; }
    }
}
