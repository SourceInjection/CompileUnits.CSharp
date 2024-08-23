namespace CompileUnits.CSharp.Test.Constraints
{
    internal class ConstraintResources
    {
        private static string InterfaceWithConstraint(string constraint)
        {
            return $"interface MyInterface<T> where T : {constraint} {{ }}";
        }

        public static object[] Constraints =
        {
            new object[] { InterfaceWithConstraint("new()"), ConstraintKind.Constructor },
            new object[] { InterfaceWithConstraint("struct"), ConstraintKind.Struct },
            new object[] { InterfaceWithConstraint("class"), ConstraintKind.Class },
            new object[] { InterfaceWithConstraint("class?"), ConstraintKind.ClassNullable },
            new object[] { InterfaceWithConstraint("notnull"), ConstraintKind.NotNull },
            new object[] { InterfaceWithConstraint("unmanaged"), ConstraintKind.Unmanaged },
            new object[] { InterfaceWithConstraint("MyClass"), ConstraintKind.OfType },
            new object[] { InterfaceWithConstraint("default"), ConstraintKind.Default },
        };
    }
}
