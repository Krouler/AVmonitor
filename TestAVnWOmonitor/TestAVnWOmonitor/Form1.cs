using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 


namespace TestAVnWOmonitor
{

    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello World! \n");
            byte[] content = File.ReadAllBytes(tbFilePath.Text.ToString());
            string kekes = ConvertByteToHex(content);
            Console.WriteLine(kekes + "\n");
            var BaseSig = File.ReadAllLines("BaseSign.txt");
            bool flag = false;
            int buff = 0;
            string Bufff;
            for (int i = 0; i < BaseSig.Length; i++)
            {
                if (kekes.Contains(BaseSig[i]))
                {
                    flag = true;
                    buff = i;
                }
            }

            if (flag == true)
            {
                lblStatus.Text = "Вредоносный файл!";
                lblStatus.ForeColor = Color.Red;
                Bufff = DateTime.Now.ToString() + " После проверки обнаружен вредоносный файл!\n";
            }

            else
            {
                lblStatus.Text = "Чистый файл!";
                lblStatus.ForeColor = Color.Green;
                Bufff = DateTime.Now.ToString() + " После проверки файл оказался чист!\n";
            }
            
            logTextBox.Text += Environment.NewLine + Bufff;

        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = ofd.FileName;
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //public void Pepega(string Paths)
        //{
        //   label2.Text = "Infected!" + Paths;
        //}
        
        private void MonStart_Click(object sender, EventArgs e)
        {
            string Path2 = PathBox.Text.ToString();
            string Filter2 = FilterForMonitor.Text.ToString();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "TestMonitor.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = $"\"{Path2}\" {Filter2}";
            using (Process exeProcess = Process.Start(startInfo)) { }
            /*Testing.Run();*/
            Log.Handle(logTextBox, ": Монитор начал свою работу с параметрами:"+Environment.NewLine+$"Проверяемая папка: {Path2}" + Environment.NewLine + $"Фильтр: {Filter2}");


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Quarrantine = File.ReadAllLines("D:\\Quarantine\\QuarantineJournal.txt");
            string buffFile = "";
            string buffFileName = "";
            for ( int i=1; i<Quarrantine.Length ;i++ )
            {
                if (Quarrantine.Length >= 2)
                {
                    buffFile = Quarrantine[i];
                    buffFileName = buffFile.Remove(buffFile.LastIndexOf(";"), buffFile.Length - buffFile.LastIndexOf(";"));
                    buffFileName = buffFileName.Remove(0, buffFileName.LastIndexOf(";") + 1);
                    LBforQuarantine.Items.Add(buffFileName);
                }
            }
        }

