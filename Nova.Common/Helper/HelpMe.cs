using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace Nova.Common.Helper
{
    class HelpMe
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static Random _rnd = new Random(Environment.TickCount);

        public static string GetRandomFilename(int length, string extension)
        {
            char[] tempChars = new char[length];
            for (int i = 0; i < length; i++)
                tempChars[i] = CHARS[_rnd.Next(CHARS.Length)];

            return new string(tempChars) + extension;
        }

        public static string GetRandomName(int length)
        {
            char[] tempChars = new char[length];
            for (int i = 0; i < length; i++)
                tempChars[i] = CHARS[_rnd.Next(CHARS.Length)];

            return new string(tempChars);
        }
        public static byte[] CImgToByte(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        public static Bitmap GetDesktop(int Mode, int Number, Rectangle bounds)
        {
            if (Number < 0 || Number >= Screen.AllScreens.Length)
                Number = 0;

          

        

            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height,
                                           PixelFormat.Format32bppArgb);

            using (Graphics graph = Graphics.FromImage(screenshot))
            {
                if (Mode == 1)
                    graph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                else if (Mode == 2)
                    graph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size,
                                    CopyPixelOperation.SourceCopy);
            }

            return screenshot;
        }
        public static bool IsWindowsXP()
        {
            var OsVersion = Environment.OSVersion.Version;
            return OsVersion.Major == 5 && OsVersion.Minor >= 1;
        }

        public static Image CByteToImg(byte[] img)
        {
            MemoryStream ms = new MemoryStream(img, 0, img.Length);
            ms.Write(img, 0, img.Length);
            return Image.FromStream(ms, true);
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resized;
        }
        public static Bitmap ResizeImageProportional(Image image, int maxWidth, int maxHeight)
        {
            double ratio = Math.Min((double)maxWidth / image.Width, (double)maxHeight / image.Height);
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            Bitmap resized = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return resized;
        }
        public static string GetFileSize(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = size;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }
            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }

        public static int GetFileIcon(string Extension)
        {
            if (!string.IsNullOrEmpty(Extension))
            {
                switch (Extension.ToLower())
                {
                    default:
                        return 2;
                    case ".exe":
                        return 3;
                    case ".txt":
                        return 4;
                    case ".rar":
                    case ".zip":
                    case ".zipx":
                    case ".tar":
                    case ".tgz":
                    case ".s7z":
                    case ".7z":
                    case ".bz2":
                    case ".cab":
                    case ".zz":
                        return 5;
                    case ".doc":
                    case ".docx":
                    case ".odt":
                        return 6;
                    case ".pdf":
                        return 7;
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".bmp":
                    case ".gif":
                        return 8;
                    case ".mp4":
                    case ".mov":
                    case ".avi":
                    case ".wmv":
                        return 9;
                    case ".mp3":
                    case ".wav":
                        return 10;
                }
            }
            else
                return 2;
        }
     
    }
}
