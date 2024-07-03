namespace CodeUnits.CSharp.Test.Types.Class
{
    [TestFixture]
    internal class ClassTests
    {
        [Test]
        [TestCaseSource(typeof(ClassResources), nameof(ClassResources.Configurations))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types.OfType<IClass>().Single();
            var value = sut.GetType().GetProperty(propertyName)?.GetValue(sut);

            Assert.Multiple(() =>
            {
                Assert.That(sut.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(sut.ContainingType, Is.Null);
                Assert.That(sut.TypeKind, Is.EqualTo(TypeKind.Class));
                Assert.That(value, Is.EqualTo(expectedValue));
            });
        }
    }
}
