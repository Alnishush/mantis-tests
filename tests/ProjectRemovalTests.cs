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
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {
            // Подготовка: убедимся, что есть хотя бы один проект для удаления
            ProjectData projectToRemove = new ProjectData("Test Project for Removal");

            // Получаем текущий список проектов
            List<ProjectData> oldProjects = app.Project.GetProjectList();

            // Если проектов нет, создаем один для удаления
            if (oldProjects.Count == 0)
            {
                app.Project.Create(projectToRemove);
                oldProjects = app.Project.GetProjectList();
            }

            // Действие: удаляем проект
            app.Project.Remove(projectToRemove);

            // Проверка: получаем новый список проектов
            List<ProjectData> newProjects = app.Project.GetProjectList();

            // Убеждаемся, что количество проектов уменьшилось на 1
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1));

            // Убеждаемся, что удаленного проекта больше нет в списке
            CollectionAssert.DoesNotContain(newProjects, projectToRemove);
        }
    }
}
