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
        private List<Note> _notesList = new List<Note>();
        public MainForm()
        {
            InitializeComponent();
            CategoryComboBox.Items.AddRange(Enum.GetNames(typeof(NoteApp.NotesCategory)));
            CategoryComboBox.Items.Add("All");
            _notesList = _project.Notes;
            _notesList = _project.SortNotes(_notesList);
            UpdateListBox();
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
            var Note = new Note { };
            var noteForm = new NoteForm() { TepmNote = Note };
            var dialogResult = noteForm.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            _project.Notes.Add(noteForm.TepmNote);
            _notesList.Add(noteForm.TepmNote);
            NotesListBox.Items.Add(noteForm.TepmNote.Title);
            UpdateListBox();
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
                var selectNote = _notesList[selectIndex];

                var updateNote = new NoteForm { TepmNote = selectNote };
                var dialogResult = updateNote.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                var noteSelectIndex = _project.Notes.IndexOf(selectNote);
                _notesList.RemoveAt(selectIndex);
                _project.Notes.RemoveAt(noteSelectIndex);
                _notesList.Insert(selectIndex, updateNote.TepmNote);
                _project.Notes.Insert(noteSelectIndex, updateNote.TepmNote);
                NotesListBox.Items.Insert(selectIndex, updateNote.TepmNote.Title);
                UpdateListBox();
                _project.SelectedIndex = NotesListBox.SelectedIndex;
                ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
            }
        }

        /// <summary>
        /// Удаление заметки
        /// </summary>
        private void DeleteNote()
        {
            var selectedIndex = NotesListBox.SelectedIndex;
            Note selectNote = _notesList[selectedIndex];
            if (NotesListBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"Note is not selected!", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = MessageBox.Show($@"Are you sure you want to delete the note:
                    {_notesList[selectedIndex].Title}?", @"Confirmation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result != DialogResult.OK)
                {
                    return;
                }

                var noteSelectIndex = _project.Notes.IndexOf(selectNote);
                _notesList.RemoveAt(selectedIndex);
                _project.Notes.RemoveAt(noteSelectIndex);
                NotesListBox.Items.RemoveAt(selectedIndex);
                UpdateListBox();
                ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
                if (NotesListBox.Items.Count != 0)
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
            CategoryComboBox.SelectedIndex = CategoryComboBox.Items.Count - 1;
            UpdateListBox();
            LastOpenNote();
            ProjectManager.SaveToFile(_project, ProjectManager.PathFile(), _directoryPath);
        }

        /// <summary>
        /// Свойство выбора заметки
        /// </summary>
        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = NotesListBox.SelectedIndex;

            if (index < 0)
            {
                return;
            }
            else
            {
                if (NotesListBox.Items.Count == 0)
                {
                    ClearingFields();
                }
            }
            var selectNote = _notesList[index];
                _project.SelectedIndex = NotesListBox.SelectedIndex;
                NameNote.Text = selectNote.Title;
                TextNoteTextBox.Text = selectNote.TextNote;
                TimeCreate.Value = selectNote.TimeCreate;
                TimeUpdate.Value = selectNote.TimeLastChange;
                NotesCategory.Text = selectNote.NoteCategory.ToString();

            }

            private void ClearingFields()
            {
                NameNote.Text = "";
                TextNoteTextBox.Text = "";
                TimeCreate.Text = "";
                TimeUpdate.Text = "";
                NotesCategory.Text = "";
            }

            /// <summary>
            /// Обновление списка заметок
            /// </summary>
            private void UpdateListBox()
            {
                _notesList = _project.Notes;
                if (CategoryComboBox.SelectedIndex != CategoryComboBox.Items.Count - 1)
                {
                    _notesList = _project.SortNotes(_notesList, (NotesCategory)CategoryComboBox.SelectedIndex);
                }
                else
                {
                    _notesList = _project.SortNotes(_notesList);
                }
                NotesListBox.Items.Clear();
                for (int i = 0; i < _notesList.Count; i++)
                {
                    NotesListBox.Items.Add(_notesList[i].Title);
                }
            }
            /// <summary>
            /// Метод обработки последней заметки
            /// </summary>
            private void LastOpenNote()
            {
                if (_project.SelectedIndex > NotesListBox.Items.Count - 1)
                {
                    NotesListBox.SelectedIndex = 0;
                }
                else
                {
                    NotesListBox.SelectedIndex = _project.SelectedIndex;
                }
            }
            /// <summary>
            /// Добавление заметки при нажатии на кнопку AddNoteButton
            /// </summary>
            private void AddNoteButton_Click(object sender, EventArgs e)
            {
                AddNote();
                UpdateListBox();
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
                _project.SelectedIndex = NotesListBox.SelectedIndex;
                ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
            }

            /// <summary>
            /// Закрытие формы, через кнопку в меню
            /// </summary>
            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                _project.SelectedIndex = NotesListBox.SelectedIndex;
                Close();
            }

            private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                UpdateListBox();
            }
        }
    }