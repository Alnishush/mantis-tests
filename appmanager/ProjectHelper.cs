using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { } // Ссылка на менеджер

        public void Create(ProjectData newProject)
        {
            OpenProjectsTab();
            SubmitCreateNewProject();
            //Thread.Sleep(2000);
            FillProjectForm(newProject);
            SubmitAddProject();
        }

        public void OpenProjectsTab()
        {
            driver.Url = "http://localhost/mantisbt-2.27.1/manage_proj_page.php";
        }

        public void SubmitCreateNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
        }

        public void SubmitAddProject()
        {
            driver.FindElement(By.XPath("//div[3]/input")).Click();
        }
    }
}
