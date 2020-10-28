﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


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
        /// Категория заметки
        /// </summary>
        private NotesCategory _noteCategory;

        /// <summary>
        /// Содержание заметки
        /// </summary>
        private string _textNote;

        /// <summary>
        /// Дата создания
        /// </summary>
        private DateTime _timeCreate = DateTime.Now;

        /// <summary>
        /// Дата изменения
        /// </summary>
        private DateTime _timeUpdate = DateTime.Now;

        /// <summary>
        /// Свойство имени заметки.
        /// Проверка на длину длину символом: менее 50 символов.
        /// Устанавливает первую букву в верхний регистр.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = char.ToUpper(value[0]) + value.Substring(1);
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Имя заметки должно быть не более 50 символов!");
                }
                else
                {
                    if (value != string.Empty)
                    {
                        _title = value;
                    }
                    else _title = "Безымянный";
                    TimeLastChange = DateTime.Now;
                }
            }
        }
        /// <summary>
        /// Свойство категории заметки. Заменяет время исправления при смене категории
        /// </summary>
        public NotesCategory NoteCategory
        {
            get { return _noteCategory; }
            set
            {
                _noteCategory = value;
                TimeLastChange = DateTime.Now;
            }
        }
        /// <summary>
        /// Свойство имени заметки. Изменяет время после изменения имени.
        /// </summary>
        public string TextNote
        {
            get { return _title; }
            set
            {
                _textNote = value;
                TimeLastChange = DateTime.Now;

            }
        }
        /// <summary>
        /// Свойство для времени создания
        /// </summary>
        public DateTime TimeCreate
        {
            get { return _timeCreate; }
        }
        /// <summary>
        /// Свойство для изменения времени
        /// </summary>
        public DateTime TimeLastChange
        {
            get { return _timeUpdate; }
            set
            {
                _timeUpdate = DateTime.Now;
            }
        }
        /// <summary>
        /// Метод клонирования
        /// </summary>
        /// <returns>Возвращает копию класса Note</returns>
        public object Clone()
        {
            return new Note
            {
                Title = this.Title,
                TextNote = this.TextNote,
                TimeLastChange = this.TimeLastChange,
                NoteCategory = this.NoteCategory
            };
        }
    }
}
