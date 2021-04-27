using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Cache
{
    public interface ICoreCache
    {
        public string GetValueAsync(string key);

    }
}
