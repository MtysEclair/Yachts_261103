
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YachtMaintenance
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Koltseg> koltsegek =
            new BindingList<Koltseg>();

        private readonly string fajlNev = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "yacht_koltsegek_2024.csv");

        public Form1()
        {
            InitializeComponent();

            Text = "Yacht karbantartási költségnyilvántartás";

            cmbKategoria.Items.AddRange(new string[]
            {
                "Maintenance",
                "Repairs",
                "Insurance",
                "Docking Fees",
                "Other"
            });

            cmbKategoria.DropDownStyle =
                ComboBoxStyle.DropDownList;

            dgvKoltsegek.ReadOnly = true;
            dgvKoltsegek.AllowUserToAddRows = false;
            dgvKoltsegek.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvKoltsegek.DataSource = koltsegek;

            btnHozzaadas.Click += btnHozzaadas_Click;

            AdatokBetoltese();
        }

        private void AdatokBetoltese()
        {
            if (!File.Exists(fajlNev))
            {
                MessageBox.Show(
                    "Nem található a CSV-fájl:\n" + fajlNev);
                return;
            }

            try
            {
                foreach (string sor in File.ReadLines(
                    fajlNev, Encoding.UTF8).Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(sor))
                        continue;

                    string[] adat = sor.Split(';');

                    if (adat.Length != 6)
                        throw new FormatException(
                            "Hibás CSV-sor: " + sor);

                    Koltseg koltseg = new Koltseg
                    {
                        Id = int.Parse(adat[0]),
                        YachtName = adat[1],
                        Datum = DateTime.ParseExact(
                            adat[2],
                            "yyyy-MM-dd",
                            CultureInfo.InvariantCulture),
                        Kategoria = adat[3],
                        Osszeg = decimal.Parse(
                            adat[4],
                            CultureInfo.InvariantCulture),
                        Megjegyzes = adat[5]
                    };

                    koltsegek.Add(koltseg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Hiba az adatok beolvasásakor:\n"
                    + ex.Message);
            }
        }

        private void btnHozzaadas_Click(
            object sender, EventArgs e)
        {
            string yachtNev = txtYachtName.Text.Trim();
            string megjegyzes = txtMegjegyzes.Text.Trim();

            if (string.IsNullOrWhiteSpace(yachtNev)
                || cmbKategoria.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Add meg a yacht nevét és a kategóriát!");
                return;
            }

            if (!decimal.TryParse(
                    txtOsszeg.Text,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out decimal osszeg)
                || osszeg <= 0)
            {
                MessageBox.Show(
                    "Adj meg egy érvényes, pozitív összeget!");
                return;
            }

            if (yachtNev.Contains(";") ||
                megjegyzes.Contains(";") ||
                yachtNev.Contains("\n") ||
                megjegyzes.Contains("\n"))
            {
                MessageBox.Show(
                    "A szövegek nem tartalmazhatnak " +
                    "pontosvesszőt vagy sortörést!");
                return;
            }

            int ujId = koltsegek.Count == 0
                ? 1
                : koltsegek.Max(k => k.Id) + 1;

            Koltseg ujKoltseg = new Koltseg
            {
                Id = ujId,
                YachtName = yachtNev,
                Datum = dtpDatum.Value.Date,
                Kategoria = cmbKategoria.SelectedItem.ToString(),
                Osszeg = osszeg,
                Megjegyzes = megjegyzes
            };

            koltsegek.Add(ujKoltseg);

            try
            {
                AdatokMentese();
            }
            catch (Exception ex)
            {
                koltsegek.Remove(ujKoltseg);
                MessageBox.Show(
                    "A mentés sikertelen:\n" + ex.Message);
                return;
            }

            txtYachtName.Clear();
            txtOsszeg.Clear();
            txtMegjegyzes.Clear();
            cmbKategoria.SelectedIndex = -1;

            MessageBox.Show(
                "A költség sikeresen hozzáadva!");
        }

        private void AdatokMentese()
        {
            string ideiglenesFajl = fajlNev + ".tmp";

            using (StreamWriter iro = new StreamWriter(
                ideiglenesFajl,
                false,
                new UTF8Encoding(false)))
            {
                iro.WriteLine(
                    "id;yachtname;datum;kategoria;osszeg;megjegyzes");

                foreach (Koltseg k in koltsegek)
                {
                    iro.WriteLine(
                        $"{k.Id};" +
                        $"{k.YachtName};" +
                        $"{k.Datum:yyyy-MM-dd};" +
                        $"{k.Kategoria};" +
                        $"{k.Osszeg.ToString(CultureInfo.InvariantCulture)};" +
                        $"{k.Megjegyzes}");
                }
            }

            File.Copy(ideiglenesFajl, fajlNev, true);
            File.Delete(ideiglenesFajl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
