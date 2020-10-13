using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace NoteApp
{
    /// <summary>
    /// Класс Запись. Здесь хранится информация о Название заметки,ее категории
    /// содержании,даты создания и дате изменения
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Название заметки
        /// </summary>
        private string _Title;

        /// <summary>
        /// Категория заметки
        /// </summary>
        private string _NotesCategory;

        /// <summary>
        /// Содержание заметки
        /// </summary>
        private string _TextNote;

        /// <summary>
        /// Дата создания
        /// </summary>
        private DateTime _TimeCreate;

        /// <summary>
        /// Дата изменения
        /// </summary>
        private DateTime _TimeLastChange;

        public string Title
        {
            get => _Title;
            set
            {
                if (!IsLonger(value, 50))
                {
                    _Title = char.ToUpper(value[0]) + value.Substring(1);
                    OnPropertyChanged(nameof(Title));
                }
                else
                {
                    throw new ArgumentException("Длина названия не может быть больше 50 символов");
                }

                
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

       

    }
}