        private void BrowsePapka_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            string Keks2 = "";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                Keks2 = FBD.SelectedPath;
                PathBox.Text = Keks2;
            }
            MonStart.Enabled = true;


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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LBforQuarantine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LBforQuarantine.Items.Clear();
            var Quarrantine = File.ReadAllLines("D:\\Quarantine\\QuarantineJournal.txt");
            string buffFile = "";
            string buffFileName = "";
            for (int i = 1; i < Quarrantine.Length; i++)
            {
                if (Quarrantine.Length >= 2)
                {
                    buffFile = Quarrantine[i];
                    try
                    {
                        buffFileName = buffFile.Remove(buffFile.LastIndexOf(";"), buffFile.Length - buffFile.LastIndexOf(";"));
                        buffFileName = buffFileName.Remove(0, buffFileName.LastIndexOf(";") + 1);
                        LBforQuarantine.Items.Add(buffFileName);
                    }
                    catch(Exception err)
                    {

                    }
                }
            }
            string Bufff = DateTime.Now.ToString() + "Обновление списка карантина произошло успешно!\n";
            logTextBox.Text += Environment.NewLine + Bufff;

        }

        private void RestoreFileButt_Click(object sender, EventArgs e)
        {
            string indexTxt = LBforQuarantine.SelectedItem.ToString() ;
            Vosstanovlenie(indexTxt);
            string Bufff = DateTime.Now.ToString() + $": {indexTxt} Файл был восстановлен пользователем!\n";
            logTextBox.Text += Environment.NewLine + Bufff;

        }

        public static void Vosstanovlenie(string PathToFile)
        {
            string Identity = $"{PathToFile}";
            var QuarrJour = File.ReadAllLines("D:\\Quarantine\\QuarantineJournal.txt");
            string buffFile = "";
            string ID = "";
            int buffNumb = 0;
            int buffN = 0;
            for (int i = 0; i < QuarrJour.Length; i++)
            {
                if (QuarrJour[i].Contains(Identity))
                {
                    buffFile = QuarrJour[i];
                    ID = buffFile[buffFile.IndexOf(";") - 1].ToString();
                    buffNumb = i;
                    buffN += 1;
                }
                else if (i - 1 == QuarrJour.Length && buffN != 1) {  }
            }
            string buffSigna = "20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20";



            string buffFileName = Identity;
           
            File.Move($"D:\\Quarantine\\{ID}.quarantine", $"{buffFileName}");
            byte[] content = File.ReadAllBytes($"{buffFileName}");
            string kekes = ConvertByteToHex(content);
           
            string buffByteString = buffFile.Remove(0, buffFile.LastIndexOf(";") + 1);
            kekes = kekes.Replace(buffSigna, buffByteString);
           
            var openFile = File.Open($"{buffFileName}", FileMode.Truncate);
            openFile.Write(ConvertHexToByte(kekes), 0, ConvertHexToByte(kekes).Length);
            openFile.Close();
            File.WriteAllBytes($"{buffFileName}", ConvertHexToByte(kekes));
            string[] KekW = new string[QuarrJour.Length - 1];
            for (int i = 0; i < KekW.Length; i++)
            {
                if (i != buffNumb)
                {
                    KekW[i] = QuarrJour[i];
                }
            }
            File.WriteAllLines("D:\\Quarantine\\QuarantineJournal.txt", KekW);
            string Bufff = DateTime.Now.ToString() + $": {PathToFile} File was restored by user!\n";
            byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
            var Journall = File.Open("D:\\Journal.txt", FileMode.Append);
            Journall.Write(infoJuor, 0, infoJuor.Length);
            Journall.Close();

        }

        public static void VosstanovlenieILechenie(string PathToFile)
        {
            string Identity = $"{PathToFile}";
            var QuarrJour = File.ReadAllLines("D:\\Quarantine\\QuarantineJournal.txt");
            string buffFile = "";
            string ID = "";
            int buffNumb = 0;
            int buffN = 0;
            for (int i = 0; i < QuarrJour.Length; i++)
            {
                if (QuarrJour[i].Contains(Identity))
                {
                    buffFile = QuarrJour[i];
                    ID = buffFile[buffFile.IndexOf(";") - 1].ToString();
                    buffNumb = i;
                    buffN += 1;
                }
                else if (i - 1 == QuarrJour.Length && buffN != 1) { }
            }
            string buffSigna = "20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20";



            string buffFileName = Identity;

            File.Move($"D:\\Quarantine\\{ID}.quarantine", $"{buffFileName}");
            byte[] content = File.ReadAllBytes($"{buffFileName}");
            string kekes = ConvertByteToHex(content);

            string buffByteString = buffFile.Remove(0, buffFile.LastIndexOf(";") + 1);
            kekes = kekes.Replace(buffSigna, buffByteString);
            var BaseSig = File.ReadAllLines("BaseSign.txt");
            int buff = 0;
            for (int i = 0; i < BaseSig.Length; i++)
            {
                if (kekes.Contains(BaseSig[i]))
                {
                   
                    buff = i;
                    
                }
            }

            kekes = CuringFile(kekes, BaseSig[buff]);


            var openFile = File.Open($"{buffFileName}", FileMode.Truncate);
            openFile.Write(ConvertHexToByte(kekes), 0, ConvertHexToByte(kekes).Length);
            openFile.Close();
            File.WriteAllBytes($"{buffFileName}", ConvertHexToByte(kekes));
            string[] KekW = new string[QuarrJour.Length - 1];
            for (int i = 0; i < KekW.Length; i++)
            {
                if (i != buffNumb)
                {
                    KekW[i] = QuarrJour[i];
                }
            }
            File.WriteAllLines("D:\\Quarantine\\QuarantineJournal.txt", KekW);
            string Bufff = DateTime.Now.ToString() + $": {PathToFile} File was restored and cured by user!\n";
            byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
            var Journall = File.Open("D:\\Journal.txt", FileMode.Append);
            Journall.Write(infoJuor, 0, infoJuor.Length);
            Journall.Close();



        }

        public static void DeleteFile(string PathToFile)
        {
            
            string Identity = $"{PathToFile}";
            var QuarrJour = File.ReadAllLines("D:\\Quarantine\\QuarantineJournal.txt");
            string buffFile = "";
            string ID = "";
            int buffNumb = 0;
            int buffN = 0;
            string Bufff = "";
            for (int i = 0; i < QuarrJour.Length; i++)
            {
                if (QuarrJour[i].Contains(Identity))
                {
                    buffFile = QuarrJour[i];
                    ID = buffFile[buffFile.IndexOf(";") - 1].ToString();
                    buffNumb = i;
                    buffN += 1;
                }
                else if (i - 1 == QuarrJour.Length && buffN != 1) { }
            }
            string[] KekW = new string[QuarrJour.Length - 1];
            for (int i = 0; i < KekW.Length; i++)
            {
                if (i != buffNumb)
                {
                    KekW[i] = QuarrJour[i];
                }
            }
            File.WriteAllLines("D:\\Quarantine\\QuarantineJournal.txt", KekW);
            File.Delete($"D:\\Quarantine\\{ID}.quarantine");
            Bufff = DateTime.Now.ToString() + $": {PathToFile} File was infected! Deleted by user!\n";
           
            byte[] infoJuor = new UTF8Encoding(true).GetBytes(Bufff);
            var Journall = File.Open("D:\\Journal.txt", FileMode.Append);
            Journall.Write(infoJuor, 0, infoJuor.Length);
            Journall.Close();
           



        }

        private void RestoreCureFileButt_Click(object sender, EventArgs e)
        {
            string indexTxt = LBforQuarantine.SelectedItem.ToString();
            VosstanovlenieILechenie(indexTxt);
            string Bufff = DateTime.Now.ToString() + $": {indexTxt} Файл был восстановлен и вылечен пользователем!";
            logTextBox.Text += Environment.NewLine + Bufff;
        }

        private void DeleteFileButt_Click(object sender, EventArgs e)
        {
            string indexTxt = LBforQuarantine.SelectedItem.ToString();
            DeleteFile(indexTxt);
            string Bufff = DateTime.Now.ToString() + $": {indexTxt} Файл был удален пользователем!\n";
            logTextBox.Text += Environment.NewLine + Bufff;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    //public class Testing
    //{
        
    //    [STAThread]
        
    //    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    //    public static void Run()
    //    {

    //        string Popoga = "";

    //        string Keks = "";

    //        FolderBrowserDialog FBD = new FolderBrowserDialog();

    //        if (FBD.ShowDialog() == DialogResult.OK)
    //        {
    //            Keks = FBD.SelectedPath;

    //        }

    //        Console.WriteLine("Selected path: " + Keks);


    //        // using (FileSystemWatcher watcher = new FileSystemWatcher())
    //        // {

    //        //     watcher.Path = Keks;

    //        //     watcher.NotifyFilter = NotifyFilters.LastAccess
    //        //                      | NotifyFilters.LastWrite
    //        //                      | NotifyFilters.FileName
    //        //                      | NotifyFilters.DirectoryName;

    //        //     string filterkeks = Console.ReadLine();

    //        //     watcher.Filter = filterkeks;

    //        //     watcher.Changed += OnChanged;
    //        //     //watcher.Created += OnChanged;
    //        //    //watcher.Deleted += OnChanged;
    //        //     watcher.Renamed += OnRenamed;

    //        //     watcher.EnableRaisingEvents = true;
    //        //     watcher.IncludeSubdirectories = true;
 
    //        //     Console.WriteLine("Type \"shapka\" to exit");

    //        //     while (Console.ReadLine() != "shapka") ;
    //        //}

    //        //void OnChanged(object source, FileSystemEventArgs e)
    //        //{
    //        //    Thread Tre = new Thread(MsgBox);
    //        //    Tre.Start();
    //        //    var md5signatures = File.ReadAllLines("MD5base.txt");
    //        //    string MD5s = GetMD5FromFile(e.FullPath);
    //        //    if (md5signatures.Contains(MD5s))
    //        //    {

    //        //        Popoga = e.FullPath;
    //        //        MsgBox();
    //        //    }

    //        //}

    //        //void OnRenamed(object source, RenamedEventArgs e)
    //        //{
    //        //    var md5signatures = File.ReadAllLines("MD5base.txt");
    //        //    string MD5s = GetMD5FromFile(e.FullPath);
    //        //    if (md5signatures.Contains(MD5s))
    //        //    {
    //        //        Popoga = e.FullPath;
    //        //        MsgBox();

    //        //    }

    //        //}
    //        //string GetMD5FromFile(string filenPath)
    //        //{
    //        //    using (var md5 = MD5.Create())
    //        //    {
    //        //        using (var stream = File.OpenRead(filenPath))
    //        //        {
    //        //            return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
    //        //        }
    //        //    }
    //        //}
    //    }

    //    private static void MsgBox()
    //    {
    //        MessageBox.Show("Infected!", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             
    //    }
    //}
}
