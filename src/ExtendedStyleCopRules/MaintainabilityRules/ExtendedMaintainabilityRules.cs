using StyleCop;
using StyleCop.CSharp;

namespace ExtendedStyleCopRules.MaintainabilityRules
{
    [SourceAnalyzer(typeof(CsParser))]
    public class ExtendedMaintainabilityRules : SourceAnalyzer
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
            ValidateConstantAccessibility(element);

            return true;
        }

        private void ValidateConstantAccessibility(CsElement element)
        {
            // not target element
            if (element.Generated ||
                element.ElementType != ElementType.Field)
            {
                return;
            }

            // the ProtectedAndInternal case seems not applied to AccessModifier
            if (element.AccessModifier == AccessModifierType.Private ||
                element.AccessModifier == AccessModifierType.Internal ||
                element.ActualAccess == AccessModifierType.ProtectedAndInternal)
            {
                return;
            }

            AddViolation(element, Rules.ConstantMustRestrictedInAssembly);
        }
    }
}
