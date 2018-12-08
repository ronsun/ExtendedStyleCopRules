﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ExtendedStyleCopRules.Tests.Models;
using FluentAssertions;
using NUnit.Framework;
using StyleCop;

namespace ExtendedStyleCopRules.Tests
{
    [TestFixture()]
    public class ExtendedStyleCopRulesTests
    {
        [TestCaseSource(nameof(TestCase_RuleTest))]
        public void RuleTest(string checkId, StyleCopViolations expectedValidationResult)
        {
            // arrange
            Directory.CreateDirectory(Locations.ValidationResultDirectory);
            string validationResultPath = Path.Combine(Locations.ValidationResultDirectory, $"{checkId}.xml");

            string ruleSettingPath = Path.Combine(Locations.TestDataDirectory, checkId, $"{checkId}.StyleCop");
            string codePath = Path.Combine(Locations.TestDataDirectory, checkId, $"{checkId}.cs");

            StyleCopConsole console = new StyleCopConsole(
                ruleSettingPath,
                false,
                validationResultPath,
                Locations.AddInDirectory,
                false,
                Locations.BaseDirectory);

            CodeProject project = new CodeProject(
                checkId.GetHashCode(),
                Locations.BaseDirectory,
                new Configuration(null),
                0);

            console.Core.Environment.AddSourceCode(project, codePath, null);

            // act
            console.Start(new CodeProject[] { project }, true);

            StyleCopViolations actualValidationResult;
            using (Stream s = new FileStream(validationResultPath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(StyleCopViolations));
                actualValidationResult = (StyleCopViolations)serializer.Deserialize(s);
            }

            // assert
            bool testDataExist = File.Exists(ruleSettingPath) && File.Exists(codePath);
            testDataExist.Should().BeTrue();
            actualValidationResult.ViolationItems.Should().BeEquivalentTo(expectedValidationResult.ViolationItems);
        }

        private static List<object[]> TestCase_RuleTest()
        {
            var expectedValidationResult = new StyleCopViolations() { };
            return new List<object[]>()
            {
                EA1301TestResource()
            };
        }

        private static object[] EA1301TestResource()
        {
            string checkId = "EA1301";
            var expectedValidationResult = new StyleCopViolations()
            {
                ViolationItems = new List<StyleCopViolations.Violation>()
                {
                   new StyleCopViolations.Violation()
                   {
                       LineNumber = "7",
                       RuleNamespace = "ExtendedStyleCopRules.NamingRules.ExtendedNamingRules",
                       Rule = Rules.PrivateFieldNamesMustStartWithUnderscore.ToString(),
                       RuleId = checkId
                   }
                }
            };
            return new object[] { checkId, expectedValidationResult };
        }
    }
}