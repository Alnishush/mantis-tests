using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                Type(By.Name("name"), project.ProjectName);
            }

            public void SubmitAddProject()
            {
                driver.FindElement(By.XPath("//div[3]/input")).Click();
            }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            OpenProjectsTab();

            // Находим все строки проектов
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tbody.tr")); // тут может быть неправильно

            foreach (IWebElement element in elements)
            {
                // Находим все колонки в строке
                IList<IWebElement> column = element.FindElements(By.TagName("td")); //тут может быть проблема в поиске названия, т.к. оно находится между тегами <a>

                // Извлекаем название проекта
                string projectName = column[0].Text;

                projects.Add(new ProjectData(projectName));
            }
            return projects;
        }
    }
}
