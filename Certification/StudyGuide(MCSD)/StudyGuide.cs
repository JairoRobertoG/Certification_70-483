using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification.StudyGuide_MCSD_
{
    class StudyGuide
    {
        public StudyGuide()
        {
        }

        //Asynchronous File I/O
        public async void WriteAsyncFile()
        {
            FileStream file = File.Create("Sample.txt");
            StreamWriter writer = new StreamWriter(file);
            await writer.WriteAsync("Asynchronously Written Data example");
            writer.Close();
        }

        //Read from file
        public async void ReadFromFile()
        {
            FileStream readFile = File.Open("Sample.txt", FileMode.Open);
            StreamReader reader = new StreamReader(readFile);
            string result = await reader.ReadToEndAsync();
            Console.WriteLine(result);
        }
    }
}
