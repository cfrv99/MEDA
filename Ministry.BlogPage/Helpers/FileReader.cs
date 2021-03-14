using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Helpers
{
    public class FileReader
    {
        public static string ReadFileContentFromEmbeddedRecourse(string fileAddress)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = fileAddress;
            string result = string.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
