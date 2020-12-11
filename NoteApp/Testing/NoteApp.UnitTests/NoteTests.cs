using System;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {
        [Test]
        public void Name_GoodName_ReturnsSameName()
        {
            //Setup
            var note = new Note();
            var sourceName = "Мы с Кежиком идем в качалку";
            var expectedName = sourceName;

            //Act
            note.Title = sourceName;
            var actualName = note.Title;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Text_GoodText_ReturnsSameText()
        {
            //Setup
            var note = new Note();
            var sourceName = "Мы с Кежиком идем в качалку на выходных";
            var expectedName = sourceName;

            //Act
            note.TextNote = sourceName;
            var actualName = note.TextNote;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Category_GoodCategory_ReturnsSameCategory()
        {
            //Setup
            var note = new Note();
            var sourceName = NotesCategory.Documents;
            var expectedName = sourceName;

            //Act
            note.NoteCategory = sourceName;
            var actualName = note.NoteCategory;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Create_GoodTimeCreate_ReturnsSameDate()
        {
            //Setup
            var note = new Note();
            var sourceName = new DateTime(2020,12,09);
            var expectedName = sourceName;

            //Act
            note.TimeCreate = sourceName;
            var actualName = note.TimeCreate;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Modify_GoodTimeModify_ReturnsSameDate()
        {
            //Setup
            var note = new Note();
            var sourceName = new DateTime(2020, 12, 09);
            var expectedName = sourceName;

            //Act
            note.TimeLastChange = sourceName;
            var actualName = note.TimeLastChange;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_BadName_ThrowsException()
        {
            //Setup
            var note = new Note();
            var sourceName ="Мы с Кежиком идем в качалку и нас никто и ничто не остоновит, ведь это хорошо для здоровья...Наверное :)";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    note.Title = sourceName;
                }
            );
        }

        [Test]
        public void Name_NoneName_ReturnsBasicName()
        {
            //Setup
            var note = new Note();
            var sourceName = "";
            var expectedName = "Безымянный";

            //Act
            note.Title = sourceName;
            var actualName = note.Title;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Clone_GoodClone_ReturnSameData()
        {
            //Setup
            var sourceCategory = NotesCategory.Work;
            var notesCategory = sourceCategory;
            var expectedNote = new Note
            {
                Title = "Работка",
                TextNote = "I love my work",
                NoteCategory = notesCategory,
                TimeCreate = new DateTime(2020, 12, 09),
                TimeLastChange = new DateTime(2020, 12, 09)
            };
            
            //Act
            var actualNote = expectedNote.Clone() as Note;
            var expected = JsonConvert.SerializeObject(expectedNote);
            var actual = JsonConvert.SerializeObject(actualNote);

            //Assert
            NUnit.Framework.Assert.AreEqual(expected, actual);
        }
    }
}