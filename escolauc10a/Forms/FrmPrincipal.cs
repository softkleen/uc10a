﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escolauc10a.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAluno frmAluno = new FrmAluno();
            frmAluno.MdiParent = this;
            frmAluno.Show();
        }
    }
}
