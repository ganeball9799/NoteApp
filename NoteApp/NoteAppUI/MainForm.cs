using Newtonsoft.Json;
using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NoteAppUI
{
    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Хранилище для данных
        /// </summary>
        private Project _project = new Project();
        public MainForm()
        {
            InitializeComponent();
            //CategoryComboBox.DataSource = Enum.GetValues(typeof(NotesCategory));
            CategoryComboBox.Items.Add("All");
            CategoryComboBox.Items.Add(NoteApp.NotesCategory.Work);
            CategoryComboBox.Items.Add(NoteApp.NotesCategory.Home);
            CategoryComboBox.Items.Add(NoteApp.NotesCategory.HealthAndSport);
            CategoryComboBox.Items.Add(NoteApp.NotesCategory.Peoples);
            CategoryComboBox.Items.Add(NoteApp.NotesCategory.Documents);
            CategoryComboBox.Items.Add(NoteApp.NotesCategory.Finances);
            CategoryComboBox.Items.Add(NoteApp.NotesCategory.Other);
        }

        /// <summary>
        /// Путь к файлу с данными
        /// </summary>
        private readonly string _filePath = ProjectManager.PathFile();

        private readonly string _directoryPath = ProjectManager.PathDirectory();

        /// <summary>
        /// добавление заметки
        /// </summary>
        private void AddNote()
        {
            var Note = new Note{};
            var noteForm = new NoteForm() { TepmNote = Note };
            var dialogResult = noteForm.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            _project.Notes.Add(noteForm.TepmNote);
            NotesListBox.Items.Add(noteForm.TepmNote.Title);
            ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
        }

        /// <summary>
        /// Редактирование заметки
        /// </summary>
        private void EditNote()
        {
            if (NotesListBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"Note is not selected!", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var selectIndex = NotesListBox.SelectedIndex;
                var selectNote = _project.Notes[selectIndex];

                var updateNote = new NoteForm { TepmNote = selectNote };
                var dialogResult = updateNote.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }
                _project.Notes.RemoveAt(selectIndex);
                NotesListBox.Items.RemoveAt(selectIndex);
                _project.Notes.Insert(selectIndex, updateNote.TepmNote);
                NotesListBox.Items.Insert(selectIndex, updateNote.TepmNote.Title);
                NotesListBox.SelectedIndex = selectIndex;
                ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
            }
        }

        /// <summary>
        /// Удаление заметки
        /// </summary>
        private void DeleteNote()
        {
            if (NotesListBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"Note is not selected!", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var selectedIndex = NotesListBox.SelectedIndex;
                var result = MessageBox.Show($@"Are you sure you want to delete the note:
                    {_project.Notes[selectedIndex].Title}?", @"Confirmation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result != DialogResult.OK)
                {
                    return;
                }
                _project.Notes.RemoveAt(selectedIndex);
                NotesListBox.Items.RemoveAt(selectedIndex);
                ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
                if (NotesListBox.Items.Count > 0)
                {
                    NotesListBox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Загрузка данных из файла
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.LoadFromFile(_filePath);
            FillingNotesListBox();
            ProjectManager.SaveToFile(_project, ProjectManager.PathFile(), _directoryPath);
        }

        /// <summary>
        /// Загрузка названий заметок в ListBox
        /// </summary>
        private void FillingNotesListBox()
        {
           foreach (var t in _project.Notes)
           {
                NotesListBox.Items.Add(t.Title);
           }
        }

        /// <summary>
        /// Свойство выбора заметки
        /// </summary>
        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = NotesListBox.SelectedIndex;
            if (index >= 0)
            {
                NameNote.Text = _project.Notes[index].Title;
                TextNoteTextBox.Text = _project.Notes[index].TextNote;
                TimeCreate.Value = _project.Notes[index].TimeCreate;
                TimeUpdate.Value = _project.Notes[index].TimeLastChange;
                NotesCategory.Text = _project.Notes[index].NoteCategory.ToString();
            }

        }

        /// <summary>
        /// Добавление заметки при нажатии на кнопку AddNoteButton
        /// </summary>
        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        /// <summary>
        /// Добавление заметки при нажатии на кнопку EditNoteButton
        /// </summary>
        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        /// <summary>
        /// Добавление заметки при нажатии на кнопку RemoveNoteButton
        /// </summary>
        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            DeleteNote();
        }

        /// <summary>
        /// Добавление заметки, через кнопку
        /// </summary>
        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        /// <summary>
        /// Редактирование заметки, через кнопку
        /// </summary>
        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
        }

        /// <summary>
        /// Удаление заметки, через кнопку
        /// </summary>
        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteNote();
        }

        /// <summary>
        /// Открытие окна About
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

        /// <summary>
        /// Метод для открытия окна About
        /// </summary>
        private void ShowAboutForm()
        {
            var about = new AboutForm();
            about.ShowDialog();
        }

        /// <summary>
        ///Закрытие формы с сохранением данных 
        /// </summary>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
        }

        /// <summary>
        /// Закрытие формы, через кнопку в меню
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}