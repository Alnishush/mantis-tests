//10
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient(); //объект через который можно обращаться к операциям
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;           //поле
            issue.description = issueData.Description;   //поле
            issue.category = issueData.Category;         //поле
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;               //поле
            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
