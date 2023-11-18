using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Tools
{
    public class StringCreator
    {
        readonly StringWriter writer;

        public string NewLine { get => writer.NewLine; set => writer.NewLine = value; }

        public string Text => writer.ToString();

        public StringCreator() : this(CultureInfo.InvariantCulture)
        {
        }

        public StringCreator(CultureInfo cultureInfo)
        {
            writer = new StringWriter();
            NewLine = "\n";
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        #region Write

        public void Write(bool value)
        {
            Write(value ? '1' : '0');
        }

        public void Write(bool[] array)
        {
            WriteArray(array, Write);
        }

        public void Write(byte[] array)
        {
            WriteArray(array, WriteAsChar);
        }

        public void Write(char value)
        {
            writer.Write(value);
        }

        public void Write(object value)
        {
            Type type = value.GetType();
            if (type == typeof(char))
                Write((char)value);
            else if (type == typeof(bool))
                Write((bool)value);
            else
                writer.Write(value + " ");
        }

        public void Write(params object[] values)
        {
            foreach (object value in values)
                Write(value);
        }

        private void WriteArray<T>(T[] array, Action<T> action)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
                action(array[i]);
        }

        #endregion

        #region WriteAs

        public void WriteAsChar(byte value)
        {
            writer.Write((char)value);
        }

        public void WriteAsInt(params object[] values)
        {
            Array.ForEach(values, v => Write(Convert.ToInt32(v)));
        }

        public void WriteAsString(string value)
        {
            writer.Write("\"" + value + "\"");
        }

        public void WriteAsDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull where TValue : notnull
        {
            bool first = true;
            foreach (var pair in dictionary)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    Write(',');
                }
                WriteAsString(pair.Key.ToString()!);
                Write(':');
                WriteAsString(pair.Value.ToString()!);
            }
        }

        #endregion
    }
}
