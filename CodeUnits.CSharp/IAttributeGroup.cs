using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents attribute groups.<br/>
    /// E.g.: [AttributeA(argA1), AttributeB(argB1, argB2), AttributeC] is a attribute group of 3 attributes.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/attribute-tutorial">attribute tutorial</see>
    /// and <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/attributes">language specification</see>.
    /// </summary>
    public interface IAttributeGroup
    {
        /// <summary>
        /// The target of an attribute group.<br/>
        /// This might be <see langword="null"/> since these are optional.<br/>
        /// E.g.: [type: MyCustomAttribute("whatever")] would have 'type' as <see cref="AttributeTarget"/>
        /// </summary>
        string AttributeTarget { get; }

        /// <summary>
        /// Lists all attributes within this attribute group.
        /// </summary>
        IReadOnlyList<IAttribute> Attributes { get; }
    }
}
