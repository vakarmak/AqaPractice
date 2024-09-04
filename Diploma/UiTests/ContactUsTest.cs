﻿using Diploma.PageObjects;
using Microsoft.Playwright;

namespace Diploma.UiTests;

internal class ContactUsTest : UiTestFixture
{
    private HomePage _homePage;
    private ContactUsPage _contactUsPage;
    
    [SetUp]
    public void SetUpPages()
    {
        _homePage = new HomePage(Page);
        _contactUsPage = new ContactUsPage(Page!);
    }
    
    [Test]
    public async Task ContactUs()
    {
        // Arrange
        var name = UserData["name"];
        var email = UserData["email"];
        const string subject = "Test";
        const string message = "This is a test message";
        
        // Act
        await _contactUsPage.GoToContactUsPage();
        await _contactUsPage.IsGetInTouchTitleVisible();
        await _contactUsPage.FillContactUsForm(name, email, subject, message);
        await _contactUsPage.UploadImage();
        await _contactUsPage.SubmitForm();
        await _homePage.GoToHomePage();
        
        // Assert
        await _homePage.VerifyHomePageIsOpened();
    }
}