using System;
using System.Linq;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Text;

namespace TestMonitor
{

    class Testing
    {
        [STAThread]
        static void Main(string[] args)
    {
            

            Run(args[0], args[1]);
            Console.Read();
            
    }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run(string Path2, string Filter2)
        {
            Encoding Pepega = new UTF8Encoding(true);
            string CurseStatus = "";
            Console.WriteLine("Выбранный путь: " + Path2);


            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = Path2;

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

                string filterkeks = Filter2;

                watcher.Filter = filterkeks;

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;
                
                Console.WriteLine("Напишите \"STOP\" для остановки работы программы");

                while (Console.ReadLine() != "STOP") ;
            }

            void OnChanged(object source, FileSystemEventArgs e)
            {
                Thread.Sleep(100);
                try {
                    
                    
                    byte[] content = File.ReadAllBytes(e.FullPath);
                    string kekes = ConvertByteToHex(content);
                    
                    var BaseSig = File.ReadAllLines("BaseSign.txt");
                    bool flag = false;
                    int buff = 0;
                    var Journall = File.Open("D:\\Journal.txt", FileMode.Append);
                    string Bufff;
                    


                    for (int i = 0; i < BaseSig.Length; i++)
                    {
                        if (kekes.Contains(BaseSig[i]))
                        {
                            flag = true;
                            buff = i;
                            if ((double)BaseSig[i].Length / (double)kekes.Length <= 0.95)
                            {
                                CurseStatus = "Quarantine";
                            }
                            else { CurseStatus = "Delete"; }
                        }
                    }

                    if (flag == true && CurseStatus == "Quarantine")
                    {
                            Console.WriteLine($"{e.FullPath} Обнаружен вредоносный файл! Перемещение в карантин...");
                            
                            var QuarantineJourRead = File.ReadAllLines("D:\\Quarantine\\QuarantineJournal.txt");
                            var QuarantineJourWrite = File.Open("D:\\Quarantine\\QuarantineJournal.txt", FileMode.Append);
                            string FirstBytes = FirstBytesOfFile(kekes, 50);
                            string NameQuarr = e.FullPath.Remove(0,e.FullPath.LastIndexOf("\\")+1);
                            int IDentify = QuarantineJourRead.Length;
                            string filePath = e.FullPath;
                            string buffQuar = $"ID:{IDentify};{NameQuarr};{filePath};{FirstBytes}\n";

                            byte[] infoJuorQuar = new UTF8Encoding(true).GetBytes(buffQuar);
                            QuarantineJourWrite.Write(infoJuorQuar, 0, infoJuorQuar.Length);
                            QuarantineJourWrite.Close();
                            
                            kekes = CuringFile(kekes, FirstBytes);
                           
                            var Cured1 = File.Open(e.FullPath, FileMode.Truncate);
                            byte[] CuredByte = ConvertHexToByte(kekes);
                            
                            byte[] bom = Pepega.GetPreamble();
                            Cured1.Write(bom, 0, bom.Length);
                            Cured1.Write(CuredByte, 0, CuredByte.Length);
                            Cured1.Close();
                            var Cured2 = File.Open(e.FullPath, FileMode.Open);
                            Cured2.Write(bom, 0, bom.Length);
                            Cured2.Write(CuredByte, 0, CuredByte.Length);
                            Cured2.Close();
                           
                            File.Move(e.FullPath, $"D:\\Quarantine\\{IDentify}.quarantine");
                            Console.WriteLine($"{e.FullPath} Успешно перемещен в карантин!");
                            Bufff = DateTime.Now.ToString() + $":{e.FullPath} Обнаружен вредоносный файл! Перемещен в карантин с идентификатором:{IDentify}!\n";
                            byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
                            Journall.Write(infoJuor, 0, infoJuor.Length);
                            Journall.Close();
                    }
                    else if (flag == true && CurseStatus == "Delete")
                    {
                        
                        Bufff = DateTime.Now.ToString() + $": {e.FullPath} Обнаружен вредоносный файл! Удален из-за высокой концентрации вредоносных сигнатур!\n";
                        byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
                        Journall.Write(infoJuor, 0, infoJuor.Length);
                        Journall.Close();
                        File.Delete(e.FullPath);
                        Console.WriteLine($"{e.FullPath} Обнаружен вредоносный файл! Удален из-за высокой концентрации вредоносных сигнатур!");
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToString() + $"  {e.FullPath} Файл чист!");
                        Bufff = DateTime.Now.ToString() + $": {e.FullPath} После проверки файл оказался чист! \n";
                        byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
                        Journall.Write(infoJuor, 0, infoJuor.Length);
                        Journall.Close();
                    }
                    

                }
                catch(Exception err)
                {
                    Console.WriteLine("", err);
                }
                }

