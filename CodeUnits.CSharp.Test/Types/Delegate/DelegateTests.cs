namespace CodeUnits.CSharp.Test.Types.Delegate
{
    [TestFixture]
    internal class DelegateTests
    {
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
        public void GenericTypeArgumentIsCorrectlyLinked(string code, string expectedName, Variance expectedVariance)
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
        public void ParameterTest(string code, (string, string, ParameterModifier)[] parameters)
        {
            var cu = CodeUnit.FromString(code);
            var result = cu.Types().OfType<IDelegate>().Single();
            

            Assert.Multiple(() =>
            {
                Assert.That(result.Parameters, Has.Count.EqualTo(parameters.Length));
                for(var i = 0; i < parameters.Length; i++)
                {
                    var param = result.Parameters[i];
                    Assert.That(param.Type.FormatedText, Is.EqualTo(parameters[i].Item1));
                    Assert.That(param.Name, Is.EqualTo(parameters[i].Item2));
                    Assert.That(param.Modifier, Is.EqualTo(parameters[i].Item3));
                    TreeNodeAssert.LinksAreValid(param);
                }
            });
        }
    }
}
