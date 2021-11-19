
using System.Threading;
using System.IO;
using System.Security.AccessControl;
using System;
using System.Diagnostics;
using System.Drawing;
using FlaUI.Core;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using FlaUI.Core.Definitions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Logging;

namespace POC
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start(@"C:\Users\tryam\AppData\Local\slack\slack.exe");

            var application = Application.Launch(@"C:\Users\tryam\AppData\Local\slack\slack.exe");
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            var childElements = mainWindow.FindAllChildren();

            foreach (var item in childElements)
            {
                item.DrawHighlight();
            }

            int count = 0;
            do
            {
                Thread.Sleep(5000);
                Point point = new Point();
                point.X = 1370;
                point.Y = 20;

                Mouse.LeftClick(point);
                count += 1;
                Thread.Sleep(6000);

                Console.WriteLine("Count 10000 out of "+ count.ToString());

            } while (count < 100000);
        }
    }
}
