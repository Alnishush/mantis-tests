using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        /*public void Login()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "password"
            };

            app.Auth.Login(account);
        }*/

        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "password"
            };
            app.Auth.Login(account);

            ProjectData newProject = new ProjectData()
            {
                Name = "newProject2"
            };
            app.Project.Create(newProject);
        }
    }
}
