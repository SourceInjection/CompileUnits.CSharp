namespace CompileUnits.CSharp.Test.Members
{
    internal static class Class
    {
        public static string WithMember(string memberDefinition)
        {
            return $"class MyClass {{ {memberDefinition} }}";
        }
    }
}
