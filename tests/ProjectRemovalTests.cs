using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "password"
            };

            // Подготовка: убедимся, что есть хотя бы один проект для удаления
            ProjectData projectToRemove = new ProjectData("Test Project for Removal");

            // Получаем текущий список проектов
            List<ProjectData> oldProjects = app.Project.GetProjectList(account);

            // Если проектов нет, создаем один для удаления
            if (oldProjects.Count == 0)
            {
                /*app.Project.Create(projectToRemove);
                oldProjects = app.Project.GetProjectList(account);*/

                // Создаем проект через MantisConnect веб-сервис (mc_project_add)
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData projectData = new Mantis.ProjectData();
                projectData.name = "projectToRemove";

                client.mc_project_add("administrator", "password", projectData);
                oldProjects = app.Project.GetProjectList(account);
            }

            // Действие: удаляем проект
            app.Project.Remove(projectToRemove);

            // Проверка: получаем новый список проектов
            List<ProjectData> newProjects = app.Project.GetProjectList(account);

            // Убеждаемся, что количество проектов уменьшилось на 1
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1));

            // Убеждаемся, что удаленного проекта больше нет в списке
            CollectionAssert.DoesNotContain(newProjects, projectToRemove);
        }
    }
}
