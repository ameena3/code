using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    //Application user list and userComputer relation class.
    class Relations
    {
       public List<string> applicationUsers;
       public  Dictionary<string, List<Computer>> userComputers { get; set; }
    }
}
