using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Dispensa_Financeira_Automática
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de calcular.", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string nome, matricula, curso, disciplina, semDesconto, comDesconto, descontoSemDispensa, descontoComDispensa;

                    int numeroParcela, chTotal, chDispensa, proximaParcela, parcelasEmAberto;

                    double valorParcela, valorCurso, valorCh, valorChDispensa, valorDispensa, desconto, valorIncidir, valorIncidirDesconto, novoValorParcela, novoValorParcelaDesconto, valorDesconto, diferencaBeneficios, valorFinalcomDesconto, porcentagemDesconto;

                    nome = textBox7.Text;
                    matricula = textBox8.Text;
                    curso = textBox9.Text;
                    numeroParcela = Convert.ToInt32(textBox1.Text);
                    valorParcela = Convert.ToDouble(textBox4.Text);
                    valorCurso = (Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox4.Text));
                    chTotal = Convert.ToInt32(textBox2.Text);
                    chDispensa = Convert.ToInt32(textBox3.Text);
                    proximaParcela = Convert.ToInt32(textBox5.Text);
                    desconto = Convert.ToDouble(textBox11.Text);
                    disciplina = textBox6.Text;
                    valorCh = valorCurso / chTotal;
                    valorChDispensa = valorCh * chDispensa;
                    valorDispensa = valorChDispensa * 0.9;
                    parcelasEmAberto = numeroParcela - proximaParcela + 1;
                    valorIncidir = valorDispensa / parcelasEmAberto;
                    novoValorParcela = valorParcela - valorIncidir;
                    valorDesconto = valorCurso * desconto / 100;
                    diferencaBeneficios = valorDispensa - valorDesconto;
                    valorIncidirDesconto = diferencaBeneficios / parcelasEmAberto;
                    novoValorParcelaDesconto = valorParcela - valorIncidirDesconto;
                    porcentagemDesconto = (desconto * novoValorParcelaDesconto) / 100;
                    valorFinalcomDesconto = novoValorParcelaDesconto - porcentagemDesconto;

                    semDesconto = ("Prezados, " + "\r\n\r\n" +
                        "Informamos que a dispensa financeira referente a(s) disciplina(s) abaixo foi realizada, pois o(a) aluno(a) não possui nenhuma modalidade de desconto.\r\n\r\n" +
                        "Observamos que os descontos e bolsas não são acumulativos com dispensa financeira, mas predomina aquele que proporciona o maior benefício ao aluno(a).\r\n\r\n" +
                        "A dispensa acadêmica já foi realizada. \r\n\r\n" +
                        "Nome Completo: " + nome + "\r\n" +
                        "Código do Aluno: " + matricula + "\r\n" +
                        "Dados do curso: " + curso + "\r\n\r\n" +
                        "Disciplina(s): " + "\r\n" +
                        disciplina + "\r\n\r\n" +
                        "Segue o cálculo da dispensa financeira: " + "\r\n\r\n" +
                        "Condição de pagamento: " + numeroParcela + " x R$ " + valorParcela.ToString("N2") + " = R$ " + valorCurso.ToString("N2") + "\r\n" +
                        "Carga horária total do curso: " + chTotal + "\r\n" +
                        "Carga horária dispensada: " + chDispensa + "\r\n" +
                        "Valor da dispensa: R$ " + valorDispensa.ToString("N2") + "\r\n\r\n" +
                        "O valor de R$ " + valorDispensa.ToString("N2") + ", será diluído nas próximas " + parcelasEmAberto + " parcelas em aberto. \r\n\r\n" +
                        "Em cada parcela incidirá o valor de R$ " + valorIncidir.ToString("N2") + ", ficando cada uma no valor de R$ " + novoValorParcela.ToString("N2") + ".");

                    comDesconto = ("Prezados, " + "\r\n\r\n" +
                        "Ao analisar a solicitação de dispensa acadêmica, verificamos que o(a) aluno(a) foi contemplado(a) com " + desconto + "% de desconto de ex-aluno. \r\n\r\n" +
                        "Observamos que os descontos e bolsas não são acumulativos com dispensa acadêmica, mas predomina aquele que proporciona o maior benefício ao aluno(a).\r\n\r\n" +
                        "A dispensa acadêmica já foi realizada.\r\n\r\n" +
                         "Nome Completo: " + nome + "\r\n" +
                        "Código do Aluno: " + matricula + "\r\n" +
                        "Dados do curso: " + curso + "\r\n\r\n" +
                        "Disciplina(s): " + "\r\n" +
                        disciplina + "\r\n\r\n" +
                        "Segue o cálculo da dispensa financeira: " + "\r\n\r\n" +
                        "Condição de pagamento: " + numeroParcela + " x R$ " + valorParcela.ToString("N2") + " = R$ " + valorCurso.ToString("N2") + "\r\n" +
                        "Carga horária total do curso: " + chTotal + "\r\n" +
                        "Carga horária dispensada: " + chDispensa + "\r\n\r\n" +
                        "Valor da dispensa: R$ " + valorDispensa.ToString("N2") + "\r\n" +
                        "Desconto de " + desconto + "% - " + numeroParcela + " parcela(s) para pagamento em dia: R$ " + valorDesconto.ToString("N2") + ". \r\n");

                    descontoSemDispensa = ("\r\n" + "De acordo com o cálculo acima, o valor do desconto " + desconto + "% de ex-aluno para pagamento em dia, predomina sobre a dispensa financeira. \r\n" +
                        "Sendo assim, a dispensa acadêmica já foi realizada.");

                    descontoComDispensa = ("Diferença dos benefícios: R$ " + diferencaBeneficios.ToString("N2") + "\r\n\r\n" +
                        "De acordo com o cálculo acima, o valor da dispensa acadêmica é maior. \r\n\r\n" +
                        "Dessa forma, o valor da dispensa financeira é a diferença entre os dois benefícios. \r\n\r\n" +
                        "O valor de R$ " + diferencaBeneficios.ToString("N2") + ", será diluído nas próximas " + parcelasEmAberto + " parcelas em aberto. \r\n\r\n" +
                        "Em cada parcela, incidirá o valor de R$ " + valorIncidirDesconto.ToString("N2") + ", ficando cada uma no valor de R$ " + novoValorParcelaDesconto.ToString("N2") + ". \r\n" +
                        "Sobre este valor, também incidirá o desconto de ex-aluno para pagamento em dia. \r\n" +
                        "Assim, o valor com desconto ficará R$ " + valorFinalcomDesconto.ToString("N2") + ". \r\n");

                    if (radioButton2.Checked && desconto == 0 || radioButton1.Checked && desconto > 0)
                    {
                        MessageBox.Show("Verifique se os campos de desconto estão corretos", "Desconto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            if (radioButton1.Checked)
                            {
                                textBox10.Text = (semDesconto);
                            }

                            else if (radioButton2.Checked && diferencaBeneficios > 0)
                            {
                                textBox10.Text = (comDesconto + descontoComDispensa);
                            }

                            else if (radioButton2.Checked && diferencaBeneficios < 0)
                            {
                                textBox10.Text = (comDesconto + descontoSemDispensa);
                            }
                        }
                        catch 
                        {

                        }
                    }   
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, insira números válidos.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void LimparForm()
        {
            foreach (Control controle in this.Controls)
            {
                if (controle is TextBox)        
                {
                    ((TextBox)controle).Clear();
                }
            }
        }
    }
}
