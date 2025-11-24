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




namespace Clock
{
    public partial class ChooseFont : Form
    {
        new public Font Font { get; set; }
        public ChooseFont()
        {
            InitializeComponent();
           LoadFonts();
        }
        
        void LoadFonts()
        {
            Console.WriteLine(Application.ExecutablePath);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Directory.GetParent(Application.ExecutablePath));
            string directory = $"{Application.ExecutablePath}\\..\\..\\..\\Fonts";
            Directory.SetCurrentDirectory(directory);
            Console.WriteLine(Directory.GetCurrentDirectory());

            //////////////////////////////////////////////////
           
            comboBoxFont.Items.AddRange(GetFilesByExt(Directory.GetCurrentDirectory(),"*.ttf"));
            comboBoxFont.Items.AddRange(GetFilesByExt(Directory.GetCurrentDirectory(),"*.otf"));
            string[] GetFilesByExt (string derectory,string format)
            { 
                string[] files = Directory.GetFiles(derectory,format);
            for (int i = 0; i < files.Length; i++) 
            {
                files[i] = files[i].Split('\\').Last();
            }
                return files;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Font = labelExample.Font;
        }

        private void ChooseFont_Load(object sender, EventArgs e)
        {
           // LoadFonts();
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("\nSelectedIndexChanged:\n");
            //Console.WriteLine($"Selected index:\t{(sender as ComboBox).SelectedIndex}");
            //Console.WriteLine($"Selected item: \t{(sender as ComboBox).SelectedItem}");
           // Console.WriteLine($"Selected text: \t{(sender as ComboBox).SelectedText.ToString()}");
           // Console.WriteLine($"Selected value:\t{(sender as ComboBox).SelectedValue.ToString()}");
            Console.WriteLine("\n__________________________________\n");
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile((sender as ComboBox).SelectedItem.ToString());
            labelExample.Font = new Font(pfc.Families[0],32);
        }
    }
}
