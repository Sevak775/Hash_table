using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    class Hash_Table_
    {
        public Node[] hash_table = new Node[50];

        public int Hash(string name, string srname, int number)
        {
            int cur_hash = 25;
            name = srname + number;

            foreach (var item in name.ToCharArray())
            {
                checked
                {
                    cur_hash = ((cur_hash << 2) + cur_hash / 8 - cur_hash / 2);
                    cur_hash /= 2;
                }
            }

            return cur_hash;
        }

        public void Add(string name, string surname, int number)
        {
            int hash = Hash(name, surname, number);
            int hash_node = hash;

            hash %= 10;

            if (hash == 0)
            {
                hash += 1;
            }


            if (hash_table[hash] == null)
            {
                Node n = new Node(name, surname, number);
                n.hash_value = hash_node;
                hash_table[hash] = n;
            }
            else
            {
                while (hash_table[hash] != null)
                {
                    try
                    {
                        hash += 1;
                        if (hash_table[hash] == null)
                        {
                            Node n = new Node(name, surname, number);
                            hash_table[hash] = n;
                            break;
                        }
                    }
                    catch
                    {
                        if (hash > hash_table.Length)
                        {
                            Node[] copy_table = new Node[hash_table.Length * 2];

                            for (int i = 0; i < hash_table.Length; i++)
                            {
                                copy_table[i] = hash_table[i];
                            }
                            hash_table = copy_table;

                            if (hash_table[hash] == null)
                            {
                                Node n = new Node(name, surname, number);
                                hash_table[hash] = n;

                            }

                        }
                        Console.WriteLine("Zangvac@ lcvec");
                    }


                }
            }


        }

        public Node Search(string key, int value)
        {
            int index = 0;
            for (int i = 0; i < hash_table.Length; i++)
            {
                if (hash_table[i] != null)
                {
                    if (hash_table[i].Key == key && hash_table[i].Value == value)
                    {
                        Console.WriteLine($"Key={hash_table[i].Key} Value={hash_table[i].Value}");
                        index = i;
                        break;
                    }
                }
            }
            if (index == 0 && hash_table[0] == null)
            {
                throw new Exception("nman element zangvacum chka");
            }


            return hash_table[index];
        }


    }
}
