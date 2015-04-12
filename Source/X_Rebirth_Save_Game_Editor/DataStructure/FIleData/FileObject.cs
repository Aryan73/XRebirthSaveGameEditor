using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_Rebirth_Save_Game_Editor.DataStructure.FIleData
{

    public class FileObject
    {

        List<FileObject> OlderVersions = new List<FileObject>();
        public string Name = null;
        public string Path
        {
            get
            {
                string path = Name;
                DirectoryObject curDir = Parent;
                for (int i = 1; i < (Depth - Steps); i++)
                {
                    path = curDir.Name + "\\" + path;
                    curDir = curDir.Parent;
                }
                return path;
            }
        }

        private uint _Start = 0;
        public uint Start
        {
            get
            {
                return _Start;
            }
            set
            {
                _Start = value;
            }
        }

        private int _Size = 0;
        public int Size
        {
            get
            {
                return _Size;
            }
            set
            {
                _Size = value;
            }
        }
        public Int64 Epoch = 0;
        public string Hash = null;
        private string _Cat = null;
        public string Cat
        {
            get
            {
                return _Cat;
            }
            set
            {
                _Cat = value;
            }
        }
        public int Steps = 0;
        private DirectoryObject Parent = null;
        private int Depth = 0;

        public int Versions
        {
            get
            {
                return OlderVersions.Count + 1;
            }
        }

        public FileObject(DirectoryObject parent, string cat, string name, uint start, int size, Int64 epoch, string hash, int depth)
        {
            Cat = cat;
            Name = name;
            Start = start;
            Size = size;
            Epoch = epoch;
            Hash = hash;
            Parent = parent;
            Depth = depth;
        }

        public void AddFileVersion(string cat, uint start, int size, Int64 epoch, string hash)
        {
            if (Epoch > epoch)
            {
                OlderVersions.Add(new FileObject(Parent, cat, Name, start, size, epoch, hash, Depth));
            }
            else
            {
                OlderVersions.Add(new FileObject(Parent, Cat, Name, Start, Size, Epoch, Hash, Depth));
                Cat = cat;
                Start = start;
                Size = size;
                Epoch = epoch;
                Hash = hash;
            }
        }

        public string GetFileAsString(string location)
        {
            FileStream fs = new FileStream(location + _Cat.Replace(".cat", ".dat"), FileMode.Open, FileAccess.Read);
            fs.Position = Start;
            byte[] array = new byte[Size];
            fs.Read(array, 0, Size);
            return System.Text.Encoding.Default.GetString(array);
        }

        public void ExtractFile(string location, string extractionLocation = null)
        {
            FileStream fsIn = new FileStream(location + _Cat.Replace(".cat", ".dat"), FileMode.Open, FileAccess.Read);
            FileStream fsOut;
            fsIn.Position = Start;
            byte[] array = new byte[Size];
            fsIn.Read(array, 0, Size);
            string fullPath = Path;
            if (!string.IsNullOrEmpty(extractionLocation))
            {
                fullPath = extractionLocation + "\\" + Path;
            }
            string dirPath = fullPath.Substring(0, fullPath.LastIndexOf("\\"));
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            fsOut = new FileStream(fullPath, FileMode.Create);
            fsOut.Write(array, 0, Size);
            fsOut.Flush();
            fsOut.Close();
        }
        
    }
}
