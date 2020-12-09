using System;
using System.Runtime.CompilerServices;

namespace NoteApp
{
    /// <summary>
    /// Класс Запись. Здесь хранится информация о название заметки,ее категории
    /// содержании,даты создания и дате изменения
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Название заметки
        /// </summary>
        private string _title;

        /// <summary>
        /// Свойство имени заметки.
        /// Проверка на длину длину символом: менее 50 символов.
        /// Устанавливает первую букву в верхний регистр.
        /// </summary>
        public string Title
        {
            get => _title; 
            set
            {
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Имя заметки должно быть не более 50 символов!");
                }
                else
                {
                    if (value !="")
                    {
                        _title = value;
                    }
                    else _title = "Безымянный";
                }
            }
        }
        /// <summary>
        /// Свойство категории заметки. Заменяет время исправления при смене категории
        /// </summary>
        public NotesCategory NoteCategory { get; set; }

        /// <summary>
        /// Свойство имени заметки. Изменяет время после изменения имени.
        /// </summary>
        public string TextNote { get; set; }

        /// <summary>
        /// Свойство для времени создания
        /// </summary>
        public DateTime TimeCreate { get; set; } = DateTime.Now;

        /// <summary>
        /// Свойство для изменения времени
        /// </summary>
        public DateTime TimeLastChange { get; set; } = DateTime.Now;

        /// <summary>
        /// Метод клонирования
        /// </summary>
        /// <returns>Возвращает копию класса Note</returns>
        public object Clone()
        {
            return new Note
            {
                Title = Title,
                TextNote = TextNote,
                TimeLastChange = TimeLastChange,
                TimeCreate = TimeCreate,
                NoteCategory = NoteCategory
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Note note)
            {
                if (note.Title != this.Title)
                {
                    return false;
                }
                if (note.TextNote != this.TextNote)
                {
                    return false;
                }
                if (note.TimeCreate != this.TimeCreate)
                {
                    return false;
                }
                if (note.TimeLastChange != this.TimeLastChange)
                {
                    return false;
                }
                if (note.NoteCategory != this.NoteCategory)
                {
                    return false;
                }
                return true;
            }

            return false;
        }

    }
}
