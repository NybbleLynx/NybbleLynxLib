using System.Collections.Generic;
using NUnit.Framework;
using NybbleLynx.Lib.Core.Helpers;

namespace NybbleLynx.Lib.Core.Tests.Helpers
{
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void GivenANullObject_WhenGuardingAgainstNull_ThenExceptionIsThrown()
        {
            const string paramName = "invalidInstance";

            Assert.That(() => Guard.AgainstNull<object>(null!, paramName), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo(paramName));
        }

        [Test]
        public void GivenAValidObject_WhenGuardingAgainstNull_ThenNoExceptionIsThrown()
        {
            var testObject = new TestObject();

            Assert.That(() => Guard.AgainstNull(testObject, nameof(testObject)), Throws.Nothing);
        }

        [Test]
        public void GivenAValidObject_WhenGuardingAgainstNull_ThenReturnedObjectIsTheSame()
        {
            var testObject = new TestObject();

            var result = Guard.AgainstNull(testObject, nameof(testObject));

            Assert.That(result, Is.SameAs(testObject));
        }

        [TestCaseSource(nameof(NullOrEmptyStringCases))]
        public void GivenAnInvalidString_WhenGuardingAgainstNullAndEmpty_ThenExceptionIsThrown(string invalidValue, string parameterName)
        {
            Assert.That(() => Guard.AgainstNullAndEmpty(invalidValue, parameterName),
                Throws.ArgumentNullException.With.Property("ParamName")
                      .EqualTo(parameterName));
        }

        private static IEnumerable<TestCaseData> NullOrEmptyStringCases()
        {
            yield return new TestCaseData(null, "nullValue").SetName("GivenANullString_WhenGuardingAgainstNullAndEmpty_ThenExceptionIsThrown");
            yield return new TestCaseData("", "emptyValue").SetName("GivenAnEmptyString_WhenGuardingAgainstNullAndEmpty_ThenExceptionIsThrown");
            yield return new TestCaseData("         ", "whitespaceValue").SetName("GivenAWhitespaceString_WhenGuardingAgainstNullAndEmpty_ThenExceptionIsThrown");
        }

        [Test]
        public void GivenAValidString_WhenGuardingAgainstNullAndEmpty_ThenNoExceptionIsThrown()
        {
            const string paramName = "validString";

            Assert.That(() => Guard.AgainstNullAndEmpty("string value", paramName), Throws.Nothing);
        }

        #region Test Items

        private class TestObject
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
        }
            
        #endregion
    }
}