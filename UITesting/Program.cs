using System;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace UITesting
{
    class Program
    {
        static async Task Main()
        {
            await ManyBrowser();
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

            System.Threading.Thread.Sleep(3000);
        }


        static async Task ManyContext()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 50,
            });

            var desktopFirefox = playwright.Devices["Desktop Firefox"];
            var pixel2 = playwright.Devices["Pixel 2"];

            if (desktopFirefox is not null && desktopFirefox.ViewportSize is not null)
            {
                desktopFirefox.ViewportSize.Width = 1920;
                desktopFirefox.ViewportSize.Height = 1080;
            }

            var desktopFirefoxContext = await browser.NewContextAsync(desktopFirefox);
            var pixel2context = await browser.NewContextAsync(pixel2);

            var desktopFirefoxPage = await desktopFirefoxContext.NewPageAsync();
            var pixel2page = await pixel2context.NewPageAsync();
            
            await pixel2page.GotoAsync("https://playwright.dev/dotnet");
            await desktopFirefoxPage.GotoAsync("https://playwright.dev/dotnet");

            await pixel2page.ScreenshotAsync(new() { Path = "pixel2Screenshot.png" });
            await desktopFirefoxPage.ScreenshotAsync(new() { Path = "dekstopFirefoxScreenshot.png" });
        }

        static async Task ManyBrowser()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var chromiumBrowser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 50,
            });
            await using var webKitBrowser = await playwright.Webkit.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 50,
            });
            await using var firefoxBrowser = await playwright.Firefox.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 50,
            });

            var chromeCtx = await chromiumBrowser.NewContextAsync();
            var wkCtx = await webKitBrowser.NewContextAsync();
            var ffCtx = await firefoxBrowser.NewContextAsync();

            var chromePage = await chromeCtx.NewPageAsync();
            var wkPage = await wkCtx.NewPageAsync();
            var ffPage = await ffCtx.NewPageAsync();

            await chromePage.GotoAsync("https://playwright.dev/dotnet");
            await wkPage.GotoAsync("https://playwright.dev/dotnet");
            await ffPage.GotoAsync("https://playwright.dev/dotnet");

            await chromePage.ScreenshotAsync(new() { Path = "ChromeScreenshot.png" });
            await wkPage.ScreenshotAsync(new() { Path = "WebKitScreenshot.png" });
            await ffPage.ScreenshotAsync(new() { Path = "FireFoxScreenshot.png" });
        }
    }
}
