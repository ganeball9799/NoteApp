using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace NoteApp.UnitTests
{
    class Routes
    {
        public static string DataFolderForTest()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(location) + @"\TestData";
        }

        public static string FilePath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return path + @"\NoteApp\NoteApp.json";
        }

        public static string DirectoryPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return path + @"\NoteApp\";
        }
    }
}
