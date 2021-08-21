using System;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace UITesting
{
    class Program
    {
        static async Task Main()
        {
            await Pixel2Sample();
        }

        static async Task Sample()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 50,
            });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://playwright.dev/dotnet");
            await page.ScreenshotAsync(new() { Path = "screenshot.png" });
        }

        static async Task Pixel2Sample()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 50,
            });

            var pixel2 = playwright.Devices["Pixel 2"];
            var context = await browser.NewContextAsync(pixel2);
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://playwright.dev/dotnet");
            await page.ScreenshotAsync(new() { Path = "screenshot.png" });
        }
    }
}
