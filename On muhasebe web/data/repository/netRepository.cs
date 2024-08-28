using On_muhasebe_web.Business;
using System.Data;
using System.Data.SqlClient;
namespace On_muhasebe_web.data.repository
{
    public interface INetRepository
    {
        IEnumerable<netkayit> GetNetKayitlari();
        int Inserttarih(tarih kayit);
     
    }
    public class netRepository : INetRepository
    {
        private readonly string _connectionString;

        public netRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IEnumerable<netkayit> GetNetKayitlari()
        {
            var kayitlar = new List<netkayit>();
            var con = new SqlConnection(_connectionString);
            con.Open();
            var cmd = new SqlCommand("SELECT * FROM netD2", con);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
                kayitlar.Add(new netkayit
                {
                    id = (int)reader["id"],
                    SorguTarihi = (DateTime)reader["SorguTarihi"],
                    ToplamGelir= int.Parse(reader["ToplamGelir"].ToString()),
                    ToplamGider=int.Parse(reader["ToplamGider"].ToString()),
                    Net= int.Parse(reader["Net"].ToString())
,
                });
            return kayitlar;
        }
        public int Inserttarih(tarih kayit) 
        {
            SqlCommand cmd;
            var con = new SqlConnection(_connectionString);
            DateTime startdate = kayit.StartDate ;
            DateTime enddate=kayit.EndDate;
            int toplamGelir = 0;
            int toplamGider = 0;
            con.Open();
            cmd = new SqlCommand("SELECT SUM(deger) toplamGelir from gelirkayitD2 WHERE tarih BETWEEN @startdate AND @enddate", con);
            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            toplamGelir = (int)cmd.ExecuteScalar();

            SqlCommand cmd2 = new SqlCommand("SELECT SUM(deger) toplamGider from giderkayitD2 WHERE tarih BETWEEN @startdate AND @enddate", con);
            cmd2.Parameters.AddWithValue("@startdate", startdate);
            cmd2.Parameters.AddWithValue("@enddate", enddate);
            toplamGider = (int)cmd2.ExecuteScalar();

            int net = toplamGelir - toplamGider;
            SqlCommand cmd3 = new SqlCommand("INSERT INTO netD2 (SorguTarihi, ToplamGelir, ToplamGider, Net) VALUES (@Tarih, @ToplamGelir, @ToplamGider, @Net)", con);
            cmd3.Parameters.AddWithValue("@Tarih", DateTime.Now);
            cmd3.Parameters.AddWithValue("@ToplamGelir", toplamGelir);
            cmd3.Parameters.AddWithValue("@ToplamGider", toplamGider);
            cmd3.Parameters.AddWithValue("@Net", net);
            cmd3.ExecuteNonQuery();
            return net;


        }

        }
    }
   


