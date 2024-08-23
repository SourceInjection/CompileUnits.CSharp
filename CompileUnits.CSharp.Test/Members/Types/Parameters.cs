namespace CompileUnits.CSharp.Test.Members.Types
{
    internal class Parameters
    {
        public static void Test<T>(string code, ParameterInfo[] expectedParameters, Func<T, IReadOnlyList<IParameter>> getParameters) where T : ITreeNode
        {
            var cu = CompileUnit.FromString(code);
            var result = getParameters(cu.Types().OfType<T>().Single());

            Assert.Multiple(() =>
            {
                Assert.That(result, Has.Count.EqualTo(expectedParameters.Length));
                for (var i = 0; i < expectedParameters.Length; i++)
                {
                    var expected = expectedParameters[i];
                    var param = result[i];

                    Assert.That(param.Type.FormatedText, Is.EqualTo(expected.Type));
                    Assert.That(param.Name, Is.EqualTo(expected.Name));
                    Assert.That(param.Modifier, Is.EqualTo(expected.Modifier));
                    TreeNodeAssert.LinksAreValid(param);
                }
            });
        }
    }
}
