using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeChecklistInspector
{
    public static class ChecklistLoader
    {
        public static async Task<string> LoadFromUrlAsync(string url)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }

        public static string LoadFromFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new System.IO.FileNotFoundException("El archivo no existe.", filePath);
            }
            return System.IO.File.ReadAllText(filePath, Encoding.UTF8);
        }
    }
}
