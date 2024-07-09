namespace CodeUnits.CSharp.Test.Types.Enum
{
    internal class EnumTests
    {
        private static void CommonTest(ICodeUnit cu, IEnum sut)
        {
            Assert.Multiple(() =>
            {
                Assert.That(sut.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(sut.ContainingType, Is.Null);
                Assert.That(sut.TypeKind, Is.EqualTo(TypeKind.Enum));
                TreeNodeAssert.LinksAreValid(sut);
            });
        }

        [Test]
        public void EnumIsCorrectlyLinkedAtNamespace()
        {
            string code = "enum XY { X, Y };";

            var cu = CodeUnit.FromString(code);
            var result = cu.Types().OfType<IEnum>().Single();

            CommonTest(cu, result);
        }

        [Test]
        [TestCaseSource(typeof(EnumResources), nameof(EnumResources.BaseTypes))]
        public void BaseTypeTest(string code, string baseType)
        {
            var result = CodeUnit.FromString(code).Types()
                .OfType<IEnum>()
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.BaseType.FormatedText, Is.EqualTo(baseType));
                TreeNodeAssert.LinksAreValid(result);
            });
        }

        [Test]
        [TestCaseSource(typeof(EnumResources), nameof(EnumResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            var sut = CodeUnit.FromString(code).Types().OfType<IEnum>().Single();
            var value = sut.GetType().GetProperty(propertyName)!.GetValue(sut);

            Assert.That(value, Is.EqualTo(expectedValue));
        }
    }
}
