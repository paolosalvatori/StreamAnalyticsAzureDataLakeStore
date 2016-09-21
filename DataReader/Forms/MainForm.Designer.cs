namespace Microsoft.AzureCat.Samples.DataReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelTreeView = new Microsoft.AzureCat.Samples.DataReader.HeaderPanel();
            this.dataLakeTreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.directoryHeaderPanel = new Microsoft.AzureCat.Samples.DataReader.HeaderPanel();
            this.fileListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastModifiedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataLakeStoreTreeView = new System.Windows.Forms.TreeView();
            this.logHeaderPanel = new Microsoft.AzureCat.Samples.DataReader.HeaderPanel();
            this.logPanel = new System.Windows.Forms.Panel();
            this.logTabControl = new System.Windows.Forms.TabControl();
            this.logTabPage = new System.Windows.Forms.TabPage();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.jsonTabPage = new System.Windows.Forms.TabPage();
            this.jsonTreeView = new System.Windows.Forms.TreeView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.entityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelTreeView.SuspendLayout();
            this.directoryHeaderPanel.SuspendLayout();
            this.logHeaderPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.logTabControl.SuspendLayout();
            this.logTabPage.SuspendLayout();
            this.jsonTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityBindingSource)).BeginInit();
            this.logContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1184, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem,
            this.saveLogToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log As...";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // logWindowToolStripMenuItem
            // 
            this.logWindowToolStripMenuItem.Checked = true;
            this.logWindowToolStripMenuItem.CheckOnClick = true;
            this.logWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logWindowToolStripMenuItem.Name = "logWindowToolStripMenuItem";
            this.logWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.logWindowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.logWindowToolStripMenuItem.Text = "&Log Window";
            this.logWindowToolStripMenuItem.Click += new System.EventHandler(this.logWindowToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip.TabIndex = 20;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(16, 40);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer.Panel1.Controls.Add(this.dataLakeStoreTreeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logHeaderPanel);
            this.splitContainer.Size = new System.Drawing.Size(1152, 696);
            this.splitContainer.SplitterDistance = 397;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 21;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.directoryHeaderPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1152, 397);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 14;
            // 
            // panelTreeView
            // 
            this.panelTreeView.BackColor = System.Drawing.Color.White;
            this.panelTreeView.Controls.Add(this.dataLakeTreeView);
            this.panelTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTreeView.ForeColor = System.Drawing.Color.White;
            this.panelTreeView.HeaderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panelTreeView.HeaderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.panelTreeView.HeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.panelTreeView.HeaderHeight = 24;
            this.panelTreeView.HeaderText = "Data Explorer";
            this.panelTreeView.Icon = global::Microsoft.AzureCat.Samples.DataReader.Properties.Resources.SmallWorld;
            this.panelTreeView.IconTransparentColor = System.Drawing.Color.White;
            this.panelTreeView.Location = new System.Drawing.Point(0, 0);
            this.panelTreeView.Margin = new System.Windows.Forms.Padding(2, 4, 5, 2);
            this.panelTreeView.Name = "panelTreeView";
            this.panelTreeView.Padding = new System.Windows.Forms.Padding(5, 28, 5, 4);
            this.panelTreeView.Size = new System.Drawing.Size(309, 397);
            this.panelTreeView.TabIndex = 1;
            // 
            // dataLakeTreeView
            // 
            this.dataLakeTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataLakeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLakeTreeView.ImageIndex = 0;
            this.dataLakeTreeView.ImageList = this.imageList;
            this.dataLakeTreeView.Indent = 20;
            this.dataLakeTreeView.ItemHeight = 20;
            this.dataLakeTreeView.Location = new System.Drawing.Point(5, 28);
            this.dataLakeTreeView.Name = "dataLakeTreeView";
            this.dataLakeTreeView.SelectedImageIndex = 0;
            this.dataLakeTreeView.Size = new System.Drawing.Size(299, 365);
            this.dataLakeTreeView.TabIndex = 14;
            this.dataLakeTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dataLakeTreeView_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "AzureLogo.ico");
            this.imageList.Images.SetKeyName(1, "Folder.ico");
            this.imageList.Images.SetKeyName(2, "SmallDocument.png");
            this.imageList.Images.SetKeyName(3, "triangle shadow yellow.png");
            // 
            // directoryHeaderPanel
            // 
            this.directoryHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.directoryHeaderPanel.Controls.Add(this.fileListView);
            this.directoryHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directoryHeaderPanel.ForeColor = System.Drawing.Color.White;
            this.directoryHeaderPanel.HeaderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.directoryHeaderPanel.HeaderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.directoryHeaderPanel.HeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.directoryHeaderPanel.HeaderHeight = 24;
            this.directoryHeaderPanel.HeaderText = "Documents";
            this.directoryHeaderPanel.Icon = global::Microsoft.AzureCat.Samples.DataReader.Properties.Resources.SmallWorld;
            this.directoryHeaderPanel.IconTransparentColor = System.Drawing.Color.White;
            this.directoryHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.directoryHeaderPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.directoryHeaderPanel.Name = "directoryHeaderPanel";
            this.directoryHeaderPanel.Padding = new System.Windows.Forms.Padding(2, 26, 1, 2);
            this.directoryHeaderPanel.Size = new System.Drawing.Size(839, 397);
            this.directoryHeaderPanel.TabIndex = 2;
            // 
            // fileListView
            // 
            this.fileListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.sizeColumnHeader,
            this.lastModifiedColumnHeader});
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.FullRowSelect = true;
            this.fileListView.Location = new System.Drawing.Point(2, 26);
            this.fileListView.Name = "fileListView";
            this.fileListView.OwnerDraw = true;
            this.fileListView.Size = new System.Drawing.Size(836, 369);
            this.fileListView.SmallImageList = this.imageList;
            this.fileListView.TabIndex = 3;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.fileListView_DrawColumnHeader);
            this.fileListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.fileListView_DrawItem);
            this.fileListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.fileListView_DrawSubItem);
            this.fileListView.DoubleClick += new System.EventHandler(this.fileListView_DoubleClick);
            this.fileListView.Resize += new System.EventHandler(this.fileListView_Resize);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 535;
            // 
            // sizeColumnHeader
            // 
            this.sizeColumnHeader.Text = "Size";
            this.sizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeColumnHeader.Width = 100;
            // 
            // lastModifiedColumnHeader
            // 
            this.lastModifiedColumnHeader.Text = "Last Modified";
            this.lastModifiedColumnHeader.Width = 200;
            // 
            // dataLakeStoreTreeView
            // 
            this.dataLakeStoreTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataLakeStoreTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLakeStoreTreeView.ImageIndex = 0;
            this.dataLakeStoreTreeView.ImageList = this.imageList;
            this.dataLakeStoreTreeView.Indent = 20;
            this.dataLakeStoreTreeView.ItemHeight = 20;
            this.dataLakeStoreTreeView.Location = new System.Drawing.Point(0, 0);
            this.dataLakeStoreTreeView.Name = "dataLakeStoreTreeView";
            this.dataLakeStoreTreeView.SelectedImageIndex = 0;
            this.dataLakeStoreTreeView.Size = new System.Drawing.Size(1152, 397);
            this.dataLakeStoreTreeView.TabIndex = 15;
            // 
            // logHeaderPanel
            // 
            this.logHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.logHeaderPanel.Controls.Add(this.logPanel);
            this.logHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logHeaderPanel.ForeColor = System.Drawing.Color.White;
            this.logHeaderPanel.HeaderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.logHeaderPanel.HeaderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.logHeaderPanel.HeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.logHeaderPanel.HeaderHeight = 24;
            this.logHeaderPanel.HeaderText = "Log";
            this.logHeaderPanel.Icon = global::Microsoft.AzureCat.Samples.DataReader.Properties.Resources.SmallDocument;
            this.logHeaderPanel.IconTransparentColor = System.Drawing.Color.White;
            this.logHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.logHeaderPanel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.logHeaderPanel.Name = "logHeaderPanel";
            this.logHeaderPanel.Padding = new System.Windows.Forms.Padding(5, 28, 5, 4);
            this.logHeaderPanel.Size = new System.Drawing.Size(1152, 291);
            this.logHeaderPanel.TabIndex = 0;
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.logTabControl);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.ForeColor = System.Drawing.Color.Black;
            this.logPanel.Location = new System.Drawing.Point(5, 28);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(1142, 259);
            this.logPanel.TabIndex = 0;
            // 
            // logTabControl
            // 
            this.logTabControl.Controls.Add(this.logTabPage);
            this.logTabControl.Controls.Add(this.jsonTabPage);
            this.logTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.logTabControl.Location = new System.Drawing.Point(0, 0);
            this.logTabControl.Name = "logTabControl";
            this.logTabControl.SelectedIndex = 0;
            this.logTabControl.Size = new System.Drawing.Size(1142, 259);
            this.logTabControl.TabIndex = 2;
            this.logTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.logTabControl_DrawItem);
            // 
            // logTabPage
            // 
            this.logTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.logTabPage.Controls.Add(this.lstLog);
            this.logTabPage.Location = new System.Drawing.Point(4, 22);
            this.logTabPage.Name = "logTabPage";
            this.logTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.logTabPage.Size = new System.Drawing.Size(1134, 233);
            this.logTabPage.TabIndex = 1;
            this.logTabPage.Text = "Log";
            // 
            // lstLog
            // 
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLog.ContextMenuStrip = this.logContextMenuStrip;
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.Location = new System.Drawing.Point(3, 3);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1128, 227);
            this.lstLog.TabIndex = 1;
            this.lstLog.Leave += new System.EventHandler(this.lstLog_Leave);
            // 
            // jsonTabPage
            // 
            this.jsonTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.jsonTabPage.Controls.Add(this.jsonTreeView);
            this.jsonTabPage.Location = new System.Drawing.Point(4, 22);
            this.jsonTabPage.Name = "jsonTabPage";
            this.jsonTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.jsonTabPage.Size = new System.Drawing.Size(1134, 233);
            this.jsonTabPage.TabIndex = 0;
            this.jsonTabPage.Text = "JSON";
            // 
            // jsonTreeView
            // 
            this.jsonTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTreeView.ImageIndex = 0;
            this.jsonTreeView.ImageList = this.imageList;
            this.jsonTreeView.Location = new System.Drawing.Point(3, 3);
            this.jsonTreeView.Name = "jsonTreeView";
            this.jsonTreeView.SelectedImageIndex = 0;
            this.jsonTreeView.Size = new System.Drawing.Size(1128, 227);
            this.jsonTreeView.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // logContextMenuStrip
            // 
            this.logContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripMenuItem,
            this.copySelectedToolStripMenuItem,
            this.toolStripSeparator27,
            this.clearAllToolStripMenuItem,
            this.clearSelectedToolStripMenuItem,
            this.toolStripSeparator29,
            this.saveAllToolStripMenuItem,
            this.saveSelectedToolStripMenuItem});
            this.logContextMenuStrip.Name = "logContextMenuStrip";
            this.logContextMenuStrip.Size = new System.Drawing.Size(153, 170);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // copySelectedToolStripMenuItem
            // 
            this.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem";
            this.copySelectedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copySelectedToolStripMenuItem.Text = "Copy Selected";
            this.copySelectedToolStripMenuItem.Click += new System.EventHandler(this.copySelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(146, 6);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // clearSelectedToolStripMenuItem
            // 
            this.clearSelectedToolStripMenuItem.Name = "clearSelectedToolStripMenuItem";
            this.clearSelectedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearSelectedToolStripMenuItem.Text = "Clear Selected";
            this.clearSelectedToolStripMenuItem.Click += new System.EventHandler(this.clearSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(146, 6);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // saveSelectedToolStripMenuItem
            // 
            this.saveSelectedToolStripMenuItem.Name = "saveSelectedToolStripMenuItem";
            this.saveSelectedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveSelectedToolStripMenuItem.Text = "Save Selected";
            this.saveSelectedToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Azure Data Lake Store Explorer";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelTreeView.ResumeLayout(false);
            this.directoryHeaderPanel.ResumeLayout(false);
            this.logHeaderPanel.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logTabControl.ResumeLayout(false);
            this.logTabPage.ResumeLayout(false);
            this.jsonTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entityBindingSource)).EndInit();
            this.logContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private HeaderPanel logHeaderPanel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.BindingSource entityBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private HeaderPanel panelTreeView;
        private System.Windows.Forms.TreeView dataLakeStoreTreeView;
        private HeaderPanel directoryHeaderPanel;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.TabControl logTabControl;
        private System.Windows.Forms.TabPage logTabPage;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.TabPage jsonTabPage;
        private System.Windows.Forms.TreeView dataLakeTreeView;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader sizeColumnHeader;
        private System.Windows.Forms.ColumnHeader lastModifiedColumnHeader;
        private System.Windows.Forms.TreeView jsonTreeView;
        private System.Windows.Forms.ContextMenuStrip logContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedToolStripMenuItem;
    }
}