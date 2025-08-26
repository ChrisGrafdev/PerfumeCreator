using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfumeCreator
{
    public partial class FormDefineAmount : Form
    {
        public event Action<MaterialUnit> AddAmountAction;
        private MaterialUnit _existingMaterialAmount = null;
        public FormDefineAmount(string fragranceName)
        {
            InitializeComponent();
            this.AcceptButton = buttonAddAmountSave;
            labelAddAmountFragrance.Text = fragranceName;
            comboBoxAddAmountUnit.DataSource = Enum.GetValues(typeof(UnitType));
        }
        public FormDefineAmount(string fragranceName, MaterialUnit existingAmount)
        {
            InitializeComponent();
            this.AcceptButton = buttonAddAmountSave;
            labelAddAmountFragrance.Text = fragranceName;
            comboBoxAddAmountUnit.DataSource = Enum.GetValues(typeof(UnitType));
            _existingMaterialAmount = existingAmount;
            comboBoxAddAmountUnit.SelectedItem = Globals.ViewportMaterialUnit;
            textBoxAddAmountValue.Text = existingAmount.GetUnitAmount(Globals.ViewportMaterialUnit).ToString();
        }

        private void buttonAddAmountSave_Click(object sender, EventArgs e)
        {
            if (textBoxAddAmountValue.Text.Length == 0)
            {
                // invoke function for input checking - tbd
                return;
            }
            float amount;
            if (!(float.TryParse(textBoxAddAmountValue.Text, out amount)))
            {
                // invoke function for input checking - tbd
                return;
            }

            MaterialUnit materialUnit = new MaterialUnit((UnitType)comboBoxAddAmountUnit.SelectedIndex, amount);
            AddAmountAction?.Invoke(materialUnit);

            this.Close();
        }

        private void buttonAddAmountCancel_Click(object sender, EventArgs e)
        {
            AddAmountAction?.Invoke(null);
            this.Close();
        }
    }
}
