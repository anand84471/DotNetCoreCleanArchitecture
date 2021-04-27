using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging
{
    public class AppLogger<T>:IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public AppLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInformation(StringBuilder stringBuilder, params object[] args)
        {
            if (stringBuilder != null)
            {
                _logger.LogInformation(stringBuilder.ToString(), args);
            }
        }

        public void LogWarning(StringBuilder stringBuilder, params object[] args)
        {
            if (stringBuilder != null)
            {
                _logger.LogWarning(stringBuilder.ToString(), args);
            }
        }

        public void LogError(StringBuilder stringBuilder, params object[] args)
        {
            if (stringBuilder != null)
            {
                _logger.LogError(stringBuilder.ToString(), args);
            }
        }
    }
}
