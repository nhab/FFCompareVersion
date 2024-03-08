using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCompareVersion
{
    public class FileFolderLoader
    {
        // Function to load names and dates of files and folders into TreeNode
        public static TreeNode LoadFilesAndFolders(string folderPath)
        {
            TreeNode rootNode = new TreeNode(Path.GetFileName(folderPath));
            LoadFilesAndFoldersRecursively(folderPath, rootNode);
            return rootNode;
        }

        private static void LoadFilesAndFoldersRecursively(string folderPath, TreeNode parentNode)
        {
            try
            {
                // Load files
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    TreeNode fileNode = new TreeNode($"{fileInfo.Name} - {fileInfo.LastWriteTime}");
                    parentNode.Nodes.Add(fileNode);
                }

                // Load folders
                foreach (string subFolderPath in Directory.GetDirectories(folderPath))
                {
                    TreeNode folderNode = new TreeNode(Path.GetFileName(subFolderPath));
                    LoadFilesAndFoldersRecursively(subFolderPath, folderNode);
                    parentNode.Nodes.Add(folderNode);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., access denied)
                Console.WriteLine($"Error loading files and folders: {ex.Message}");
            }
        }

        // Function to load TreeNode into TreeView
        public static void LoadTreeNodeIntoTreeView(TreeNode rootNode,ref TreeView treeView)
        {
            treeView.Nodes.Add(rootNode);
        }

        void LoadIntoTextBox(string path, ref TextBox textBox1)
        {
            
            string[] srcFiles = System.IO.Directory.GetFiles(path);
            string[] srcFolders = System.IO.Directory.GetDirectories(path);

            textBox1.Text = "Source Files:\r\n " + string.Join(",", srcFiles); ;
            textBox1.Text += "\r\n" + "Source Directories: \r\n" + string.Join(",", srcFolders);

        }
    }
}