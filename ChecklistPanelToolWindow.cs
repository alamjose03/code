using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CodeChecklistInspector
{
    [Guid("f1a7a5b3-abc1-4214-af0e-0000c0de0001")]
    public class ChecklistPanelToolWindow: ToolWindowPane
    {
        private ChecklistPanel panel;
        public ChecklistPanelToolWindow() : base(null)
        {
            this.Caption = "Code Checklist Inspector";
            panel = new ChecklistPanel();
            this.Content = panel;

            _ = panel.RunChecklistAsync("https://github.com/fernandoCab26/CheckList/blob/main/CheckListC%23.md");
        }
    }
}
