﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Push
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> modules = GitLib.SearchModules();

            Console.WriteLine($"已找到项目:");
            for (int i = 0; i < modules.Count; i++)
            {
                Console.WriteLine(modules[i]);
            }

            string addcmd = "add .";
            string commitcmd = "commit -m \"{0}\"";
            string pushcmd = "push";

            Console.WriteLine("请输入本次操作名称:");
            string? optinename = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(optinename))
            {
                optinename = "Commit by scripts";
            }
            Console.WriteLine($"即将开始执行操作{optinename}");
            commitcmd = string.Format(commitcmd, optinename);
            string[] commands = new[] { addcmd, commitcmd, pushcmd };

            for (int i = 0; i < modules.Count; i++)
            {
                GitLib.ExcuteCommand(modules[i], commands);
            }


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'push'已完成,请按任意键退出!");
            Console.Read();
        }
    }
}
