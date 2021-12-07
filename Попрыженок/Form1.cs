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
    public partial class Form1 : Form
    {
        Model1 db = new Model1();
        public Agent agn { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "poprigDataSet.Agent". При необходимости она может быть перемещена или удалена.
            this.agentTableAdapter.Fill(this.poprigDataSet.Agent);
            agentBindingSource.DataSource = db.Agent.ToList();
            if(agn == null)
            {
                agentBindingSource.AddNew();
            }
            else
            {
                agentBindingSource.Add(agn);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Agent agn = (Agent)agentBindingSource.Current;
            DialogResult dr = MessageBox.Show("Удалить запись?" + agn.ID + "?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                db.Agent.Remove(agn);
            }
            try
            {
                db.SaveChanges();
                agentBindingSource.DataSource = db.Agent.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
            Form3 db3 = new Form3();
            db3.agn = null;
            DialogResult agn = db3.ShowDialog();
            if(agn == DialogResult.OK)
            {
                agentBindingSource.DataSource = null;
                agentBindingSource.DataSource = db.Agent.ToList();
            }
        }
    }
}
