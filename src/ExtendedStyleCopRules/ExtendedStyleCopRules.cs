using StyleCop;
using StyleCop.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedStyleCopRules
{
    [SourceAnalyzer(typeof(CsParser))]
    public class ExtendedStyleCopRules : SourceAnalyzer
    {
    }
}
