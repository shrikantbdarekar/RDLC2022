# RDLC Report in .NET 8 C# Windows Project

## Overview
Microsoft does not provide built-in tools or options for RDLC reporting in .NET 8. After extensive research and testing, the following solution worked for me.

## Prerequisites
Add the following NuGet packages using NuGet Package Manager:

- `ReportViewerCore.NETCore`
- `ReportViewerCore.WinForms`

These packages are maintained by [lkosson](https://github.com/lkosson/reportviewercore/).

## Implementation

### 1. Create the Report Class
Create a class named `Report` to load the RDLC report and provide data sources:

```csharp
class Report
{
    public static void Load(LocalReport report)
    {
        var items = new[]
        {
            new ReportItem { Description = "Widget 6000", Price = 104.99m, Qty = 1 },
            new ReportItem { Description = "Gizmo MAX", Price = 1.41m, Qty = 25 }
        };
        
        var parameters = new[] { new ReportParameter("Title", "Invoice 4/2020") };
        
        using var fs = new FileStream("Report1.rdlc", FileMode.Open);
        report.LoadReportDefinition(fs);
        report.DataSources.Add(new ReportDataSource("DataSet1", items));
        report.SetParameters(parameters);
    }
}
```

### 2. Create the Report Item Class
Create a `ReportItem` class to define the data structure:

```csharp
public class ReportItem
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Qty { get; set; }
    public decimal Total => Price * Qty;
}
```

### 3. Implement the Report Viewer in a Windows Form
In the form where you want to display the report, use the following code:

```csharp
public partial class Form1 : Form
{
    private readonly ReportViewer reportViewer;
    
    public Form1()
    {
        InitializeComponent();
        
        Text = "Report Viewer";
        WindowState = FormWindowState.Maximized;
        reportViewer = new ReportViewer { Dock = DockStyle.Fill };
        this.Controls.Add(reportViewer);
        Application.DoEvents();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Report.Load(reportViewer.LocalReport);
        reportViewer.RefreshReport();
    }
}
```

## Conclusion
This setup enables RDLC reports in a .NET 8 C# Windows Forms project using `ReportViewerCore.NETCore` and `ReportViewerCore.WinForms`.

For more details, refer to the official [ReportViewerCore repository](https://github.com/lkosson/reportviewercore/).

