namespace CodeUnits.CSharp
{
    /// <summary>
    /// This interface represents arguments.<br/>
    /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters">Method parameters</see>.
    /// </summary>
    public interface IArgument
    {
        /// <summary>
        /// The expression which is passed to a e.g. method or constructor.
        /// </summary>
        ICodeFragment Expression { get; }

        /// <summary>
        /// If the argument targets a parameter this represents its name.<br/>
        /// This might be <see langword="null"/> since named arguments are optional.<br/>
        /// See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments">named and optional arguments</see>.
        /// </summary>
        string TargetedParameter { get; }
    }
}
