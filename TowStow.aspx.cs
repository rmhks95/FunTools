using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{

    static string[,] options = new string[24, 5] {{"TS10033B", "2in x 2 5/16in",  "3in Drop", "3 1/2in Rise", "2in"},
 {"TS10035B", "1 7/8in x 2in", "3in Drop", "3 1/2in Rise", "2in"},
 {"TS10047B", "1 7/8in x 2in x 2 5/16in", "3in Drop", "3 1/2in Rise", "2in"},
 {"TS10037B", "2in x 2 5/16in", "5in Drop", "5 1/2in Rise", "2in"},
 {"TS10038B", "1 7/8in x 2in", "5in Drop", "5 1/2in Rise", "2in"},
 {"TS10048B", "1 7/8in x 2in x 2 5/16in", "5in Drop", "5 1/2in Rise", "2in"},
 {"TS10040B", "2in x 2 5/16in", "7in Drop", "7 1/2in Rise", "2in"},
 {"TS10049B", "1 7/8in x 2in x 2 5/16in", "7in Drop", "7 1/2in Rise", "2in"},
 {"TS10043B", "2in x 2 5/16in", "9in Drop", "9 1/2in Rise", "2in"},
 {"TS10050B", "1 7/8in x 2in x 2 5/16in", "9in Drop", "9 1/2in Rise", "2in"},
 {"TS20037B", "2in x 2 5/16in", "5in Drop", "4 1/2in Rise", "2.5in"},
 {"TS20048B", "1 7/8in x 2in x 2 5/16in", "5in Drop", "4 1/2in Rise", "2.5in"},
 {"TS20040B", "2in x 2 5/16in", "7in Drop", "7 1/2in Rise", "2.5in"},
 {"TS20049B", "1 7/8in x 2in x 2 5/16in", "7in Drop", "7 1/2in Rise", "2.5in"},
 {"TS10033C", "2in x 2 5/16in","3in Drop", "3 1/2in Rise", "2in"},
 {"TS10047C", "1 7/8in x 2in x 2 5/16in", "3in Drop", "3 1/2in Rise", "2in"},
 {"TS10037C", "2in x 2 5/16in", "5in Drop", "5 1/2in Rise", "2in"},
 {"TS10048C", "1 7/8in x 2in x 2 5/16in", "5in Drop", "5 1/2in Rise", "2in"},
 {"TS10033BB", "2in x 2 5/16in", "3in Drop", "3 1/2in Rise", "2in"},
 {"TS10047BB", "1 7/8in x 2in x 2 5/16in", "3in Drop", "3 1/2in Rise", "2in"},
 {"TS10037BB", "2in x 2 5/16in", "5in Drop", "5 1/2in Rise", "2in"},
 {"TS10048BB", "1 7/8in x 2in x 2 5/16in", "5in Drop", "5 1/2in Rise", "2in"},
{"TS10055", "Pintle Hitch with 2in Ball", "8 1/2in Drop", "4 1/2in Rise", "2in" },
{"TS10056", "Pintle Hitch with 2 5/16in Ball", "8 1/2in Drop", "4 1/2in Rise", "2in"} };
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        double diff;
        string[,] use = new string[24, 5];
        if (TrailHeight.Text != "" && TruckHeight.Text != "")
        {

            double Trailer = Convert.ToInt32(TrailHeight.Text);
            double Truck = Convert.ToDouble(TruckHeight.Text);
            int up = 0;

            if (Trailer < Truck)
            {
                diff = Truck - Trailer;
                
                if (diff <= 3)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (options[i, 2] == "3in Drop")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }
                            up++;
                        }
                    }
                }
                else if (diff <= 5)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (options[i, 2] == "5in Drop")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }

                            up++;
                        }
                    }

                }
                else if (diff <= 7)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (options[i, 2] == "7in Drop")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }

                            up++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (diff <= 8.5)
                            if (options[i, 2] == "8 1/2in Drop")
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    use[up, j] = options[i, j];
                                }

                                up++;
                            }
                        if (options[i, 2] == "9in Drop")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }

                            up++;
                        }
                    }
                }

            }
            else
            {
                diff = Trailer - Truck;


                if (diff <= 3.5)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (options[i, 3] == "3 1/2in Rise")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }

                            up++;
                        }
                    }
                }
                else if (diff <= 5.5)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if(diff <= 4.5)
                        {
                            if (options[i, 3] == "4 1/2in Rise")
                                {
                                    for (int j = 0; j < 5; j++)
                                    {
                                        use[up, j] = options[i, j];
                                    }

                                    up++;
                                }
                        }
                        if (options[i, 3] == "5 1/2in Rise")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }

                            up++;
                        }
                    }
                }
                else if (diff <= 7.5)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (options[i, 3] == "7 1/2in Rise")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }

                            up++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (options[i, 3] == "9 1/2in Rise")
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                use[up, j] = options[i, j];
                            }

                            up++;
                        }
                    }
                }
            }


            if (use[0, 0] != null)
            {
                DataTable dt2 = new DataTable("test");

                // DataColumn you can use constructor DataColumn(name,type);
                DataColumn dc0 = new DataColumn("  Part Number  ");
                DataColumn dc1 = new DataColumn("  Ball Size  ");
                DataColumn dc2 = new DataColumn("  Drop Adjustment  ");
                DataColumn dc3 = new DataColumn("  Rise Adjustment  ");
                DataColumn dc4 = new DataColumn("  Shank  ");

                dt2.Columns.Add(dc0);
                dt2.Columns.Add(dc1);
                dt2.Columns.Add(dc2);
                dt2.Columns.Add(dc3);
                dt2.Columns.Add(dc4);






                for (int i = 0; i < 24; i++)
                {
                    if (use[i, 0] != null)
                    {

                        DataRow dr = dt2.NewRow();
                        dr["  Part Number  "] = use[i, 0];
                        dr["  Ball Size  "] = use[i, 1];
                        dr["  Drop Adjustment  "] = use[i, 2];
                        dr["  Rise Adjustment  "] = use[i, 3];
                        dr["  Shank  "] = use[i, 4];
                        dt2.Rows.Add(dr);

                    }
                }

                Session["dt2"] = dt2;
                TSlist.DataSource = dt2;
                TSlist.DataBind();



            }
        }
    }


}