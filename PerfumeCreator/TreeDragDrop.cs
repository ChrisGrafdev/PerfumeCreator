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

            if (compatible is not IAccordPerfumeCompatible && _formComponentUseCase != FormComponentUseCase.Accord)
                return false; // wrong usecase

            if (compatible is IOnlyAccordCompatible || compatible is IAccordPerfumeCompatible)
            {
                // Get target location
                Point targetPoint = _refTreeView.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = _refTreeView.GetNodeAt(targetPoint);

                // Create new/first (root) Accord/Perfume entry
                if (targetNode == null)
                {
                    Action<object?> createCollectionHandler = null;
                    // open CreateAccord-Form
                    var createCollectionWindow = new FormCreateCollection(_formComponentUseCase, (Basis)compatible);
                    //createCollectionWindow.CreateCollectionAction += (newCollection) =>
                    createCollectionHandler = (newCollection) =>
                    {
                        createCollectionWindow.CreateCollectionAction -= createCollectionHandler;
                        if (newCollection == null)
                        {
                            if (_refStatusLabel != null) _refStatusLabel.Text = "Abort creation of new accord";
                            return;
                        }
                        TreeNode newCollectionNode = CollectionAsTreeNode((Basis)newCollection);
                        _refTreeView.Nodes.Add(newCollectionNode);
                    };
                    if (!createCollectionWindow.IsDisposed)
                    {
                        createCollectionWindow.CreateCollectionAction += createCollectionHandler;
                        createCollectionWindow.Show();
                    }
                }
                // Add Molecule/Accord to existing Accord
                else
                {
                    // open DefineAmount-Form
                    Action<object?> materialAmountHandler = null;
                    var addMaterialAmountWindow = new FormDefineAmount(((Basis)compatible)._name);
                    //addMaterialAmountWindow.AddAmountAction += (newAmount) =>
                    materialAmountHandler = (newAmount) =>
                    {
                        addMaterialAmountWindow.AddAmountAction -= materialAmountHandler;
                        if (newAmount == null)
                        {
                            if (_refStatusLabel != null) _refStatusLabel.Text = "Amount is required, abort adding new Element";
                            return;
                        }
                        MaterialUnit materialAmount = (MaterialUnit)newAmount;
                        // find the Root-Node
                        while (targetNode?.Parent != null)
                        {
                            targetNode = targetNode.Parent;
                        }
                        if (targetNode?.Tag is Accord existingAccord && compatible is IOnlyAccordCompatible accordComp)
                        {
                            // add component to accord mixture
                            existingAccord.AddComponentToAccord(accordComp, materialAmount);
                            // update TreeView
                            targetNode.Nodes.Add(ComponentAsTreeNode((Basis)accordComp, materialAmount));
                            return;
                        }
                        else if (targetNode?.Tag is Perfume existingPerfume && compatible is IAccordPerfumeCompatible perfumeComp)
                        {
                            existingPerfume.AddComponentToPerfume(perfumeComp, materialAmount);
                            targetNode.Nodes.Add(ComponentAsTreeNode((Basis)perfumeComp, materialAmount));
                            return;
                        }
                        // should not reach this point -> possible error
                        if (_refStatusLabel != null)
                            _refStatusLabel.Text = "New Component could not be merged to existing TreeNode";
                    };
                    addMaterialAmountWindow.AddAmountAction += materialAmountHandler;
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

        private TreeNode? CollectionAsTreeNode(Basis collection)
        {
            List<TreeNode> ingredientTreeNodes = new List<TreeNode>();
            if (collection is Molecule || collection is Diluent) return null;

            if (collection is Accord)
            {
                List<(IOnlyAccordCompatible, MaterialUnit)> ingredients = ((Accord)collection).GetIngredientsList();

                foreach ((IOnlyAccordCompatible Frag, MaterialUnit Amount) in ingredients)
                {
                    ingredientTreeNodes.Add(ComponentAsTreeNode((Basis)Frag, Amount));
                }
                TreeNode newCollectionNode = new TreeNode(collection._name, ingredientTreeNodes.ToArray());
                newCollectionNode.Tag = collection;
                return newCollectionNode;
            }
            else if (collection is Perfume)
            {
                List<(IAccordPerfumeCompatible, MaterialUnit)> ingredients = ((Perfume)collection).GetIngredientsList();

                foreach ((IAccordPerfumeCompatible Frag, MaterialUnit Amount) in ingredients)
                {
                    ingredientTreeNodes.Add(ComponentAsTreeNode((Basis)Frag, Amount));
                }
                TreeNode newCollectionNode = new TreeNode(collection._name, ingredientTreeNodes.ToArray());
                newCollectionNode.Tag = collection;
                return newCollectionNode;
            }
            return null;
        }

        private TreeNode? ComponentAsTreeNode(Basis component, MaterialUnit amount)
        {
            if (component == null || amount == null)
            {
                if (_refStatusLabel != null) _refStatusLabel.Text = "Component or Amount is not set";
                return null;
            }

            string amountString = amount.GetUnitAmount(Globals.ViewportMaterialUnit).ToString() + " " + Globals.ViewportMaterialUnit.ToString();

            TreeNode moleculeNode = new TreeNode(component._name + " : " + amountString);
            moleculeNode.Tag = (component, amount);
            return moleculeNode;
        }
    }
}
