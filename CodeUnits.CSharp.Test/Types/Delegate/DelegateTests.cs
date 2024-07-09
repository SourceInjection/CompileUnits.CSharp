namespace CodeUnits.CSharp.Test.Types.Delegate
{
    [TestFixture]
    internal class DelegateTests
    {
        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.ModifierConfigs))]
        public void ModifierTest(string code, string propertyName, object expectedValue)
        {
            var sut = CodeUnit.FromString(code).Types().OfType<IDelegate>().Single();
            var value = sut.GetType().GetProperty(propertyName)!.GetValue(sut);

            Assert.That(value, Is.EqualTo(expectedValue));
        }


        private static void CommonTest(ICodeUnit cu, IDelegate sut)
        {
            Assert.Multiple(() =>
            {
                Assert.That(sut.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(sut.ContainingType, Is.Null);
                Assert.That(sut.TypeKind, Is.EqualTo(TypeKind.Delegate));
                TreeNodeAssert.LinksAreValid(sut);
            });
        }

        [Test]
        public void DelegateIsCorrectlyLinkedAtNamespace()
        {
            string code = "delegate int Del();";

            var cu = CodeUnit.FromString(code);
            var result = cu.Types().OfType<IDelegate>().Single();

            CommonTest(cu, result);
        }

        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.GenericTypeParameters))]
        public void TypeArgumentTest(string code, string expectedName, Variance expectedVariance)
        {
            var cu = CodeUnit.FromString(code);
            var del = cu.Types().OfType<IDelegate>().Single();
            var result = del.GenericTypeArguments[0];

            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(expectedName));
                Assert.That(result.Variance, Is.EqualTo(expectedVariance));
                TreeNodeAssert.LinksAreValid(result);
            });
        }

        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.Parameters))]
        public void ParameterTest(string code, ParameterInfo[] parameters)
        {
            var cu = CodeUnit.FromString(code);
            var result = cu.Types().OfType<IDelegate>().Single();

            Assert.Multiple(() =>
            {
                Assert.That(result.Parameters, Has.Count.EqualTo(parameters.Length));
                for (var i = 0; i < parameters.Length; i++)
                {
                    var expected = parameters[i];
                    var param = result.Parameters[i];

                    Assert.That(param.Type.FormatedText, Is.EqualTo(expected.Type));
                    Assert.That(param.Name, Is.EqualTo(expected.Name));
                    Assert.That(param.Modifier, Is.EqualTo(expected.Modifier));
                    TreeNodeAssert.LinksAreValid(param);
                }
            });
        }

        [Test]
        [TestCaseSource(typeof(DelegateResources), nameof(DelegateResources.ReturnTypes))]
        public void ReturnTypeTest(string code, string expectedType)
        {
            var result = CodeUnit.FromString(code).Types()
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
            var result = CodeUnit.FromString(code).Types()
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
