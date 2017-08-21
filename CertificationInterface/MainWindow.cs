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
using Certification.Chapters.manage_program_flow;
using System.Diagnostics;
using CertificationInterface.Utilities;

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

        private void btn_thread_class_Click(object sender, EventArgs e)
        {
            multithreading_asynchronous_processing.UsingTaskFactory();
        }
    }
}
