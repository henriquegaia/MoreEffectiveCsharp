﻿using System;

namespace Utilities
{
    public static class Log
    {
        public static ConsoleColor DefaultForeground = ConsoleColor.White;

        public static void Line(string s) => Console.WriteLine($"{DateTime.Now}: {s}");

        public static void Success(string line = "Success")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            LogAndReset(line);
        }

        public static void Failure(string line = "Failure")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LogAndReset(line);
        }

        public static void Exception(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            LogAndReset(exception.Message);
        }

        public static void Info(string line = "Continue ...")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            LogAndReset(line);
        }

        private static void LogAndReset(string line)
        {
            Line(line);
            Console.ForegroundColor = DefaultForeground;
        }

        public static void ThreadCount() => 
            Info($"ThreadCount: {AsyncAndThreading.ThreadCount().ToString()}");
    }

}
