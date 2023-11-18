using System.Globalization;

namespace Common.Utils.Tools
{
    public class StringParser
    {
        private readonly CultureInfo _cultureInfo;
        private readonly StringReader _reader;
        private readonly string _str;
        private readonly char _decimalNumberSeparator;

        public StringParser(string s) : this(s, CultureInfo.InvariantCulture)
        {
        }

        public StringParser(string s, CultureInfo cultureInfo)
        {
            _reader = new StringReader(s);
            _str = s;

            _decimalNumberSeparator = cultureInfo.NumberFormat.NumberDecimalSeparator[0];
            _cultureInfo = cultureInfo;
        }

        public string Text => _str;

        public string String
        {
            get
            {
                SkipChar();
                return GetSentence('\"');
            }
        }

        /// <summary>
        /// Doesn't skip '\n'
        /// </summary>
        /// <returns></returns>
        public char Char => (char)_reader.Read();
        public bool Bool => Char == '1';

        public byte Byte => (byte)Int;
        public int Int => IsMatching('-') ? -UInt : UInt;
        public int UInt
        {
            get
            {
                int result = 0;
                while (!IsEnd)
                {
                    char c = Char;
                    if (!char.IsNumber(c))
                        break;
                    result = result * 10 + (c - 48);
                }
                return result;
            }
        }
        public float Float
        {
            get
            {
                StringWriter result = new StringWriter();
                int multiplier = IsMatching('-') ? -1 : 1;
                bool decimals = false;
                while (!IsEnd)
                {
                    char c = Char;
                    if (!decimals && c == _decimalNumberSeparator)
                        decimals = true;
                    else if (c == 'E')
                    {
                        result.Write(c);
                        c = Char;
                    } else if (!char.IsNumber(c))
                        break;
                    result.Write(c);
                }
                string str = result.ToString();
                return str == string.Empty ? 0 : float.Parse(str, _cultureInfo) * multiplier;
            }
        }

        public string Paragraph => GetSentence('\t');
        public string Row => GetSentence('\n');

        public string GetTheRest()
        {
            return _reader.ReadToEnd();
        }

        public string GetTheRestOfLine()
        {
            return _reader.ReadLine();
        }

        public string GetSentence(char breakChar)
        {
            StringWriter writer = new StringWriter();
            while (!IsEnd)
            {
                char c = Char;
                if (c == breakChar)
                    break;
                writer.Write(c);
            }
            return writer.ToString();
        }

        public string GetSentenceToEnd(char start, char end)
        {
            int amount = 1;
            StringWriter writer = new StringWriter();
            while (!IsEnd)
            {
                char c = Char;
                if (c == start)
                    amount++;
                else if (c == end)
                    if (--amount == 0)
                        break;
                writer.Write(c);
            }
            return writer.ToString();
        }

        public string GetSentenceToLast(char breakChar)
        {
            int id = _str.LastIndexOf(breakChar);
            if (id < 0)
                return "";
            for (int i = 0; i <= id; i++)
                _reader.Read();
            return _str.Substring(0, id);
        }

        public string GetWord()
        {
            return GetSentence(' ');
        }

        public bool IsEnd => _reader.Peek() < 0;

        public void Skip(char breakChar)
        {
            while (!IsEnd && Char != breakChar) ;
        }

        public void SkipChar()
        {
            _reader.Read();
        }

        public void SkipToNumber()
        {
            while (!IsEnd)
            {
                int peek = _reader.Peek();
                if (char.IsNumber((char)peek))
                    return;
                else
                    SkipChar();
            }
        }

        public void SkipWhiteSpaces()
        {
            while (!IsEnd)
            {
                int peek = _reader.Peek();
                if (char.IsWhiteSpace((char)peek))
                    SkipChar();
                else
                    return;
            }
        }

        public void SkipToEnd(char start, char end)
        {
            int amount = 1;
            while (!IsEnd)
            {
                char c = Char;
                if (c == start)
                    amount++;
                else if (c == end)
                    if (--amount == 0)
                        break;
            }
        }

        public bool IsMatching(char c)
        {
            int peek = _reader.Peek();
            if (peek < 0)
                throw new DataEnd();
            if (c == peek)
            {
                SkipChar();
                return true;
            }
            return false;
        }


        public static int Count(string @string, char @char)
        {
            int result = 0;
            foreach (char character in @string)
            {
                if (character == @char)
                    result++;
            }
            return result;
        }

        class DataEnd : System.Exception
        {

        }

    }
}
