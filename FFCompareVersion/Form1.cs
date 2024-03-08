namespace FFCompareVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSrc_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                txtSource.Text = folderBrowserDialog1.SelectedPath;

        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                txtDest.Text = folderBrowserDialog1.SelectedPath;

        }

        // Load the TreeNode from the text file
        private void btnOpen_Click(object sender, EventArgs e)
        {

            TreeNode loadedNode = TreeViewFile.LoadTreeNodeFromFile("TreeNodes.txt");

            FileFolderLoader.LoadTreeNodeIntoTreeView(loadedNode, ref treeViewSource);
        }

       
        private void btnLoadToTreeview_Click(object sender, EventArgs e)
        {
            string src = txtSource.Text;


            TreeNode fileFolderNode = FileFolderLoader.LoadFilesAndFolders(src);
            FileFolderLoader.LoadTreeNodeIntoTreeView(fileFolderNode, ref treeViewSource);
        }

 

        private void btnSaveToText_Click(object sender, EventArgs e)
        {
            string src = txtSource.Text;

            TreeNode fileFolderNode = FileFolderLoader.LoadFilesAndFolders(src);
            TreeViewFile.SaveTreeNodeToFile(fileFolderNode, "TreeNodes.txt");
        }
        private void btnSave2sqlite_Click(object sender, EventArgs e)
        {
            
            string src = txtSource.Text;
            TreeNode fileFolderNode = FileFolderLoader.LoadFilesAndFolders(src);
            string dbFilePath = "d:\\db1.db";
            TreeNodeDatabaseManager db = new TreeNodeDatabaseManager(dbFilePath);
            
            db.SaveTreeNodeToDatabase(fileFolderNode, "tbSrc");
        }

    }
}
