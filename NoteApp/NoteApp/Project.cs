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
        public int SelectedIndex { get; set; }
        /// <summary>
        /// Содержит список всех заметок
        /// </summary>
        public List<Note> Notes = new List<Note>();
        
        public List<Note> SortNotes(NotesCategory category, List<Note> notes)
        {   
            List<Note> sortList = new List<Note>();
            foreach (Note currentNote in notes)
            {
                if (currentNote.NoteCategory == category)
                {
                    sortList.Add(currentNote);
                }
            }
            if (sortList.Count == 0)
            {
                return sortList;
            }
            SortNotes(sortList);
            return sortList;
        }

        public List<Note> SortNotes(List<Note> notes)
        {
            notes.Sort((x, y) => y.TimeLastChange.CompareTo(x.TimeLastChange));
            return notes;
        }
        
    }
    
}
