using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ListaDeContatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Contato[] contatos = new Contato[1];

        private void Escrever(Contato contato)
        {
            StreamWriter escreverEmArquivo = new StreamWriter("Contatos.txt");
            escreverEmArquivo.WriteLine(contatos.Length + 1);
            escreverEmArquivo.WriteLine(contato.Nome);
            escreverEmArquivo.WriteLine(contato.Sobrenome);
            escreverEmArquivo.WriteLine(contato.Telefone);

            for (int x = 0; x < contatos.Length; x++)
            {
                escreverEmArquivo.WriteLine(contatos[x].Nome);
                escreverEmArquivo.WriteLine(contatos[x].Sobrenome);
                escreverEmArquivo.WriteLine(contatos[x].Telefone);
            }

            escreverEmArquivo.Close();
        }

        private void Ler()
        {
            StreamReader LerArquivo = new StreamReader("Contatos.txt");
            contatos = new Contato[Convert.ToInt32(LerArquivo.ReadLine())];

            for (int x = 0; x < contatos.Length; x++) 
            {
                contatos[x] = new Contato();
                contatos[x].Nome = LerArquivo.ReadLine();
                contatos[x].Sobrenome = LerArquivo.ReadLine();
                contatos[x].Telefone = LerArquivo.ReadLine();
            }

            LerArquivo.Close();
        }

        // Atualizar a tela do programa com os contatos
        private void Exibir()
        { 
            //limpa a lista de contatos
            listBoxContato.Items.Clear();

            for (int x = 0; x < contatos.Length; x++)
            {
                listBoxContato.Items.Add(contatos[x].ToString());
            }
        }

        private void LimparFormulario()
        {
            textBoxNome.Text = string.Empty;
            textBoxSobrenome.Text = string.Empty;
            textBoxTelefone.Text = string.Empty;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            //objeto da classe contato
            Contato contato = new Contato();
            contato.Nome = textBoxNome.Text;
            contato.Sobrenome = textBoxSobrenome.Text;
            contato.Telefone = textBoxTelefone.Text;   

            //listBoxContato.Items.Add(contato.ToString());

            Escrever(contato);
            Ler();
            Exibir();
            LimparFormulario();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ler();
            Exibir();
        }
    }
}
