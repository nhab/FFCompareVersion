using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FFCompareVersion
{
    public class TreeViewFile
    {
        public static void SaveTreeToBinaryFile(TreeNode rootNode, string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, rootNode);
                }

                Console.WriteLine($"Tree saved to {filePath} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tree to file: {ex.Message}");
            }
        }

        
        public static TreeNode LoadTreeFromBinaryFile(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    return (TreeNode)binaryFormatter.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tree from file: {ex.Message}");
                return null;
            }
        }

        public static void SaveTreeNodeToFile(TreeNode rootNode, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    SaveTreeNodeRecursively(rootNode, writer, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving TreeNode to file: {ex.Message}");
            }
        }

        private static void SaveTreeNodeRecursively(TreeNode node, StreamWriter writer, int depth)
        {
            string indentation = new string('\t', depth);
            writer.WriteLine($"{indentation}{node.Text}");

            foreach (TreeNode childNode in node.Nodes)
            {
                SaveTreeNodeRecursively(childNode, writer, depth + 1);
            }
        }

        // Load TreeNode from a text file
        public static TreeNode LoadTreeNodeFromFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return LoadTreeNodeRecursively(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading TreeNode from file: {ex.Message}");
                return null;
            }
        }

        private static TreeNode LoadTreeNodeRecursively(StreamReader reader)
        {
            TreeNode rootNode = null;
            TreeNode currentNode = null;
            int currentDepth = -1;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().Trim();
                if (line.Length == 0) continue;

                int depth = line.Length - line.TrimStart('\t').Length;

                if (rootNode == null)
                {
                    rootNode = new TreeNode(line.Trim());
                    currentNode = rootNode;
                    currentDepth = depth;
                }
                else if (depth > currentDepth)
                {
                    TreeNode childNode = new TreeNode(line.Trim());
                    currentNode.Nodes.Add(childNode);
                    currentNode = childNode;
                    currentDepth = depth;
                }
                else
                {
                    while (depth <= currentDepth)
                    {
                        currentNode = currentNode.Parent;
                        currentDepth--;
                    }

                    TreeNode siblingNode = new TreeNode(line.Trim());
                    currentNode.Parent.Nodes.Add(siblingNode);
                    currentNode = siblingNode;
                    currentDepth = depth;
                }
            }

            return rootNode;
        }
    }
}
