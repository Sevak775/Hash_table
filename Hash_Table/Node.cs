using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    class Node
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Srname { get; set; }
        public int hash_value { get; set; }

        public Node(string name, string srname, int number)
        {
            Name = name;
            Srname = srname;
            Number = number;
            Key = name + " " + srname;
            Value = number;
        }
    }
}
