#nullable enable
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CVNetCoreTests
{
    public static class Extensions
    {
        #region Methods

        public static Stream GetEmbeddedResourceStream(this Assembly assembly, string relativeResourcePath)
        {
            if (string.IsNullOrEmpty(relativeResourcePath))
            {
                throw new ArgumentNullException("relativeResourcePath");
            }

            var auxList = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            string resourcePath =
                $"{Regex.Replace(assembly.ManifestModule.Name, @"\.(exe|dll)$", string.Empty, RegexOptions.IgnoreCase)}.TestData.{relativeResourcePath}";

            Stream? stream = assembly.GetManifestResourceStream(resourcePath);
            if (stream == null)
            {
                throw new ArgumentException(
                    $"The specified embedded resource \"{relativeResourcePath}\" is not found.");
            }

            return stream;
        }

        #endregion
    }
}