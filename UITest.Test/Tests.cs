using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest.Test
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        private TimeSpan interval = new TimeSpan(0, 2, 0);

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.WaitForElement(c => c.Marked("ToggleTestMode"));
        }

        [Test]
        public void CanSwitchAutomationIdMode()
        {  
            // 1: verify that entry is not found yet
            var entry = app.Query(c => c.All().Marked("UsernameEntryId"));
            Assert.AreEqual(0, entry.Count());
            // 2: tap the ToggleTestMode button
            app.Tap(c => c.Marked("ToggleTestMode"));
            // 3: wait for ToggleTestMode to reappear
            var button = app.WaitForElement(c => c.Marked("ToggleTestMode"));
            // 4: query for UsernameEntryId again using the AutomationId
            var entrySecondQuery = app.Query(c => c.Marked("UsernameEntryId"));
            // 5: verify that UsernameEntryId is found 
            Assert.AreEqual(1, entrySecondQuery.Count());
        }

        [Test]
        public void IdentifyElementsWithAutomationId()
        {
            // 1: verify that the entry, username label and button are not found yet
            var entry = app.Query(c => c.All().Marked("UsernameEntryId"));
            var label = app.Query(c => c.All().Marked("UsernameLabelId"));
            var deviceLabel = app.Query(c => c.All().Marked("DeviceLabelId"));
            var androidButton = app.Query(c => c.All().Marked("AndroidRadioButtonId"));
            var iOSButton = app.Query(c => c.All().Marked("iOSRadioButtonId"));
            Assert.AreEqual(0, entry.Count());
            Assert.AreEqual(0, label.Count());
            Assert.AreEqual(0, deviceLabel.Count());
            Assert.AreEqual(0, androidButton.Count());
            Assert.AreEqual(0, iOSButton.Count());
            // 2: tap the ToggleTestMode button
            app.Tap(c => c.Marked("ToggleTestMode"));
            // 3: wait for ToggleTestMode to reappear
            var toggleTestModeButton = app.WaitForElement(c => c.Marked("ToggleTestMode"));
            // 4: query for the entry, labels and buttons again using their AutomationId
            var entrySecondQuery = app.Query(c => c.Marked("UsernameEntryId"));
            var labelSecondQuery = app.Query(c => c.Marked("UsernameLabelId"));
            var deviceLabelSecondQuery = app.Query(c => c.All().Marked("DeviceLabelId"));
            var androidButtonSecondQuery = app.Query(c => c.All().Marked("AndroidRadioButtonId"));
            var iOSButtonSecondQuery = app.Query(c => c.All().Marked("iOSRadioButtonId"));
            // 5: verify that the entry, labels and buttons are found 
            Assert.AreEqual(1, entrySecondQuery.Count());
            Assert.AreEqual(1, labelSecondQuery.Count());
            Assert.AreEqual(1, deviceLabelSecondQuery.Count());
            Assert.AreEqual(1, androidButtonSecondQuery.Count());
            Assert.AreEqual(1, iOSButtonSecondQuery.Count());
            // 6: enter text in UsernameEntryId
            app.EnterText(c => c.Marked("UsernameEntryId"), "Xamarin");
            // 7: wait for text input
            app.WaitForElement(c => c.Marked("UsernameEntryId").Text("Xamarin"), "Timed out waiting for text entry", interval);
            // 8: verify that the text on UsernameLabelId matches text on UsernameEntryId
            var labelTextMatchedWithEntry = app.Query(c => c.Marked("UsernameLabelId").Text("Xamarin"));
            Assert.AreEqual(1, labelTextMatchedWithEntry.Count());
        }
    }
}
