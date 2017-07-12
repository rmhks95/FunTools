using System;
using System.IO;
using System.Linq;
using System.Web.UI;

public partial class About : Page
{
    static int total;
    public static int i = 0;
    public static string[,] needs = new string[total,8];
    public static string[] current = new string[8];
    private int UpRD;

    //public static string[] Department = { "R & D", "PRODUCT PROTOTYPES", "ENGINEERING", "TESTING", "PRODUCTION EQUIMENT", "FIXTURES, JIGS, TOOLING", "SHOW INVENTORY", "MARKETING", "MAINTENANCE", "SAFETY", "QUALITY", "OTHER" };
    //public static string[] prodLine = { "", "FARM & RANCH", "BALLS", "BALL MOUNTS", "CAB PROTECTOR", "FLAT BED", "GOOSENECK", "JOB SHOP", "MOTORCYCLE LATCH", "RCVR HITCH", "RV", "GN COUPLER", "TOW/STOW", "BISON", "OTHER" };

    /// <summary>
    /// Main Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        total = CountParts();

        needs = new string[total, 8];
        if (!Page.IsPostBack)
        {
            current = new string[8];
            
        }
    }

    /// <summary>
    /// Finds How many parts exist
    /// </summary>
    /// <returns></returns>
    protected int CountParts()
    {
        int total = 0;
        total = total + File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt")).Count();
        return (total);
    }

    /// <summary>
    /// After everything is filled out
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        makeList();
        Session["part"] = current;
        Empty();
        
    }

  

    /// <summary>
    /// Empty's form
    /// </summary>
    protected void Empty()
    {
        Response.Redirect(Request.RawUrl);
        return;
    }

    /// <summary>
    /// Makes the list from the inputed information
    /// </summary>
    protected void makeList()
    {
        if (current[0] == null)
        {
            current[0] = DateTime.Now.ToString();
            current[1] = Name_Box.Text;
            current[2] = Phone_Box.Text;
            current[3] = Type_box.Text;
            current[4] = CSR_Box.Text;
            current[5] = Prod_Box.Text;
            current[6] = Sugg_Box.Text;
            
            
            updateList(current);
            //Session["nest"] = needs;
        }
       

    }

    /// <summary>
    /// Puts part in correct next location
    /// </summary>
    /// <param name="use"></param>
    protected void updateList(string[] use)
    {
            using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Suggestions.txt"), true))
            {

                string output = "";
                if (use[0] != null && use[0] != "")
                {
                    for (int j = 0; j < 8; j++)
                    {
                        output += use[j] + "|";
                    }
                    sw.WriteLine(output);
                }
                sw.Flush();
                sw.Close();
            }
        
    }







}
