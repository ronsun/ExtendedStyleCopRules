using StyleCop;
using StyleCop.CSharp;

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
                csdocument.WalkDocument(new CodeWalkerElementVisitor<object>(VisitElement));
            }
        }

        private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            ValidatePrivateFieldPrefix(element);

            return true;
        }

        private void ValidatePrivateFieldPrefix(CsElement element)
        {
            // not target element
            if (element.Generated ||
                element.ElementType != ElementType.Field ||
                element.AccessModifier != AccessModifierType.Private)
            {
                return;
            }

            if (!element.Declaration.Name.StartsWith("_"))
            {
                AddViolation(element, Rules.PrivateFieldNamesMustStartWithUnderscore);
            }
        }
    }
}
