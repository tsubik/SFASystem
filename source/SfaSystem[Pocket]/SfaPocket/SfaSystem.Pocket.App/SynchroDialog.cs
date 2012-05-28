using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App
{
    public partial class SynchroDialog : Form
    {
        public delegate void CloseDelegate();

        public SynchroDialog()
        {
            InitializeComponent();
            synchroControl1.SynchroEnds += new EventHandler<EventArgs>(synchroControl1_SynchroEnds);
        }

        void synchroControl1_SynchroEnds(object sender, EventArgs e)
        {
            DialogClose();
        }

        void DialogClose()
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new CloseDelegate(DialogClose));
            else
            {
                this.Close();
            }
        }

        void Instance_SynchronizationError(object sender, SyncErrorEventArgs e)
        {
            DialogClose();
        }

        void Instance_SynchronizationCompleted(object sender, SyncComplEventArgs e)
        {
            DialogClose();
        }

        private void SynchroDialog_Load(object sender, EventArgs e)
        {
            Point newlocation = this.Location;
            newlocation.X = (int) (Screen.PrimaryScreen.WorkingArea.Size.Width - this.Size.Width) / 2;
            newlocation.Y = (int)(Screen.PrimaryScreen.WorkingArea.Size.Height - this.Size.Height) / 2;

            this.Location = newlocation;
            synchroControl1.SynchroStart();

        }
    }
}