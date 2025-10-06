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
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "password"
            };

            List<ProjectData> oldProjects = app.Project.GetProjectList(account); // Сохраняет старый список

            ProjectData newProject = new ProjectData("newProject2");
            app.Project.Create(newProject);

            List<ProjectData> newProjects = app.Project.GetProjectList(account); // Сохраняет новый список
            oldProjects.Add(newProject);
            //oldProjects.Sort();
            //newProjects.Sort();
            ClassicAssert.AreEqual(oldProjects, newProjects);
        }
    }
}
