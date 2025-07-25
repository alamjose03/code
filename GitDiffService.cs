using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChecklistInspector
{
    public static class GitDiffService
    {
        public static string GetModifiedLines()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "diff --unified=0",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = Process.Start(startInfo);
            return process != null ? process.StandardOutput.ReadToEnd() : string.Empty;

        }
    }
}
