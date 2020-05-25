using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
namespace GameEngine.Tests
{
    public class GameStateFixture : IDisposable
    {
        public GameState GState { private set; get; }

        public ExtentReports _extent;
        public ExtentTest _test;

        public GameStateFixture()
        {
            GState = new GameState();
            setUpReportGenerator();
        }

        private void setUpReportGenerator()
        {
            /*
            _extent = new ExtentReports();
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
            var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
            _extent.AddSystemInfo("Environment", "Journey of Quality");
            _extent.AddSystemInfo("User Name", "JIM");
            _extent.AttachReporter(htmlReporter);
            */
        }

        public void Dispose()
        {
            //cleanUp
            /*
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = “” +TestContext.CurrentContext.Result.StackTrace + “”;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, “Test ended with ” +logstatus + ” – ” +errorMessage);
                        _test.Log(logstatus, “Snapshot below: ” +_test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, “Test ended with ” +logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, “Test ended with ” +logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }*/
        }
    }
}
