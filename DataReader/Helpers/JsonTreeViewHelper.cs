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

#region Using Guidelines
using System.Windows.Forms;
using Newtonsoft.Json.Linq; 
#endregion

namespace Microsoft.AzureCat.Samples.DataReader.Helpers
{
    public static class JsonTreeViewHelper
    {
        #region Private Constants
        private const int NodeIconIndex = 3;
        #endregion

        #region Public Static Methods
        public static void LoadJsonToTreeView(this TreeView treeView, string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            var jobject = JObject.Parse(json);
            AddObjectNodes(jobject, "JSON", treeView.Nodes);
        }

        public static void LoadJsonArrayToTreeView(this TreeView treeView, string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            var array = JArray.Parse(json);
            foreach (var item in array)
            {
                AddObjectNodes(item.ToObject<JObject>(), "record", treeView.Nodes);
            }
        }

        public static void AddObjectNodes(JObject jobject, string name, TreeNodeCollection parent)
        {
            var node = new TreeNode(name, NodeIconIndex, NodeIconIndex);
            parent.Add(node);

            foreach (var property in jobject.Properties())
            {
                AddTokenNodes(property.Value, property.Name, node.Nodes);
            }
        }

        private static void AddArrayNodes(JArray array, string name, TreeNodeCollection parent)
        {
            var node = new TreeNode(name, NodeIconIndex, NodeIconIndex);
            parent.Add(node);

            for (var i = 0; i < array.Count; i++)
            {
                AddTokenNodes(array[i], $"[{i}]", node.Nodes);
            }
        }

        private static void AddTokenNodes(JToken token, string name, TreeNodeCollection parent)
        {
            var value = token as JValue;
            if (value != null)
            {
                parent.Add(new TreeNode($"{name}: {value.Value}", NodeIconIndex, NodeIconIndex));
            }
            else
            {
                var array = token as JArray;
                if (array != null)
                {
                    AddArrayNodes(array, name, parent);
                }
                else
                {
                    var o = token as JObject;
                    if (o != null)
                    {
                        AddObjectNodes(o, name, parent);
                    }
                }
            }
        } 
        #endregion
    }
}
