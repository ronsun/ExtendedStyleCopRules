using StyleCop;
using StyleCop.CSharp;
using System.Collections.Generic;

namespace ExtendedStyleCopRules.NamingRules
{
    [SourceAnalyzer(typeof(CsParser))]
    public class ExtendedNamingRules : SourceAnalyzer
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

            var typesContainFiled = new List<ElementType>()
            {
                ElementType.Class,
                ElementType.Namespace,
                ElementType.Root,
                ElementType.Struct
            };

            if (typesContainFiled.Contains(element.ElementType))
            {
                foreach (var child in element.ChildElements)
                {
                    CheckNamingRule(child);
                }
            }
        }
    }
}
