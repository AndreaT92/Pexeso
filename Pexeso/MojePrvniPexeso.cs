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
        int pocetPokusu = 0;
        DateTime casZahajeniHry;
        bool ZacinaHra = true;

        public MojePrvniPexeso()
        {
            InitializeComponent();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            TimeSpan uplynulyCas = DateTime.Now - casZahajeniHry;


            LabelTime.Text = string.Format("{0:D2}:{1:D2}", uplynulyCas.Minutes, uplynulyCas.Seconds);
        }
        private void StiskTlacitka_Click(object sender, EventArgs e)
        {
            if (ZacinaHra)
            {
                casZahajeniHry = DateTime.Now;
                Timer.Start();
                Timer.Tick += Timer_Tick;
                ZacinaHra = false;
            }

            pocetStisknuti++;

            LabelNaPokusy.Text = $" Pokusy: {pocetPokusu.ToString()}";
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

                        if (prvniTlacitko == druheTlacitko)
                        {
                            pocetStisknuti = 1;
                        }
                        pocetPokusu++;
                        break;

                    case 3:
                        if (prvniTlacitko != druheTlacitko)
                        {
                            if (prvniTlacitko.Text == druheTlacitko.Text)
                            {
                                JeSpravne = true;
                            }
                            else
                            {
                                prvniTlacitko.ForeColor = SystemColors.ActiveCaption;
                                druheTlacitko.ForeColor = SystemColors.ActiveCaption;
                                JeSpravne = false;
                            }
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
                casZahajeniHry = DateTime.Now;
                ZacinaHra = true;
                pocetPokusu = 0;
                LabelNaPokusy.Text = "Pokusy: ";
            }
        }

    }
}

