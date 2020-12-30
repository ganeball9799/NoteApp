namespace NoteAppUI
{
    partial class NoteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameNoteTextBox = new System.Windows.Forms.TextBox();
            this.NoteCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.TimeCreateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TimeUpdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TextNoteTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Created:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(215, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modified:";
            // 
            // NameNoteTextBox
            // 
            this.NameNoteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameNoteTextBox.Location = new System.Drawing.Point(79, 11);
            this.NameNoteTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.NameNoteTextBox.MaximumSize = new System.Drawing.Size(750, 20);
            this.NameNoteTextBox.Name = "NameNoteTextBox";
            this.NameNoteTextBox.Size = new System.Drawing.Size(563, 20);
            this.NameNoteTextBox.TabIndex = 4;
            this.NameNoteTextBox.TextChanged += new System.EventHandler(this.NameNoteTextBox_TextChanged);
            // 
            // NoteCategoryComboBox
            // 
            this.NoteCategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoteCategoryComboBox.FormattingEnabled = true;
            this.NoteCategoryComboBox.Location = new System.Drawing.Point(79, 37);
            this.NoteCategoryComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.NoteCategoryComboBox.MinimumSize = new System.Drawing.Size(20, 0);
            this.NoteCategoryComboBox.Name = "NoteCategoryComboBox";
            this.NoteCategoryComboBox.Size = new System.Drawing.Size(179, 21);
            this.NoteCategoryComboBox.TabIndex = 5;
            // 
            // TimeCreateDateTimePicker
            // 
            this.TimeCreateDateTimePicker.CustomFormat = "dd.MM.yyyy hh:mm";
            this.TimeCreateDateTimePicker.Enabled = false;
            this.TimeCreateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeCreateDateTimePicker.Location = new System.Drawing.Point(79, 64);
            this.TimeCreateDateTimePicker.Name = "TimeCreateDateTimePicker";
            this.TimeCreateDateTimePicker.Size = new System.Drawing.Size(123, 20);
            this.TimeCreateDateTimePicker.TabIndex = 6;
            this.TimeCreateDateTimePicker.Value = new System.DateTime(2020, 11, 24, 0, 0, 0, 0);
            // 
            // TimeUpdateDateTimePicker
            // 
            this.TimeUpdateDateTimePicker.CustomFormat = "dd.MM.yyyy hh:mm";
            this.TimeUpdateDateTimePicker.Enabled = false;
            this.TimeUpdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimeUpdateDateTimePicker.Location = new System.Drawing.Point(272, 65);
            this.TimeUpdateDateTimePicker.Name = "TimeUpdateDateTimePicker";
            this.TimeUpdateDateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.TimeUpdateDateTimePicker.TabIndex = 7;
            this.TimeUpdateDateTimePicker.Value = new System.DateTime(2020, 11, 24, 0, 0, 0, 0);
            // 
            // TextNoteTextBox
            // 
            this.TextNoteTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextNoteTextBox.Location = new System.Drawing.Point(18, 91);
            this.TextNoteTextBox.Multiline = true;
            this.TextNoteTextBox.Name = "TextNoteTextBox";
            this.TextNoteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextNoteTextBox.Size = new System.Drawing.Size(628, 307);
            this.TextNoteTextBox.TabIndex = 8;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(470, 406);
            this.OkButton.Margin = new System.Windows.Forms.Padding(5);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(83, 28);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelButton.Location = new System.Drawing.Point(563, 406);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(83, 28);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 442);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TextNoteTextBox);
            this.Controls.Add(this.TimeUpdateDateTimePicker);
            this.Controls.Add(this.TimeCreateDateTimePicker);
            this.Controls.Add(this.NoteCategoryComboBox);
            this.Controls.Add(this.NameNoteTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(437, 370);
            this.Name = "NoteForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Note";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameNoteTextBox;
        private System.Windows.Forms.ComboBox NoteCategoryComboBox;
        private System.Windows.Forms.DateTimePicker TimeCreateDateTimePicker;
        private System.Windows.Forms.DateTimePicker TimeUpdateDateTimePicker;
        private System.Windows.Forms.TextBox TextNoteTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}