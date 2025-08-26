using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeCreator
{
    public class TreeDragDrop
    {
        private TreeView _refTreeView;
        private ToolStripStatusLabel _refStatusLabel = null;
        public TreeDragDrop(TreeView targetTreeView, ToolStripStatusLabel statusLabel = null)
        {
            _refTreeView = targetTreeView;
            _refStatusLabel = statusLabel;
        }

        public bool ExecuteTreeNodeDragDrop(TreeNode draggedNode, DragEventArgs e)
        {
            if (draggedNode?.Tag is IAccordCompatible accordCompatible)
            {
                // Get target location
                Point targetPoint = _refTreeView.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = _refTreeView.GetNodeAt(targetPoint);

                // Create new/first Accord entry
                if (targetNode == null)
                {
                    // open CreateAccord-Form
                    var createAccordWindow = new FormCreateAccord(accordCompatible);
                    createAccordWindow.CreateAccordAction += (newAccord) =>
                    {
                        if (newAccord == null)
                        {
                            if (_refStatusLabel != null) _refStatusLabel.Text = "Abort creation of new accord";
                            return;
                        }
                        TreeNode newAccordNode = AccordAsTreeNode(newAccord);
                        _refTreeView.Nodes.Add(newAccordNode);
                        return; // ?
                    };
                    createAccordWindow.Show();
                }
                // Add Molecule/Accord to existing Accord
                else
                {
                    // open DefineAmount-Form
                    var addMaterialAmountWindow = new FormDefineAmount(((Fragrance)accordCompatible)._name);
                    addMaterialAmountWindow.AddAmountAction += (newAmount) =>
                    {
                        if (newAmount == null)
                        {
                            if(_refStatusLabel != null) _refStatusLabel.Text = "Amount is required, abort adding new Element";
                            return;
                        }
                        MaterialUnit materialAmount = (MaterialUnit)newAmount;
                        // find the Root-Node
                        while (targetNode?.Parent != null)
                        {
                            targetNode = targetNode.Parent;
                        }
                        if (targetNode?.Tag is Accord existingAccord)
                        {
                            if (accordCompatible is Fragrance fragranceComponent)
                            {
                                existingAccord.mixFragrance(fragranceComponent, materialAmount);
                            }
                            else if (accordCompatible is Diluent diluentComponent)
                            {
                                existingAccord.diluteFragrance(diluentComponent, materialAmount);
                            }
                            else
                            {
                                if (_refStatusLabel != null) _refStatusLabel.Text = "Added Component is rather Fragrance nor Diluent";
                                return;
                            }
                            // update TreeView
                            targetNode.Nodes.Add(AddComponentToAccord(accordCompatible, materialAmount));
                        }
                        else
                        {
                            _refStatusLabel.Text = "TargetNode has no Accord-Tag";
                            return;
                        }
                    };
                    addMaterialAmountWindow.ShowDialog();
                }
                return true;
            }
            else if (_refStatusLabel != null)
            {
                _refStatusLabel.Text = "Object is not Compatible! - aborting";
            }
            return false;
        }


    }
}
