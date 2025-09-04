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
    public partial class FormCreateMolecule : Form
    {
        public event Action<Molecule> CreateMoleculeAction;
        public FormCreateMolecule()
        {
            InitializeComponent();
            this.AcceptButton = buttonMolCreateSave;
            comboBoxMolCreateCategory.DataSource = Enum.GetValues(typeof(ScentCategory));
            comboBoxMolCreateDilutionType.DataSource = Enum.GetValues(typeof(DilutionType));
            comboBoxMolCreateNoteLevel.DataSource = Enum.GetValues(typeof(NoteLevel));
            textBoxMolCreateName.Focus();
        }

        private void buttonMolCreateCancel_Click(object sender, EventArgs e)
        {
            CreateMoleculeAction?.Invoke(null);
            this.Close();
        }

        private string _name;
        private float _concentration;
        private DilutionType _dilutionType;
        private float _unitAmount;
        private MaterialUnit _materialUnit;
        private ScentCategory _scentCategory;
        private float _fullPrice;
        private NoteLevel _noteLevel;
        private string _manufacturer;

        private void buttonMolCreateSave_Click(object sender, EventArgs e)
        {
            if (!checkData())
            {
                // CreateMoleculeAction?.Invoke(null);
                return;
            }

            Molecule molecule = new Molecule(
                _name,
                _materialUnit,
                _concentration,
                _fullPrice,
                _dilutionType,
                _scentCategory,
                _noteLevel,
                _manufacturer);

            if (textBoxMolCreateDescription.Text.Length > 0)
                molecule._description = textBoxMolCreateDescription.Text;
            if (textBoxMolCreateComment.Text.Length > 0)
                molecule._comment = textBoxMolCreateComment.Text;
            if (textBoxMolCreateScents.Text.Length > 0)
                molecule._scents = textBoxMolCreateScents.Text.Split(',').ToList();

            CreateMoleculeAction?.Invoke(molecule);

            this.Close();
        }

        private bool checkData()
        {
            // mark all required fields in red
            _name = textBoxMolCreateName.Text;
            if (_name == "")
            {
                /*
                 * TDB: check if name already exists
                 */
                textBoxMolCreateName.BackColor = Color.OrangeRed;
                return false;
            }
            if (!(float.TryParse(textBoxMolCreateFragranceDilution.Text, out _concentration)))
            {
                textBoxMolCreateFragranceDilution.BackColor = Color.OrangeRed;
                return false; // has to be more detailed...
            }
            _dilutionType = (DilutionType)comboBoxMolCreateDilutionType.SelectedItem;
            if (!(float.TryParse(textBoxMolCreateFullAmount.Text, out _unitAmount)))
            {
                textBoxMolCreateFullAmount.BackColor = Color.OrangeRed;
                return false;
            }
            _materialUnit = new MaterialUnit(UnitType.Milligram, _unitAmount * 1000.0f);
            _scentCategory = (ScentCategory)comboBoxMolCreateCategory.SelectedItem;
            if (!(float.TryParse(textBoxMolCreateTotalPrice.Text, out _fullPrice)))
            {
                textBoxMolCreateTotalPrice.BackColor = Color.OrangeRed;
                return false;
            }
            _noteLevel = (NoteLevel)comboBoxMolCreateNoteLevel.SelectedItem;

            if (textBoxMolCreateManufacturer.Text.Length > 0)
                _manufacturer = textBoxMolCreateManufacturer.Text;
            else
                _manufacturer = "unknown";
            return true;
        }

        private void FormCreateMolecule_FormClosing(object sender, FormClosingEventArgs e)
        {
            CreateMoleculeAction?.Invoke(null);
        }
    }
}
