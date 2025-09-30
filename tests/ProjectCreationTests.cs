using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase // было  : TestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            ProjectData newProject = new ProjectData("newProject3");
            
            app.Project.Create(newProject);

            // Проверяем, что проект появился в таблице
            ClassicAssert.IsTrue(app.Project.IsProjectInTable(newProject.Name),
                $"Проект '{newProject.Name}' должен отображаться в таблице");
        }

    }
}
