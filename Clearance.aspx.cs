using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        double diff;
        double truck;
        double trailer;

        if(TtoC.Text != "" && CtoTE.Text != "")
        {
            truck = Convert.ToDouble(TtoC.Text);
            trailer = Convert.ToDouble(CtoTE.Text);

            if(truck > trailer)
            {
                Rec.Text = "Large enough clearance";
            }
            else
            {

                diff = trailer - truck;
                
                if(diff <= 4)
                {
                    Rec.Text = "Your trailer is " + diff + " inches to wide. We recommend a 4-inch Extender.";
                }
                else
                {
                    Rec.Text = "Your trailer is " + diff + " inches to wide. We recommend an Extend-A-Goose Coupler.";
                }

            }

        }
       
    }
}