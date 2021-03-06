﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zodiacon.ManagedWindows.Core;
using Zodiacon.ManagedWindows.Processes;

namespace ProcessList {
    class Program {
        static void Main(string[] args) {
            var processes = SystemInformation.EnumProcesses();
            foreach (var pi in processes) {
                Console.Write($"{pi.Name} ({pi.Id}) Threads: {pi.Threads} Parent: {pi.ParentId}");
                if (pi.Id > 0) {
                    try {
                        using (var process = NativeProcess.Open(ProcessAccessMask.QueryLimitedInformation, pi.Id)) {
                            Console.Write($" Start: {process.CreateTime}");
                        }
                    }
                    catch { }
                }
                Console.WriteLine();
            }
        }
    }
}
