using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChecklistInspector
{
    public static class ChecklistProcessor
    {
        public static async Task<string> ProcessChecklist(string checklistContent, string diff)
        {
            var prompt = $"Usa el siguiente checklist para revisar el código modificado. Indica los puntos que no se cumplen y cómo corregirlos.\n\nChecklist:\n{checklistContent}\n\nCódigo modificado:\n{diff}";

            var response = await LLMClient.SendPrompt(prompt);
            return response;
        }
    }
}
