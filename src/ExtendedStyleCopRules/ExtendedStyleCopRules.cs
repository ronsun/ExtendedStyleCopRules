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
        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument csdocument = (CsDocument)document;

            if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
            {
                CheckNamingRule(csdocument.RootElement);
            }
        }

        private void CheckNamingRule(CsElement element)
        {
            if (element.ElementType == ElementType.Field && element.AccessModifier == AccessModifierType.Private)
            {
                if (!element.Declaration.Name.StartsWith("_"))
                {
                    AddViolation(element, Rules.PrivateFieldNamesMustStartWithUnderscore);
                }
            }

            foreach (var child in element.ChildElements)
            {
                CheckNamingRule(child);
            }
        }
    }
}
