namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a generic type parameter definition.
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-type-parameters">generic type parameters</see>.
    /// </summary>
    public interface IGenericTypeParameter: IAttributeable
    {
        /// <summary>
        /// The name of the generic type parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The defined variance of the generic type parameter.
        /// </summary>
        Variance Variance { get; }
    }
}
