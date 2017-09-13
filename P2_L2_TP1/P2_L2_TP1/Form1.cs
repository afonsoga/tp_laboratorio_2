using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2_L2_TP1
{
    public partial class Form1 : Form
    {
        string operador;
        double resultado;
        Numero miNumero1 = new Numero();
        Numero miNumero2 = new Numero();      
        
        public Form1()
        {
            InitializeComponent();
            this.txtNumero1.Text = miNumero1.getNumero().ToString();
            this.txtNumero2.Text = miNumero2.getNumero().ToString();
            this.cmbOperacion.Text = "+";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            operar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        public void operar()
        {
            Numero operador1 = new Numero(this.txtNumero1.Text);
            Numero operador2 = new Numero(this.txtNumero2.Text);
            Numero valorFinal;
       
            resultado = Calculadora.operar(operador1, operador2, operador);

            valorFinal = new Numero(resultado);
            lblResultado.Text = valorFinal.getNumero().ToString();
        }

        public void limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperacion.Text = "+";
        }

        private void cmbOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = Calculadora.validarOperador(this.cmbOperacion.Text);
        }
    }
}
