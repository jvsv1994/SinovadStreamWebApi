﻿using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SinovadDemo.Transversal.Logger
{
    public class SyslogLoggerProvider : ILoggerProvider
    {
        private string _host;
        private string _assenblyName;
        private string _environmentName;
        private int _port;

        private readonly Func<string, LogLevel, bool> _filter;

        public SyslogLoggerProvider(string host, int port, string assenblyName, string environmentName, Func<string, LogLevel, bool> filter)
        {
            _host = host;
            _port = port;
            _assenblyName = assenblyName;
            _environmentName = environmentName;
            _filter = filter;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SyslogLogger(categoryName, _host, _port, _assenblyName, _environmentName, _filter);
        }

        public void Dispose()
        {
        }
    }

    public class SyslogLogger : ILogger
    {
        private const int SyslogFacility = 16;

        private string _categoryName;
        private string _host;
        private int _port;
        private string _assenblyName;
        private string _environmentName;

        private readonly Func<string, LogLevel, bool> _filter;

        public SyslogLogger(string categoryName,
                            string host,
                            int port, string assenblyName, string environmentName,
                            Func<string, LogLevel, bool> filter)
        {
            _categoryName = categoryName;
            _host = host;
            _port = port;
            _assenblyName = assenblyName;
            _environmentName = environmentName;
            _filter = filter;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _filter == null || _filter(_categoryName, logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            message = $"{logLevel}: {message}";

            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception.ToString();
            }

            var syslogLevel = MapToSyslogLevel(logLevel);
            Send(syslogLevel, message);
        }

        internal void Send(SyslogLogLevel logLevel, string message)
        {
            if (string.IsNullOrWhiteSpace(_host) || _port <= 0)
            {
                return;
            }

            var hostName = Dns.GetHostName();
            var level = SyslogFacility * 8 + (int)logLevel;
            var logMessage = string.Format("[{0}] {1} | {2} | {3}", _environmentName, _assenblyName, hostName, message);
            var bytes = Encoding.UTF8.GetBytes(logMessage);

            using (var client = new UdpClient())
            {
                client.SendAsync(bytes, bytes.Length, _host, _port).Wait();
            }
        }

        private SyslogLogLevel MapToSyslogLevel(LogLevel level)
        {
            if (level == LogLevel.Critical)
                return SyslogLogLevel.Critical;
            if (level == LogLevel.Debug)
                return SyslogLogLevel.Debug;
            if (level == LogLevel.Error)
                return SyslogLogLevel.Error;
            if (level == LogLevel.Information)
                return SyslogLogLevel.Info;
            if (level == LogLevel.None)
                return SyslogLogLevel.Info;
            if (level == LogLevel.Trace)
                return SyslogLogLevel.Info;
            if (level == LogLevel.Warning)
                return SyslogLogLevel.Warn;

            return SyslogLogLevel.Info;
        }
    }

    public enum SyslogLogLevel
    {
        Emergency,
        Alert,
        Critical,
        Error,
        Warn,
        Notice,
        Info,
        Debug
    }

    public class NoopDisposable : IDisposable
    {
        public static NoopDisposable Instance = new NoopDisposable();

        public void Dispose()
        {
        }
    }
    public static class SyslogLoggerExtensions
    {
        public static ILoggerFactory AddSyslog(this ILoggerFactory factory,
                                        string host, int port, string assenblyName = null, string environmentName = null,
                                        Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new SyslogLoggerProvider(host, port, assenblyName, environmentName, filter));
            return factory;
        }
    }
}
