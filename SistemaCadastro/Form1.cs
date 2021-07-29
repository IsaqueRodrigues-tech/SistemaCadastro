using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        List<Pessoas> pessoa;
        public Form1()
        {
            InitializeComponent();

            pessoa = new List<Pessoas>();


            comboEC.Items.Add("Casado");
            comboEC.Items.Add("Solteiro");
            comboEC.Items.Add("Viuvo");
            comboEC.Items.Add("Divorciado");

            comboEC.SelectedIndex = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach(Pessoas people in pessoa)
            {
                if (people.Nome == textNome.Text)
                {
                    index = pessoa.IndexOf(people);
                }
            }
            if (textNome.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo nome.");
                textNome.Focus();
                return;
            }
            if (txtTelefone.Text == "")
            {
                MessageBox.Show("Preencha o campo telefone.");
                textNome.Focus();
                return;
            }
            char sexo;

            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoas p = new Pessoas();
            p.Nome = textNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEC.SelectedIndex.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veiculo = checkVeículo.Checked;
            p.Sexo = sexo;

            if(index < 0)
            {
                pessoa.Add(p);
            }
            else
            {
                pessoa[index] = p;
            }

            btLimpar_Click(btLimpar, EventArgs.Empty);
            Listar();


        }

        private void excluir_Click(object sender, EventArgs e)
        {
            int indice = lista.SelectedIndex;
            pessoa.RemoveAt(indice);
            Listar();              
            
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            textNome.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 1;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeículo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioOutro.Checked = false;
            textNome.Focus();


        }

        private void Listar()
        {
            lista.Items.Clear();

            foreach(Pessoas p in pessoa)
            {
                lista.Items.Add(p.Nome);
            }
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoas p = pessoa[indice];

            textNome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivil;
            txtTelefone.Text = p.Telefone;
            checkCasa.Checked = p.CasaPropria;
            checkVeículo.Checked = p.Veiculo;

            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioOutro.Checked = true;
                    break;

            }
        }
    }
}
