using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedStyleCopRules.Tests.Models
{
    [XmlRoot("StyleCopViolations")]
    public class StyleCopViolations
    {
        [XmlElement("Violation")]
        public List<Violation> ViolationItems { get; set; }

        public class Violation
        {
            // Ignore properties which not key point for validation
            // (Section, Source and Vaule of the XML element)

            [XmlAttribute("LineNumber")]
            public string LineNumber { get; set; }

            [XmlAttribute("RuleNamespace")]
            public string RuleNamespace { get; set; }

            [XmlAttribute("Rule")]
            public string Rule { get; set; }

            [XmlAttribute("RuleId")]
            public string RuleId { get; set; }
        }
    }
}
