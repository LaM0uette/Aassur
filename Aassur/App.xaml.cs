﻿using System.Reflection;
using Aassur.Core.Data;

namespace Aassur;

public partial class App
{
    public static DbData DbData { get; } = new();
    
    public App()
    {
        CreateSqliteDbIfNotExist();
        InitializeComponent();
        
        MainPage = new AppShell();
    }

    private static void CreateSqliteDbIfNotExist()
    {
        const string resourceName = "Aassur.Core.DataBase.Aassur.db";
        var assembly = Assembly.GetExecutingAssembly();
        
        var destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Aassur");
        Directory.CreateDirectory(destinationDirectory);
        var destinationFile = Path.Combine(destinationDirectory, "Aassur.db");

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream is null) throw new InvalidOperationException("Could not find embedded resource");

        if (File.Exists(destinationFile)) return;
        using var fileStream = File.Create(destinationFile);
        stream.CopyTo(fileStream);
    }
    
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 1100;
        const int newHeight = 700;
        
        window.Width = newWidth;
        window.MinimumWidth = newWidth;
        window.Height = newHeight;
        window.MinimumHeight = newHeight;

        return window;
    }
}