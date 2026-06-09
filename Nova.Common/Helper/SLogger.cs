using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Nova.Common.Helper
{
    public class SLogger
    {
        private static string logFilePath;
        private static object lockObject = new object();

        // 日志级别枚举
        public enum LogLevel
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR
        }

        public static LogLevel CurrentLogLevel { get; set; } = LogLevel.DEBUG;

        // 静态构造函数，初始化默认日志路径
        static SLogger()
        {
            // 默认路径：应用程序目录下的 Logs 文件夹
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logDirectory = Path.Combine(appDirectory, "Logs");

            // 确保日志目录存在
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // 默认日志文件名：应用程序名_日期.log
            string appName = Process.GetCurrentProcess().ProcessName;
            string logFileName = $"{appName}_{DateTime.Now:yyyyMMdd}.log";
            logFilePath = Path.Combine(logDirectory, logFileName);
        }

        // 设置日志文件路径（可选，用于自定义）

        public static void SetLogFile(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            logFilePath = filePath;
        }

        // 记录调试信息
        [Conditional("DEBUG")]
        public static void Debug(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Log(LogLevel.DEBUG, message, memberName, filePath, lineNumber);
        }

        // 记录普通信息
        [Conditional("DEBUG")]
        public static void Info(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Log(LogLevel.INFO, message, memberName, filePath, lineNumber);
        }

        // 记录警告信息
        [Conditional("DEBUG")]
        public static void Warning(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Log(LogLevel.WARNING, message, memberName, filePath, lineNumber);
        }

        // 记录错误信息
        public static void Error(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Log(LogLevel.ERROR, message, memberName, filePath, lineNumber);
        }

        // 记录异常信息
        public static void Error(
            Exception ex,
            string customMessage = "",
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            string message = string.IsNullOrEmpty(customMessage)
                ? ex.ToString()
                : $"{customMessage} - {ex.Message}\n{ex.StackTrace}";
            Log(LogLevel.ERROR, message, memberName, filePath, lineNumber);
        }

        // 核心日志方法
        private static void Log(
            LogLevel level,
            string message,
            string memberName,
            string filePath,
            int lineNumber)
        {
            if (level < CurrentLogLevel) return;

            // 提取类名和文件名
            string className = Path.GetFileNameWithoutExtension(filePath);
            string fileName = Path.GetFileName(filePath);

            // 格式：时间 [级别] 类名.方法名 (文件名:行号) - 消息
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {className}.{memberName} ({fileName}:{lineNumber}) - {message}";

            // 输出到控制台
            Console.WriteLine(logEntry);

            // 写入文件
            try
            {
                lock (lockObject)
                {
                    // 每次写入前确保目录存在
                    string directory = Path.GetDirectoryName(logFilePath);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"写入日志文件失败: {ex.Message}");
            }
        }

        // 清空日志文件
        public static void ClearLog()
        {
            try
            {
                lock (lockObject)
                {
                    if (File.Exists(logFilePath))
                    {
                        File.WriteAllText(logFilePath, string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"清空日志文件失败: {ex.Message}");
            }
        }

        // 获取当前日志文件路径
        public static string GetLogFilePath()
        {
            return logFilePath;
        }
    }
}
