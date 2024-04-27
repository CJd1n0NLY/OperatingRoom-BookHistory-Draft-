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
    public partial class EditRooms_UC : UserControl
    {
        public EditRooms_UC()
        {
            InitializeComponent();
        }

        private void EditRooms_UC_Load(object sender, EventArgs e)
        {
            cmbBoxAmenities.Items.Add("Kitchen");
            cmbBoxAmenities.Items.Add("Bathroom");
            cmbBoxAmenities.Items.Add("Bedroom");
            cmbBoxAmenities.Items.Add("Balcony");
        }

        private void cmbBoxAmenities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxAmenities.SelectedIndex == 0)
            {
                kitchenAmenities.Visible = true;
                bathroomAmenities.Visible = false;
                bedroomAmenities.Visible = false;
                roomAmenities.Visible = false;

            }
            else if (cmbBoxAmenities.SelectedIndex == 1)
            {
                kitchenAmenities.Visible = false;
                bathroomAmenities.Visible = true;
                bedroomAmenities.Visible = false;
                roomAmenities.Visible = false;
            }
            else if (cmbBoxAmenities.SelectedIndex == 2)
            {
                kitchenAmenities.Visible = false;
                bathroomAmenities.Visible = false;
                bedroomAmenities.Visible = true;
                roomAmenities.Visible = false;
            }
            else if (cmbBoxAmenities.SelectedIndex == 3)
            {
                kitchenAmenities.Visible = false;
                bathroomAmenities.Visible = false;
                bedroomAmenities.Visible = false;
                roomAmenities.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Rooms Checkbox
            cbKitchen.Checked = false;
            cbBathroom.Checked = false;
            cbBedroom.Checked = false;
            cbBalcony.Checked = false;

            //Kitchen Amenities Checkbox
            cbCoffeeMachine.Checked = false;
            cbToaster.Checked = false;
            cbBlender.Checked = false;
            cbPlates.Checked = false;
            cbUtensils.Checked = false;
            cbPans.Checked = false;

            //Bathroom Amenities Checkbox
            cbShampoo.Checked = false;
            cbBodySoap.Checked = false;
            cbBidet.Checked = false;
            cbShower.Checked = false;
            cbBathTowel.Checked = false;
            cbHairDryer.Checked = false;

            //Bedroom Amenities Checkbox
            cbExtraPillows.Checked = false;
            cbHangers.Checked = false;
            cbBedSheets.Checked = false;
            cbDrawer.Checked = false;
            cbWardrobe.Checked = false;

            //Room Amenities Checkbox
            cbWifi.Checked = false;
            cbAirConditioned.Checked = false;
            cbRoomService.Checked = false;
            cbFreeParking.Checked = false;
            cbWashingMachine.Checked = false;
            cbLuggageStorage.Checked = false; 
        }
    }
}
