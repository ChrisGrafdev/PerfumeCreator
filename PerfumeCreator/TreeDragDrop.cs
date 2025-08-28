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
        private FormComponentUseCase _formComponentUseCase;

        public TreeDragDrop(FormComponentUseCase formComponentUseCase, TreeView targetTreeView, ToolStripStatusLabel statusLabel = null)
        {
            _formComponentUseCase = formComponentUseCase;
            _refTreeView = targetTreeView;
            _refStatusLabel = statusLabel;
        }

        public bool ExecuteTreeNodeDragDrop(TreeNode draggedNode, DragEventArgs e)
        {
            object compatible = draggedNode?.Tag;
            if (compatible == null || e == null) return false;

            if (compatible is IOnlyAccordCompatible || compatible is IAccordPerfumeCompatible)
            {
                // Get target location
                Point targetPoint = _refTreeView.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = _refTreeView.GetNodeAt(targetPoint);

                // Create new/first Accord/Perfume entry
                if (targetNode == null)
                {
                    // open CreateAccord-Form
                    var createCollectionWindow = new FormCreateCollection(_formComponentUseCase, compatible);
                    createCollectionWindow.CreateAccordAction += (newCollection) =>
                    {
                        if (newCollection == null)
                        {
                            if (_refStatusLabel != null) _refStatusLabel.Text = "Abort creation of new accord";
                            return;
                        }
                        TreeNode newCollectionNode = AccordAsTreeNode(newCollection);
                        _refTreeView.Nodes.Add(newCollectionNode);
                        return; // ?
                    };
                    createCollectionWindow.Show();
                }
                // Add Molecule/Accord to existing Accord
                else
                {
                    // open DefineAmount-Form
                    var addMaterialAmountWindow = new FormDefineAmount(((Basis)accordCompatible)._name);
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
                            if (accordCompatible is Basis fragranceComponent)
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

        private TreeNode CollectionAsTreeNode(object collection)
        {
            List<TreeNode> ingredientTreeNodes = new List<TreeNode>();
            if (collection is Accord accord)
            {
                List<(IOnlyAccordCompatible, MaterialUnit)> ingredients = accord.GetIngredientsList();
                foreach ((IOnlyAccordCompatible Frag, MaterialUnit Amount) in ingredients)
                {
                    //ingredientTreeNodes.Add(AddComponentToAccord(Frag, Amount));
                }
                TreeNode newCollectionNode = new TreeNode(accord._name, ingredientTreeNodes.ToArray());
                newCollectionNode.Tag = accord;
                return newCollectionNode;
            }
            else if(collection is Perfume perfume)
            {
                List<(IAccordPerfumeCompatible, MaterialUnit)> ingredients = perfume.GetIngredientsList();
                foreach ((IAccordPerfumeCompatible Frag, MaterialUnit Amount) in ingredients)
                {
                    //ingredientTreeNodes.Add(AddComponentToAccord(Frag, Amount));
                }
                TreeNode newCollectionNode = new TreeNode(accord._name, ingredientTreeNodes.ToArray());
                newCollectionNode.Tag = accord;
                return newCollectionNode;
            }
        }

        private TreeNode AddComponentToAccord(IOnlyAccordCompatible accordComponent, MaterialUnit amount)
        {
            if (accordComponent == null || amount == null)
            {
                toolStripStatusLabelMain.Text = "Fragrance or Amount is not set";
                return null;
            }

            if (accordComponent is Basis fragrance)
            {
                string amountString = amount.GetUnitAmount(Globals.ViewportMaterialUnit).ToString() + " " + Globals.ViewportMaterialUnit.ToString();
                //if (Globals.ViewportMaterialUnit == UnitType.Drops)
                //    amountString = amount.GetDropAmount().ToString() + " drops";
                //else
                //    amountString = amount.GetMilligramAmount().ToString() + " mg";
                TreeNode moleculeNode = new TreeNode(fragrance._name + " : " + amountString);
                moleculeNode.Tag = (accordComponent, amount);
                return moleculeNode;
            }
            /*else if (accordComponent is Accord subAccord)
            {
                string amountString;
                if (Globals.ViewportMaterialUnit == UnitType.Drops)
                    amountString = amount.GetDropAmount().ToString() + " drops";
                else
                    amountString = amount.GetMilligramAmount().ToString() + " mg";
                TreeNode accordNode = new TreeNode(subAccord._name + " : " + amountString);
                accordNode.Tag = (subAccord, amount);
                return accordNode;
            }*/
            // Error -> should not accure due to previous checks
            toolStripStatusLabelMain.Text = "Error while converting Molecules/Accords to Nodes";
            return null;
        }
    }
}
