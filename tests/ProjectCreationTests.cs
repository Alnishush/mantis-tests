using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase // было  : TestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            List<ProjectData> oldProjects = app.Project.GetProjectList(); // Сохраняет старый список

            ProjectData newProject = new ProjectData("newProject");
            app.Project.Create(newProject);

            List<ProjectData> newProjects = app.Project.GetProjectList(); // Сохраняет новый список
            oldProjects.Add(newProject);
            oldProjects.Sort();
            newProjects.Sort();
            ClassicAssert.AreEqual(oldProjects, newProjects);

            // Проверяем, что проект появился в таблице
            //ClassicAssert.IsTrue(app.Project.IsProjectInTable(newProject.Name),
            //    $"Проект '{newProject.Name}' должен отображаться в таблице");
        }

    }
}
