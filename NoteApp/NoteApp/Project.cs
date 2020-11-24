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
        /// <summary>
        /// Содержит список всех заметок
        /// </summary>
        //public List<Note> Notes = new List<Note>();
        
        ///Код,который пусть будет пока здесь
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    }
    
}
