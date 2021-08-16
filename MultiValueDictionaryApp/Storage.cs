using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace MultiValueDictionaryApp
{
    public static class Storage
    {

        private static Dictionary<String, List<String>> dictionary;

        static Storage()
        {
            dictionary = new Dictionary<String, List<String>>(); 
        }

        public static List<string> Keys()
        {
            return dictionary.Keys.ToList();
        }

        public static List<string> Members(String key)
        {
            if (!dictionary.ContainsKey(key))
            {
                throw new KeyNotFoundException("ERROR, key does not exist.");
            }

            return dictionary.Where(d => d.Key.Contains(key)).SelectMany(v => v.Value).ToList();
        }
        
        public static void Add(String key, String value)
        {
            List<string> dictReturnValues = null;

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new List<string>());
            }

            if(dictionary.TryGetValue(key, out dictReturnValues))
            {
                if (dictReturnValues.Exists(v => v == value))
                {
                    throw new CustomException("ERROR, member already exists for key.");
                }

                dictReturnValues.Add(value);
            }
        }

        public static void Remove(String key, String value)
        {
            // throw notfound exception
            List<string> dictReturnValues = null;

            if (!dictionary.ContainsKey(key))
            {
                throw new KeyNotFoundException("ERROR, key does not exist.");
            }

            if (dictionary.TryGetValue(key, out dictReturnValues))
            {
                if (!dictReturnValues.Exists(v => v == value))
                {
                    throw new CustomException("ERROR,  member does not exist.");
                }

                dictReturnValues.Remove(value);

                // check for last value with the same key
                if(dictReturnValues.Count == 0)
                {
                    dictionary.Remove(key);
                }
            }

        }

        public static void RemoveAll(String key)
        {
            if (!dictionary.ContainsKey(key))
            {
                throw new KeyNotFoundException("ERROR, key does not exist.");
            }

            // Simple and Concise...
            // No need to find value, and empty value... simply removing the key does the job
            // Saves 0(n) space
            /*
             * In reference to
             * Removes all members for a key and removes the key from the dictionary.
             * */
            dictionary.Remove(key);
        }

        public static void Clear()
        {
            dictionary.Clear();
        }

        public static bool KeyExists(String key)
        {
            return dictionary.ContainsKey(key);
        }

        public static bool MemberExists(String key, String member)
        {
            List<string> dictReturnValues = null;

            if (!dictionary.ContainsKey(key))
            {
                return false;
            }

            if (dictionary.TryGetValue(key, out dictReturnValues))
            {
                if (dictReturnValues.Exists(v => v == member))
                {
                    return true;
                }
            }

            return false;
        }

        public static List<string> AllMembers()
        {
            return dictionary.SelectMany(d => d.Value).ToList();
        }

        public static List<String> Items()
        {
            // lets do it old school
            // this O(n^2) can definitely be optimized
            // TODO: remove inner for loop
            List<String> returnOutput = new List<string>();

            foreach(KeyValuePair<string, List<String>> item in dictionary)
            {
                foreach(String listItem in item.Value)
                {
                    returnOutput.Add(item.Key + ": " + listItem);
                }
            }


            return returnOutput;
        }

    }
}
