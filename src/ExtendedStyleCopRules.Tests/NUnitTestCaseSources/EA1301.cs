using System.Collections.Generic;
using ExtendedStyleCopRules.NamingRules;
using ExtendedStyleCopRules.Tests.Models;

namespace ExtendedStyleCopRules.Tests.NUnitTestCaseSources
{
    public class EA1301
    {
        public static object[] GetTestResources()
        {
            string checkId = "EA1301";
            var expectedValidationResult = new StyleCopViolations()
            {
                ViolationItems = new List<StyleCopViolations.Violation>()
                {
                   new StyleCopViolations.Violation()
                   {
                       LineNumber = "7",
                       RuleNamespace = typeof(ExtendedNamingRules).FullName,
                       Rule = Rules.PrivateFieldNamesMustStartWithUnderscore.ToString(),
                       RuleId = checkId
                   }
                }
            };
            return new object[] { checkId, expectedValidationResult };
        }
    }
}
