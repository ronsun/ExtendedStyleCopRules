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
                csdocument.WalkDocument(new CodeWalkerElementVisitor<object>(VisitElement));
            }
        }

        private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            // not target element
            if (element.Generated ||
                element.ElementType != ElementType.Field ||
                element.AccessModifier != AccessModifierType.Private)
            {
                return true;
            }

            if (!element.Declaration.Name.StartsWith("_"))
            {
                AddViolation(element, Rules.PrivateFieldNamesMustStartWithUnderscore);
            }

            return true;
        }

        #region Sample for another way to write customer rules

        //public override void AnalyzeDocument(CodeDocument document)
        //{
        //    CsDocument csdocument = (CsDocument)document;

        //    if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
        //    {
        //        CheckNamingRule(csdocument.RootElement);
        //    }
        //}

        //private void CheckNamingRule(CsElement element)
        //{
        //    if (element.ElementType == ElementType.Field && element.AccessModifier == AccessModifierType.Private)
        //    {
        //        if (!element.Declaration.Name.StartsWith("_"))
        //        {
        //            AddViolation(element, Rules.PrivateFieldNamesMustStartWithUnderscore);
        //        }
        //    }

        //    foreach (var child in element.ChildElements)
        //    {
        //        CheckNamingRule(child);
        //    }
        //}

        #endregion
    }
}
