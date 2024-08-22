namespace CodeUnits.CSharp.Test.Constraints
{
    [TestFixture]
    internal class ConstraintTests
    {
        [Test]
        [TestCaseSource(typeof(ConstraintResources), nameof(ConstraintResources.Constraints))]
        public void ConstraintClauseIsOfDesiredKind(string code, ConstraintKind expectedKind)
        {
            var iface = CodeUnit.FromString(code).Members.OfType<IInterface>().Single();

            var typeArg = iface.GenericTypeArguments.Single();
            var constraint = iface.Constraints.Single();

            Assert.Multiple(() =>
            {
                Assert.That(constraint.TargetedTypeArgument, Is.EqualTo(typeArg));
                Assert.That(constraint.Clauses.Single().Kind, Is.EqualTo(expectedKind));
            });
        }
    }
}
