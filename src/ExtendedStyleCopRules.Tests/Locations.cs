using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedStyleCopRules.Tests
{
    public class Locations
    {
        public static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string ValidationResultDirectory = Path.Combine(BaseDirectory, "ValidationResult");

        public static readonly string TestDataDirectory = Path.Combine(BaseDirectory, "TestData");

        public static readonly List<string> AddInDirectory = new List<string>()
        {
            BaseDirectory
        };
    }
}
