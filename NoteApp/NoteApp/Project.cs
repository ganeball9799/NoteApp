using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace NoteApp
{
    /// <summary>
    /// Класс который содержит список всех контактов
    /// </summary>
    public class Project
    {
        public int SelectedIndex { get; set; }
        /// <summary>
        /// Содержит список всех заметок
        /// </summary>
        public List<Note> Notes = new List<Note>();
    }
    
}
