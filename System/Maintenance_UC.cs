using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class Maintenance_UC : UserControl
    {
        private int clickedRowIndex;
        public Maintenance_UC()
        {
            InitializeComponent();
        }

        private void Maintenance_UC_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                int rowIndex = gridMaintenance.Rows.Add("Room " + i);
                gridMaintenance.Rows[rowIndex].Cells[1].Value = "Not Set";
                gridMaintenance.Rows[rowIndex].Cells[2].Value = "N/A";
                gridMaintenance.Rows[rowIndex].Cells[3].Value = "N/A";
            }

            cbMaintenanceStatus.Items.Add("Not Set");
            cbMaintenanceStatus.Items.Add("Set Schedule");
            cbMaintenanceStatus.Items.Add("On Going");
        }

        private void gridMaintenance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
        
                clickedRowIndex = e.RowIndex;

                DataGridViewRow row = gridMaintenance.Rows[e.RowIndex];
                txtRoomNumber.Text = row.Cells[0].Value.ToString();
            }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex >= 0)
            {
                if(cbMaintenanceStatus.Text != "")
                {
                    MessageBox.Show("Maintenance Successfully Scheduled");
                    gridMaintenance.Rows[clickedRowIndex].Cells[1].Value = cbMaintenanceStatus.Text;
                    gridMaintenance.Rows[clickedRowIndex].Cells[2].Value = dateTimePicker.Text;
                }
            }
            else
            {
                MessageBox.Show("No row has been clicked yet.");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tmrSetTime.Start();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
        bool timeSetExpanded = true;
        private void tmrSetTime_Tick(object sender, EventArgs e)
        {
            if (timeSetExpanded)
            {
                tmrSetTime.Start();
                panelSetTime.Height += 10;
                if(panelSetTime.Height >= 198)
                {
                    tmrSetTime.Stop();
                    timeSetExpanded = false;
                }
            } else
            {
                tmrSetTime.Start();
                panelSetTime.Height -= 10;
                if(panelSetTime.Height <= 0)
                {
                    tmrSetTime.Stop();
                    timeSetExpanded = true;
                }
            }
        }
    }

 
}
