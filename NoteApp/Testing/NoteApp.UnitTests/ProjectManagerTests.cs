using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTests
    {
        [Test]
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            // Setup
            var sourceProject = new Project();
            sourceProject.Notes.Add(new Note()
            {
                Title = "Note",
                TextNote = "Text",
                NoteCategory = NotesCategory.Documents,
                TimeCreate = new DateTime(2020,12,09),
                TimeLastChange = new DateTime(2020, 12, 09)
            });
            sourceProject.Notes.Add(new Note()
            {
                Title = "Note2",
                TextNote = "Text2",
                NoteCategory = NotesCategory.Work,
                TimeCreate = new DateTime(2020, 12, 09),
                TimeLastChange = new DateTime(2020, 12, 09)
            });

            var location = Assembly.GetExecutingAssembly().Location;
            var testDataFolder = Path.GetDirectoryName(location) + @"\TestData";
            Directory.CreateDirectory(testDataFolder);
            var actualFileName = testDataFolder + @"\actualProject.json";
            var expectedFileName = testDataFolder + @"\expectedProject.json";

            // Act
            ProjectManager.SaveToFile(sourceProject, actualFileName);

            // Assert
            var actualFileContent = File.ReadAllText(actualFileName);
            var expectedFileContent = File.ReadAllText(expectedFileName);
            NUnit.Framework.Assert.AreEqual(expectedFileContent, actualFileContent);
        }
    }
}