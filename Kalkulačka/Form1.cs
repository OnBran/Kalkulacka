using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulačka
{
    public partial class Kalkulačka : Form
    {
       // provadena operace
        enum enOperace {plus, minus, krat, deleno, clear, rovnase};

        //stavové proměnné
        float mflCislo1, mflCislo2, mflVysledek;
        bool mblNovaOperace;
        enOperace menAktOperace;
        //---------------------------------------------------------------------------------------------------------------------------
        // konstruktor
        //---------------------------------------------------------------------------------------------------------------------------
        public Kalkulačka()
        {
            InitializeComponent();

            // init promennych
            VseVymazat();
            txtDisplej.Text = "0";
        }
        private void btCislo_Click(object sender, EventArgs e)
        {
            try 
            {
                // smazat úvodní nulu
                if (mblNovaOperace == true) txtDisplej.Text = "";
                mblNovaOperace = false;

                // přidat další číslo
                txtDisplej.Text = txtDisplej.Text + ((Button)sender).Text;
            }
            catch   (Exception ex)
            {
            }      
        }
        private void btOperace_Click(object sender, EventArgs e)
        {
            Button lobjTlacitko;

            // zavola funkci
            lobjTlacitko = (Button)sender;

            switch (lobjTlacitko.Text)
            {
                // clear
                case "C": VseVymazat();
                    mblNovaOperace=true;
                    txtDisplej.Text = "0";
                    break;
                // backspace
                case "⌫": PosledniVymazat();
                    mblNovaOperace = true;
                    break;
                // plus
                case "+":
                    mflCislo2 = Convert.ToSingle(txtDisplej.Text);
                    menAktOperace = enOperace.plus;
                    mblNovaOperace = true;
                    break;
                // minus
                case "-":
                    mflCislo2 = Convert.ToSingle(txtDisplej.Text);
                    menAktOperace = enOperace.minus;
                    mblNovaOperace = true;
                    break;
                // krat
                case "*":
                    mflCislo2 = Convert.ToSingle(txtDisplej.Text);
                    menAktOperace = enOperace.krat;
                    mblNovaOperace = true;
                    break;
                // deleno
                case ":":
                    mflCislo2 = Convert.ToSingle(txtDisplej.Text);
                    menAktOperace = enOperace.deleno;
                    mblNovaOperace = true;
                    break;
                // rovnase
                case "=":
                    mflCislo1 = Convert.ToSingle(txtDisplej.Text);

                    if (menAktOperace == enOperace.plus) mflVysledek = mflCislo2 + mflCislo1;
                    else if (menAktOperace == enOperace.minus) mflVysledek = mflCislo2 - mflCislo1;
                    else if (menAktOperace == enOperace.krat) mflVysledek = mflCislo2 * mflCislo1;
                    else if (menAktOperace == enOperace.deleno) mflVysledek = mflCislo2 / mflCislo1;
                    else mflVysledek = mflCislo1;
                   
                    menAktOperace = enOperace.rovnase;
                    mblNovaOperace = true;
                    txtDisplej.Text = mflVysledek.ToString();
                    break;
            }    
        }

        private void Kalkulačka_Load(object sender, EventArgs e)
        {

        }

        private void VseVymazat()
        {
           // clear
            mblNovaOperace = true;

            // init promennych
            mflCislo1 = mflCislo2 = mflVysledek = 0;
            menAktOperace = enOperace.clear;

        }
        private void PosledniVymazat()
        {
            string a;

            mblNovaOperace = true;

            a = txtDisplej.Text;
            a=a.Substring(0,a.Length-1);
            txtDisplej.Text = a;
        }
    
    }   
    
    
}
