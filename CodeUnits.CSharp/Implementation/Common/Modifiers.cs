using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp.Implementation.Common
{
    internal static class Modifiers
    {
        private const string Static = "static";
        private const string Sealed = "sealed";
        private const string Abstract = "abstract";
        private const string Readonly = "readonly";
        private const string New = "new";
        private const string Virtual = "virtual";
        private const string Private = "private";
        private const string Protected = "protected";
        private const string Internal = "internal";
        private const string Public = "public";

        public static (AccessModifier AccessModifier, bool HasNewModifier, bool IsStatic, InheritanceModifier InheritanceModifier)
            OfEvent(IEnumerable<string> modifiers)
        {
            var overwritableModifiers = OfOverwriteable(modifiers);
            var hasStaticModifier = modifiers.Any(s => s == Static);

            return (overwritableModifiers.AccessModifier,
                overwritableModifiers.HasNewModifier,
                hasStaticModifier,
                overwritableModifiers.InheritanceModifier);
        }

        public static (AccessModifier AccessModifier, bool HasNewModifier, bool IsStatic, bool IsSealed, bool IsAbstract)
            OfClass(IEnumerable<string> modifiers)
        {
            var commonModifiers = OfAny(modifiers);
            var others = Seek(modifiers, Static, Sealed, Abstract);
            return (commonModifiers.AccessModifier, commonModifiers.HasNewModifier, others[Static], others[Sealed], others[Abstract]);
        }

        public static (AccessModifier AccessModifier, bool HasNewModifier, bool IsReadonly, bool IsStatic)
            OfField(IEnumerable<string> modifiers)
        {
            var commonModifiers = OfAny(modifiers);
            var others = Seek(modifiers, Static, Readonly);
            return (commonModifiers.AccessModifier, commonModifiers.HasNewModifier, others[Readonly], others[Static]);
        }

        public static (AccessModifier AccessModifier, bool HasNewModifier, bool IsReadonly)
            OfStruct(IEnumerable<string> modifiers)
        {
            var commonModifiers = OfAny(modifiers);
            var others = Seek(modifiers, Readonly);
            return (commonModifiers.AccessModifier, commonModifiers.HasNewModifier, others[Readonly]);
        }

        public static (AccessModifier AccessModifier, bool HasNewModifier)
            OfEnum(IEnumerable<string> modifiers) => OfAny(modifiers);

        public static (AccessModifier AccessModifier, bool HasNewModifier)
            OfDelegate(IEnumerable<string> modifiers) => OfAny(modifiers);

        public static (AccessModifier AccessModifier, bool HasNewModifier)
            OfInterface(IEnumerable<string> modifiers) => OfAny(modifiers);

        public static (AccessModifier AccessModifier, bool HasNewModifier)
            OfConstant(IEnumerable<string> modifier) => OfAny(modifier);

        public static (AccessModifier AccessModifier, bool HasNewModifier, InheritanceModifier InheritanceModifier)
            OfProperty(IEnumerable<string> modifiers) => OfOverwriteable(modifiers);

        public static (AccessModifier AccessModifier, bool HasNewModifier, InheritanceModifier InheritanceModifier)
            OfMethod(IEnumerable<string> modifiers) => OfOverwriteable(modifiers);

        public static (AccessModifier AccessModifier, bool HasNewModifier, InheritanceModifier InheritanceModifier)
            OfIndexer(IEnumerable<string> modifiers) => OfOverwriteable(modifiers);

        private static (AccessModifier AccessModifier, bool HasNewModifier, InheritanceModifier InheritanceModifier)
            OfOverwriteable(IEnumerable<string> modifiers)
        {
            var commonModifiers = OfAny(modifiers);
            var inheritanceModifiers = new HashSet<InheritanceModifier>();
            foreach (var modifier in modifiers)
                MayAddInheritanceModifier(inheritanceModifiers, modifier);
            return (commonModifiers.AccessModifier, commonModifiers.HasNewModifier, MergeInheritanceModifiers(inheritanceModifiers));
        }

        private static (AccessModifier AccessModifier, bool HasNewModifier)
            OfAny(IEnumerable<string> modifiers)
        {
            var hasNewModifier = modifiers.Any(s => s == New);
            return (Accessibility(modifiers), hasNewModifier);
        }

        public static AccessModifier Accessibility(IEnumerable<string> modifiers)
        {
            var accessModifiers = new HashSet<AccessModifier>();

            foreach (var modifier in modifiers)
                MayAddAccessModifier(accessModifiers, modifier);

            return MergeAccessModifiers(accessModifiers);
        }

        private static Dictionary<string, bool> Seek(IEnumerable<string> modifiers, params string[] modifierNames)
        {
            var result = modifierNames.ToDictionary(s => s, _ => false);
            foreach (var modifier in modifiers.Where(s => result.ContainsKey(s)))
                result[modifier] = true;
            return result;
        }

        private static void MayAddInheritanceModifier(HashSet<InheritanceModifier> inheritanceModifiers, string modifier)
        {
            if (modifier == Sealed)
                inheritanceModifiers.Add(InheritanceModifier.Sealed);
            else if (modifier == Abstract)
                inheritanceModifiers.Add(InheritanceModifier.Abstract);
            else if (modifier == Virtual)
                inheritanceModifiers.Add(InheritanceModifier.Virtual);
        }

        private static void MayAddAccessModifier(HashSet<AccessModifier> accessModifiers, string modifier)
        {
            if (modifier == Private)
                accessModifiers.Add(AccessModifier.Private);
            else if (modifier == Public)
                accessModifiers.Add(AccessModifier.Public);
            else if (modifier == Internal)
                accessModifiers.Add(AccessModifier.Internal);
            else if (modifier == Protected)
                accessModifiers.Add(AccessModifier.Protected);
        }

        private static InheritanceModifier MergeInheritanceModifiers(HashSet<InheritanceModifier> inheritanceModifiers)
        {
            if (inheritanceModifiers.Count == 0)
                return InheritanceModifier.None;
            if (inheritanceModifiers.Count == 1)
                return inheritanceModifiers.First();
            throw new ArgumentException(
                $"multiple definition of inheritance modifiers found in argument '{inheritanceModifiers}'");
        }

        private static AccessModifier MergeAccessModifiers(HashSet<AccessModifier> modifiers)
        {
            if (modifiers.Count == 0)
                return AccessModifier.None;
            if (modifiers.Count == 1)
                return modifiers.First();

            if (modifiers.Count == 2 && modifiers.Contains(AccessModifier.Protected))
            {
                if (modifiers.Contains(AccessModifier.Internal))
                    return AccessModifier.ProtectedInternal;
                if (modifiers.Contains(AccessModifier.Private))
                    return AccessModifier.PrivateProtected;
            }
            throw new ArgumentException($"argument {modifiers} length can not be greater than 2 and " +
                $"if length is 2 must contain private protected or protected internal.");
        }
    }
}
