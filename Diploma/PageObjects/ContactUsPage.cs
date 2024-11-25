﻿using Microsoft.Playwright;

namespace Diploma.PageObjects;

internal class ContactUsPage(IPage? page)
{
    // Locators
    private ILocator NameInput => page!.Locator("//input[@name='name']");
    private ILocator EmailInput => page!.Locator("//input[@name='email']");
    private ILocator SubjectInput => page!.Locator("//input[@name='subject']");
    private ILocator MessageInput => page!.Locator("//textarea[@id='message']");

    private ILocator ChooseFileButton => page!.Locator("//input[@name='upload_file']");
    private ILocator SubmitButton => page!.Locator("//input[@name='submit']");

    // Methods
    public async Task FillContactUsForm(string name, string email, string subject, string message)
    {
        await NameInput.FillAsync(name);
        await EmailInput.FillAsync(email);
        await SubjectInput.FillAsync(subject);
        await MessageInput.FillAsync(message);
    }

    public async Task UploadImage()
    {
        var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\"));
        var imageDirectory = Path.Combine(projectDirectory, "Diploma", "TestArtefacts");
        var imagePath = Path.Combine(projectDirectory, "Diploma", "TestArtefacts", "test_image.jpg");

        if (!Directory.Exists(imageDirectory))
        {
            Directory.CreateDirectory(imageDirectory);
            Console.WriteLine($"Created Scripts directory at path: {imageDirectory}");
        }

        if (!File.Exists(imagePath))
        {
            throw new FileNotFoundException($"File is not found: {imagePath}");
        }

        await ChooseFileButton.SetInputFilesAsync(imagePath);
    }

    public async Task SubmitForm()
    {
        page!.Dialog += async (_, dialog) => { await dialog.AcceptAsync(); };

        await SubmitButton.ClickAsync();
    }
}