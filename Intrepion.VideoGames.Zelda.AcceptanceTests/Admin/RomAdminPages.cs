using Bogus;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Intrepion.VideoGames.Zelda.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class RomAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        var faker = new Faker();
        var aRandomString = faker.Random.String2(10);
        var someRandomString = faker.Random.String2(10);
        await Page.GetByTestId("romNavLink").ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Add");

        await Page.GetByLabel("File Name:", new() { Exact = true }).FillAsync("aFileName" + aRandomString);
        await Page.GetByLabel("Is Test?:", new() { Exact = true }).CheckAsync();
        await Page.GetByLabel("SHA256 Sum:", new() { Exact = true }).FillAsync("aSha256Sum" + aRandomString);
        // CreatePropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom View");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Edit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Edit");

        await Page.GetByLabel("File Name:", new() { Exact = true }).FillAsync("someFileName" + someRandomString);
        await Page.GetByLabel("Is Test?:", new() { Exact = true }).CheckAsync();
        await Page.GetByLabel("SHA256 Sum:", new() { Exact = true }).FillAsync("someSha256Sum" + someRandomString);
        // ModifyPropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom View");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Delete" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Back to Grid" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Rom Home");
    }

    [SetUp]
    public async Task SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
        if (string.IsNullOrEmpty(baseUrl))
        {
            baseUrl = "http://localhost:5043";
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
