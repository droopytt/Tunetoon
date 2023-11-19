using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tunetoon.Accounts;
using Tunetoon.Login;

namespace Tunetoon.Game
{
    public class RewrittenGameHandler : GameHandlerBase<RewrittenAccount>
    {
        private const string TargetLogMessage = "Using gameServer from launcher";
        private const int MaximumWaitTimeInSeconds = 30;
        private readonly Config config;
        private int borderOffset = -1;

        public RewrittenGameHandler(Config config)
        {
            this.config = config;
        }

        public override void SetupBaseEnvVariables(ILoginResult result, Process gameProcess)
        {
            gameProcess.StartInfo.EnvironmentVariables["TTR_GAMESERVER"] = result.GameServer;
            gameProcess.StartInfo.EnvironmentVariables["TTR_PLAYCOOKIE"] = result.Cookie;
        }

        public override void StartGame(RewrittenAccount account)
        {
            if (account.LoggedIn)
            {
                var gameProcess = new Process();
                SetupBaseEnvVariables(account.LoginResult, gameProcess);
                gameProcess.StartInfo.RedirectStandardOutput = true;
                StartGame(account, gameProcess, config.RewrittenPath, "TTREngine64.exe");
            }
        }

        protected override void PerformPostLoginOverrides(List<RewrittenAccount> accountList)
        {
                Task.Run(() => {
                    var activeProcesses = accountList.Select(account => ActiveProcesses[account]).ToList();

                    var loadedProcesses = AwaitWindowsReady(activeProcesses).ToList();

                    if (loadedProcesses.Count > 2)
                    {
                        var targetWindowRects = CreateTargetWindowRectsFromProcesses(loadedProcesses);
                        ResizeWindowsAndSendKey(accountList, targetWindowRects);
                    }
                });
        }
        private List<WindowRect> CreateTargetWindowRectsFromProcesses(List<Process> loadedProcesses)
        {
            // TODO hack fix this
            if (borderOffset == -1)
            {
                borderOffset = CalculateBorderOffset(loadedProcesses.First());
            }
            var targetWindowRects = CreateTargetWindowRects(loadedProcesses.Count, borderOffset);
            return targetWindowRects;
        }

