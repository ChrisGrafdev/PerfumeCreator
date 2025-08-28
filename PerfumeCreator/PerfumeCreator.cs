namespace PerfumeCreator
{
    public partial class FormPerfumeCreator : Form
    {
        //#####################################
        // Initial window/application settings
        //#####################################
        private double mainSplitterRatio = 0.75;
        public FormPerfumeCreator()
        {
            InitializeComponent();
            splitContainerL0.SplitterMoved += SplitContainerL0_SplitterMoved;
            this.Resize += PerfumeCreator_Resize;

            comboBoxDilutionCalcMode.DataSource = Enum.GetValues(typeof(DilutionTarget));
            comboBoxDilutionCalcInputUnit.DataSource = Enum.GetValues(typeof(UnitType));
        }

        //#######################
        // Window Action Methods
        //#######################
        private void PerfumeCreator_Resize(object? sender, EventArgs e) // not working?
        {
            splitContainerL0.SplitterDistance = (int)(splitContainerL0.Width * mainSplitterRatio);
        }

        private void SplitContainerL0_SplitterMoved(object sender, SplitterEventArgs e)
        {
            mainSplitterRatio = (double)splitContainerL0.SplitterDistance / splitContainerL0.Width;
        }


        //######################
        // Application controls
        //######################
        private void butAddMolecule_Click(object sender, EventArgs e)
        {
            var createMoleculeWindow = new FormCreateMolecule();
            createMoleculeWindow.CreateMoleculeAction += (newMolecule) =>
            {
                if (newMolecule == null) return;
                TreeNode treeNode = MoleculeAsTreeNode(newMolecule);
                bool categoryFound = false;
                foreach (TreeNode categoryNode in treeViewMolecule.Nodes)
                {
                    if (categoryNode.Text == treeNode.Text)
                    {
                        categoryNode.Nodes.Add(treeNode.Nodes[0]);
                        categoryFound = true;
                    }
                }
                if (!categoryFound)
                    treeViewMolecule.Nodes.Add(treeNode);
            };
            createMoleculeWindow.Show();
        }

        private double _fragranceAmount;
        private double _diluentAmount;
        private void buttonDiluentCalcCalculate_Click(object sender, EventArgs e)
        {
            string inputText = textBoxDilutionCalcInputAmount.Text;
            string percentageText = textBoxDilutionCalcFinalPercent.Text;
            double inputAmountValue;
            double percentageValue;
            if (!(double.TryParse(inputText, out inputAmountValue)))
            {
                textBoxDilutionCalcInputAmount.BackColor = Color.Red;
                buttonDiluentCalcSetResult.Enabled = false;
                return;
            }
            if (!(double.TryParse(percentageText, out percentageValue)))
            {
                textBoxDilutionCalcFinalPercent.BackColor = Color.Red;
                buttonDiluentCalcSetResult.Enabled = false;
                return;
            }

            if (percentageValue < 0)
            {
                toolStripStatusLabelMain.Text = "Percentage value out of range";
                percentageValue = 0;
                textBoxDilutionCalcFinalPercent.Text = "0";
            }
            else if (percentageValue > 100)
            {
                toolStripStatusLabelMain.Text = "Percentage value out of range";
                percentageValue = 100;
                textBoxDilutionCalcFinalPercent.Text = "100";
            }
            percentageValue /= 100.0;
            if ((DilutionTarget)comboBoxDilutionCalcMode.SelectedItem == DilutionTarget.InputAmount)
            {
                double finalAmount = inputAmountValue / percentageValue;
                _fragranceAmount = inputAmountValue;
                _diluentAmount = finalAmount - _fragranceAmount;
            }
            else
            {
                _fragranceAmount = inputAmountValue * percentageValue;
                _diluentAmount = inputAmountValue - _fragranceAmount;
            }
            labelDilutionCalcFragranceResult.Text = _fragranceAmount.ToString();
            labelDilutionCalcDiluentResult.Text = _diluentAmount.ToString();
            buttonDiluentCalcSetResult.Enabled = true;
        }

        private void textBoxDilutionCalcFinalPercent_TextChanged(object sender, EventArgs e)
        {
            textBoxDilutionCalcFinalPercent.BackColor = Color.White;
        }

        private void textBoxDilutionCalcInputAmount_TextChanged(object sender, EventArgs e)
        {
            textBoxDilutionCalcInputAmount.BackColor = Color.White;
        }

        private void buttonDiluentCalcSetResult_Click(object sender, EventArgs e)
        {
            // to be done
            toolStripStatusLabelMain.Text = "Write function not implemented yet!";
        }

        private void treeViewAccord_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode targetNode = e.Node;
            if (targetNode?.Parent == null && targetNode?.Tag is Accord existingAccord)
            {
                // Open CreateAccord Window based on current Settings...
                toolStripStatusLabelMain.Text = "Not implemented yet";
            }
            else if (targetNode?.Parent != null && targetNode?.Tag is (Basis frag, MaterialUnit amount))
            {
                // open DefineAmount-Form
                var addMaterialAmountWindow = new FormDefineAmount(frag._name, amount);
                addMaterialAmountWindow.AddAmountAction += (newAmount) =>
                {
                    if (newAmount == null)
                    {
                        toolStripStatusLabelMain.Text = "Amount is required, abort adding new Element";
                        return;
                    }
                    var (accordCompatible, _) = ((IOnlyAccordCompatible, MaterialUnit))targetNode.Tag;
                    targetNode.Tag = (accordCompatible, (MaterialUnit)newAmount);
                    targetNode.Text = frag._name + " : " + ((MaterialUnit)newAmount).GetUnitAmount(Globals.ViewportMaterialUnit).ToString() + " " + Globals.ViewportMaterialUnit.ToString();
                };
                addMaterialAmountWindow.ShowDialog();
            }
            else
            {
                toolStripStatusLabelMain.Text = "Selected target Note doesn't have a Tag";
            }
        }

        //##################################
        // addition functions for app logic
        //##################################
        private TreeNode MoleculeAsTreeNode(Molecule molecule)
        {
            TreeNode[] propertyNodes = {
                new TreeNode("Note level: " + molecule._noteLevel.ToString()),
                new TreeNode("Concentration: " + molecule._concentration.ToString()),
                new TreeNode("Dilution type: " + molecule._dilutionType.ToString()),
                new TreeNode("Manufacturer: " + molecule._manufacturer.ToString())
            };
            TreeNode[] node = { new TreeNode(molecule._name, propertyNodes) };
            node[0].Tag = molecule;

            TreeNode categoryNode = new TreeNode(molecule._scentCategory.ToString(), node);
            return categoryNode;
        }

        /*private TreeNode AccordAsTreeNode(Accord accord)
        {
            List<(IAccordCompatible Frag, MaterialUnit Amount)> ingredients = accord.getIngredients();
            List<TreeNode> ingredientTreeNodes = new List<TreeNode>();
            foreach ((IAccordCompatible Frag, MaterialUnit Amount) in ingredients)
            {
                ingredientTreeNodes.Add(AddComponentToAccord(Frag, Amount));
            }
            TreeNode newAccordNode = new TreeNode(accord._name, ingredientTreeNodes.ToArray());
            newAccordNode.Tag = accord;
            return newAccordNode;
        }*/
        /*private TreeNode AddComponentToAccord(IAccordCompatible accordComponent, MaterialUnit amount)
        {
            if (accordComponent == null || amount == null)
            {
                toolStripStatusLabelMain.Text = "Fragrance or Amount is not set";
                return null;
            }

            if (accordComponent is Fragrance fragrance)
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
            }
            // Error -> should not accure due to previous checks
            toolStripStatusLabelMain.Text = "Error while converting Molecules/Accords to Nodes";
            return null;
        }*/

        //#########################
        // Drap&Drop functionality
        //#########################

        private void treeViewMolecule_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var item = e.Item;
            if (item == null) return;

            TreeNode node = (TreeNode)item;
            if (node.Tag != null)
            {
                DoDragDrop(node, DragDropEffects.Copy);
                toolStripStatusLabelMain.Text = "Drag item: " + node.ToString();
            }
            else
            {
                toolStripStatusLabelMain.Text = "Item not dragable!";
            }
        }

        private void treeViewAccord_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var item = e.Item;
            if (item == null) return;

            TreeNode node = (TreeNode)item;
            if (node.Tag is Accord && node.Parent == null) // get root-layer Accord
            {
                DoDragDrop(node, DragDropEffects.Link);
                toolStripStatusLabelMain.Text = "Drag item: " + node.ToString();
            }
            else
            {
                toolStripStatusLabelMain.Text = "Item not dragable!";
            }
        }

        private void treeViewAccord_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                if (draggedNode?.Tag is Accord)
                {
                    e.Effect = DragDropEffects.Link;
                }
                else
                    e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeViewAccord_DragDrop(object sender, DragEventArgs e)
        {
            if (e == null) return;
            if (!e.Data.GetDataPresent(typeof(TreeNode)))
                return;

            /*TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (draggedNode?.Tag is IAccordCompatible accordCompatible)
            {
                // Get target location
                Point targetPoint = treeViewAccord.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = treeViewAccord.GetNodeAt(targetPoint);

                // Create new/first Accord entry
                if (targetNode == null)
                {
                    // open CreateAccord-Form
                    var createAccordWindow = new FormCreateAccord(accordCompatible);
                    createAccordWindow.CreateAccordAction += (newAccord) =>
                    {
                        if (newAccord == null)
                        {
                            toolStripStatusLabelMain.Text = "Abort creation of new accord";
                            return;
                        }
                        TreeNode newAccordNode = AccordAsTreeNode(newAccord);
                        treeViewAccord.Nodes.Add(newAccordNode);
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
                            toolStripStatusLabelMain.Text = "Amount is required, abort adding new Element";
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
                                toolStripStatusLabelMain.Text = "Added Component is rather Fragrance nor Diluent";
                                return;
                            }
                            // update TreeView
                            targetNode.Nodes.Add(AddComponentToAccord(accordCompatible, materialAmount));
                        }
                        else
                        {
                            toolStripStatusLabelMain.Text = "TargetNode has no Accord-Tag";
                            return;
                        }
                    };
                    addMaterialAmountWindow.ShowDialog();
                }
            }
            else
            {
                toolStripStatusLabelMain.Text = "Object is not IAccordCompatible! - aborting";
                return;
            }*/
        }


        //###################################
        // Application Setting Functionality
        //###################################

        private void dropsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // select Drops as material unit
            Globals.ViewportMaterialUnit = UnitType.Drops;
            dropsToolStripMenuItem.Checked = true;
            milligramToolStripMenuItem.Checked = false;
        }

        private void milligramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // select Milligram as material unit
            Globals.ViewportMaterialUnit = UnitType.Milligram;
            milligramToolStripMenuItem.Checked = true;
            dropsToolStripMenuItem.Checked = false;
        }

    }
}
