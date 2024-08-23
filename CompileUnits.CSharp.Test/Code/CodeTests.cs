namespace CompileUnits.CSharp.Test.Code
{
    [TestFixture]
    internal class CodeTests
    {
        private static string ClassWithMethodWithCode(string code)
        {
            return $"class MyClass {{ void DoStuff() {{ {code} }} }}";
        }

        [Test]
        [TestCaseSource(typeof(CodeResources), nameof(CodeResources.ExampleStrings))]
        public void ParsingDifferentStatements_DoesReturnAValidResult(string code)
        {
            var method = CompileUnit.FromString(ClassWithMethodWithCode(code))
                .Members.OfType<IClass>().Single()
                .Members.OfType<IMethod>().Single();

            Assert.That(method, Is.Not.Null);
        }
    }
}
