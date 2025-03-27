using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RDLC2022
{
    public partial class Form1 : Form
    {
        private readonly ReportViewer reportViewer;
        public Form1()
        {
            InitializeComponent();

            Text = "Report viewer";
            WindowState = FormWindowState.Maximized;
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer);
            Application.DoEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Report.Load(reportViewer.LocalReport);
            reportViewer.RefreshReport();
            //base.OnLoad(e);
        }
    }
}
