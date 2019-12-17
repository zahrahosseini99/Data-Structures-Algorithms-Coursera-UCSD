// Bloom filter: https://www.jasondavies.com/bloomfilter/
using System;
using System.Collections;
using System.Linq;
using TestCommon;


namespace A10
{
    public class Q4BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;

        public Q4BloomFilter(int filterSize, int hashFnCount)
        {
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];
            HashFunctions[0] = Hash1;
            HashFunctions[1] = Hash2;
            HashFunctions[2] = Hash3;
            HashFunctions[3] = Hash4;
        }


        public void Add(string str)
        {
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                Filter[HashFunctions[i](str)] = true;
            }
        }


        public bool Test(string str)
        {
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                if (Filter[HashFunctions[i](str)] == true)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public int Hash1(string str)
        {
            int hash = 7;
            for (int i = 0; i < str.Length; i++)
            {
                hash = hash * 31 + str[i];
            }
            return (hash % Filter.Length + Filter.Length) % Filter.Length;
        }
        public int Hash2(string str)
        {
            int hash = 0;
            char c;
            int x = 236;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                c = str[i];
                hash = ((hash * x + (int)c) % Filter.Length + Filter.Length) % Filter.Length;
            }
            return hash;
        }
        public int Hash3(string str)
        {
            int hash = 11;
            for (int i = 0; i < str.Length; i++)
            {
                hash = hash * 37 + str[i];
            }
            return (hash % Filter.Length + Filter.Length) % Filter.Length;
        }
        public int Hash4(string str)
        {
            int hash = 0;
            char c;
            int x = 543;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                c = str[i];
                hash = ((hash * x + (int)c) % Filter.Length + Filter.Length) % Filter.Length;
            }
            return hash;
        }
    }
}