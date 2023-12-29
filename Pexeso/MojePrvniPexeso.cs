namespace Pexeso
{
    public partial class MojePrvniPexeso : Form
    {
        Button prvniTlacitko;
        Button druheTlacitko;
        bool JeSpravne = false;
        bool vyhraliJste = false;
        bool vsechnaVypnuta = false;
        int pocetStisknuti = 0;
        public MojePrvniPexeso()
        {
            InitializeComponent();
        }

        private void StiskTlacitka_Click(object sender, EventArgs e)
        {
            pocetStisknuti++;
            Button tlacitko = (Button)sender;
            if (!JeSpravne)
            {
                switch (pocetStisknuti)
                {
                    case 1:
                        prvniTlacitko = tlacitko;
                        tlacitko.ForeColor = SystemColors.ActiveCaptionText;
                        break;

                    case 2:
                        druheTlacitko = tlacitko;
                        tlacitko.ForeColor = SystemColors.ActiveCaptionText;
                        break;

                    case 3:
                        if (prvniTlacitko.Text != druheTlacitko.Text)
                        {
                            prvniTlacitko.ForeColor = SystemColors.ActiveCaption;
                            druheTlacitko.ForeColor = SystemColors.ActiveCaption;
                            JeSpravne = false;

                        }
                        else
                        {
                            JeSpravne = true;

                        }
                        pocetStisknuti = 0;
                        break;

                }
                if (JeSpravne)
                {

                    prvniTlacitko.Enabled = false;
                    druheTlacitko.Enabled = false;
                    JeSpravne = false;
                    KontrolaVyhry();
                }

            }
        }
        private void KontrolaVyhry()
        {
            vsechnaVypnuta = true;

            foreach (Button tlacitko in this.Controls.OfType<Button>())
            {
                if (tlacitko.Enabled)
                {
                    vsechnaVypnuta = false;
                    break;
                }
            }

            vyhraliJste = vsechnaVypnuta;

            if (vyhraliJste)
            {
                DialogResult result = MessageBox.Show("Vyhráli jste! Chcete hrát znovu?", "Gratulujeme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    ResetHry();
                }
                else
                {

                    Application.Exit();
                }
            }
        }
        private void ResetHry()
        {
            foreach (Button tlacitko in this.Controls.OfType<Button>())
            {
                tlacitko.ForeColor = SystemColors.ActiveCaption;
                tlacitko.Enabled = true;
            }
        }
    }
}

