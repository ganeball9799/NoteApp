using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTests
    {
        public Project PrepareProject()
        {
            var sourseProject = new Project();
            sourseProject.Notes.Add(new Note()
            {
                Title = "Note",
                TextNote = "Text",
                NoteCategory = NotesCategory.Documents,
                TimeCreate = new DateTime(2020, 12, 09),
                TimeLastChange = new DateTime(2020, 12, 09)
            });
            sourseProject.Notes.Add(new Note()
            {
                Title = "Note2",
                TextNote = "Text2",
                NoteCategory = NotesCategory.Work,
                TimeCreate = new DateTime(2020, 12, 09),
                TimeLastChange = new DateTime(2020, 12, 09)
            });
            return sourseProject;
        }

        [Test]
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            // Setup
            var sourceProject = PrepareProject();
            var testDataFolder = Routes.DataFolderForTest();
            var actualFileName = testDataFolder + @"\actualProject.json";
            var expectedFileName = testDataFolder + @"\expectedProject.json";
            if (File.Exists(actualFileName))
            {
                File.Delete(actualFileName);
            }

            // Act
            ProjectManager.SaveToFile(sourceProject, actualFileName, testDataFolder);

            var isFileExist = File.Exists(actualFileName);
            Assert.AreEqual(true, isFileExist);

            // Assert
            var actualFileContent = File.ReadAllText(actualFileName);
            var expectedFileContent = File.ReadAllText(expectedFileName);
            NUnit.Framework.Assert.AreEqual(expectedFileContent, actualFileContent);
        }
        
        [Test]
        public void LoadFromFile_CorrectProject_FileLoadedCorrectly()
        {
            //Setup
            var expectedProject = PrepareProject();
            var testDataFolder = Routes.DataFolderForTest();
            var testFileName = testDataFolder + @"\expectedProject.json";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testFileName);
            
            //Assert
            Assert.AreEqual(expectedProject.Notes.Count, actualProject.Notes.Count);

            Assert.Multiple(() =>
                {
                    for (int i = 0; i < expectedProject.Notes.Count; i++)
                    {
                        Assert.AreEqual(expectedProject.Notes[i], actualProject.Notes[i]);
                    }
                });
        }

        [Test]
        public void LoadFromFile_UnCorrectPath_ReturnEmptyProject()
        {
            //Setup
            var testFileName = Routes.DataFolderForTest() + "wrong";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testFileName);

            //Assert
            Assert.IsEmpty(actualProject.Notes);
        }

        [Test]
        public void LoadFromFile_UnCorrectFile_ReturnEmptyProject()
        {
            //Setup
            var testDataFolder = Routes.DataFolderForTest();
            var testFileName = testDataFolder + @"\defectiveProject.json";

            //Act
            var actualProject = ProjectManager.LoadFromFile(testFileName);

            //Assert
            Assert.IsEmpty(actualProject.Notes);
        }

        [Test]
        public void FilePath_GoodFilePath_ReturnSamePath()
        {
            //Setup
            var expectedPath = Routes.FilePath();
            //Act
            var actualPath = ProjectManager.PathFile();

            //Assert
            Assert.AreEqual(expectedPath, actualPath);
        }

        [Test]
        public void DirectoryPath_GoodDirectoryPath_ReturnSameDirectory()
        {
            //Setup
            var expectedPath = Routes.DirectoryPath();
            //Act
            var actualPath = ProjectManager.PathDirectory();

            //Assert
            Assert.AreEqual(expectedPath, actualPath);
        }
    }
}