using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class Contact : Page
{
    static int total;
    int showing;
    string[,] needs = new string[total, 8];
    string[,] display = new string[total, 8];
    string[,] found = new string[total, 8];


    /// <summary>
    /// Main method that gets parts and displays in table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            total = CountParts();
            showing = Show();
            Start();
        }
    }

    protected void Start()
    {

        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt")))
        {
            var yep = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt"));
            yep.Close();
        }


        needs = new string[total, 8];
        display = new string[total, 8];

        string[] split = new string[8];
        StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt"));
        string line;
        for (int i = 0; i < total; i++)
        {


            line = SR.ReadLine();
            if (line != null)
            {
                split = line.Split('|');
                int m = 0;
                if (split.Length > 8)
                    m = 8;
                else
                    m = split.Length;
                for (int j = 0; j < m; j++)
                {
                    needs[i, j] = split[j];
                }
                split = new string[8];

                //needs = (string[,])Session["nest"];

            }

        }
        SR.Close();


        string[] open = new string[(total)];
        for (int i = 0; i < total; i++)
        {
            if (needs[i, 0] != null)
            {
                open[i] = needs[i, 0];
            }
        }

        //System.Array.Sort(open);
        showing = Show();
        display = new string[showing, 8];
        int p = 0;
        int n = open.Length - 1;
        while (n > -1)
        {
            if (open[n] != null)
            {
                for (int h = total - 1; h > -1; h--)
                {
                    if (p < showing)
                    {
                        if (open[n] == needs[h, 0])
                        {
                            for (int q = 0; q < 8; q++)
                            {
                                display[p, q] = needs[h, q];
                            }
                            needs[h, 0] = "";

                            p++;
                        }

                    }
                }
            }
            n = n - 1;
        }
        loadTable(display);
    }


    protected void loadTable(string[,] display)
    {

        GridView1.DataSource = null;
        GridView1.DataBind();
        if (display[0, 0] != null)
        {
            Needs_Box.Visible = false;
            Session["array"] = display;
            DataTable dt2 = new DataTable("test");

            DataColumn dc1 = new DataColumn("Date Entered");
            DataColumn dc2 = new DataColumn("Name");
            DataColumn dc3 = new DataColumn("Phone");
            DataColumn dc4 = new DataColumn("DIST/DLR/RTL");
            DataColumn dc5 = new DataColumn("CSR");
            DataColumn dc6 = new DataColumn("PRODUCT");
            DataColumn dc7 = new DataColumn("SUGGESTION");

            
            dt2.Columns.Add(dc1);
            dt2.Columns.Add(dc2);
            dt2.Columns.Add(dc3);
            dt2.Columns.Add(dc4);
            dt2.Columns.Add(dc5);
            dt2.Columns.Add(dc6);
            dt2.Columns.Add(dc7);


            int show;
            if (display.Length / 8 > 0)
                show = (display.Length / 8);
            else
                show = 1;
            for (int i = 0; i < show; i++)
            {
                if (display[i, 0] != null)
                {

                    DataRow dr = dt2.NewRow();
                    dr["Date Entered"] = display[i, 0];
                    dr["Name"] = display[i, 1];
                    dr["Phone"] = display[i, 2];
                    dr["DIST/DLR/RTL"] = display[i, 3];
                    dr["CSR"] = display[i, 4];
                    dr["PRODUCT"] = display[i, 5];
                    dr["SUGGESTION"] = display[i, 6];
                    dt2.Rows.Add(dr);
                }
            }

            GridView1.DataSource = dt2;
            Session["dt3"] = dt2;
            if (!IsPostBack)
                GridView1.DataBind();

        }
        else
        {
            Needs_Box.Text = "No Suggestions";
        }
    }


    /// <summary>
    /// Finds How many parts exist
    /// </summary>
    /// <returns></returns>
    protected int CountParts()
    {
        int total = 0;
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt")).Count() + 3;
        return (total);
    }


    /// <summary>
    /// Colors parts based on location
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {
    }


    /// <summary>
    /// Gets row number and calls bind data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //GridView1.PageIndex = e.NewEditIndex;
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }

    /// <summary>
    /// Cancels row edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TaskGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Reset the edit index.
        GridView1.EditIndex = -1;
        //Bind data to the GridView control.
        BindData();
    }

    /// <summary>
    /// Edits part from textboxes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TaskGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Retrieve the table from the session object.
        DataTable dt = (DataTable)Session["dt3"];

        //Update the values.
        GridViewRow row = GridView1.Rows[e.RowIndex];

        int selected = e.RowIndex;

        display = (string[,])Session["array"];
        display[selected, 1] = ((TextBox)(row.Cells[2].Controls[0])).Text;
        display[selected, 2] = ((TextBox)(row.Cells[3].Controls[0])).Text;
        display[selected, 3] = ((TextBox)(row.Cells[4].Controls[0])).Text;
        display[selected, 4] = ((TextBox)(row.Cells[5].Controls[0])).Text;
        display[selected, 5] = ((TextBox)(row.Cells[6].Controls[0])).Text;
        display[selected, 6] = ((TextBox)(row.Cells[7].Controls[0])).Text;
        

        //Reset the edit index.
        GridView1.EditIndex = -1;

        //Bind data to the GridView control.
        FixLists(display, selected);
        Page_Load(null, null);
        BindData();
    }

    /// <summary>
    /// Sets table source and binds it
    /// </summary>
    protected void BindData()
    {
        GridView1.DataSource = Session["dt3"];
        GridView1.DataBind();
    }



    /// <summary>
    /// Updates files to new inputs
    /// </summary>
    /// <param name="use"></param>
    protected void FixLists(string[,] use, int selected)
    {
        int all = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt")).Count() + 3;
        string[] split = new string[(showing * 8)];
        string[,] updated = new string[all, 8];
        using (StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt")))
        {
            string line;
            for (int i = 0; i < all; i++)
            {
                line = SR.ReadLine();
                if (line != null)
                {
                    split = line.Split('|');
                    if (split[4] != use[selected, 4])
                    {
                        int q;
                        if (split.Length < 8)
                        { q = split.Length; }
                        else
                        { q = 8; }

                        for (int j = 0; j < q; j++)
                        {
                            updated[i, j] = split[j];
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            updated[i, j] = use[selected, j];
                        }
                    }
                }
            }

        }
        var fole1 = File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt"));
        fole1.Close();
        using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt"), true))
        {
            for (int i = 0; i < all; i++)
            {
                string output = "";
                if (updated[i, 0] != null && updated[i, 0] != "")
                {
                    for (int j = 0; j < 8; j++)
                    {
                        output += updated[i, j] + "|";
                    }
                    sw.WriteLine(output);
                }

            }
            sw.Close();
        }
        Start();
    }


    protected int Show()
    {
        int picked;


        if (DropDownList1.Text == "100")
        {
            picked = 100;
        }
        else if (DropDownList1.Text == "500")
        {
            picked = 500;
        }
        else
        {
            picked = CountParts();
        }

        return picked;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        showing = Show();
        Start();
        BindData();
    }

    protected void Sbut_Click(object sender, EventArgs e)
    {
        Search();
        BindData();
    }

    protected void Search()
    {
        total = CountParts();
        needs = new string[total, 8];
        display = new string[total, 8];

        string[] split = new string[8];
        StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt"));
        string line;
        for (int i = 0; i < total; i++)
        {


            line = SR.ReadLine();
            if (line != null)
            {
                split = line.Split('|');
                int m = 0;
                if (split.Length > 8)
                    m = 8;
                else
                    m = split.Length;
                for (int j = 0; j < m; j++)
                {
                    needs[i, j] = split[j];
                }
                split = new string[8];

                //needs = (string[,])Session["nest"];

            }

        }
        SR.Close();


        string[] open = new string[(total)];
        for (int i = 0; i < total; i++)
        {
            if (needs[i, 0] != null)
            {
                open[i] = needs[i, 0];
            }
        }

        System.Array.Sort(open);
        display = new string[total, 8];
        int p = 0;
        int n = open.Length - 1;
        while (n > -1)
        {
            if (open[n] != null)
            {
                for (int h = total - 1; h > -1; h--)
                {
                    if (open[n] == needs[h, 0])
                    {
                        for (int q = 0; q < 8; q++)
                        {
                            display[p, q] = needs[h, q];
                        }
                        needs[h, 0] = "";

                        p++;
                    }


                }
            }
            n = n - 1;
        }


        string check = sBox.Text;
        int o = 0;
        for (int k = 0; k < (display.Length / 8); k++)
        {
            if (display[k, 0] != null)
            {
                for (int z = 0; z < 8; z++)
                {
                    if (display[k, z].ToLower().Contains(check.ToLower()))
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            found[o, j] = display[k, j];
                        }
                        o++;
                        break;
                    };
                }


                //for (p = 0; p < 8; p++)
                //{
                //   if (check[p] != null)
                //    {
                //       if (check[p].ToLower().Contains(sBox.Text.ToLower()))
                //       {
                //           for (int j = 0; j < 8; j++)
                //           {
                //              found[o, j] = display[k, j];
                //           }
                //           o++;
                //           break;
                //       }
                //    }

                //}

            }

        }
        loadTable(found);
    }
}




