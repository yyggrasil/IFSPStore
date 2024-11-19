using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace IFSPStore.App
{
    public partial class CadastroBase : MaterialForm
    {
        #region declarações
        protected bool isAltercao = false;
        #endregion

        #region Construtor
        public CadastroBase()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos CRUD

        protected void LimpaCampos()
        {
            isAltercao = false;
            foreach (var control in tabPageCadastro.Controls)
            {
                if (control is MaterialTextBoxEdit)
                {
                    ((MaterialTextBoxEdit)control).Clear();
                }
                if (control is MaterialMaskedTextBox)
                {
                    ((MaterialMaskedTextBox)control).Clear();
                }
            }
        }
        protected virtual void CarregaGrid()    {  }

        protected virtual void Novo() 
        {
            LimpaCampos();
            TabControl.SelectedIndex = 0;
            TabControl.Focus();
        }
        protected virtual void Salvar() { }
        protected virtual void Editar() 
        {
            if (GridViewConsulta.SelectedRows.Count > 0)
            {
                isAltercao = true;
                var linha = GridViewConsulta.SelectedRows[0];
                CarregaRegistro(linha);
                TabControl.SelectedIndex = 0;
                TabControl.Focus();
            }
            else
            {
                MessageBox.Show(@"Selecione algum registro!", @"IFSP Store",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        protected virtual void Deletar() { }

        protected virtual void CarregaRegistro(DataGridViewRow? linha) { }

        #endregion

        #region eventos form
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Deseja realmente calncelar?", @"IFSP Store",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpaCampos();
                TabControl.SelectedIndex = 1;
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (GridViewConsulta.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(@"Deseja realmente excluir?", @"IFSP Store",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = (int)GridViewConsulta.SelectedRows[0].Cells["id"].Value;
                    Deletar(id);
                    CarregaGrid();
                }
            }
            else
            {
                MessageBox.Show(@"Selecione algum registro!", @"IFSP Store",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        #endregion
    }
}
