using System.Collections;

namespace CodeUnits.CSharp.Test.Types.Class
{
    [TestFixture]
    internal class ClassTests
    {
        private static void CommonTest(ICodeUnit cu, IClass sut)
        {
            Assert.Multiple(() =>
            {
                Assert.That(sut.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(sut.ContainingType, Is.Null);
                Assert.That(sut.TypeKind, Is.EqualTo(TypeKind.Class));
            });
        }


        [Test]
        [TestCaseSource(typeof(ClassResources), nameof(ClassResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types().OfType<IClass>().Single();
            var value = sut.GetType().GetProperty(propertyName)?.GetValue(sut);

            Assert.Multiple(() =>
            {
                CommonTest(cu, sut);
                Assert.That(value, Is.EqualTo(expectedValue));
            });
        }

        [Test]
        [TestCaseSource(typeof(ClassResources), nameof(ClassResources.CollectionConfigs))]
        public void CollectionHasElementTest(string code, string propertyName)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types().OfType<IClass>().Single();
            var value = sut.GetType().GetProperty(propertyName)?.GetValue(sut) as IEnumerable;

            Assert.Multiple(() =>
            {
                CommonTest(cu, sut);
                CollectionAssert.IsNotEmpty(value);
            });
        }
    }
}
