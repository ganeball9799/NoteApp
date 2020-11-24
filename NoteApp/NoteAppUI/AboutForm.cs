using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Переход по ссылке для написания сообщения
        /// </summary>
        private void LinkMail_Click(object sender, EventArgs e)
        {
            Process.Start("mailto://ganeball9799@mail.ru");
        }

        /// <summary>
        /// Переход к репозиторию проекта
        /// </summary>
        private void LinkGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ganeball9799/NoteApp");
        }
    }
}
