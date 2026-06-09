using Microsoft.Win32;
using System;

namespace Nova.Common.Helper
{
    static public class OSInfo
    {
        static public int Bits => IntPtr.Size * 8;

        static private string _Edition;
        static private string _Name;
        static private string _ProductName;

        private static T ReadRegistry<T>(string valueName, T defaultValue = default(T))
        {
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(valueName);
                        if (value != null)
                            return (T)Convert.ChangeType(value, typeof(T));
                    }
                }
            }
            catch { }
            return defaultValue;
        }
        #region 获取真实系统名称（解决 Win11 识别问题）
        private static string GetRealProductName()
        {
            if (_ProductName != null) return _ProductName;

            // 优先从注册表读取 ProductName
            string productName = ReadRegistry("ProductName", "");

            // Windows 11 识别：Build >= 22000 且 ProductName 包含 Windows 10
            if (BuildNumber >= 22000 && productName.Contains("Windows 10"))
            {
                _ProductName = productName.Replace("Windows 10", "Windows 11");
            }
            else
            {
                _ProductName = productName;
            }

            return _ProductName;
        }
        #endregion

        #region EDITION
        static public string Edition
        {
            get
            {
                if (_Edition != null) return _Edition;

                string editionId = ReadRegistry("EditionID", "");
                switch (editionId.ToLower())
                {
                    case "core": _Edition = "Home"; break;
                    case "corecountryspecific": _Edition = "China"; break;
                    case "coresinglelanguage": _Edition = "Home Single Language"; break;
                    case "professional": _Edition = "Pro"; break;
                    case "professionaln": _Edition = "Pro N"; break;
                    case "enterprise": _Edition = "Enterprise"; break;
                    case "enterprisen": _Edition = "Enterprise N"; break;
                    case "education": _Edition = "Education"; break;
                    case "educationn": _Edition = "Education N"; break;
                    case "proeducation": _Edition = "Pro Education"; break;
                    case "proeducationn": _Edition = "Pro Education N"; break;
                    case "probusiness": _Edition = "Pro for Workstations"; break;
                    case "enterprisenevaluation": _Edition = "Enterprise Evaluation"; break;
                    default: _Edition = string.IsNullOrEmpty(editionId) ? "Unknown" : editionId; break;
                }
                return _Edition;
            }
        }
        #endregion

        #region NAME
        static public string Name
        {
            get
            {
                if (_Name != null) return _Name;

                string productName = GetRealProductName();

                // 如果 ProductName 有效，直接使用
                if (!string.IsNullOrEmpty(productName) && productName != "Unknown")
                {
                    _Name = productName;
                    return _Name;
                }

                // 降级方案：根据 Build 号判断
                if (BuildNumber >= 22000)
                    _Name = "Windows 11";
                else if (BuildNumber >= 10240)
                    _Name = "Windows 10";
                else if (BuildNumber >= 9600)
                    _Name = "Windows 8.1";
                else if (BuildNumber >= 9200)
                    _Name = "Windows 8";
                else if (BuildNumber >= 7601)
                    _Name = "Windows 7 SP1";
                else if (BuildNumber >= 7600)
                    _Name = "Windows 7";
                else
                    _Name = "Unknown";

                return _Name;
            }
        }
        #endregion

        #region VERSION
        static public string Version
        {
            get
            {
                string major = ReadRegistry("CurrentMajorVersionNumber", 0).ToString();
                string minor = ReadRegistry("CurrentMinorVersionNumber", 0).ToString();
                string build = ReadRegistry("CurrentBuild", "0");

                if (major != "0" && minor != "0")
                    return $"{major}.{minor}.{build}";

                string version = ReadRegistry("CurrentVersion", "");
                if (!string.IsNullOrEmpty(version) && build != "0")
                    return $"{version}.{build}";

                return Environment.OSVersion.Version.ToString();
            }
        }

        static public int BuildNumber
        {
            get
            {
                // UBR 是更准确的 Build 号
                int ubr = ReadRegistry("UBR", 0);
                int build = ReadRegistry("CurrentBuild", 0);

                if (build > 0)
                {
                    // 如果有 UBR，组合成完整 Build
                    if (ubr > 0)
                        return build;
                    return build;
                }
                return Environment.OSVersion.Version.Build;
            }
        }

        static public string ReleaseId
        {
            get
            {
                string display = ReadRegistry("DisplayVersion", "");
                if (!string.IsNullOrEmpty(display)) return display;
                return ReadRegistry("ReleaseId", "");
            }
        }
        #endregion

        #region FULL NAME
        static public string FullName
        {
            get
            {
                if (Name == "Unknown" || Name.Contains("Unknown"))
                    return $"Windows (Build {BuildNumber})";

                string release = ReleaseId;
                string edition = Edition;

                // 如果是 Home/Pro 等，去掉重复
                if (Name.Contains(edition) && edition != "Unknown")
                    return string.IsNullOrEmpty(release) ? Name : $"{Name} {release}".Trim();

                return string.IsNullOrEmpty(release)
                    ? $"{Name} {edition}".Trim()
                    : $"{Name} {edition} {release}".Trim();
            }
        }
        #endregion

        #region 简单判断方法
        /// <summary>
        /// 是否为 Windows 11
        /// </summary>
        static public bool IsWindows11 => BuildNumber >= 22000;

        /// <summary>
        /// 是否为 Windows 10
        /// </summary>
        static public bool IsWindows10 => BuildNumber >= 10240 && BuildNumber < 22000;

        /// <summary>
        /// 是否为 Windows Server
        /// </summary>
        static public bool IsServer
        {
            get
            {
                string installType = ReadRegistry("InstallationType", "");
                return !string.IsNullOrEmpty(installType) && installType.Contains("Server");
            }
        }
        #endregion
    }
}