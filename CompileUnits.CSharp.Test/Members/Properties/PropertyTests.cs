using CompileUnits.CSharp.Test.Members.Types;

namespace CompileUnits.CSharp.Test.Members.Properties
{
    [TestFixture]
    internal class PropertyTests
    {
        private static IProperty GetSut(string code)
        {
            var cu = CompileUnit.FromString(code);
            return cu.Members.OfType<IClass>().Single().Members
                .OfType<IProperty>()
                .Single();
        }

        [Test]
        public void PropertyHasGetter()
        {
            var property = GetSut(Class.WithMember("public int X { get; }"));

            Assert.That(property.Getter, Is.Not.Null);
        }

        [Test]
        public void PropertyHasArrowGetter()
        {
            var property = GetSut(Class.WithMember("public int X { get => 3; }"));

            Assert.That(property.Getter, Is.Not.Null);
        }

        [Test]
        public void PropertyHasSetter()
        {
            var property = GetSut(Class.WithMember("public int X { set; }"));

            Assert.That(property.Setter, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(typeof(PropertyResources), nameof(PropertyResources.Initializers))]
        public void PropertyHasInitializer(string code)
        {
            var property = GetSut(Class.WithMember(code));

            Assert.That(property.Initialization, Is.Not.Null);
        }

        [Test]
        public void PropertyHasAddressedInterface()
        {
            var property = GetSut(Class.WithMember("public int IFace<Z,Y>.X { set; }"));

            Assert.That(property.AddressedInterface.FormatedText, Is.EqualTo("IFace<Z, Y>"));
        }

        [Test]
        [TestCaseSource(typeof(PropertyResources), nameof(PropertyResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            Modifier.MemberTest<IProperty>(Class.WithMember(code), propertyName, expectedValue);
        }

        [Test]
        [TestCaseSource(typeof(PropertyResources), nameof(PropertyResources.GetterModifiers))]
        public void PropertyHasExpectedGetterModifier(string code, AccessModifier expectedModifier)
        {
            var property = GetSut(Class.WithMember(code));

            Assert.That(property.Getter.AccessModifier, Is.EqualTo(expectedModifier));
        }

        [Test]
        [TestCaseSource(typeof(PropertyResources), nameof(PropertyResources.SetterModifiers))]
        public void PropertyHasExpectedSetterModifier(string code, AccessModifier expectedModifier)
        {
            var property = GetSut(Class.WithMember(code));

            Assert.That(property.Setter.AccessModifier, Is.EqualTo(expectedModifier));
        }

        [Test]
        [TestCaseSource(typeof(PropertyResources), nameof(PropertyResources.ReturnTypes))]
        public void ReturnTypeTest(string code, string expectedType)
        {
            var property = GetSut(Class.WithMember(code));

            Assert.Multiple(() =>
            {
                Assert.That(property.Type.FormatedText, Is.EqualTo(expectedType));
                TreeNodeAssert.LinksAreValid(property);
            });
        }
    }
}