            void OnRenamed(object source, RenamedEventArgs e)
            {
                Thread.Sleep(100);
                try {
                    
                    byte[] content = File.ReadAllBytes(e.FullPath);
                    string kekes = ConvertByteToHex(content);
                   
                    var BaseSig = File.ReadAllLines("BaseSign.txt");
                    bool flag = false;
                    int buff = 0;
                    var Journall = File.Open("D:\\Journal.txt", FileMode.Append);
                    string Bufff;
                    for (int i = 0; i < BaseSig.Length; i++)
                    {
                        if (kekes.Contains(BaseSig[i]))
                        {
                            flag = true;
                            buff = i;
                            if ((double)BaseSig[i].Length / (double)kekes.Length <= 0.95)
                            {
                                CurseStatus = "Quarantine";
                            }
                            else { CurseStatus = "Delete"; }
                        }
                    }

                    if (flag == true && CurseStatus == "Quarantine")
                    {
                        Console.WriteLine($"{e.FullPath} Обнаружен вредоносный файл! Перемещение в карантин...");

                        var QuarantineJourRead = File.ReadAllLines("D:\\Quarantine\\QuarantineJournal.txt");
                        var QuarantineJourWrite = File.Open("D:\\Quarantine\\QuarantineJournal.txt", FileMode.Append);
                        string FirstBytes = FirstBytesOfFile(kekes, 50);
                        string NameQuarr = e.FullPath.Remove(0,e.FullPath.LastIndexOf("\\")+1);
                        int IDentify = QuarantineJourRead.Length;
                        string filePath = e.FullPath;
                        string buffQuar = $"ID:{IDentify};{NameQuarr};{filePath};{FirstBytes}\n";

                        byte[] infoJuorQuar = new UTF8Encoding(true).GetBytes(buffQuar);
                        QuarantineJourWrite.Write(infoJuorQuar, 0, infoJuorQuar.Length);
                        QuarantineJourWrite.Close();

                        kekes = CuringFile(kekes, FirstBytes);

                        var Cured1 = File.Open(e.FullPath, FileMode.Truncate);
                        byte[] CuredByte = ConvertHexToByte(kekes);

                        byte[] bom = Pepega.GetPreamble();
                        Cured1.Write(bom, 0, bom.Length);
                        Cured1.Write(CuredByte, 0, CuredByte.Length);
                        Cured1.Close();
                        var Cured2 = File.Open(e.FullPath, FileMode.Open);
                        Cured2.Write(bom, 0, bom.Length);
                        Cured2.Write(CuredByte, 0, CuredByte.Length);
                        Cured2.Close();

                        File.Move(e.FullPath, $"D:\\Quarantine\\{IDentify}.quarantine");
                        Console.WriteLine($"{e.FullPath} Успешно перемещен в карантин!");
                        Bufff = DateTime.Now.ToString() + $":{e.FullPath} Обнаружен вредоносный файл! Перемещен в карантин с идентификатором:{IDentify}!\n";
                        byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
                        Journall.Write(infoJuor, 0, infoJuor.Length);
                        Journall.Close();
                    }
                    else if (flag == true && CurseStatus == "Delete")
                    {

                        Bufff = DateTime.Now.ToString() + $": {e.FullPath} Обнаружен вредоносный файл! Удален из-за высокой концентрации вредоносных сигнатур!\n";
                        byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
                        Journall.Write(infoJuor, 0, infoJuor.Length);
                        Journall.Close();
                        File.Delete(e.FullPath);
                        Console.WriteLine($"{e.FullPath} Обнаружен вредоносный файл! Удален из-за высокой концентрации вредоносных сигнатур!");
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToString() + $"  {e.FullPath} Файл чист!");
                        Bufff = DateTime.Now.ToString() + $": {e.FullPath} После проверки файл оказался чист! \n";
                        byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
                        Journall.Write(infoJuor, 0, infoJuor.Length);
                        Journall.Close();
                    }






                }
                catch (Exception err)
                {
                    Console.WriteLine("", err);
                }
            }

        }
        
        public static string ConvertByteToHex(byte[] byteData)
        {
            string hexValues = BitConverter.ToString(byteData);
            if (hexValues.Replace("-", "").Length % 2 != 0)
            {
                hexValues = 0 + hexValues;
            }
            hexValues = hexValues.Replace("-", " ");
            return hexValues;
        }

        public static byte[] ConvertHexToByte(string hexData)
        {

            hexData = hexData + " ";
            int Counter = hexData.Split(new string[] { " " }, StringSplitOptions.None).Count() - 1;
            byte[] buff = new byte[Counter];

            for (int i = 0; i < Counter - 1; i++)
            {
                buff[i] = Convert.ToByte(string.Concat(hexData[0], hexData[1]), 16);
                hexData = hexData.Remove(0, 3);
            }

            return buff;
        }
        public static string CuringFile(string mainText, string CursedSignature)
        {
            string buff = CursedSignature;
            string buff2 = "";
            do
            {
                if (buff.Length != 2)
                {
                    buff2 += "20 ";
                    buff = buff.Remove(0, 3);
                }
                else
                {
                    buff2 += "20";
                    buff = buff.Remove(0, 2);
                }
            } while (buff.Length != 0);
            mainText = mainText.Replace(CursedSignature, buff2);
            return mainText;
        }

        public static string FirstBytesOfFile(string originalFile, int count)
        {

            int buffcount = (count / 2) - 1;
            string buff = originalFile.Remove((buffcount + count), originalFile.Length - (buffcount + count));
            return buff;

        }


        //var md5signatures = File.ReadAllLines("MD5base.txt");
        //    if (md5signatures.Contains(tbMD5.Text))
        //    {
        //        Console.WriteLine($"File: {e.FullPath} Infected!");
        //    }

        //    else
        //    {
        //        Console.WriteLine($"File: {e.FullPath} Clean!");
        //    }

    }
}
