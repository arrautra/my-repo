using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace WebApplication1
{
    public interface ICache
    {
        void Add(string key, object value, DateTime expires);
        T Get<T>(string key);
    }


    public class MyCache : ICache
    {
        public void Add(string key, object value, DateTime expires)
        {
            if (!(HttpRuntime.Cache == null))
                HttpRuntime.Cache.Add(key, value, null, expires, Cache.NoSlidingExpiration, CacheItemPriority.Default, OnRemoved);
        }

        public T Get<T>(string key)
        {
            T retVal = default(T);

            if (!(HttpRuntime.Cache == null))
                retVal = (T) HttpRuntime.Cache.Get(key);

            return (T)retVal;
        }

        public void OnRemoved(string key, object value, CacheItemRemovedReason reason)
        {

        }
    }
}
