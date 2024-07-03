namespace CodeUnits.CSharp.Test.Namespaces
{
    [TestFixture]
    internal class NamespaceTests
    {
        [Test]
        public void ParsingEmptyString_DoesNotThrowAnyException()
        {
            Assert.DoesNotThrow(() => CodeUnit.FromString(""));
        }

        [Test]
        public void ACodeUnits_ParentNamespace_IsAlwaysNull()
        {
            var result = CodeUnit.FromString("");
            Assert.That(result.ContainingNamespace, Is.Null);
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1826:Do not use Enumerable methods on indexable collections", Justification = "<Pending>")]
        public void ParsingCode_WithOneNamespace_DoesReturnCodeUnitWithThisNamespace()
        {
            var nsName = "XY";
            var ns = $"namespace {nsName} {{ }}";

            var cu = CodeUnit.FromString(ns);
            var result = cu.Namespaces[0];

            Assert.Multiple(() =>
            {
                Assert.That(result.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(result.Name, Is.EqualTo(nsName));
            });
        }

        [Test]
        public void ParsingCode_WithStaticUsingDirective_DoesReturnCodeUnitWithStaticUsingDirective()
        {
            var ns = "XY.AB";
            var myClass = "MyClass";
            var code = $"using static {ns}.{myClass};";

            var cu = CodeUnit.FromString(code);
            var result = cu.UsingDirectives
                .OfType<IUsingStaticDirective>()
                .First();

            Assert.Multiple(() =>
            {
                Assert.That(result.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(result.Type.FormatedText, Is.EqualTo($"{ns}.{myClass}"));
                Assert.That(result.IsKind(UsingDirectiveKind.Static), Is.True);
            });
        }

        [Test]
        public void ParsingCode_WithUsingNamespaceDirective_DoesReturnCodeUnitWithUsingNamespaceDirective()
        {
            var ns = "XY.AB";
            var code = $"using {ns};";

            var cu = CodeUnit.FromString(code);
            var result = cu.UsingDirectives
                .OfType<IUsingNamespaceDirective>()
                .First();

            Assert.Multiple(() =>
            {
                Assert.That(result.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(result.Namespace, Is.EqualTo(ns));
                Assert.That(result.IsKind(UsingDirectiveKind.Namespace), Is.True);
            });
        }

        [Test]
        public void ParsingCode_WithUsingAliasDirective_DoesReturnCodeUnitWithUsingAliasDirective()
        {
            var ns = "XY.AB";
            var type = "Type";
            var code = $"using {type} = {ns}.{type};";

            var cu = CodeUnit.FromString(code);
            var result = cu.UsingDirectives
                .OfType<IUsingAliasDirective>()
                .First();

            Assert.Multiple(() =>
            {
                Assert.That(result.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(result.Type.FormatedText, Is.EqualTo($"{ns}.{type}"));
                Assert.That(result.Alias, Is.EqualTo(type));
                Assert.That(result.IsKind(UsingDirectiveKind.Alias), Is.True);
            });
        }

        [Test]
        public void ParsingCode_WithExternAliasDirective_DoesReturnCodeUnitWithExternAlias()
        {
            var aliasName = "XY";
            var code = $"extern alias {aliasName};";

            var cu = CodeUnit.FromString(code);
            var result = cu.ExternAliases[0];

            Assert.Multiple(() =>
            {
                Assert.That(result.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(result.Name, Is.EqualTo(aliasName));
            });
        }

        [Test]
        public void ParsingCode_WithEmptyClass_DoesReturnCodeUnitWithThisClass()
        {
            var type = "MyClass";
            var code = $"class {type} {{ }}";

            var cu = CodeUnit.FromString(code);
            var result = cu.Types[0];

            Assert.Multiple(() =>
            {
                Assert.That(result.ContainingNamespace, Is.EqualTo(cu));
                Assert.That(result.Name, Is.EqualTo(type));
                Assert.That(result.MemberKind, Is.EqualTo(MemberKind.Type));
                Assert.That(result.AccessModifier, Is.EqualTo(AccessModifier.None));
                Assert.That(result.HasNewModifier, Is.False);
                Assert.That(result.AttributeGroups, Is.Empty);
                Assert.That(result.HasNewModifier, Is.False);
            });
        }
    }
}
