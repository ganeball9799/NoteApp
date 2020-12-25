using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;


namespace NoteApp
{
    /// <summary>
    /// Класс который содержит список всех контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Содержит индекс текущей заметки
        /// </summary>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Содержит список всех заметок
        /// </summary>
        public List<Note> Notes = new List<Note>();

        /// <summary>
        /// Сортировка по дате изменения и категории заметок
        /// </summary>
        public List<Note> SortNotes(List<Note> notes, NotesCategory category)
        {
            return notes = notes.Where(item => item.NoteCategory == category).OrderByDescending(item => item.TimeLastChange).ToList();
        }
        /// <summary>
        /// Сортировка по дате изменения
        /// </summary>
        public List<Note> SortNotes(List<Note> notes)
        {
            return notes = notes.OrderByDescending(item => item.TimeLastChange).ToList();
        }

    }

}
