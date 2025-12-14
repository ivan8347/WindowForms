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
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;




namespace Clock
{
    public partial class ChooseFont : Form
    {
        new public Font Font { get; set; }
        public string Filename { get; set; }
        public ChooseFont()
        {
            InitializeComponent();
            LoadFonts();
            comboBoxFont.SelectedIndex = 0;
            //numericUpDownFontSize.Value = 32;
        }

        public ChooseFont(string font_name, int font_size) 
        {
            InitializeComponent();
            Filename = font_name;
            numericUpDownFontSize.Value = font_size;
            LoadFonts();
            comboBoxFont.SelectedIndex = comboBoxFont.Items.IndexOf(Filename);
            Font = labelExample.Font;

        }
        /* void LoadFonts()
         {
             Console.WriteLine(Application.ExecutablePath);
             Console.WriteLine(Directory.GetCurrentDirectory());
             Console.WriteLine(Directory.GetParent(Application.ExecutablePath));
             string directory = $"{Application.ExecutablePath}\\..\\..\\..\\Fonts";
             Directory.SetCurrentDirectory(directory);
             Console.WriteLine(Directory.GetCurrentDirectory());

             //////////////////////////////////////////////////

             comboBoxFont.Items.AddRange(GetFilesByExt(Directory.GetCurrentDirectory(), "*.ttf"));
             comboBoxFont.Items.AddRange(GetFilesByExt(Directory.GetCurrentDirectory(), "*.otf"));
             string[] GetFilesByExt(string derectory, string format)
             {
                 string[] files = Directory.GetFiles(derectory, format);
                 for (int i = 0; i < files.Length; i++)

                     files[i] = files[i].Split('\\').Last();

                 return files;
             }
         }*/
        void LoadFonts()
        {
            //Directory.SetCurrentDirectory("..\\..\\Fonts");
            Console.WriteLine(Directory.GetCurrentDirectory());

            comboBoxFont.Items.AddRange(GetFontsFormat("*.ttf"));
            comboBoxFont.Items.AddRange(GetFontsFormat("*.otf"));
        }
        static string[] GetFontsFormat(string format)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), format);
            for (int i = 0; i < files.Length; i++)
                files[i] = files[i].Split('\\').Last();
            return files;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ViewExampleFont();
            this.Font = labelExample.Font;
            Filename = comboBoxFont.SelectedItem.ToString();
        }

        private void ChooseFont_Load(object sender, EventArgs e)
        {
            //LoadFonts();
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewExampleFont();
        }

        void ViewExampleFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile((comboBoxFont).SelectedItem.ToString());
            labelExample.Font = new Font(pfc.Families[0], (int)numericUpDownFontSize.Value);

        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            ViewExampleFont();
        }

        private void btnApple_Click(object sender, EventArgs e)
        {
            ViewExampleFont();
        }
    }
}
