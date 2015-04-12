using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_Rebirth_Save_Game_Editor.DataStructure.FIleData
{
    public class DirectoryObject
    {
        public string Name = null;
        private List<DirectoryObject> SubDirectories = new List<DirectoryObject>();
        private List<FileObject> Files = new List<FileObject>();
        private List<string> Cat = new List<string>();
        public DirectoryObject Parent = null;

        public DirectoryObject(DirectoryObject parent, string name, string cat, string path, uint start, int size, Int64 epoch, string hash, int depth)
        {
            Parent = parent;
            Name = name;
            AddPath(cat, path, start, size, epoch, hash, depth);
        }

        public void AddPath(string cat, string path, uint start, int size, Int64 epoch, string hash, int depth)
        {
            if (!Cat.Contains(cat))
            {
                Cat.Add(cat);
            }

            if (path.Contains('/'))
            {
                int i = path.IndexOf('/');
                string name = path.Substring(0, i);
                List<DirectoryObject> temp = SubDirectories.Where(a => a.Name == name).ToList();
                if (temp.Count > 0)
                {
                    temp.First().AddPath(cat, path.Substring(i + 1), start, size, epoch, hash, depth + 1);
                }
                else
                {
                    SubDirectories.Add(new DirectoryObject(this, name, cat, path.Substring(i + 1), start, size, epoch, hash, depth + 1));
                }
            }
            else
            {
                if (Files.Exists(a => a.Name == path))
                {
                    Files.Where(a => a.Name == path).First().AddFileVersion(cat, start, size, epoch, hash);
                }
                else
                {
                    Files.Add(new FileObject(this, cat, path, start, size, epoch, hash, depth));
                }
            }
        }

        public void GetTreeView(TreeNodeCollection nodes)
        {
            foreach (DirectoryObject dir in SubDirectories)
            {
                nodes.Add(dir.Name, dir.Name);
                dir.GetTreeView(nodes[dir.Name].Nodes);
            }
        }

        public List<FileObject> GetFileList(List<string> node, int steps, string catFilter)
        {
            List<FileObject> files = new List<FileObject>();
            if (node.Count > 0)
            {
                string name = node.Last();
                node.Remove(name);
                return SubDirectories.Where(a => a.Name == name).First().GetFileList(node, steps + 1, catFilter);
            }
            else
            {
                foreach (DirectoryObject dir in SubDirectories)
                {
                    files.AddRange(dir.GetFileList(node, steps, catFilter));
                }

                files.AddRange(Files.Where(a => (catFilter == "All" || a.Cat == catFilter)));
                files.ForEach(a => a.Steps = steps);
            }
            return files;
        }

        public FileObject GetFile(List<string> path, string file)
        {
            if (path.Count <= 0)
            {
                List<FileObject> f = Files.Where(a => a.Name == file).ToList();

                if (f.Count <= 0)
                {
                    return null;
                }
                else
                {
                    return f.First();
                }
            }
            else
            {
                List<DirectoryObject> d = SubDirectories.Where(a => a.Name == path.First()).ToList();

                if (d.Count <= 0)
                {
                    return null;
                }
                else
                {
                    path.RemoveAt(0);
                    return d.First().GetFile(path, file);
                }
            }
        }
    }
}
