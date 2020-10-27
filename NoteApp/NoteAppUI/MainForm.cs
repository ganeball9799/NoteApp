using Newtonsoft.Json;
using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Project product = null;

            //Создаём экземпляр сериализатора
            //JsonSerializer Serializer = new JsonSerializer();
           
            //Открываем поток для записи в файл с указанием пути
            // using (StreamWriter sw = new StreamWriter(@"d:\json.txt"))
            //using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                // Serializer.Serialize(writer, project);
            }
            // using (StreamReader sr = new StreamReader(@"d:\json.txt"))
            //using (JsonReader reader = new JsonTextReader(sr))
            {
                //project = (Project)Serializer.Deserialize<Project>(reader);
            }
        }


    }
}
