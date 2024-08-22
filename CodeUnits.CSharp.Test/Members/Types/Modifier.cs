namespace CodeUnits.CSharp.Test.Members.Types
{
    internal class Modifier
    {
        public static void TypeTest<T>(string code, string propertyName, object expectedValue)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types().OfType<T>().Single();
            var value = sut!.GetType().GetProperty(propertyName)!.GetValue(sut);

            Assert.That(value, Is.EqualTo(expectedValue));
        }

        public static void MemberTest<T>(string code, string propertyName, object expectedValue)
        {
            var cu = CodeUnit.FromString(code);
            var sut = cu.Types().OfType<IStructuredType>().Single().Members.OfType<T>().Single();
            var value = sut!.GetType().GetProperty(propertyName)!.GetValue(sut);

            Assert.That(value, Is.EqualTo(expectedValue));
        }
    }
}
