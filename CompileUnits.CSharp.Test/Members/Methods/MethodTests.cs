using CompileUnits.CSharp.Test.Members.Types;

namespace CompileUnits.CSharp.Test.Members.Methods
{
    [TestFixture]
    internal class MethodTests
    {
        private static IMethod GetSut(string code)
        {
            var cu = CompileUnit.FromString(code);
            return cu.Members.OfType<IClass>().Single().Members
                .OfType<IMethod>()
                .Single();
        }

        [Test]
        [TestCaseSource(typeof(MethodResources), nameof(MethodResources.MethodBodies))]
        public void MethodHasBody(string body)
        {
            var method = GetSut(Class.WithMember($"public int X() {body}"));

            Assert.That(method.Body, Is.Not.Null);
        }

        [Test]
        public void MethodHasGenericTypeArgument()
        {
            var argument = "T";
            var sut = GetSut(Class.WithMember($"void X<{argument}>();")).GenericTypeParameters.Single();

            Assert.That(sut.Name, Is.EqualTo(argument));

        }

        [Test]
        public void MethodHasAddressedInterface()
        {
            var method = GetSut(Class.WithMember("public int IFace<Z,Y>.X() { }"));

            Assert.That(method.AddressedInterface.FormatedText, Is.EqualTo("IFace<Z, Y>"));
        }

        [Test]
        [TestCaseSource(typeof(MethodResources), nameof(MethodResources.ModifierConfigs))]
        public void ModifierTest(string code, string methodName, object expectedValue)
        {
            Modifier.MemberTest<IMethod>(Class.WithMember(code), methodName, expectedValue);
        }

        [Test]
        [TestCaseSource(typeof(MethodResources), nameof(MethodResources.ReturnTypes))]
        public void ReturnTypeTest(string code, string expectedType)
        {
            var method = GetSut(Class.WithMember(code));

            Assert.Multiple(() =>
            {
                Assert.That(method.ReturnType.FormatedText, Is.EqualTo(expectedType));
                TreeNodeAssert.LinksAreValid(method);
            });
        }
    }
}
