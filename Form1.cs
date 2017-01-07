using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Játék helyének meghatározása - Nem annyira fontos
            if (File.Exists("aom.exe"))
            {
                textBox1.Text = "Helyi futás";
                textBox1.Enabled = false;
                button1.Enabled = false;
                LoadRecs();
            }
            else if(File.Exists("path.txt"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader("path.txt");
//                textBox1.Text=file.ReadLine(); - Az ellenőrzés miatt amint beleirja a fájl értékét, már rögtön irná vissza
                string path = file.ReadLine(); //Nem a legjobb megoldás, de megoldás - Amint beolvasta bele is fogja irni az útvonalat
                file.Close();
                textBox1.Text=path;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = textBox1.Text;
            //Leellenőrzi, hogy létezik-e a beirt hely, ha nem, akkor feljebb lépdelünk...
            //Ez saját algoritmus - A feltüntett oldal segitségével oldottam meg, de itt, ebben a helyzetben nem találkoztam vele, sem kódként, sem a gyakorlatban
            while(!Directory.Exists(openFileDialog1.InitialDirectory) && openFileDialog1.InitialDirectory.Length<2)
            {
//                MessageBox.Show(openFileDialog1.InitialDirectory);
                int index = openFileDialog1.InitialDirectory.LastIndexOf("\\"); //http://stackoverflow.com/questions/2660723/remove-characters-after-specific-character-in-string-then-remove-substring
//                MessageBox.Show(index+"");
                if (index > 0)
                    openFileDialog1.InitialDirectory = openFileDialog1.InitialDirectory.Substring(0, index); // or index + 1 to keep slash
            }
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
//            MessageBox.Show("A szöveg megváltozott. Azért nézem meg, mert én is állitom a szöveget."); - Pipa
            //Megpróbálja betölteni a felvételeket - Csak előbb leellenőrzi, hogy az aom.exe létezik-e, mert ha beirta a helyet, akkor nem biztos
            int index=textBox1.Text.LastIndexOf(".");
            if (index > 0) //Az aom.exe van beállitva
            {
                index = textBox1.Text.LastIndexOf("\\");
                textBox1.Text = textBox1.Text.Substring(0, index); //Ez elvileg újra meghivja ezt a függvényt, ezáltal annyiszor végzi el ezt, ahányszor szükséges (bár normál használat esetében elég egyszer)
            }
            //Ha az utolsó karakter \-jel, ellenőrizze le a mappa létezését
//            MessageBox.Show(textBox1.TextLength+"");
            if (textBox1.Text.Substring(textBox1.TextLength - 1, 1) == "\\")
            {
                if (!Directory.Exists(textBox1.Text))
                {
                    //button1_Click(sender, e); - Ne kényszeritsük a felhasználót
                    label2.Text = "A hely érvénytelen";
                }
                //Minden fontosabb ellenőrzés megtörtént, mehet a betöltés - Ha van \-jel a végén
                //Természetesen most jöttem rá, hogy a legegyszerűbb, ha az EXE-t berakom a játék mappájába... Egyébként...
                label2.Text = "Betöltés...";
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter("path.txt");
                file.WriteLine(textBox1.Text); //http://msdn.microsoft.com/en-us/library/aa287548(v=vs.71).aspx

                file.Close();
                LoadRecs(); //A textBox1.Text-ben el van tárolva a hely, nem szükséges átadni
            }
        }
        string path;
        int num = 0;
        private void LoadRecs()
        {
            if (textBox1.Text == "Helyi futás")
            {
                path = "";
            }
            else
            {
                path = textBox1.Text;
            }
            //Felvételek számának meghatározása
//            int num=0; - Legyen nyilvános - Egy másik helyen is használom
            num = 0; //Akkor itt állitom vissza - Egy lenti megjegyzésemre válaszolva
            for (int i = 1; i < 10; i++)
                if (File.Exists(path+"savegame\\Recorded Game " + i + ".rec"))
                    num = i;
            if (num == 0)
                label2.Text = "Nem található felvétel.";
            else //Található felvétel - Láthatóvá tesz megfelelő számú mezőt
            {
                label2.Text = num + " felvétel található. A nem mentett felvételek törlésre kerülnek!";
                if (num >= 1)
                { //label[num+2], textBox[num+1], button[num+1]
                    label3.Visible = true;
                    textBox2.Visible = true;
                    button2.Visible = true;
                }
                if (num >= 2)
                { //label[num+2], textBox[num+1], button[num+1]
                    label4.Visible = true;
                    textBox3.Visible = true;
                    button3.Visible = true;
                }
                if (num >= 3)
                { //label[num+2], textBox[num+1], button[num+1]
                    label5.Visible = true;
                    textBox4.Visible = true;
                    button4.Visible = true;
                }
                if (num >= 4)
                { //label[num+2], textBox[num+1], button[num+1]
                    label6.Visible = true;
                    textBox5.Visible = true;
                    button5.Visible = true;
                }
                if (num >= 5)
                { //label[num+2], textBox[num+1], button[num+1]
                    label7.Visible = true;
                    textBox6.Visible = true;
                    button6.Visible = true;
                }
                if (num >= 6)
                { //label[num+2], textBox[num+1], button[num+1]
                    label8.Visible = true;
                    textBox7.Visible = true;
                    button7.Visible = true;
                }
                if (num >= 7)
                { //label[num+2], textBox[num+1], button[num+1]
                    label9.Visible = true;
                    textBox8.Visible = true;
                    button8.Visible = true;
                }
                if (num >= 8)
                { //label[num+2], textBox[num+1], button[num+1]
                    label10.Visible = true;
                    textBox9.Visible = true;
                    button9.Visible = true;
                }
                if (num >= 9)
                { //label[num+2], textBox[num+1], button[num+1]
                    label11.Visible = true;
                    textBox10.Visible = true;
                    button10.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 1.rec", path + "savegame\\" + textBox2.Text + ".rec");
            label3.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 2.rec", path + "savegame\\" + textBox3.Text + ".rec");
            label4.Visible = false;
            textBox3.Visible = false;
            button3.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 3.rec", path + "savegame\\" + textBox4.Text + ".rec");
            label5.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 4.rec", path + "savegame\\" + textBox5.Text + ".rec");
            label6.Visible = false;
            textBox5.Visible = false;
            button5.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 5.rec", path + "savegame\\" + textBox6.Text + ".rec");
            label7.Visible = false;
            textBox6.Visible = false;
            button6.Visible = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 6.rec", path + "savegame\\" + textBox7.Text + ".rec");
            label8.Visible = false;
            textBox7.Visible = false;
            button7.Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 7.rec", path + "savegame\\" + textBox8.Text + ".rec");
            label9.Visible = false;
            textBox8.Visible = false;
            button8.Visible = false;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            File.Move(path + "savegame\\Recorded Game 8.rec", path + "savegame\\" + textBox9.Text + ".rec");
            label10.Visible = false;
            textBox9.Visible = false;
            button9.Visible = false;
        }
        private void button10_Click(object sender, EventArgs e)
        {
//            MessageBox.Show(path+"Recorded Game 9.rec\n"+path + textBox10.Text + ".rec"); - Végig kell kattintgatnom a gombokon előbb
            File.Move(path + "savegame\\Recorded Game 9.rec", path + "savegame\\" + textBox10.Text + ".rec");
            label11.Visible = false;
            textBox10.Visible = false;
            button10.Visible = false; //Bemásolgattam az összes ilyen hármast és átirtam a true-t false-ra (csere)
        }

        private void button11_Click(object sender, EventArgs e)
        {
//            MessageBox.Show(num+"");
            label2.Text = "Betöltés...";
            if (num == 0) //Nem talált felvételt, keressen
            {
                LoadRecs();
            }
            else //Talált, törölje - Mindet -- Olyan szép volt, hogy még az else-hez sem kellett kapcsos zárójel - De hát most már kell
            {
                for (int i = 1; i < 10; i++)
                    if (File.Exists(path + "savegame\\Recorded Game " + i + ".rec"))
                        File.Delete(path + "savegame\\Recorded Game " + i + ".rec");
//                LoadRecs(); //A lehető legegyszerűbb módja a dolgok visszaállitásának - Csak előtte el kell tüntetni mindent...
                //Vagy utána...
                label3.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                label4.Visible = false;
                textBox3.Visible = false;
                button3.Visible = false;
                label5.Visible = false;
                textBox4.Visible = false;
                button4.Visible = false;
                label6.Visible = false;
                textBox5.Visible = false;
                button5.Visible = false;
                label7.Visible = false;
                textBox6.Visible = false;
                button6.Visible = false;
                label8.Visible = false;
                textBox7.Visible = false;
                button7.Visible = false;
                label9.Visible = false;
                textBox8.Visible = false;
                button8.Visible = false;
                label10.Visible = false;
                textBox9.Visible = false;
                button9.Visible = false;
                label11.Visible = false;
                textBox10.Visible = false;
                button10.Visible = false;
                LoadRecs(); //De... Inkább előtte :D -- Aha, csak a num-ot vissza kell állitani - Vagy itt, vagy a LoadRecs-ben
            }
            
        }
    }
}
