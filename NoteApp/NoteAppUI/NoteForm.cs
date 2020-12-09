using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    /// <summary>
    /// Класс предназначенный для добавления и редактирования заметок
    /// </summary>
    public partial class NoteForm : Form
    {
        private Note tempNote;

        /// <summary>
        /// Временное хранилище для данных
        /// </summary>
        public Note TepmNote
        {
            get => tempNote;
            set
            {
                tempNote = value;
                NameNoteTextBox.Text = value.Title;
                TimeCreateDateTimePicker.Value = value.TimeCreate;
                TimeUpdateDateTimePicker.Value = value.TimeLastChange;
                TextNoteTextBox.Text = value.TextNote;
                NoteCategoryComboBox.Text = value.NoteCategory.ToString();
            }
        }
        public NoteForm()
        {
            InitializeComponent();
            NoteCategoryComboBox.DataSource = Enum.GetValues(typeof(NotesCategory));
        }

       
        /// <summary>
        /// Действие, при активации кнопки ОК
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            NewNote();
        }

        /// <summary>
        /// Действие, при активации кнопки Cancel
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Действия, при закрытии формы
        /// </summary>
       private void AddEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Cancel) return;
            if (NameNoteTextBox.Text == "" && NoteCategoryComboBox.Text == "" && TextNoteTextBox.Text == "")
            {
                return;
            }

            var dialogAnswer = MessageBox.Show(@"The entered data will not be saved.",
                @"Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogAnswer == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Создание заметки, для добавления и редактирования
        /// </summary>
        private void NewNote()
        {
            try
            {
                TepmNote.Title = NameNoteTextBox.Text;
                TepmNote.TimeCreate = TimeCreateDateTimePicker.Value;
                TepmNote.TimeLastChange = DateTime.Now;
                TepmNote.TextNote = TextNoteTextBox.Text;
                var notesCategory = (NotesCategory) NoteCategoryComboBox.SelectedItem;
                TepmNote.NoteCategory = notesCategory ;
                DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка введеных данных на правильность и верность
        /// </summary>
        private void NameNoteTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = NameNoteTextBox.Text;
            int lengt;
            lengt = text.Length;
            if (lengt > 50)
            {
                NameNoteTextBox.BackColor = Color.LightCoral;
            }
            else
            {
                NameNoteTextBox.BackColor = Color.White;
            }

        }
    }
}
