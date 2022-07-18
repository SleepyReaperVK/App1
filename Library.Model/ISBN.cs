using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ISBN
    {
        private const int _prefix = 978;
        public static Dictionary<string, int> Countries { get; set; }
        public static Dictionary<string, int> Publishers { get; set; }

        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                if (!Countries.ContainsKey(value))
                    throw new IsbnException($"Country '{value}' is not recognized by ISBN");
                _country = value;
            }
        }

        private string _publisher;
        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                if (!Publishers.ContainsKey(value))
                    throw new IsbnException($"Publisher '{value}' is not recognized by ISBN");
                _publisher = value;
            }
        }
        public int SerialNumber { get; set; }

        public int Control { get { return (Countries[Country] + Publishers[Publisher] + SerialNumber) % 10; } }

        public override string ToString()
        {
            return $"{_prefix}-{Countries[Country].ToString("D3")}-{Publishers[Publisher].ToString("D3")}-{SerialNumber.ToString("D3")}-{Control}";
        }
    }

    public class IsbnException : Exception
    {
        public IsbnException(string message)
            : base(message) { }
    }
}
