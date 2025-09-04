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
        public event Action<ICollectionReturn> CreateCollectionAction;
        private FormComponentUseCase _formComponentUseCase;
        private Basis _base;
        private MaterialUnit _materialUnit;
        private string _name;
        private ScentCategory _scentCategory;
        private NoteLevel _noteLevel;
        private string _comment;

        private void FormInstanciator()
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

        }

        public FormCreateCollection(FormComponentUseCase useCase, Basis compatibleBase)
        {
            InitializeComponent();
            this.AcceptButton = buttonAccCreateSave;
            _formComponentUseCase = useCase;
            FormInstanciator();
            _base = compatibleBase;

            // open MaterialAmount-Form
            string fragranceName = compatibleBase._name;

            Action<object?> materialAmountHandler = null;
            var addMaterialAmountWindow = new FormDefineAmount(fragranceName);
            //addMaterialAmountWindow.AddAmountAction += (newAmount) =>
            materialAmountHandler = (newAmount) =>
            {
                addMaterialAmountWindow.AddAmountAction -= materialAmountHandler;
                if (newAmount == null) // AddAmount canceled
                {
                    CreateCollectionAction?.Invoke(null);
                    this.Close();
                    return;
                }
                _materialUnit = (MaterialUnit)newAmount;
            };
            if (!addMaterialAmountWindow.IsDisposed)
            {
                addMaterialAmountWindow.AddAmountAction += materialAmountHandler;
                addMaterialAmountWindow.ShowDialog();
            }
        }


        private void buttonAccCreateSave_Click(object sender, EventArgs e)
        {
            if (!checkData()) return;

            if (_formComponentUseCase == FormComponentUseCase.Accord)
            {
                Accord accord = new Accord(_name, (IOnlyAccordCompatible)_base, _materialUnit); //_scentCategory, _noteLevel, _comment);
                CreateCollectionAction?.Invoke(accord);
            }
            else
            {
                Perfume perfume = new Perfume(_name, (IAccordPerfumeCompatible)_base, _materialUnit);
                CreateCollectionAction?.Invoke(perfume);
            }
            CreateCollectionAction?.Invoke(null);
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
            CreateCollectionAction?.Invoke(null);
            this.Close();
        }

        private void FormCreateCollection_FormClosing(object sender, FormClosingEventArgs e)
        {
            CreateCollectionAction?.Invoke(null);
        }
    }
}
