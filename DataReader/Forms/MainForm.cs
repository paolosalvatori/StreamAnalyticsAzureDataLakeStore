#region Copyright
//=======================================================================================
// Microsoft Azure Customer Advisory Team  
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://blogs.msdn.com/b/paolos/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright © 2015 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.AzureCat.Samples.DataReader.Helpers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace Microsoft.AzureCat.Samples.DataReader
{
    public partial class MainForm : Form
    {
        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string DateFormat = "<{0,2:00}:{1,2:00}:{2,2:00}> {3}";
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";
        private const string LogFileNameFormat = "EventReaderLog-{0}.txt";
        private const string PlaceHolderNode = "PlaceHolderNode";

        //***************************
        // Constants
        //***************************
        private const string SaveAsTitle = "Save Log As";
        private const string SaveAsExtension = "txt";
        private const string SaveAsFilter = "Text Documents (*.txt)|*.txt";

        //***************************
        // Configuration Parameters
        //***************************
        //***************************
        // Configuration Parameters
        //***************************
        private const string AdlsAccountNameParameter = "adlsAccountName";
        private const string SubscriptionIdParameter = "subscriptionId";
        private const string TenantIdParameter = "tenantId";
        private const string ClientIdParameter = "clientId";
        private const string RedirectUriParameter = "redirectUri";

        //***************************
        // Icons
        //***************************
        private const int AzureIconIndex = 0;
        private const int FolderIconIndex = 1;
        private const int FileIconIndex = 2;

        //***************************
        // ListView Column Indexes
        //***************************
        private const int NameListViewColumnIndex = 0;
        private const int SizeListViewColumnIndex = 1;
        private const int LastModifiedListViewColumnIndex = 2;
        #endregion

        #region Public Constructor
        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ReadConfiguration();
        }
        #endregion

        #region Private Fields
        private TreeNode rootNode;
        private string subscriptionId;
        private string tenantId;
        private string clientId;
        private string redirectUri;
        private static DataLakeStoreFileSystemManagementClient adlsFileSystemClient;
        private static string adlsAccountName;
        #endregion

        #region Public Methods
        public void HandleException(Exception ex)
        {
            if (string.IsNullOrEmpty(ex?.Message))
            {
                return;
            }
            WriteToLog(string.Format(CultureInfo.CurrentCulture, ExceptionFormat, ex.Message));
            if (!string.IsNullOrEmpty(ex.InnerException?.Message))
            {
                WriteToLog(string.Format(CultureInfo.CurrentCulture, InnerExceptionFormat, ex.InnerException.Message));
            }
        }
        #endregion

        #region Private Methods
        public static bool IsJson(string item)
        {
            if (item == null)
            {
                throw new ArgumentException("The item argument cannot be null.");
            }
            try
            {
                var obj = JToken.Parse(item);
                return obj != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string IndentJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
        #endregion

        #region Private Methods
        private async Task GetEntities()
        {
            try
            {
                // Authenticate the user
                var tokenCredentials = await AuthenticateUserAsync(tenantId, 
                                                                   "https://management.core.windows.net/",
                                                                    clientId, 
                                                                    new Uri(redirectUri));

                SetupClients(tokenCredentials, subscriptionId);

                Cursor = Cursors.WaitCursor;
                dataLakeTreeView.SuspendLayout();
                dataLakeTreeView.BeginUpdate();
                dataLakeTreeView.Nodes.Clear();

                var rootNodeUri = $"adl://{adlsAccountName.ToLower()}.azuredatalakestore.net/";
                rootNode = dataLakeTreeView.Nodes.Add(rootNodeUri,
                                                      rootNodeUri,
                                                      AzureIconIndex,
                                                      AzureIconIndex);

                WriteToLog($"The application is now connected to the {adlsAccountName} account.");

                var fileStatusesResult = await adlsFileSystemClient.FileSystem.ListFileStatusAsync(adlsAccountName, "/");
                rootNode.Tag = new NodeTag
                {
                    FileStatusProperties = null,
                    Children = fileStatusesResult.FileStatuses.FileStatus
                };
                if (fileStatusesResult.FileStatuses != null &&
                    fileStatusesResult.FileStatuses.FileStatus.Any())
                {
                    foreach (var fileStatusProperties in fileStatusesResult.
                                                  FileStatuses.
                                                  FileStatus.
                                                  Where(fileStatus => fileStatus.Type == FileType.DIRECTORY))
                    {
                        WriteToLog($"The directory {fileStatusProperties.PathSuffix} has been successfully retrieved.");

                        var node = rootNode.Nodes.Add(fileStatusProperties.PathSuffix,
                                                      fileStatusProperties.PathSuffix,
                                                      FolderIconIndex,
                                                      FolderIconIndex);
                        node.Nodes.Add(PlaceHolderNode,
                                       PlaceHolderNode,
                                       FolderIconIndex,
                                       FolderIconIndex);
                        node.Tag = new NodeTag
                        {
                            FileStatusProperties = fileStatusProperties,
                            Children = null
                        };
                    }
                }

                ShowChildren(rootNode);
                rootNode.Expand();
                dataLakeTreeView.SelectedNode = rootNode;
                dataLakeTreeView.SelectedNode.EnsureVisible();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                dataLakeTreeView.ResumeLayout();
                dataLakeTreeView.EndUpdate();
                dataLakeTreeView.Refresh();
                Cursor = Cursors.Default;
            }
        }

        private void ReadConfiguration()
        {
            try
            {
                adlsAccountName = ConfigurationManager.AppSettings[AdlsAccountNameParameter];
                if (string.IsNullOrWhiteSpace(adlsAccountName))
                {
                    WriteToLog("adlsAccountName setting cannot be null.");
                }
                subscriptionId = ConfigurationManager.AppSettings[SubscriptionIdParameter];
                if (string.IsNullOrWhiteSpace(subscriptionId))
                {
                    WriteToLog("subscriptionId setting cannot be null.");
                }
                tenantId = ConfigurationManager.AppSettings[TenantIdParameter];
                if (string.IsNullOrWhiteSpace(tenantId))
                {
                    WriteToLog("tenantId setting cannot be null.");
                }
                clientId = ConfigurationManager.AppSettings[ClientIdParameter];
                if (string.IsNullOrWhiteSpace(clientId))
                {
                    WriteToLog("clientId setting cannot be null.");
                }
                redirectUri = ConfigurationManager.AppSettings[RedirectUriParameter];
                if (string.IsNullOrWhiteSpace(redirectUri))
                {
                    WriteToLog("redirectUri setting cannot be null.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void WriteToLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(InternalWriteToLog), message);
            }
            else
            {
                InternalWriteToLog(message);
            }
        }

        private void InternalWriteToLog(string message)
        {
            lock (this)
            {
                if (string.IsNullOrEmpty(message))
                {
                    return;
                }
                var lines = message.Split('\n');
                var now = DateTime.Now;
                var space = new string(' ', 19);

                for (var i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                    {
                        var line = string.Format(DateFormat,
                                                 now.Hour,
                                                 now.Minute,
                                                 now.Second,
                                                 lines[i]);
                        lstLog.Items.Add(line);
                    }
                    else
                    {
                        lstLog.Items.Add(space + lines[i]);
                    }
                }
                lstLog.SelectedIndex = lstLog.Items.Count - 1;
                lstLog.SelectedIndex = -1;
            }
        }

        private string GetFullPath(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            if (node == rootNode)
            {
                return "/";
            }
            return $"{GetFullPath(node.Parent)}/{((NodeTag)(node.Tag)).FileStatusProperties.PathSuffix}";
        }

        private async Task<bool> GetChildrenAsync(TreeNode node, FileType? fileType = null)
        {
            if (!(node?.Tag is NodeTag))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(node.FirstNode?.Name) ||
                string.Compare(node.FirstNode.Name,
                               PlaceHolderNode,
                               StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return false;
            }
            // Remove the placeholder node
            node.FirstNode.Remove();

            // Retrieve children items
            var childrenList = await RefreshChildrenAsync(node, fileType);

            var fileStatusPropertieses = childrenList as IList<FileStatusProperties> ?? childrenList.ToList();
            var nodeTag = (NodeTag) node.Tag;
            nodeTag.Children = fileStatusPropertieses;
            if (!fileStatusPropertieses.Any())
            {
                return true;
            }
            foreach (var childFileStatus in fileStatusPropertieses.Where(f => f.Type == FileType.DIRECTORY))
            {
                var childNode = node.Nodes.Add(childFileStatus.PathSuffix,
                                               childFileStatus.PathSuffix,
                                               FolderIconIndex,
                                               FolderIconIndex);
                childNode.Nodes.Add(PlaceHolderNode,
                                    PlaceHolderNode,
                                    FolderIconIndex,
                                    FolderIconIndex);
                childNode.Tag = new NodeTag
                {
                    FileStatusProperties = childFileStatus,
                    Children = null
                };
            }
            return true;
        }

        private async Task<IEnumerable<FileStatusProperties>> RefreshChildrenAsync(TreeNode node, FileType? fileType)
        {
            if (!(node?.Tag is NodeTag))
            {
                return null;
            }

            // Retrieve children nodes
            var childFileStatusesResult = await adlsFileSystemClient.FileSystem.ListFileStatusAsync(adlsAccountName,
                                                                                                    GetFullPath(node));
            if (childFileStatusesResult?.FileStatuses == null ||
                !childFileStatusesResult.FileStatuses.FileStatus.Any())
            {
                return null;
            }
            Func<FileStatusProperties, bool> predicate = f => fileType == null ||
                                                        (fileType.Value == FileType.DIRECTORY ?
                                                        f.Type == FileType.DIRECTORY :
                                                        f.Type == FileType.FILE);
            var childrenList = childFileStatusesResult.FileStatuses.FileStatus;
            foreach (var item in childrenList)
            {
                WriteToLog($"The {item.PathSuffix} {item.Type.ToString().ToLower()} has been successfully retrieved.");
            }
            return childrenList.Where(predicate);
        }

        private async void HandleNodeMouseClick(TreeNode node)
        {
            try
            {
                dataLakeTreeView.SuspendLayout();
                if (!(node?.Tag is NodeTag))
                {
                    return;
                }
                await GetChildrenAsync(node);
                ShowChildren(node);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                dataLakeTreeView.ResumeLayout();
            }
        }

        private void ShowChildren(TreeNode node)
        {
            if (!(node?.Tag is NodeTag))
            {
                return;
            }
            var nodeTag = (NodeTag) node.Tag;
            var childrenList = nodeTag.Children;
            fileListView.Items.Clear();
            foreach (var childFileStatus in childrenList)
            {
                if (childFileStatus.Type == FileType.DIRECTORY)
                {
                    var item = new ListViewItem(childFileStatus.PathSuffix, FolderIconIndex);
                    item.SubItems.Add("N/A");
                    item.SubItems.Add(childFileStatus.ModificationTime.HasValue ?
                                     DateFromTimestamp(childFileStatus.ModificationTime.Value).ToString(CultureInfo.InvariantCulture) :
                                     "N/A");
                    item.Tag = childFileStatus;
                    fileListView.Items.Add(item);
                }
                else
                {
                    var item = new ListViewItem(childFileStatus.PathSuffix, FileIconIndex);
                    var sizeInMb = childFileStatus.Length.HasValue ? 
                                   $"{(((double)childFileStatus.Length.Value) / 1048576):0.00} MB" :
                                    "N/A";
                    item.SubItems.Add(sizeInMb);
                    item.SubItems.Add(childFileStatus.ModificationTime.HasValue ?
                                     DateFromTimestamp(childFileStatus.ModificationTime.Value).ToString(CultureInfo.InvariantCulture) :
                                     "N/A");
                    item.Tag = childFileStatus;
                    fileListView.Items.Add(item);
                }
            }
        }

        private void SaveLog(bool all)
        {
            try
            {
                saveFileDialog.Title = SaveAsTitle;
                saveFileDialog.DefaultExt = SaveAsExtension;
                saveFileDialog.Filter = SaveAsFilter;
                saveFileDialog.FileName = string.Format(LogFileNameFormat, DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace('/', '-').Replace(':', '-'));
                if (saveFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    return;
                }
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    if (all)
                    {
                        foreach (var t in lstLog.Items)
                        {
                            writer.WriteLine(t as string);
                        }
                    }
                    else
                    {
                        foreach (var t in lstLog.SelectedItems)
                        {
                            writer.WriteLine(t.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime DateFromTimestamp(long timestamp)
        {
            return UnixEpoch.AddMilliseconds(timestamp);
        }

        // Authenticate the user with AAD through an interactive popup.
        // You need to have an application registered with AAD in order to authenticate.
        // For more information and instructions on how to register your application with AAD, see:
        // https://azure.microsoft.com/en-us/documentation/articles/resource-group-create-service-principal-portal/
        public async Task<TokenCredentials> AuthenticateUserAsync(string tntId,
                                                                  string resource,
                                                                  string appClientId,
                                                                  Uri appRedirectUri,
                                                                  string userId = "")
        {
            var authContext = new AuthenticationContext("https://login.microsoftonline.com/" + tntId);
            var tokenAuthResult = await authContext.AcquireTokenAsync(resource,
                                                                      appClientId,
                                                                      appRedirectUri,
                                                                      new PlatformParameters(PromptBehavior.Auto));
            return new TokenCredentials(tokenAuthResult.AccessToken);
        }

        // Set up clients
        public static void SetupClients(TokenCredentials tokenCreds, string subscriptionId)
        {
            adlsFileSystemClient = new DataLakeStoreFileSystemManagementClient(tokenCreds);
        }
        #endregion

        #region Event Handlers

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        /// <summary>
        /// Saves the log to a text file
        /// </summary>
        /// <param name="sender">MainForm object</param>
        /// <param name="e">System.EventArgs parameter</param>
        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLog.Items.Count <= 0)
                {
                    return;
                }
                saveFileDialog.Title = SaveAsTitle;
                saveFileDialog.DefaultExt = SaveAsExtension;
                saveFileDialog.Filter = SaveAsFilter;
                saveFileDialog.FileName = string.Format(LogFileNameFormat, DateTime.Now.ToString(CultureInfo.CurrentUICulture).Replace('/', '-').Replace(':', '-'));
                if (saveFileDialog.ShowDialog() != DialogResult.OK || 
                    string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    return;
                }
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var t in lstLog.Items)
                    {
                        writer.WriteLine(t as string);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void logWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2Collapsed = !((ToolStripMenuItem)sender).Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void lstLog_Leave(object sender, EventArgs e)
        {
            lstLog.SelectedIndex = -1;
        }

        private void logTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawTabControlTabs(logTabControl, e, null);
        }

        private void DrawTabControlTabs(TabControl tabControl, DrawItemEventArgs e, ImageList images)
        {
            // Get the bounding end of tab strip rectangles.
            var tabstripEndRect = tabControl.GetTabRect(tabControl.TabPages.Count - 1);
            var tabstripEndRectF = new RectangleF(tabstripEndRect.X + tabstripEndRect.Width, tabstripEndRect.Y - 5,
            tabControl.Width - (tabstripEndRect.X + tabstripEndRect.Width), tabstripEndRect.Height + 5);
            var leftVerticalLineRect = new RectangleF(2, tabstripEndRect.Y + tabstripEndRect.Height + 2, 2, tabControl.TabPages[tabControl.SelectedIndex].Height + 2);
            var rightVerticalLineRect = new RectangleF(tabControl.TabPages[tabControl.SelectedIndex].Width + 4, tabstripEndRect.Y + tabstripEndRect.Height + 2, 2, tabControl.TabPages[tabControl.SelectedIndex].Height + 2);
            var bottomHorizontalLineRect = new RectangleF(2, tabstripEndRect.Y + tabstripEndRect.Height + tabControl.TabPages[tabControl.SelectedIndex].Height + 2, tabControl.TabPages[tabControl.SelectedIndex].Width + 4, 2);
            RectangleF leftVerticalBarNearFirstTab = new Rectangle(0, 0, 2, tabstripEndRect.Height + 2);

            // First, do the end of the tab strip.
            // If we have an image use it.
            if (tabControl.Parent.BackgroundImage != null)
            {
                var src = new RectangleF(tabstripEndRectF.X + tabControl.Left, tabstripEndRectF.Y + tabControl.Top, tabstripEndRectF.Width, tabstripEndRectF.Height);
                e.Graphics.DrawImage(tabControl.Parent.BackgroundImage, tabstripEndRectF, src, GraphicsUnit.Pixel);
            }
            // If we have no image, use the background color.
            else
            {
                using (Brush backBrush = new SolidBrush(tabControl.Parent.BackColor))
                {
                    e.Graphics.FillRectangle(backBrush, tabstripEndRectF);
                    e.Graphics.FillRectangle(backBrush, leftVerticalLineRect);
                    e.Graphics.FillRectangle(backBrush, rightVerticalLineRect);
                    e.Graphics.FillRectangle(backBrush, bottomHorizontalLineRect);
                    if (tabControl.SelectedIndex != 0)
                    {
                        e.Graphics.FillRectangle(backBrush, leftVerticalBarNearFirstTab);
                    }
                }
            }

            // Set up the page and the various pieces.
            var page = tabControl.TabPages[e.Index];
            using (var backBrush = new SolidBrush(page.BackColor))
            {
                using (var foreBrush = new SolidBrush(page.ForeColor))
                {
                    var tabName = page.Text;

                    // Set up the offset for an icon, the bounding rectangle and image size and then fill the background.
                    var iconOffset = 0;
                    Rectangle tabBackgroundRect;

                    if (e.Index == tabControl.SelectedIndex)
                    {
                        tabBackgroundRect = e.Bounds;
                        e.Graphics.FillRectangle(backBrush, tabBackgroundRect);
                    }
                    else
                    {
                        tabBackgroundRect = new Rectangle(e.Bounds.X, e.Bounds.Y - 2, e.Bounds.Width,
                                                          e.Bounds.Height + 4);
                        e.Graphics.FillRectangle(backBrush, tabBackgroundRect);
                        var rect = new Rectangle(e.Bounds.X - 2, e.Bounds.Y - 2, 1, 2);
                        e.Graphics.FillRectangle(backBrush, rect);
                        rect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y - 2, 1, 2);
                        e.Graphics.FillRectangle(backBrush, rect);
                        rect = new Rectangle(e.Bounds.X + e.Bounds.Width, e.Bounds.Y - 2, 1, 2);
                        e.Graphics.FillRectangle(backBrush, rect);
                        rect = new Rectangle(e.Bounds.X + e.Bounds.Width + 1, e.Bounds.Y - 2, 1, 2);
                        e.Graphics.FillRectangle(backBrush, rect);
                    }

                    // If we have images, process them.
                    if (images != null)
                    {
                        // Get sice and image.
                        var size = images.ImageSize;
                        Image icon = null;
                        if (page.ImageIndex > -1)
                            icon = images.Images[page.ImageIndex];
                        else if (page.ImageKey != "")
                            icon = images.Images[page.ImageKey];

                        // If there is an image, use it.
                        if (icon != null)
                        {
                            var startPoint =
                                new Point(tabBackgroundRect.X + 2 + ((tabBackgroundRect.Height - size.Height) / 2),
                                          tabBackgroundRect.Y + 2 + ((tabBackgroundRect.Height - size.Height) / 2));
                            e.Graphics.DrawImage(icon, new Rectangle(startPoint, size));
                            iconOffset = size.Width + 4;
                        }
                    }

                    // Draw out the label.
                    var labelRect = new Rectangle(tabBackgroundRect.X + iconOffset, tabBackgroundRect.Y + 5,
                                                  tabBackgroundRect.Width - iconOffset, tabBackgroundRect.Height - 3);
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawString(tabName, new Font(e.Font.FontFamily, 8.25F, e.Font.Style), foreBrush, labelRect, sf);
                    }
                }
            }
        }

        private async void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await GetEntities();
        }

        private void fileListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            var startX = e.ColumnIndex == 0 ? -1 : e.Bounds.X;
            var endX = e.Bounds.X + e.Bounds.Width - 1;
            // Background
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(215, 228, 242)), startX, -1, e.Bounds.Width + 1, e.Bounds.Height + 1);
            // Left vertical line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlLightLight), startX, -1, startX, e.Bounds.Y + e.Bounds.Height + 1);
            // TopCount horizontal line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlLightLight), startX, -1, endX, -1);
            // Bottom horizontal line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), startX, e.Bounds.Height - 1, endX, e.Bounds.Height - 1);
            // Right vertical line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), endX, -1, endX, e.Bounds.Height + 1);
            var roundedFontSize = (float)Math.Round(e.Font.SizeInPoints);
            var bounds = new RectangleF(e.Bounds.X + 4, (e.Bounds.Height - 8 - roundedFontSize) / 2, e.Bounds.Width, roundedFontSize + 6);
            e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(SystemColors.ControlText), bounds);
        }

        private void fileListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
            //e.DrawBackground();
            //e.DrawText();
        }

        private void fileListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void fileListView_Resize(object sender, EventArgs e)
        {
            try
            {
                fileListView.SuspendLayout();
                var listView = sender as ListView;
                if (listView == null)
                {
                    return;
                }
                var columnWidth = listView.Width -
                                  listView.Columns[SizeListViewColumnIndex].Width -
                                  listView.Columns[LastModifiedListViewColumnIndex].Width;
                listView.Columns[NameListViewColumnIndex].Width = columnWidth;
            }
            finally
            {
                fileListView.ResumeLayout();
            }
        }

        private void dataLakeTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var treeView = sender as TreeView;
            if (treeView == null ||treeView.SelectedNode == e.Node || e.Node == rootNode)
            {
                return;
            }
            var node = e.Node;
            treeView.SelectedNode = node;
            e.Node.EnsureVisible();
            HandleNodeMouseClick(e.Node);
        }

        private async void fileListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (fileListView.SelectedItems.Count <= 0)
                {
                    return;
                }
                var item = fileListView.SelectedItems[0];
                if (!(item.Tag is FileStatusProperties))
                {
                    return;
                }
                var tag = (FileStatusProperties) item.Tag;
                if (tag.Type == FileType.DIRECTORY)
                {
                    var nodeArray = dataLakeTreeView.SelectedNode.Nodes.Find(item.Text, true);
                    if (nodeArray.Length <= 0)
                    {
                        return;
                    }
                    var node = nodeArray[0];
                    dataLakeTreeView.SelectedNode = node;
                    HandleNodeMouseClick(node);
                    node.Expand();
                }
                else
                {
                    var file = tag.PathSuffix;
                    var path = $"{GetFullPath(dataLakeTreeView.SelectedNode)}/{file}";
                    using (var stream = adlsFileSystemClient.FileSystem.Open(adlsAccountName, path))
                    {
                        WriteToLog($"File {file} successfully opened");
                        using (var streamReader = new StreamReader(stream))
                        {
                            WriteToLog($"Reading {file}...");
                            var content = await streamReader.ReadToEndAsync();
                            WriteToLog($"File {file} successfully read.");
                            if (string.IsNullOrEmpty(content))
                            {
                                return;
                            }
                            var ok = false;
                            if (content[0] != '[')
                            {
                                var index = content.IndexOf('\r');
                                if (content[0] == '{' && index > 0)
                                {
                                    var entity = content.Substring(0, index);
                                    if (IsJson(entity))
                                    {
                                        content = content.Replace("}", "},");
                                        content = content.Substring(0, content.Length - 1);
                                        content = $"[{content}]";
                                        ok = true;
                                    }
                                }
                            }
                            else
                            {
                                var closingBracket = content.IndexOf("]", StringComparison.Ordinal);
                                if (closingBracket < 0)
                                {
                                    content = $"{content}]";
                                }
                                ok = IsJson(content);
                            }
                            if (!ok)
                            {
                                return;
                            }
                            WriteToLog("Loading JSON data in the treeview...");
                            jsonTreeView.LoadJsonArrayToTreeView(content);
                            WriteToLog("JSON data successfully loaded in the treeview. Open the JSON tab to read data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new StringBuilder();
                foreach (var item in lstLog.Items)
                {
                    builder.AppendLine(item.ToString());
                }
                if (builder.Length > 0)
                {
                    Clipboard.SetText(builder.ToString());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new StringBuilder();
                foreach (var item in lstLog.SelectedItems)
                {
                    builder.AppendLine(item.ToString());
                }
                if (builder.Length > 0)
                {
                    Clipboard.SetText(builder.ToString());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        private void clearSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new StringBuilder();
                var list = new List<object>();
                list.AddRange(lstLog.SelectedItems.Cast<object>().ToArray());
                foreach (var item in list)
                {
                    lstLog.Items.Remove(item);
                }
                if (builder.Length > 0)
                {
                    Clipboard.SetText(builder.ToString());
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLog(true);
        }

        private void saveSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLog(false);
        }
        #endregion
    }

    public class NodeTag
    {
        public FileStatusProperties FileStatusProperties { get; set; }
        public IList<FileStatusProperties> Children { get; set; }
    }
}
