namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a parameter definition.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters">method parameters</see>.
    /// </summary>
    public interface IParameter : IAttributeable
    {
        /// <summary>
        /// The type of the parameter.
        /// </summary>
        ITypeUsage Type { get; }

        /// <summary>
        /// The name of the parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The modifier of the parameter.
        /// </summary>
        ParameterModifier Modifier { get; }

        /// <summary>
        /// The default value of the parameter.
        /// This might be <see langword="null"/> since declaring a default value is optional.
        /// </summary>
        ICodeFragment DefaultValue { get; }

        /// <summary>
        /// If the parameter has the <see langword="params"/> keyword followed by brackets ('[]') this is <see langword="true"/>.
        /// </summary>
        bool IsParamsArray { get; }
    }

    public static class IParameterExtensions
    {
        /// <summary>
        /// If the parameter has a defined default value it is optional and this is <see langword="true"/>.
        /// </summary>
        /// <param name="parameter">The parameter to be checked.</param>
        /// <returns><see langword="true"/> if the parameter is optional else <see langword="false"/>.</returns>
        public static bool IsOptional(this IParameter parameter) => parameter.DefaultValue != null;
    }
}
