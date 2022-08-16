using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace OntarioOneCallChallange
{
    public partial class TincketInfo : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=OntarioOneCall;Integrated Security=True");
        SqlCommand cmd_parent, cmd_child;
        SqlDataAdapter adp_parent, adp_child;
        TreeNode master_node, member_node;

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            if (TreeView1.CheckedNodes.Count > 0)
            {

                foreach (TreeNode node in TreeView1.CheckedNodes)
                {
                    lbl_ParentChild.Text = node.Text;
                }
            }
            else
            {
                //CheckedNodes.Remove(e.Node.DataPath.ToString());
                //lbl_NodeDisplay.Text = "";
            }
        }

        protected void btn_populateTree_Click(object sender, EventArgs e)
        {
            TreeView1.Nodes.Clear();

            cmd_parent = new SqlCommand("select distinct MasterStationCode.master_station_code from ticketInfo, MasterStationCode where  ticketInfo.member_code = MasterStationCode.member_code order by MasterStationCode.master_station_code", con);

            try
            {
                adp_parent = new SqlDataAdapter(cmd_parent);
                DataTable dt = new DataTable();
                adp_parent.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["master_station_code"].ToString() == "OOCTEST15")
                    {

                        cmd_child = new SqlCommand("select top 12  MasterStationCode.member_code from ticketInfo, MasterStationCode where  ticketInfo.member_code = MasterStationCode.member_code and MasterStationCode.master_station_code='" + dr["master_station_code"].ToString() + "'  group by MasterStationCode.member_code", con);

                    }
                    else
                    {
                        cmd_child = new SqlCommand("select top 10  MasterStationCode.member_code from ticketInfo, MasterStationCode where  ticketInfo.member_code = MasterStationCode.member_code and MasterStationCode.master_station_code='" + dr["master_station_code"].ToString() + "'  group by MasterStationCode.member_code", con);
                    }

                    adp_child = new SqlDataAdapter(cmd_child);
                    DataTable child_dt = new DataTable();
                    adp_child.Fill(child_dt);
                    master_node = new TreeNode(dr["master_station_code"].ToString());

                    foreach (DataRow child_dr in child_dt.Rows)
                    {

                        member_node = new TreeNode();
                        member_node.Value = child_dr["member_code"].ToString();
                        master_node.ChildNodes.Add(member_node);
                    }

                    TreeView1.Nodes.Add(master_node);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void btn_ExitApp_Click1(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}