using System;
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
            var sourceName = "�� � ������� ���� � �������";
            var expectedName = sourceName;

            //Act
            note.Title = sourceName;
            var actualName = note.Title;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
            
        }

        [Test]
        public void Name_BadName_ThrowsException()
        {
            //Setup
            var note = new Note();
            var sourceName = "�� � ������� ���� � ������� � ��� ����� � ����� �� ���������, ���� ��� ������ ��� ��������...�������� :)";

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
            var expectedName = "����������";

            //Act
            note.Title = sourceName;
            var actualName = note.Title;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
            
        }
    }
}