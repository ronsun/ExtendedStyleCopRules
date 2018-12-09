using System.Collections.Generic;
using System.Linq;
using ExtendedStyleCopRules.MaintainabilityRules;
using ExtendedStyleCopRules.Tests.Models;

namespace ExtendedStyleCopRules.Tests.NUnitTestCaseSources
{
    public class EA6400
    {
        public static object[] GetTestResources()
        {
            string checkId = "EA6400";
            List<string> lineNumbers = new List<string> { "16", "18", "20" };

            var violationItems = lineNumbers.Select(ln =>
                new StyleCopViolations.Violation
                {
                    LineNumber = ln,
                    RuleNamespace = typeof(ExtendedMaintainabilityRules).FullName,
                    Rule = Rules.ConstantMustRestrictedInAssembly.ToString(),
                    RuleId = checkId
                }
            ).ToList();

            var expectedValidationResult = new StyleCopViolations()
            {
                ViolationItems = violationItems
            };

            return new object[] { checkId, expectedValidationResult };
        }
    }
}
