using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightUltimate.PageObjects
{
    internal class UltimateQaPage(IPage page)
    {
        private const string UltimateQaTargetPage = "https://courses.ultimateqa.com/enrollments";

        // Locators



        // Methods

        public async Task GoToUltimateQaPage()
        {
            await page.GotoAsync(UltimateQaTargetPage);
        }
    }
}
