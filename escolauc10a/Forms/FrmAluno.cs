using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using escolauc10a.Class;

namespace escolauc10a.Forms
{
    public partial class FrmAluno : Form // : herança
    {
        public FrmAluno()
        {
            InitializeComponent();
        }


        private void FrmAluno_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            var lista = aluno.ObterAlunos();
            foreach (var item in lista)
            {
                if (item.Ativo)
                {
                    listBox1.Items.Add(item.Id+" - "+ item.Nome + " - "+item.Email);
                }
               
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtNome.Text,txtEmail.Text,txtSenha.Text);
            aluno.Inserir();
            txtId.Text = aluno.Id.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text=="...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();
                button3.Text = "Buscar";
                btnInserir.Enabled = false;
            } 
            else if (button3.Text=="Buscar")
            {
                txtId.ReadOnly = true;
                button3.Text = "...";
                button2.Enabled = true;
                // consultar por id
                Aluno aluno = new Aluno();
                aluno.BuscarPorId(int.Parse(txtId.Text));
                txtNome.Text = aluno.Nome;
                txtEmail.Text = aluno.Email;
                txtEmail.Enabled = false;
                checkBox1.Checked = aluno.Ativo;
                checkBox1.Enabled = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txtNome.Text;
            aluno.Senha = txtSenha.Text;
            aluno.Ativo = checkBox1.Checked;
            if (aluno.Atualizar())
            {
                MessageBox.Show("Aluno Atualizado com sucesso!");
            }
        }
    }
}
