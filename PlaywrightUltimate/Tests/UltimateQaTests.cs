using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightUltimate.PageObjects;

namespace PlaywrightUltimate.Tests
{
    internal class UltimateQaTests : UiTestFixture
    {
        private UltimateQaPage _ultimateQaPage;

        [SetUp]
        public void SetupUltimateQaPage()
        {
            _ultimateQaPage = new UltimateQaPage(Page);
        }

        [Test]
        public async Task GoToUltimateQaPage()
        {
            await _ultimateQaPage.GoToUltimateQaPage();
        }
    }
}
