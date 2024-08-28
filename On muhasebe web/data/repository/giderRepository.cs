using On_muhasebe_web.Business;
using System.Data.SqlClient;
namespace On_muhasebe_web.data.repository
{
    public interface IGiderRepository
    {
        IEnumerable<giderkayit> GetGiderKayitlari();
        void InsertGiderKayit(giderkayit kayit);
        void UpdateGiderKayit(giderkayit kayit);
        void DeleteGiderKayit(int id);
    }

    public class GiderRepository : IGiderRepository
    {
        private readonly string _connectionString;

        public GiderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<giderkayit> GetGiderKayitlari()
        {
            var kayitlar = new List<giderkayit>();
            var con = new SqlConnection(_connectionString);
            con.Open();
            var cmd = new SqlCommand("SELECT * FROM giderkayitD2", con);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
                kayitlar.Add(new giderkayit
                {
                    id = (int)reader["id"],
                    ad = reader["ad"].ToString(),
                    miktar = int.Parse(reader["miktar"].ToString()),
                    deger = int.Parse(reader["deger"].ToString()),
                    tarih = (DateTime)reader["tarih"]
                });
            return kayitlar;
        }
        public void InsertGiderKayit(giderkayit kayit)
        {
            var con = new SqlConnection(_connectionString);

            con.Open();
            var cmd = new SqlCommand("INSERT INTO giderkayitD2 (ad, miktar, deger, tarih) VALUES (@Ad, @Miktar, @Deger, @Tarih)", con);

            cmd.Parameters.AddWithValue("@Ad", kayit.ad);
            cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
            cmd.Parameters.AddWithValue("@Deger", kayit.deger);
            cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
            cmd.ExecuteNonQuery();
        }

        public void UpdateGiderKayit(giderkayit kayit)
        {
            var con = new SqlConnection(_connectionString);

            con.Open();
            var cmd = new SqlCommand("UPDATE giderkayitD2 SET ad=@Ad, miktar=@Miktar, deger=@Deger, tarih=@Tarih WHERE id=@Id", con);

            cmd.Parameters.AddWithValue("@Id", kayit.id);
            cmd.Parameters.AddWithValue("@Ad", kayit.ad);
            cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
            cmd.Parameters.AddWithValue("@Deger", kayit.deger);
            cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
            cmd.ExecuteNonQuery();
        }

        public void DeleteGiderKayit(int id)
        {
            var con = new SqlConnection(_connectionString);

            con.Open();
            var cmd = new SqlCommand("DELETE FROM gelirkayitD2 WHERE id=@Id", con);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
