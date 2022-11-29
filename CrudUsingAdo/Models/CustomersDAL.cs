using System.Data.SqlClient;
namespace CrudUsingAdo.Models
{
    public class CustomersDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public CustomersDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int CustomerRegister(Customers cust)
        {
            string qry = "insert into customers values(@name,@email,@contact,@pass)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", cust.Name);
            cmd.Parameters.AddWithValue("@email", cust.Email);
            cmd.Parameters.AddWithValue("@contact", cust.Contact);
            cmd.Parameters.AddWithValue("@Pass", cust.Password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public Customers CustomerLogin(Customers cust)
        {
            Customers c = new Customers();
            string qry = "select * from Customers where email=@email and password=@pass";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", cust.Email);
            cmd.Parameters.AddWithValue("@Pass", cust.Password);
            con.Open();
            dr=cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    c.Id=Convert.ToInt32(dr["Id"]);
                    c.Name=dr["name"].ToString();
                    c.Email=dr["email"].ToString();
                }
                return c;
            }
            else
            {
                return null;
            }
        }
    }
}


