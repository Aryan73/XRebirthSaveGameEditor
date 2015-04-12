using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using X_Rebirth_Save_Game_Editor.DataStructure.FIleData;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor
{
    public partial class FormCatDatExport : Form
    {
        #region Members
        int lastFound = 0;
        private volatile bool _shouldStop = false;
        CatDatExtractor cde = null;
        TreeNode LastSelectedNode = null;
        Thread ExtracionThread = null;
        List<KeyValuePair<string, FileObject>> ExtractQueue = new List<KeyValuePair<string, FileObject>>();
        Object ExtractQueueLock = new Object();
        static FormCatDatExport instance = null;
        static object lockInstance = new object();
        #endregion

        #region Delegates
        public delegate void SetProcessStatus();
        public SetProcessStatus SetProcessStatusDelegate;
        #endregion

        #region Constructors
        private FormCatDatExport()
        {
        }

        private FormCatDatExport(CatDatExtractor cde)
        {
            InitializeComponent();

            this.cde = cde;
            cde.GetTreeView(treeView1.Nodes);
            comboBoxCatFilter.Items.Add("All");
            comboBoxCatFilter.Items.AddRange(cde.CatFiles.ToArray());
            comboBoxCatFilter.SelectedIndex = 0;
            ExtracionThread = new Thread(AscyncExtract);
            SetProcessStatusDelegate = new SetProcessStatus(SetProcessStatusMethod);
            groupBoxSearchInPreview.Enabled = false;
        }
        #endregion

        public static FormCatDatExport Instance(CatDatExtractor cde = null)
        {
            lock (lockInstance)
            {
                if (instance == null)
                {
                    instance = new FormCatDatExport(cde);
                }

                return instance;
            }
        }

        #region Methods
        #region Threaded
        public void AscyncExtract()
        {
            this.Invoke(SetProcessStatusDelegate);
            while (!_shouldStop)
            {

                KeyValuePair<string, FileObject>? current = null;
                lock (ExtractQueueLock)
                {
                    if (ExtractQueue.Count > 0)
                    {
                        current = ExtractQueue.First();
                        ExtractQueue.Remove(current.Value);
                    }
                }

                if (current != null)
                {
                    this.Invoke(SetProcessStatusDelegate);
                    current.Value.Value.ExtractFile(cde.BasePath, current.Value.Key);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public void AscyncExtractRequestStop()
        {
            _shouldStop = true;
        }

        public static void HighlightRTF(RichTextBox rtb)
        {
            int k = 0;

            string str = rtb.Text;

            int st, en;
            int lasten = -1;
            while (k < str.Length)
            {
                st = str.IndexOf('<', k);

                if (st < 0)
                    break;

                if (lasten > 0)
                {
                    rtb.Select(lasten + 1, st - lasten - 1);
                    rtb.SelectionColor = HighlightColors.HC_INNERTEXT;
                }

                en = str.IndexOf('>', st + 1);
                if (en < 0)
                    break;

                k = en + 1;
                lasten = en;

                if (str[st + 1] == '!')
                {
                    rtb.Select(st + 1, en - st - 1);
                    rtb.SelectionColor = HighlightColors.HC_COMMENT;
                    continue;

                }
                String nodeText = str.Substring(st + 1, en - st - 1);


                bool inString = false;

                int lastSt = -1;
                int state = 0;
                /* 0 = before node name
                 * 1 = in node name
                   2 = after node name
                   3 = in attribute
                   4 = in string
                   */
                int startNodeName = 0, startAtt = 0;
                for (int i = 0; i < nodeText.Length; ++i)
                {
                    if (nodeText[i] == '"')
                        inString = !inString;

                    if (inString && nodeText[i] == '"')
                        lastSt = i;
                    else
                        if (nodeText[i] == '"')
                        {
                            rtb.Select(lastSt + st + 2, i - lastSt - 1);
                            rtb.SelectionColor = HighlightColors.HC_STRING;
                        }

                    switch (state)
                    {
                        case 0:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startNodeName = i;
                                state = 1;
                            }
                            break;
                        case 1:
                            if (Char.IsWhiteSpace(nodeText, i))
                            {
                                rtb.Select(startNodeName + st, i - startNodeName + 1);
                                rtb.SelectionColor = HighlightColors.HC_NODE;
                                state = 2;
                            }
                            break;
                        case 2:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startAtt = i;
                                state = 3;
                            }
                            break;

                        case 3:
                            if (Char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
                            {
                                rtb.Select(startAtt + st, i - startAtt + 1);
                                rtb.SelectionColor = HighlightColors.HC_ATTRIBUTE;
                                state = 4;
                            }
                            break;
                        case 4:
                            if (nodeText[i] == '"' && !inString)
                                state = 2;
                            break;
                    }

                }
                if (state == 1)
                {
                    rtb.Select(st + 1, nodeText.Length);
                    rtb.SelectionColor = HighlightColors.HC_NODE;
                }

            }
        }
        #endregion
        public void SetProcessStatusMethod()
        {
            lock (ExtractQueueLock)
            {
                //ExtractQueue
                if (ExtractQueue.Count == 0)
                {
                    groupBoxExport.Text = "Export, To be processed: 0, Currently exporting: ";
                }
                else
                {
                    groupBoxExport.Text = "Export, To be processed: " + ExtractQueue.Count.ToString() + ", Currently exporting: " + ExtractQueue.First().Value.Path;
                }
            }
        }

        private void GetFileList()
        {
            string catFilter = "All";
            if (comboBoxCatFilter.Items.Contains(comboBoxCatFilter.Text))
            {
                catFilter = comboBoxCatFilter.Text;
            }

            List<string> nodes = new List<string>();
            TreeNode node = LastSelectedNode;
            while (node.Parent != null)
            {
                nodes.Add(node.Name);
                node = node.Parent;
            }
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cde.GetFileList(nodes, catFilter, textBoxEndswith.Text, textBoxContains.Text).OrderBy(a => a.Path).ToList(); ;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Name == "Cat")
                {
                    c.DisplayIndex = 0;
                    c.Width = 40;
                }
                else if (c.Name == "Path")
                {
                    c.DisplayIndex = 1;
                    c.Width = 800;
                }
                else if (c.Name == "Size")
                {
                    c.DisplayIndex = 2;
                    c.Width = 50;
                }
                else if (c.Name == "Start")
                {
                    c.DisplayIndex = 3;
                    c.Width = 70;
                }
            }
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
        #endregion

        #region Events
        #region Unused
        private void FormCatDatExport_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // For testing purposes
            //FileObject a = (FileObject)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            //a.ExtractFile(cde.BasePath);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //FileObject a = (FileObject)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            //richTextBox1.Text = a.GetFileAsString(cde.BasePath);
            //HighlightRTF(richTextBox1);
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
        }
        #endregion
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LastSelectedNode = e.Node;

            GetFileList();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (LastSelectedNode != null)
            {
                GetFileList();
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Logger.Verbose("Browse initiated.");
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult res = fbd.ShowDialog();
                if (res == DialogResult.OK || res == DialogResult.Yes)
                {
                    textBoxExportLocation.Text = fbd.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to initiated browse.", ex);
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                lock (ExtractQueueLock)
                {
                    ExtractQueue.Add(new KeyValuePair<string, FileObject>(textBoxExportLocation.Text, (FileObject)row.DataBoundItem));
                }
            }

            if (!ExtracionThread.IsAlive)
            {
                ExtracionThread.Start();

                // Wait till active just to be safe
                while (!ExtracionThread.IsAlive) ;
            }
        }

        private void FormCatDatExport_FormClosing(object sender, FormClosingEventArgs e)
        {
            lock (ExtractQueueLock)
            {
                if (ExtractQueue.Count > 0)
                {
                    MessageBox.Show("Still extracting closing this window will stop extraction. Cannot close the window till finisched. You can leave this window open and use the other window though.");
                    e.Cancel = true;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPagePreview"
                && dataGridView1.CurrentRow != null
                )
            {
                FileObject a = (FileObject)dataGridView1.CurrentRow.DataBoundItem;
                richTextBox1.Text = a.GetFileAsString(cde.BasePath);
                HighlightRTF(richTextBox1);
                groupBoxSearchInPreview.Enabled = true;
            }
            else
            {
                groupBoxSearchInPreview.Enabled = false;
            }
        }
        #endregion

        private void buttonSearchInPreview_Click(object sender, EventArgs e)
        {
            lastFound = 0;
            lastFound = richTextBox1.Find(textBoxSearchInPreview.Text, richTextBox1.SelectionStart + textBoxSearchInPreview.Text.Length, RichTextBoxFinds.None);
            if (lastFound == -1)
            {
                lastFound = richTextBox1.Find(textBoxSearchInPreview.Text, 0, RichTextBoxFinds.None);
            }

            if (lastFound != -1)
            {
                richTextBox1.SelectionStart = lastFound;
                richTextBox1.SelectionLength = textBoxSearchInPreview.Text.Length;
                richTextBox1.ScrollToCaret();
                richTextBox1.SelectionBackColor = Color.Blue;
                richTextBox1.SelectionColor = Color.White;
            }
        }

        private void textBoxSearchInPreview_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                buttonSearchInPreview_Click(null, null);
            }
        }

        public void ResizeElements()
        {
            splitContainerMain.SplitterDistance = 200;
            splitContainerRight.SplitterDistance = splitContainerRight.Height - 75;
            splitContainer1.SplitterDistance = splitContainer1.Width / 5;
            splitContainer2.SplitterDistance = (splitContainer2.Width / 3) * 2;
            splitContainer3.SplitterDistance = 50;
            splitContainer4.SplitterDistance = splitContainer4.Width / 2;
            splitContainer5.SplitterDistance = 25;
            splitContainer6.SplitterDistance = 80;
            splitContainer7.SplitterDistance = splitContainer7.Width - 60;
        }
    }

    public class HighlightColors
    {
        public static Color HC_NODE = Color.Firebrick;
        public static Color HC_STRING = Color.Blue;
        public static Color HC_ATTRIBUTE = Color.Red;
        public static Color HC_COMMENT = Color.Green;
        public static Color HC_INNERTEXT = Color.Black;
    }
}
