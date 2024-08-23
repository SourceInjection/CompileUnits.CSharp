namespace CompileUnits.CSharp.Test.Members.Types.Delegate
{
    [TestFixture]
    internal class DelegateTests
    {
        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            Modifier.TypeTest<IDelegate>(code, propertyName, expectedValue);
        }

        [Test]
        public void DelegateIsCorrectlyLinkedAtNamespace()
        {
            var code = "delegate int Del();";
            TypeLinks.Test<IDelegate>(code, TypeKind.Delegate);
        }

        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.GenericTypeParameters))]
        public void TypeArgumentTest(string code, string expectedName, Variance expectedVariance)
        {
            TypeArgument.Test<IDelegate>(code, expectedName, expectedVariance, t => t.GenericTypeArguments[0]);
        }

        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.Parameters))]
        public void ParameterTest(string code, ParameterInfo[] parameters)
        {
            Parameters.Test<IDelegate>(code, parameters, t => t.Parameters);
        }

        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.ReturnTypes))]
        public void ReturnTypeTest(string code, string expectedType)
        {
            var result = CompileUnit.FromString(code).Types()
                .OfType<IDelegate>()
                .Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.ReturnType.FormatedText, Is.EqualTo(expectedType));
                TreeNodeAssert.LinksAreValid(result);
            });
        }

        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.Constraints))]
        public void ConstraintsTest(string code, string typeArgumentName)
        {
            var result = CompileUnit.FromString(code).Types()
                .OfType<IDelegate>()
                .Single().Constraints[0];

            Assert.Multiple(() =>
            {
                Assert.That(result.TargetedTypeArgument.Name, Is.EqualTo(typeArgumentName));
                Assert.That(result.Clauses, Is.Not.Empty);
                CollectionAssert.DoesNotContain(result.ChildNodes(), result.TargetedTypeArgument);
                TreeNodeAssert.LinksAreValid(result);
            });
        }
    }
}
