using System.Collections;

namespace CodeUnits.CSharp.Test.Types.Struct
{
    internal class StructTests
    {
        [Test]
        public void StructIsCorrectlyLinkedAtNamespace()
        {
            var code = "struct MyStruct {}";
            TypeLinks.Test<IStruct>(code, TypeKind.Struct);
        }

        [Test]
        [TestCaseSource(typeof(StructResources), nameof(StructResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            Modifier.Test<IStruct>(code, propertyName, expectedValue);
        }

        [Test]
        [TestCaseSource(typeof(StructResources), nameof(StructResources.GenericTypeParameters))]
        public void TypeArgumentTest(string code, string expectedName, Variance expectedVariance)
        {
            TypeArgument.Test<IStruct>(code, expectedName, expectedVariance, t => t.GenericTypeArguments[0]);
        }

        [Test]
        [TestCaseSource(typeof(StructResources), nameof(StructResources.Inheritance))]
        public void InheritanceTest(string code, string[] expectedTypes)
        {
            var result = CodeUnit.FromString(code)
                .Types().OfType<IStruct>()
                .Single().Inheritance;

            Assert.Multiple(() =>
            {
                Assert.That(result, Has.Count.EqualTo(expectedTypes.Length));
                for (var i = 0; i < result.Count; i++)
                {
                    Assert.That(result[i].FormatedText, Is.EqualTo(expectedTypes[i]));
                    TreeNodeAssert.LinksAreValid(result[i]);
                }
            });
        }

        [Test]
        [TestCaseSource(typeof(StructResources), nameof(StructResources.CollectionConfigs))]
        public void CollectionHasElementTest(string code, string propertyName)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types().OfType<IStruct>().Single();
            var value = sut.GetType().GetProperty(propertyName)!.GetValue(sut) as IEnumerable;

            CollectionAssert.IsNotEmpty(value);
        }
    }
}
