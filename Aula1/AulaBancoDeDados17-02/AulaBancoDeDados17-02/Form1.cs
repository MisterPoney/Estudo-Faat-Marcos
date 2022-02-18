using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AulaBancoDeDados17_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        Conexao con = new Conexao();
        private void button1_Click(object sender, EventArgs e)
        {
            string texto = "insert into tb_cliente values (null,'" +
                txtNome.Text+"','"+txtCpf.Text+"','" +txtTelefone.Text + "');";
            if (con.Executa(texto))
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar!");
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt = con.Retorna("select*from tb_cliente where id_cliente=" + txtId.Text);
                txtNome.Text = dt.Rows[0]["nome_cliente"].ToString();
                txtTelefone.Text = dt.Rows[0]["celular_cliente"].ToString();
                txtCpf.Text = dt.Rows[0]["cpf_cliente"].ToString();
            }
        }
    }
}
