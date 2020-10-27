using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Менеджер проекта
    /// </summary>
    public class ProjectManager
    {
        public string PathFile()
        {
            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return filepath + @"\NoteApp\NoteApp.json";
        }

        /// <summary>
        /// Сериализация данных
        /// </summary>
        /// <param name="data">Данные для сериализации</param>
        /// <param name="filepath">Путь к файлу</param>
        public void SaveFile(Project data, string filepath)
        {
            if (filepath == null)
            {
                filepath = PathFile();
            }

            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {

                serializer.Serialize(writer, data);
            }
        }


        public Project LoadFile(string filepath)
        {
            Project project;
            if (!File.Exists(filepath))
            {
                return new Project();
            }

            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                using (JsonReader reader = new JsonTextReader(sr))
                    project = serializer.Deserialize<Project>(reader);
            }
            catch 
            {
                return new Project();
            }

            return project;
        }
    }
}

