using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeChecklistInspector
{
    public class ChecklistPanel : UserControl
    {
        private TextBox output;

        public ChecklistPanel()
        {
            output = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Text = "Aquí se mostrarán los resultados del checklist..."
            };

            this.Controls.Add(output);
        }

        public async Task RunChecklistAsync(string checklistUrl)
        {
            try
            {
                string diff = GitDiffService.GetModifiedLines();

                string checklistContent = await ChecklistLoader.LoadFromUrlAsync(checklistUrl);

                string results = await ChecklistProcessor.ProcessChecklist(checklistContent, diff);

                SetResults(results);
            }
            catch (Exception ex)
            {
                SetResults($"Error al ejecutar el checklist: {ex.Message}");
            }
        }
        public void SetResults(string results)
        {
            if (output.InvokeRequired)
            {
                output.Invoke(new Action(() => output.Text = results));
            }
            else
            {
                output.Text = results;
            }
        }
    }
}