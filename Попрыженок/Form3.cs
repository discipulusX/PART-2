using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Попрыженок
{
    public partial class Form3 : Form
    {
        public static Model1 db { get; set; }
        public Agent agn { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if(agn == null)
            {
                agentBindingSource.AddNew();
                this.Text = "Добавление новой учетной записи";
            }
            else
            {
                agentBindingSource.Add(agn);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 db = new Form1();
            db.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agent agn = new Agent();
            Model1 db = new Model1();
            if(agn == null)
            {
                agn = (Agent)agentBindingSource.Current;
                db.Agent.Add(agn);
            }
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
    }
}
