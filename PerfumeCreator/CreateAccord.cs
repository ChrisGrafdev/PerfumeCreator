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
    public partial class FormCreateCollection : Form
    {
        public event Action<Accord> CreateAccordAction;
        private FormComponentUseCase _formComponentUseCase;
        private object _base;
        private MaterialUnit _materialUnit;
        private string _name;
        private ScentCategory _scentCategory;
        private NoteLevel _noteLevel;
        private string _comment;

        private void FormInstanciator(object compatibleBase)
        {
            if (_formComponentUseCase == FormComponentUseCase.Accord)
            {
                this.Text += (" " + "Accord");
                comboBoxAccCreateCategory.DataSource = Enum.GetValues(typeof(ScentCategory));
                comboBoxAccCreateNoteLevel.DataSource = Enum.GetValues(typeof(NoteLevel));
            }
            else if (_formComponentUseCase == FormComponentUseCase.Perfume)
            {
                this.Text += (" " + "Perfume");
                labelAccCreateCategory.Text = "";
                labelAccCreateNoteLevel.Text = "";
                comboBoxAccCreateCategory.Enabled = false;
                comboBoxAccCreateNoteLevel.Enabled = false;
            }

            _base = compatibleBase;
        }

        public FormCreateCollection(FormComponentUseCase useCase, object compatibleBase)
        {
            InitializeComponent();
            this.AcceptButton = buttonAccCreateSave;
            _formComponentUseCase = useCase;
            FormInstanciator(compatibleBase);

            // open MaterialAmount-Form
            string fragranceName;
            if (compatibleBase is Fragrance frag)
                fragranceName = frag._name;
            else if (compatibleBase is Diluent dil)
                fragranceName = dil._name;
            else return; // should not happen!
            
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
        }

        
        private void buttonAccCreateSave_Click(object sender, EventArgs e)
        {
            if (!checkData()) return;

            if (_formComponentUseCase == FormComponentUseCase.Accord)
            {
                Accord accord = new Accord(_name, (IOnlyAccordCompatible)_base, _materialUnit); //_scentCategory, _noteLevel, _comment);
                CreateAccordAction?.Invoke(accord);
            }
            else
            {
                Perfume perfume = new Perfume(_name, (IAccordPerfumeCompatible)_base, _materialUnit);
            }

            this.Close();
        }

        private bool checkData()
        {
            _name = textBoxAccCreateName.Text;
            if (_name == "") return false;

            if (_formComponentUseCase == FormComponentUseCase.Accord)
            {
                _scentCategory = (ScentCategory)comboBoxAccCreateCategory.SelectedItem;
                _noteLevel = (NoteLevel)comboBoxAccCreateNoteLevel.SelectedItem;
            }
            _comment = textBoxAccCreateComment.Text;
            return true;
        }

        private void buttonAccCreateCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