        private void ResizeWindowsAndSendKey(List<RewrittenAccount> accountList, List<WindowRect> targetWindowRects)
        {
            var loggedInWindowPointers = ResizeWindows(accountList, targetWindowRects);
            Console.WriteLine("Sending keypress to windows");
            SendKeyToAllWindows(loggedInWindowPointers);
        }
        private static void SendKeyToAllWindows(List<IntPtr> loggedInWindowPointers)
        {
            foreach (var windowPointer in loggedInWindowPointers)
            {
                WindowUtils.SendKeyToWindow(windowPointer);
            }
        }
        private List<IntPtr> ResizeWindows(List<RewrittenAccount> accountList, List<WindowRect> targetWindowRects)
        {
            var loggedInWindowPointers = new BlockingCollection<IntPtr>();
            var tasks = new List<Task>();
            
            for (var i = 0; i < accountList.Count; i++)
            {
                var account = accountList[i];
                var targetPos = targetWindowRects[i % targetWindowRects.Count];
                var windowPointer = ActiveProcesses[account].MainWindowHandle;
                var task = Task.Run(() => {
                    var beforeSize = GetWindowRectangleString(windowPointer);
                    WindowUtils.Resize(windowPointer, targetPos.X, targetPos.Y, targetPos.Width, targetPos.Height);
                    var afterSize = GetWindowRectangleString(windowPointer);
                    Console.WriteLine("Before resize: " + beforeSize + " - After resize: " + afterSize);
                    Console.WriteLine(WindowUtils.GetWindowRectangle(windowPointer));
                    loggedInWindowPointers.Add(windowPointer);
                });
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            return loggedInWindowPointers.ToList();
        }
        private static BlockingCollection<Process> AwaitWindowsReady(List<Process> activeProcesses)
        {
            var loadedProcesses = new BlockingCollection<Process>();
            foreach (var process in activeProcesses)
            {
                process.OutputDataReceived += (sender, args) => {
                    if (args.Data != null && args.Data.Contains(TargetLogMessage))
                    {
                        var finishedProcess = ((Process)sender);
                        Console.WriteLine("Process " + finishedProcess.Id + " is loaded");
                        loadedProcesses.Add(finishedProcess);
                    }
                };
                process.BeginOutputReadLine();
            }

            var startTime = DateTime.Now;
            var maxWaitTime = startTime.AddSeconds(MaximumWaitTimeInSeconds);
            while (true)
            {
                if (loadedProcesses.Count == activeProcesses.Count)
                {
                    break;
                }

                if (DateTime.Now >= maxWaitTime)
                {
                    break;
                }
            }

            foreach (var activeProcess in activeProcesses)
            {
                activeProcess.CancelOutputRead();
            }
            return loadedProcesses;
        }
        
        private List<WindowRect> CreateTargetWindowRects(int numWindows, int offset)
        {
            if (numWindows % 2 != 0)
            {
                numWindows++;
            }

            var windowRects = new List<WindowRect>();
            if (Screen.PrimaryScreen == null)
            {
                throw new Exception("No primary screen found");
            }
            var screenRect = Screen.PrimaryScreen.WorkingArea;
            int width = (screenRect.Width / (numWindows / 2)) + (offset * 2);
            int height = (screenRect.Height / 2) + (offset);
            int startX = screenRect.X;
            int startY = screenRect.Y;
            int incrementX = screenRect.Width / (numWindows / 2);
            int incrementY = screenRect.Height / 2;

            for (int i = 0; i < numWindows / 2; i++)
            {
                windowRects.Add(new WindowRect(startX + (i * incrementX) - offset, startY, width, height));
            }

            for (int i = 0; i < numWindows / 2; i++)
            {
                windowRects.Add(new WindowRect(startX + (i * incrementX) - offset, incrementY, width, height));
            }

            if (windowRects.Count % 4 != 0 || config.OpenAccountsInRows)
            {
                return windowRects;
            }

            return GroupIntoFours(numWindows, windowRects);
        }
        
        private static List<WindowRect> GroupIntoFours(int numWindows, List<WindowRect> windowRects)
        {

            var groupedRects = windowRects.Select((i, index) => new
                {
                    i,
                    index
                }).GroupBy(group => group.index / 2, element => element.i)
                .ToList();

            int numPartitions = numWindows / 4;
            var partitions = new List<List<WindowRect>>();
            for (int i = 0; i < numPartitions; i++)
            {
                partitions.Add(new List<WindowRect>());
            }

            for (int i = 0; i < groupedRects.Count; i++)
            {
                var groupedRect = groupedRects[i];
                AddToPartition(partitions[i % numPartitions], groupedRect);
            }

            return partitions.SelectMany(i => i).ToList();
        }
        
        private static void AddToPartition(List<WindowRect> partition1, IGrouping<int, WindowRect> group)
        {
            partition1.AddRange(group);
        }
        
        private static int CalculateBorderOffset(Process process)
        {
            var windowHandle = process.MainWindowHandle;
            var windowRectangle = WindowUtils.GetWindowRectangle(windowHandle);
            var clientRectangle = WindowUtils.GetClientRectangle(windowHandle);
            return Math.Abs(windowRectangle.Width - clientRectangle.Width) / 2;
        }

        private static String GetWindowRectangleString(IntPtr windowPointer)
        {
            var windowRectangle = WindowUtils.GetWindowRectangle(windowPointer);
            return "(" + windowRectangle.X + ", " + windowRectangle.Y + ") Size: (" + windowRectangle.Width + ", " +
                   windowRectangle.Height + ")";
        }
        public void ResizeAllWindows(BindingList<RewrittenAccount> accountList)
        {
            Console.WriteLine("Resizing " + ActiveProcesses.Count + " windows...");
            var accountsWithWindows = accountList.Select(account => {
                try
                {
                    var ptr = ActiveProcesses[account].MainWindowHandle;
                    return account;
                }
                catch (Exception)
                {
                    return null;
                }
            }).Where(account => account != null).ToList();
            var processes = accountsWithWindows.Select(account => ActiveProcesses[account]).ToList();
            if (processes.Count <=1)
            {
                return;
            }
            var targetWindowRects = CreateTargetWindowRectsFromProcesses(processes);
            Console.WriteLine("Resized " + processes.Count + " windows");
            ResizeWindows(accountsWithWindows, targetWindowRects);
        }
    }
}
