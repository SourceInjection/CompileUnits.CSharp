namespace CodeUnits.CSharp.Test.Types.Enum
{
    internal class EnumTests
    {
        [Test]
        public void EnumIsCorrectlyLinkedAtNamespace()
        {
            var code = "enum XY { X, Y };";
            TypeLinks.Test<IEnum>(code, TypeKind.Enum);
        }

        [Test]
        [TestCaseSource(typeof(EnumResources), nameof(EnumResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            Modifier.Test<IEnum>(code, propertyName, expectedValue);
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
        public void MembersTest()
        {
            var member1 = "X";
            var member2 = "Y";
            var code = $"enum XY {{{member1}, {member2}}}";

            var sut = CodeUnit.FromString(code).Types().OfType<IEnum>().Single();

            Assert.Multiple(() =>
            {
                Assert.That(sut.Members, Has.Count.EqualTo(2));
                Assert.That(sut.Members[0].Name, Is.EqualTo(member1));
                Assert.That(sut.Members[1].Name, Is.EqualTo(member2));

                TreeNodeAssert.LinksAreValid(sut.Members[0]);
                TreeNodeAssert.LinksAreValid(sut.Members[1]);
            });
        }

        [Test]
        public void MembersValueTest()
        {
            var value = 1;
            var code = $"enum XY {{X = {value}}}";

            var sut = CodeUnit.FromString(code).Types().OfType<IEnum>().Single().Members[0];

            Assert.That(sut.Value.Symbols[0].Value, Is.EqualTo(value.ToString()));
        }

        [Test]
        public void MembersAttributesTest()
        {
            var attribute = "MyAttribute";
            var code = $"enum XY {{ [{attribute}] X }}";

            var group = CodeUnit.FromString(code).Types()
                .OfType<IEnum>()
                .Single().Members[0].AttributeGroups[0];

            var sut = group.Attributes[0];

            Assert.Multiple(() =>
            {
                Assert.That(sut.Type.FormatedText, Is.EqualTo(attribute));
                TreeNodeAssert.LinksAreValid(group);
                TreeNodeAssert.LinksAreValid(sut);
            });
        }
    }
}
