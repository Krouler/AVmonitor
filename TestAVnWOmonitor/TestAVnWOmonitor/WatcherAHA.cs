//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Security.Permissions;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;


//namespace TestAVnWOmonitor
//{


//    class WatcherAHA
//    {

//        [STAThread]

//        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]

//        public static void Run()
//        {

//            string Popoga = "";

//            string Keks = "";

//            FolderBrowserDialog FBD = new FolderBrowserDialog();

//            if (FBD.ShowDialog() == DialogResult.OK)
//            {
//                Keks = FBD.SelectedPath;
//            }

//            using (FileSystemWatcher watcher = new FileSystemWatcher())
//            {
//                watcher.Path = Keks;

//                watcher.NotifyFilter = NotifyFilters.LastAccess
//                                         | NotifyFilters.LastWrite
//                                         | NotifyFilters.FileName
//                                         | NotifyFilters.DirectoryName;

//                string filterkeks = Console.ReadLine();

//                watcher.Filter = filterkeks;

//                watcher.Changed += OnChanged;
//                //watcher.Created += OnChanged;
//                //watcher.Deleted += OnChanged;
//                watcher.Renamed += OnRenamed;

//                watcher.EnableRaisingEvents = true;
//                watcher.IncludeSubdirectories = true;

//                Console.WriteLine("Type \"shapka\" to exit");

//                while (Console.ReadLine() != "shapka") ;
//            }
            
//            void OnChanged(object source, FileSystemEventArgs e)
//            {

                
//                var md5signatures = File.ReadAllLines("MD5base.txt");
//                string MD5s = Form1.GetMD5FromFile(e.FullPath);
//                if (md5signatures.Contains(MD5s))
//                {

//                    Popoga = e.FullPath;

                
//                }

//            }

//            void OnRenamed(object source, RenamedEventArgs e)
//            {
//                var md5signatures = File.ReadAllLines("MD5base.txt");
//                string MD5s = Form1.GetMD5FromFile(e.FullPath);
//                if (md5signatures.Contains(MD5s))
//                {
//                    Popoga = e.FullPath;

//                }
//            }
//        }
//    }
//}
