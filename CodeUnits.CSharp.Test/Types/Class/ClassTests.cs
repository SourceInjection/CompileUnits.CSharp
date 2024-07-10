using System.Collections;

namespace CodeUnits.CSharp.Test.Types.Class
{
    [TestFixture]
    internal class ClassTests
    {
        [Test]
        public void ClassIsCorrectlyLinkedAtNamespace()
        {
            var code = "class MyClass {}";
            TypeLinks.Test<IClass>(code, TypeKind.Class);
        }

        [Test]
        [TestCaseSource(typeof(ClassResources), nameof(ClassResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            Modifier.Test<IClass>(code, propertyName, expectedValue);
        }

        [Test]
        [TestCaseSource(typeof(ClassResources), nameof(ClassResources.CollectionConfigs))]
        public void CollectionHasElementTest(string code, string propertyName)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types().OfType<IClass>().Single();
            var value = sut.GetType().GetProperty(propertyName)!.GetValue(sut) as IEnumerable;

            CollectionAssert.IsNotEmpty(value);
        }
    }
}
