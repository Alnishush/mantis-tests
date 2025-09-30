using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase // было  : TestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            ProjectData newProject = new ProjectData("newProject");
            
            app.Project.Create(newProject);
        }
    }
}
