using Bogus;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Intrepion.VideoGames.Zelda.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class RomTextAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        var faker = new Faker();
        var aRandomString = faker.Random.String2(10);
        var someRandomString = faker.Random.String2(10);
        await Page.GetByTestId("romTextNavLink").ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Text Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Text Add");

        await Page.GetByLabel("Is Test?:", new() { Exact = true }).CheckAsync();
        await Page.GetByLabel("Name:", new() { Exact = true }).FillAsync("aName" + aRandomString);
        await Page.GetByLabel("Text:", new() { Exact = true }).FillAsync("aText" + aRandomString);
        // CreatePropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Text View");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Edit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Text Edit");

        await Page.GetByLabel("Is Test?:", new() { Exact = true }).CheckAsync();
        await Page.GetByLabel("Name:", new() { Exact = true }).FillAsync("someName" + someRandomString);
        await Page.GetByLabel("Text:", new() { Exact = true }).FillAsync("someText" + someRandomString);
        // ModifyPropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Text View");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Delete" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Back to Grid" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Text Home");
    }

    [SetUp]
    public async Task SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
        if (string.IsNullOrEmpty(baseUrl))
        {
            baseUrl = "http://localhost:5142";
        }
        await Page.GotoAsync(baseUrl);

        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@Intrepion.VideoGames.Zelda.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@Intrepion.VideoGames.Zelda.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();
    }
}
