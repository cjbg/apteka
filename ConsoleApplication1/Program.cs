using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CsvConverter
{
    public class CsvConversion
    {

        static void DeleteFirstLine(StreamReader reader, StreamWriter writer)
        {            
            string line;
            bool firsLinePassed = false;
            while ((line = reader.ReadLine()) != null)
            {                
                if (firsLinePassed == false)
                {
                    Console.WriteLine("Usuniecie lini");
                    firsLinePassed = true;
                    continue;
                }
                
                writer.WriteLine(line);               
            }
            writer.Close();
        }

        static void t_syno(StreamReader reader, StreamWriter writer)
        {
            string line;
            string[] lines;
            bool firsLinePassed = false;
            while ((line = reader.ReadLine()) != null)
            {
                if (firsLinePassed == false)
                {
                    Console.WriteLine("Usuniecie lini");
                    firsLinePassed = true;
                    continue;
                }
                else
                {
                    lines = line.Split(';');
                    line = lines[0] + ';' + lines[1];
                }

                writer.WriteLine(line);                
            }
            writer.Close();
        }

        static void t_informacje(StreamReader reader, StreamWriter writer, StreamReader reader1)
        {
            string line,line1;
            string[] lines, lines1;
            bool firsLinePassed = false;
            while ((line = reader.ReadLine()) != null)
            {
                line1 = reader1.ReadLine();
                if (firsLinePassed == false)
                {
                    Console.WriteLine("Usuniecie lini");
                    firsLinePassed = true;
                    continue;
                }
                else
                {
                    lines = line.Split(';');
                    lines1 = line1.Split(';');
                    line = lines[0] + ';' + lines[6] + ';' + lines[11] + ';' + lines[12] + ';' + lines1[11] + ';' + lines[18]
                        + ';' + lines[15] + ';' + lines[16] + ';' + lines[19] + ';' + lines[20] + ';' + lines[21]
                        + ';' + lines[22] + ';' + lines[23] + ';' + lines[24] + ';' + lines[25] + ';' + lines[27]
                        + ';' + lines[28] + ';' + lines[29] + ';' + lines[30] + ';' + lines[31] + ';' + lines[32]
                        + ';' + lines[35] + ';' + lines[33] + ';' + lines[36] + ';' + lines[37] + ';' + lines[39] + ';' + lines[34] + ';' + lines[43];
                    line = line.Replace('N', '0');
                    line = line.Replace('T', '1');
                }

                writer.WriteLine(line);
            }
            writer.Close();
        }

        static void t_leki(StreamReader reader, StreamWriter writer)
        {
            string line;
            string[] lines;
            bool firsLinePassed = false;
            while ((line = reader.ReadLine()) != null)
            {
                if (firsLinePassed == false)
                {
                    Console.WriteLine("Usuniecie lini");
                    firsLinePassed = true;
                    continue;
                }
                else
                {
                    lines = line.Split(';');
                    line = lines[0] + ';' + lines[1] + ';' + lines[2] + ';' + lines[4] + ';' + lines[5] + ';' + lines[6];
                }

                writer.WriteLine(line);
            }
            writer.Close();
        }

        [STAThread]
        static void Main(string[] args)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Csv File|*.csv";
            saveFileDialog1.Title = "Save an Csv File";            

            char a;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            String filePath;
            //String tempFile = Path.GetTempFileName();           
             

            Console.WriteLine("Podaj ścieżkę do pliku");
            
            DialogResult result = openFileDialog.ShowDialog();       
            
            if (result == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                try
                {
                    StreamReader reader = new StreamReader(File.OpenRead(filePath));

                    Console.WriteLine("Wybierz rodzaj pliku\n1: internaz\n2: Refundacja - tranchor\n3: t_syno\n4: informacje\n5: Producenci\n6: t_leki");

                    a = Console.ReadKey().KeyChar;

                    saveFileDialog1.ShowDialog();

                    StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);

                    switch (a)
                    {
                        //Usunięcie pierwszej lini
                        case '1':

                            DeleteFirstLine(reader, writer);

                            break;
                        case '2':

                            DeleteFirstLine(reader,writer);

                            break;
                        case '3':

                            t_syno(reader, writer);

                            break;

                        case '4':

                            Console.WriteLine("Podaj parametry sprzedarzy - PARAMETR.CSV");
                            OpenFileDialog openFileDialog1 = new OpenFileDialog();
                            DialogResult result1 = openFileDialog1.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                StreamReader reader1 = new StreamReader(File.OpenRead(openFileDialog1.FileName));
                                t_informacje(reader, writer, reader1);
                            }
                            else
                            {
                                Console.WriteLine("Bug");
                            }
                            break;

                        case '5':

                            DeleteFirstLine(reader, writer);

                            break;

                        case '6':

                            t_leki(reader, writer);

                            break;
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }                
            }
            else
            {
                Console.WriteLine("Bug");
            }
            
            Console.ReadLine();
        }
    }
}
