namespace CodeUnits.CSharp.Test.Types
{
    internal class Modifier
    {
        public static void Test<T>(string code, string propertyName, object expectedValue)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types().OfType<T>().Single();
            var value = sut!.GetType().GetProperty(propertyName)!.GetValue(sut);

            Assert.That(value, Is.EqualTo(expectedValue));
        }
    }
}
