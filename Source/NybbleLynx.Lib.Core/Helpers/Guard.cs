using System;

namespace NybbleLynx.Lib.Core.Helpers
{
    /// <summary>
    /// Static class with helper method to check null or invalid arguments in constructors or methods.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Checks an object instance against null. If it is null then an <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        /// <param name="obj">The object to check against null.</param>
        /// <param name="parameterName">The parameter name to use in the exception message,</param>
        /// <exception cref="ArgumentNullException"/>
        public static TObject AgainstNull<TObject>([ValidatedNotNull]TObject obj, string parameterName) 
            => obj != null ? obj : throw new ArgumentNullException(parameterName);

        /// <summary>
        /// Checks an object instance against null. If it is null then an <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        /// <param name="value">The string value to check against null or whitespace.</param>
        /// <param name="parameterName">The parameter name to use in the exception message,</param>
        /// <exception cref="ArgumentNullException"/>
        public static void AgainstNullAndEmpty([ValidatedNotNull]string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(parameterName));
            }
        }
    }
}