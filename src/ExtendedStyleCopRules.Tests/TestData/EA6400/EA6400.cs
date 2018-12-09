namespace ExtendedStyleCopRules.Tests.TestData.EA6400
{
    internal class EA6400_Internal
    {
        protected const int ProtectedAndInternalConstant = 0;
    }

    public class EA6400_Public
    {
        private const int PrivateConstant = 0;

        internal const int InternalConstant = 0;

        #region Violate Cases

        protected internal const int ProtectedInternalConstant = 0;

        protected const int ProtectedConstant = 0;

        public const int PublicConstant = 0;

        #endregion
    }
}
