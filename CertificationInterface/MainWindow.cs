using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Certification;
using Certification.Chapters.Objective_1;
using System.Diagnostics;
using CertificationInterface.Utilities;
using System.Net.Http;
using System.IO;

namespace CertificationInterface
{
    public partial class MainWindow : Form
    {
        private ManageProgramFlow multithreading_asynchronous_processing;

        public MainWindow()
        {
            InitializeComponent();
            multithreading_asynchronous_processing = new ManageProgramFlow();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        //LISTING 1-20 Using ConfigureAwait
        //LISTING 1-21 Continuing on a thread pool instead of the UI thread
        private async void btn_ConfigureAwait_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string content = await httpClient
            .GetStringAsync("http://www.microsoft.com")
            .ConfigureAwait(false);

            using (FileStream sourceStream = new FileStream("temp.html",
            FileMode.Create, FileAccess.Write, FileShare.None,
            4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(content);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
                .ConfigureAwait(false);
            };
        }

        
        

        private void btn_delegates_Click(object sender, EventArgs e)
        {
            
        }
    }
}
