using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace System
{
    public partial class Dashboard : Form
    {
        List<int> matchedIndexes = new List<int>();

        private Guna2Panel[] rooms;
        bool Sched = false;
        bool OnGoing = false;
        bool req = false;


        public Dashboard()
        {
            InitializeComponent();
            activeTab();
            configureRooms();
            hideRoomInformation();

            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void activeTab()
        {
            lblAvailableUnit.ForeColor = Color.White;
            lblAvailableUnit.BackColor = Color.FromArgb(76, 205, 153);
            lblCheckIcon.BackColor = Color.FromArgb(76, 205, 153);
            pnlAvailUnit.Visible = true;
        }

        private void configureRooms()
        {
            rooms = new Guna2Panel[] {
                room1, room2, room3 , room4 ,room5, room6, room7, room8, room9, room10, room11,
                room12, room13 , room14 ,room15, room16, room17, room18, room19, room20, room21,
                room22, room23 , room24 ,room25, room26, room27, room28, room29, room30, room31,
                room32, room33 , room34 ,room35, room36, room37, room38, room39, room40, room41,
                room42, room43 , room44 , room45, room46, room47, room48, room49, room50,
                room51, room52, room53 , room54 ,room55, room56, room57, room58, room59, room60,  room61,
                room62, room63 , room64 ,room65, room66, room67, room68, room69, room70, room71,
                room72, room73 , room74 ,room75, room76, room77, room78, room79, room80, room81,
                room82, room83 , room84 ,room85, room86, room87, room88, room89, room90, room91,
                room92, room93 , room94 , room95, room96, room97, room98, room99, room100};



            foreach (var room in rooms)
            {
                room.Click += Room_Click;
                room.MouseLeave += Room_MouseLeave;
            }

        }

        private void hideRoomInformation()
        {
            roomInformation.Hide();
            roomNumber.Hide();
            roomNumberPanel.Hide();
            roomImage.Hide();
        }

        private void showRoomInformation()
        {
            roomInformation.Show();
            roomNumber.Show();
            roomNumberPanel.Show();
            roomImage.Show();
        }


        private void Room_Click(object sender, EventArgs e)
        {
            Guna2Panel clickedPanel = (Guna2Panel)sender;
            clickedPanel.BorderColor = Color.Red;
            Image backgroundImage = clickedPanel.BackgroundImage;
            int roomIndex = Array.IndexOf(rooms, clickedPanel) + 1;
            roomNumber.Text = "ROOM" + " " + roomIndex.ToString();

            showRoomInformation();
        }

        private void Room_MouseLeave(object sender, EventArgs e)
        {
            Guna2Panel clickedPanel = (Guna2Panel)sender;
            clickedPanel.BorderColor = Color.Black;
            showRoomInformation();

        }


        private void lblAvailableUnit_Click(object sender, EventArgs e)
        {

            lblAvailableUnit.ForeColor = Color.White;
            lblAvailableUnit.BackColor = Color.FromArgb(76, 205, 153);
            lblCheckIcon.BackColor = Color.FromArgb(76, 205, 153);

            lblScheduledMaintenance.ForeColor = Color.Black;
            lblScheduledMaintenance.BackColor = Color.Transparent;

            label5.ForeColor = Color.Black;
            label5.BackColor = Color.Transparent;

            label6.ForeColor = Color.Black;
            label6.BackColor = Color.Transparent;

            pnlAvailUnit.Show();
            panelSched.Hide();
            panelOnGoing.Hide();
            panelReq.Hide();

            lblAvailableUnit.Enabled = false;
            lblScheduledMaintenance.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;

            pnlAvailUnit.Visible = true;

        }


        private void lblCheckIcon_Click(object sender, EventArgs e)
        {
            lblAvailableUnit.BackColor = Color.FromArgb(76, 205, 153);
            lblCheckIcon.BackColor = Color.FromArgb(76, 205, 153);
            pnlAvailUnit.Visible = true;
        }


        private void lblScheduledMaintenance_Click(object sender, EventArgs e)
        {
            lblAvailableUnit.ForeColor = Color.Black;
            lblAvailableUnit.BackColor = Color.Transparent;

            lblScheduledMaintenance.ForeColor = Color.White;
            lblScheduledMaintenance.BackColor = Color.FromArgb(76, 205, 153);

            label5.ForeColor = Color.Black;
            label5.BackColor = Color.Transparent;

            label6.ForeColor = Color.Black;
            label6.BackColor = Color.Transparent;

            pnlAvailUnit.Hide();
            panelSched.Show();
            panelOnGoing.Hide();
            panelReq.Hide();

            panelReq.Width = 0;
            panelSched.Width = 0;
            panelOnGoing.Width = 0;
            req = false;
            OnGoing = false;
            timerSched.Enabled = true;
            timerOnGoing.Enabled = false;
            timerReq.Enabled = false;
            pnlAvailUnit.Hide();

            lblAvailableUnit.Enabled = true;
            lblScheduledMaintenance.Enabled = false;
            label5.Enabled = true;
            label6.Enabled = true;

        }

        private void timerSched_Tick_1(object sender, EventArgs e)
        {

            if (Sched == false)
            {
                pnlAvailUnit.SendToBack();
                panelSched.Width += 100;
                if (panelSched.Width > 1720)
                {
                    Sched = true;
                    timerSched.Enabled = false;
                }
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {
            lblAvailableUnit.ForeColor = Color.Black;
            lblAvailableUnit.BackColor = Color.Transparent;

            lblScheduledMaintenance.ForeColor = Color.Black;
            lblScheduledMaintenance.BackColor = Color.Transparent;

            label5.ForeColor = Color.White;
            label5.BackColor = Color.FromArgb(76, 205, 153);

            label6.ForeColor = Color.Black;
            label6.BackColor = Color.Transparent;

            pnlAvailUnit.Hide();
            panelSched.Hide();
            panelOnGoing.Show();
            panelReq.Hide();

            panelReq.Width = 0;
            panelSched.Width = 0;
            panelOnGoing.Width = 0;
            Sched = false;
            req = false;
            timerOnGoing.Enabled = true;
            timerSched.Enabled = false;
            timerReq.Enabled = false;
            pnlAvailUnit.Hide();
            lblAvailableUnit.Enabled = true;
            lblScheduledMaintenance.Enabled = true;
            label5.Enabled = false;
            label6.Enabled = true;

        }

        private void timerOnGoing_Tick(object sender, EventArgs e)
        {
            if (OnGoing == false)
            {
                panelOnGoing.Width += 100;
                if (panelOnGoing.Width > 1720)
                {
                    OnGoing = true;
                    timerOnGoing.Enabled = false;
                }
            }
        }

        private void panelOnGoing_Paint(object sender, PaintEventArgs e)
        {
            timerOnGoing.Enabled = true;
        }

        private void panelReq_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timerReq_Tick(object sender, EventArgs e)
        {

            if (req == false)
            {
                panelReq.Width += 100;
                if (panelReq.Width > 1720)
                {
                    req = true;
                    timerReq.Enabled = false;
                }
            }
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
            lblAvailableUnit.ForeColor = Color.Black;
            lblAvailableUnit.BackColor = Color.Transparent;

            lblScheduledMaintenance.ForeColor = Color.Black;
            lblScheduledMaintenance.BackColor = Color.Transparent;

            label5.ForeColor = Color.Black;
            label5.BackColor = Color.Transparent;

            label6.ForeColor = Color.White;
            label6.BackColor = Color.FromArgb(76, 205, 153);

            pnlAvailUnit.Hide();
            panelSched.Hide();
            panelOnGoing.Hide();
            panelReq.Show();

            panelReq.Width = 0;
            panelSched.Width = 0;
            panelOnGoing.Width = 0;
            Sched = false;
            OnGoing = false;
            timerOnGoing.Enabled = false;
            timerSched.Enabled = false;
            timerReq.Enabled = true;
            lblScheduledMaintenance.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = false;
        }

        private void btnGround_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "GROUND FLOOR";

            grpBoxGround.Show();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnFirstFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "FIRST FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Show();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnSecondFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "SECOND FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Show();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnThirdFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "THIRD FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Show();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnFourthFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "FOURTH FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxFourth.Show();
            grpBoxFifth.Hide();
            grpBoxThird.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnFifthFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "FIFTH FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxFifth.Show();
            grpBoxFourth.Hide();
            grpBoxThird.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnSixthFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "SIXTH FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Show();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnSeventhFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "SEVENTH FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Show();
            grpBoxEigth.Hide();
            grpBoxNinth.Hide();
        }

        private void btnEightFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "EIGHTH FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Show();
            grpBoxNinth.Hide();
        }

        private void btnNinthFloor_CheckedChanged(object sender, EventArgs e)
        {
            lblCurrentFloor.Text = "NINTH FLOOR";

            grpBoxGround.Hide();
            grpBoxFirst.Hide();
            grpBoxSecond.Hide();
            grpBoxThird.Hide();
            grpBoxFourth.Hide();
            grpBoxFifth.Hide();
            grpBoxSixth.Hide();
            grpBoxSeventh.Hide();
            grpBoxEigth.Hide();
            grpBoxNinth.Show();
        }
    }
}













