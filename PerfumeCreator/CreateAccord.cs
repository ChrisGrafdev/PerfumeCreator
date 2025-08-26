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
    public partial class FormCreateAccord : Form
    {
        public event Action<Accord> CreateAccordAction;

        public FormCreateAccord(IAccordCompatible compatibleBase)
        {
            InitializeComponent();
            this.AcceptButton = buttonAccCreateSave;
            string fragranceName = ((Fragrance)compatibleBase)._name;
            comboBoxAccCreateCategory.DataSource = Enum.GetValues(typeof(ScentCategory));
            comboBoxAccCreateNoteLevel.DataSource = Enum.GetValues(typeof(NoteLevel));
            _compatibleBase = compatibleBase;

            // open MaterialAmount-Form
            var addMaterialAmountWindow = new FormDefineAmount(fragranceName);
            addMaterialAmountWindow.AddAmountAction += (newAmount) =>
            {
                if (newAmount == null) // AddAmount canceled
                {
                    CreateAccordAction?.Invoke(null);
                    this.Close();
                }
                _materialUnit = (MaterialUnit)newAmount;
            };
            addMaterialAmountWindow.ShowDialog();
            //addMaterialAmountWindow.Show();
        }

        private MaterialUnit _materialUnit;
        private IAccordCompatible _compatibleBase;
        private string _name;
        private ScentCategory _scentCategory;
        private NoteLevel _noteLevel;
        private string _comment;
        private void buttonAccCreateSave_Click(object sender, EventArgs e)
        {
            if (!checkData()) return;

            Accord accord = new Accord(_name, _compatibleBase, _materialUnit); //_scentCategory, _noteLevel, _comment);

            CreateAccordAction?.Invoke(accord);

            this.Close();
        }

        private bool checkData()
        {
            _name = textBoxAccCreateName.Text;
            if (_name == "") return false;
            _scentCategory = (ScentCategory)comboBoxAccCreateCategory.SelectedItem;
            _noteLevel = (NoteLevel)comboBoxAccCreateNoteLevel.SelectedItem;
            _comment = textBoxAccCreateComment.Text;
            return true;
        }

        private void buttonAccCreateCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
