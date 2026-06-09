using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Nova.Common.Helper
{
    public class WmiHelper
    {
        public static string QuerySingleProperty(string query, string propertyName, string scope = @"root\CIMV2")
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher(scope, query))
                using (var collection = searcher.Get())
                {
                    foreach (ManagementObject mo in collection)
                    {
                        using (mo)
                        {
                            object value = mo[propertyName];
                            if (value != null)
                                return value.ToString();
                        }
                    }
                }
            }
            catch
            {
            }
            return "Unknown";
        }
        public static string QueryMultiProperty(string query, string propertyName, string scope = @"root\CIMV2", string separator = ", ")
        {
            try
            {
                var results = new List<string>();
                using (var searcher = new ManagementObjectSearcher(scope, query))
                using (var collection = searcher.Get())
                {
                    foreach (ManagementObject mo in collection)
                    {
                        using (mo)
                        {
                            object value = mo[propertyName];
                            if (value != null)
                                results.Add(value.ToString());
                        }
                    }
                }
                return results.Count > 0 ? string.Join(separator, results) : "Unknown";
            }
            catch
            {
                return "Unknown";
            }
        }
        public static T QuerySingle<T>(string query, Func<ManagementObject, T> selector, string scope = @"root\CIMV2")
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher(scope, query))
                using (var collection = searcher.Get())
                {
                    foreach (ManagementObject mo in collection)
                    {
                        using (mo)
                        {
                            return selector(mo);
                        }
                    }
                }
            }
            catch
            {
            }
            return default(T);
        }
    }
}
