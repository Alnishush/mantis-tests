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
            //Thread.Sleep(2000);
            SubmitCreateNewProject();
            //Thread.Sleep(2000);
            FillProjectForm(newProject);
            //Thread.Sleep(2000);
            SubmitAddProject();
        }

            public void OpenProjectsTab()
            {
                driver.Url = "http://localhost/mantisbt-2.27.1/manage_proj_page.php";
            }

            public void SubmitCreateNewProject()
            {
            driver.FindElement(By.CssSelector("form[action='manage_proj_create_page.php'] button[type='submit']")).Click();
        }

            public void FillProjectForm(ProjectData project)
            {
                Type(By.Name("name"), project.ProjectName);
            }

            public void SubmitAddProject()
            {
                driver.FindElement(By.CssSelector("input[value='Add Project']")).Click();
            }

        /*public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            OpenProjectsTab();

            // Находим ВСЕ ссылки проектов напрямую
            ICollection<IWebElement> projectLinks = driver.FindElements(
                By.CssSelector("table.table-bordered tbody tr td:first-child a")
            );

            foreach (IWebElement link in projectLinks)
            {
                string projectName = link.Text.Trim();
                projects.Add(new ProjectData(projectName));
            }

            return projects;
        }*/

        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            try
            {
                // Получение проектов через веб-сервис
                Mantis.ProjectData[] projectArray = client.mc_projects_get_user_accessible(account.Name, account.Password);

                // Преобразование массива в список
                foreach (Mantis.ProjectData project in projectArray)
                {
                    projects.Add(new ProjectData()
                    {
                        ProjectName = project.name
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении проектов: " + ex.Message);
                throw;
            }
            return projects;
        }

        public void Remove(ProjectData projectToRemove)
        {
            OpenProjectsTab();
            SelectFirstProject();
            SubmitDeleteProjectButton();
            SubmitDeleteProjectButton2();
        }

            public void SelectFirstProject()
            {
                driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a")).Click();
            }

            public void SubmitDeleteProjectButton()
            {
                driver.FindElement(By.CssSelector("button[formaction='manage_proj_delete.php']")).Click();
            }

            public void SubmitDeleteProjectButton2()
            {
                driver.FindElement(By.CssSelector("input[value='Delete Project']")).Click();
            }
    }
}
