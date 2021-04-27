using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogInformation(string Message, params object[] args);
        void LogWarning(string Message, params object[] args);
        void LogError(string Message, params object[] args);
        void LogInformation(StringBuilder stringBuilder, params object[] args);
        void LogWarning(StringBuilder stringBuilder, params object[] args);
        void LogError(StringBuilder stringBuilder, params object[] args);
    }
}
