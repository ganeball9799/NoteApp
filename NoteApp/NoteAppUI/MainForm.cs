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

        private List<Note> _viewNotes = new List<Note>();

        /// <summary>
        /// Путь к файлу с данными
        /// </summary>
        private readonly string _filePath = ProjectManager.PathFile();

        private readonly string _directoryPath = ProjectManager.PathDirectory();

        public MainForm()
        {
            InitializeComponent();
            CategoryComboBox.Items.AddRange(Enum.GetNames(typeof(NoteApp.NotesCategory)));
            CategoryComboBox.Items.Add("All");
            _viewNotes = _project.Notes;
            _viewNotes = _project.SortNotes(_viewNotes);
            //UpdateListBox();
        }
        
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
            _viewNotes.Add(noteForm.TepmNote);
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
                var selectNote = _viewNotes[selectIndex];
                var updateNote = new NoteForm { TepmNote = selectNote };
                var dialogResult = updateNote.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                var noteSelectIndex = _project.Notes.IndexOf(selectNote);
                _viewNotes.RemoveAt(selectIndex);
                _project.Notes.RemoveAt(noteSelectIndex);
                _viewNotes.Insert(selectIndex, updateNote.TepmNote);
                _project.Notes.Insert(noteSelectIndex, updateNote.TepmNote);
                NotesListBox.Items.Insert(selectIndex, updateNote.TepmNote.Title);
                _project.SelectedIndex = NotesListBox.SelectedIndex;
                ProjectManager.SaveToFile(_project, _filePath, _directoryPath);
                UpdateListBox();
                if (NotesListBox.Items.Count != 0)
                {
                    NotesListBox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Удаление заметки
        /// </summary>
        private void DeleteNote()
        {
            var selectedIndex = NotesListBox.SelectedIndex;
            Note selectNote = _viewNotes[selectedIndex];
            if (NotesListBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"Note is not selected!", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = MessageBox.Show($@"Are you sure you want to delete the note:
                    {_viewNotes[selectedIndex].Title}?", @"Confirmation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result != DialogResult.OK)
                {
                    return;
                }

                var noteSelectIndex = _project.Notes.IndexOf(selectNote);
                _viewNotes.RemoveAt(selectedIndex);
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
            NotesView(_project.SortNotes(_viewNotes, (NotesCategory)CategoryComboBox.SelectedIndex));
        }

        /// <summary>
        /// Свойство выбора заметки
        /// </summary>
        private void NotesView(IReadOnlyList<Note> noteView)
        {
            var index = NotesListBox.SelectedIndex;

            if (index < 0)
            {
                return;
            }
            var selectNote = _viewNotes[index];
            _project.SelectedIndex = NotesListBox.SelectedIndex;
            NameNote.Text = selectNote.Title;
            TextNoteTextBox.Text = selectNote.TextNote;
            TimeCreate.Value = selectNote.TimeCreate;
            TimeUpdate.Value = selectNote.TimeLastChange;
            NotesCategory.Text = selectNote.NoteCategory.ToString();
        }

        /// <summary>
        /// Свойство отчистки полей
        /// </summary>
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
            _viewNotes = _project.Notes;
            if (CategoryComboBox.SelectedIndex != CategoryComboBox.Items.Count - 1)
            {
                _viewNotes = _project.SortNotes(_viewNotes, (NotesCategory)CategoryComboBox.SelectedIndex);
            }
            else
            {
                _viewNotes = _project.SortNotes(_viewNotes);
            }
            NotesListBox.Items.Clear();
            for (int i = 0; i < _viewNotes.Count; i++)
            {
                NotesListBox.Items.Add(_viewNotes[i].Title);
            }

            if (NotesListBox.Items.Count == 0)
            {
                ClearingFields();
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
        private static void ShowAboutForm()
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

        /// <summary>
        /// Обновление списка заметок при выборе категории
        /// </summary>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        /// <summary>
        /// Открытие окна при нажатии клавиши F1
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ShowAboutForm();
            }
        }
    }
}