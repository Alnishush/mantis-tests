using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_defaults_inc.php");
            using (Stream localFile = File.Open("config_defaults_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_defaults_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "mantis",
                Password = "mantis",
                Email = "mantis@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts(); //10
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name); //10
            if (existingAccount != null) //10
            {
                app.Admin.DeleteAccount(existingAccount); //10
            }

            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_defaults_inc.php");
        }
    }
}
