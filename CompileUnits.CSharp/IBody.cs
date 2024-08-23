namespace CompileUnits.CSharp
{
    public enum BodyKind { Arrow, Block }

    public interface IBody : ICodeFragment
    {
        /// <summary>
        /// The kind of the body.
        /// </summary>
        BodyKind BodyKind { get; }
    }

    public static class IBodyExtensions
    {
        /// <summary>
        /// Checks if the body is of the desired kind.
        /// </summary>
        /// <param name="body">The body to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the body is of the desired kind else <see langword="false"/></returns>
        public static bool IsKind(this IBody body, BodyKind kind)
            => body.BodyKind == kind;
    }
}
