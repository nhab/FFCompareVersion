using Microsoft.Data.Sqlite;

namespace FFCompareVersion
{

    public class TreeNodeDatabaseManager
    {
        private string connectionString;

        public TreeNodeDatabaseManager(string dbFilePath)
        {
          //  connectionString = $"Data Source={dbFilePath};Version=3;";
            connectionString = $"Data Source={dbFilePath};";

        }

        // Save TreeNode to a SQLite database
        public void SaveTreeNodeToDatabase(TreeNode rootNode, string tableName)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string CreateTablSql = $"CREATE TABLE IF NOT EXISTS {tableName} (Id INTEGER PRIMARY KEY, FileName TEXT, ParentId INTEGER,FileDate TEXT)";
                    using (SqliteCommand command = new SqliteCommand(CreateTablSql, connection))
                    {

                        command.ExecuteNonQuery();

                        // Clear existing data
                        command.CommandText = $"DELETE FROM {tableName}";
                        command.ExecuteNonQuery();

                        // Save TreeNode
                        SaveTreeNodeRecursively(rootNode, command, tableName, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving TreeNode to database: {ex.Message}");
            }
        }

        private void SaveTreeNodeRecursively(
            TreeNode node, 
            SqliteCommand command, 
            string tableName,
            int? parentId            
            )
        {
            try
            {
                string query = $"INSERT INTO {tableName} (FileName, ParentId,FileDate)";
                query+= "VALUES (@FileName, @ParentId,@FileDate)";
                command.CommandText = query;
                command.Parameters.AddWithValue("@FileName", node.Text);
                command.Parameters.AddWithValue("@ParentId", parentId!=null?parentId:DBNull.Value); 
                command.Parameters.AddWithValue("@FileDate", node.Tag != null ? node.Tag.ToString(): DBNull.Value);
                command.ExecuteNonQuery();

                foreach (TreeNode childNode in node.Nodes)
                {
                    SaveTreeNodeRecursively(childNode, command, tableName, GetLastInsertedId(command));
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private int? GetLastInsertedId(SqliteCommand command)
        {
            command.CommandText = "SELECT last_insert_rowid()";
            return command.ExecuteScalar() as int?;
        }

        // Load TreeNode from a SQLite database
        public TreeNode LoadTreeNodeFromDatabase(string tableName)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string selectSQL= $"SELECT * FROM {tableName}";
                    using (SqliteCommand command = new SqliteCommand(selectSQL, connection))
                    {
                        SqliteDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            TreeNode rootNode = new TreeNode(reader["FileName"].ToString());
                            LoadTreeNodeRecursively(reader, rootNode, tableName);
                            return rootNode;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading TreeNode from database: {ex.Message}");
            }

            return null;
        }

        private void LoadTreeNodeRecursively(SqliteDataReader reader, TreeNode parentNode, string tableName)
        {
            int parentId = Convert.ToInt32(reader["Id"]);
            reader.NextResult();

            while (reader.Read())
            {
                int? currentParentId = reader["ParentId"] == DBNull.Value ? null : (int?)reader["ParentId"];

                if (currentParentId == parentId)
                {
                    TreeNode childNode = new TreeNode(reader["FileName"].ToString());
                    parentNode.Nodes.Add(childNode);
                    LoadTreeNodeRecursively(reader, childNode, tableName);
                }
            }
        }


        // Example of usage
        static void Example(
            ref TreeView treeView,
            string folderPath = @"C:\YourFolderPath"
            )
        {
             TreeNode fileFolderNode = FileFolderLoader.LoadFilesAndFolders(folderPath);

             string dbFilePath = "TreeNodes.db";

            string tableName = "TreeNodeTable";
            TreeNodeDatabaseManager dbManager = new TreeNodeDatabaseManager(dbFilePath);

            dbManager.SaveTreeNodeToDatabase(fileFolderNode, tableName);

            TreeNode loadedNode = dbManager.LoadTreeNodeFromDatabase(tableName);
             FileFolderLoader.LoadTreeNodeIntoTreeView(loadedNode,ref treeView);
        }
    }
}

