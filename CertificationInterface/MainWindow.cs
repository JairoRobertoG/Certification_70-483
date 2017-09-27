﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Certification;
using Certification.Chapters.manage_program_flow;
using System.Diagnostics;
using CertificationInterface.Utilities;
using System.Net.Http;
using System.IO;

namespace CertificationInterface
{
    public partial class MainWindow : Form
    {
        private MultithreadingAsynchronousProcessing multithreading_asynchronous_processing;

        public MainWindow()
        {
            InitializeComponent();
            multithreading_asynchronous_processing = new MultithreadingAsynchronousProcessing();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        //LISTING 1-20 Using ConfigureAwait
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
    }
}
