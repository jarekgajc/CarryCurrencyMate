using Common.Utils.Tools;

namespace Common.Utils
{
    public static class DictionaryUtils
    {
        public static Dictionary<TKey, TValue> FromString<TKey, TValue>(string s, Func<string, TKey> getKey, Func<string, TValue> getValue) where TKey : notnull
        {
            StringParser stringParser = new StringParser(s);
            Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
            bool first = true;
            while (!stringParser.IsEnd)
            {
                if (first)
                {
                    first = false;
                } else
                {
                    stringParser.SkipChar();
                }
                TKey key = getKey(stringParser.String);
                stringParser.SkipChar();
                TValue value = getValue(stringParser.String);

                dictionary.Add(key, value);
            }
            return dictionary;
        }

        public static string ToString<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull where TValue : notnull
        {
            StringCreator stringCreator = new StringCreator();
            bool first = true;
            foreach (var pair in dictionary)
            {
                if (first)
                {
                    first = false;
                } else
                {
                    stringCreator.Write(',');
                }
                stringCreator.WriteAsString(pair.Key.ToString()!);
                stringCreator.Write(':');
                stringCreator.WriteAsString(pair.Value.ToString()!);
            }

            return stringCreator.Text;
        }
    }
}
