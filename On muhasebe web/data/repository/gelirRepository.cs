using On_muhasebe_web.Business;
using System.Data;
using System;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace On_muhasebe_web.data.repository
{
    public interface IGelirRepository
    {
        IEnumerable<gelirkayit> GetGelirKayitlari();
        void InsertGelirKayit(gelirkayit kayit);
        void UpdateGelirKayit(gelirkayit kayit);
        void DeleteGelirKayit(int id);
    }

    public class GelirRepository : IGelirRepository
    {
        private readonly string _connectionString;

        public GelirRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<gelirkayit> GetGelirKayitlari()
        {
            var kayitlar = new List<gelirkayit>();
            var con = new SqlConnection(_connectionString);           
            con.Open();
            var cmd = new SqlCommand("SELECT * FROM gelirkayitD2", con);

            var reader = cmd.ExecuteReader();
                    
                        while (reader.Read())                       
                            kayitlar.Add(new gelirkayit
                            {
                                id = (int)reader["id"],
                                ad = reader["ad"].ToString(),
                                miktar = int.Parse(reader["miktar"].ToString()),
                                deger = int.Parse(reader["deger"].ToString()),
                                tarih = (DateTime)reader["tarih"]
                            });                                                                        
            return kayitlar;
        }
        public void InsertGelirKayit(gelirkayit kayit)
        {
            var con = new SqlConnection(_connectionString);
            
            con.Open();
            var cmd = new SqlCommand("INSERT INTO gelirkayitD2 (ad, miktar, deger, tarih) VALUES (@Ad, @Miktar, @Deger, @Tarih)", con);
                
                    cmd.Parameters.AddWithValue("@Ad", kayit.ad);
                    cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
                    cmd.Parameters.AddWithValue("@Deger", kayit.deger);
                    cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
                    cmd.ExecuteNonQuery();
                
            
        }

        public void UpdateGelirKayit(gelirkayit kayit)
        {
            var con = new SqlConnection(_connectionString);
            
            con.Open();
            var cmd = new SqlCommand("UPDATE gelirkayitD2 SET ad=@Ad, miktar=@Miktar, deger=@Deger, tarih=@Tarih WHERE id=@Id", con);
                
                    cmd.Parameters.AddWithValue("@Id", kayit.id);
                    cmd.Parameters.AddWithValue("@Ad", kayit.ad);
                    cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
                    cmd.Parameters.AddWithValue("@Deger", kayit.deger);
                    cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
                    cmd.ExecuteNonQuery();                          
        }

        public void DeleteGelirKayit(int id)
        {
            var con = new SqlConnection(_connectionString);
            
            con.Open();
            var cmd = new SqlCommand("DELETE FROM gelirkayitD2 WHERE id=@Id", con);
                
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                
            }
        }
    }
    /* public interface IGelirRepository
     {
         IEnumerable<gelirkayit> GelirKayitlari { get; }

         void InsertGelirKayit(gelirkayit kayit);
         void UpdateGelirKayit(gelirkayit kayit);
         void DeleteGelirKayit(int id);
     }
     public interface IGiderRepository
     {
         IEnumerable<giderkayit> GiderKayitlari { get; }

         void InsertGiderKayit(giderkayit kayit);
         void UpdateGiderKayit(giderkayit kayit);
         void DeleteGiderKayit(int id);
     }


     public class gelirRepository : IGelirRepository
     {
         private readonly string _conString;

         public gelirRepository(IConfiguration configuration)
         {
             _conString = configuration.GetConnectionString("DefaultConnection");
         }

         public IEnumerable<gelirkayit> GetGelirKayitlari()
         {
             var kayitlar = new List<gelirkayit>();

             var con = new SqlConnection(_conString);
             con.Open();

             var cmd = new SqlCommand("SELECT * FROM gelirkayitD2", con);

             var reader = cmd.ExecuteReader();

              while (reader.Read())
              {
                 kayitlar.Add(new gelirkayit
                 {
                    id = (int)reader["id"],
                    ad = reader["ad"].ToString(),
                    miktar = (int)reader["miktar"],
                    deger = (int)reader["deger"],
                    tarih = (DateTime)reader["tarih"]
                 });
              }
             return kayitlar;
         }
         public void InsertGelirKayit(gelirkayit kayit)
         {
            var con = new SqlConnection(_conString);          
            con.Open();
            var cmd = new SqlCommand("INSERT INTO gelirkayitD2 (Ad, Miktar, Deger, Tarih) VALUES (@Ad, @Miktar, @Deger, @Tarih)", con);

            cmd.Parameters.AddWithValue("@Ad", kayit.ad);
            cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
            cmd.Parameters.AddWithValue("@Deger", kayit.deger);
            cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
            cmd.ExecuteNonQuery();                          
         }
         public void UpdateGelirKayit(gelirkayit kayit)
         {
           var con = new SqlConnection(_conString);

            con.Open();
            var cmd = new SqlCommand("UPDATE gelirkayitD2 SET Ad=@Ad, Miktar=@Miktar, Deger=@Deger, Tarih=@Tarih WHERE Id=@Id", con);

            cmd.Parameters.AddWithValue("@Id", kayit.id);
            cmd.Parameters.AddWithValue("@Ad", kayit.ad);
            cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
            cmd.Parameters.AddWithValue("@Deger", kayit.deger);
            cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
            cmd.ExecuteNonQuery();          
         }
         public void DeleteGelirKayit(int id)
         {
             var con = new SqlConnection(_conString);

             con.Open();
             var cmd = new SqlCommand("DELETE FROM gelirkayitD2 WHERE Id=@Id", con);
             cmd.Parameters.AddWithValue("@Id", id);
             cmd.ExecuteNonQuery();                            
         }

     }

     public class giderRepository : IGiderRepository
     {
         public class GiderRepository : IGelirRepository
         {
             private readonly string _conString;

             public GiderRepository(IConfiguration configuration)
             {
                 _conString = configuration.GetConnectionString("DefaultConnection");
             }

             public IEnumerable<giderkayit> GetGiderKayitlari()
             {
                 var kayitlar = new List<giderkayit>();

                 var con = new SqlConnection(_conString);
                 con.Open();

                 var cmd = new SqlCommand("SELECT * FROM giderkayitD2", con);

                 var reader = cmd.ExecuteReader();

                 while (reader.Read())
                 {
                     kayitlar.Add(new giderkayit
                     {
                         id = (int)reader["id"],
                         ad = reader["ad"].ToString(),
                         miktar = (int)reader["miktar"],
                         deger = (int)reader["deger"],
                         tarih = (DateTime)reader["tarih"]
                     });
                 }
                 return kayitlar;
             }
             public void InsertGiderKayit(giderkayit kayit)
             {
                 var con = new SqlConnection(_conString);
                 con.Open();
                 var cmd = new SqlCommand("INSERT INTO giderkayitD2 (Ad, Miktar, Deger, Tarih) VALUES (@Ad, @Miktar, @Deger, @Tarih)", con);

                 cmd.Parameters.AddWithValue("@Ad", kayit.ad);
                 cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
                 cmd.Parameters.AddWithValue("@Deger", kayit.deger);
                 cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
                 cmd.ExecuteNonQuery();
             }
             public void UpdateGiderKayit(giderkayit kayit)
             {
                 var con = new SqlConnection(_conString);
                 con.Open();
                 var cmd = new SqlCommand("UPDATE giderkayitD2 SET Ad=@Ad, Miktar=@Miktar, Deger=@Deger, Tarih=@Tarih WHERE Id=@Id", con);
                 cmd.Parameters.AddWithValue("@Id", kayit.id);
                 cmd.Parameters.AddWithValue("@Ad", kayit.ad);
                 cmd.Parameters.AddWithValue("@Miktar", kayit.miktar);
                 cmd.Parameters.AddWithValue("@Deger", kayit.deger);
                 cmd.Parameters.AddWithValue("@Tarih", kayit.tarih);
                 cmd.ExecuteNonQuery();
             }
             public void DeletegiderKayit(int id)
             {
                 var con = new SqlConnection(_conString);
                 con.Open();
                 var cmd = new SqlCommand("DELETE FROM giderkayitD2 WHERE Id=@Id", con);
                 cmd.Parameters.AddWithValue("@Id", id);
                 cmd.ExecuteNonQuery();
             }
         }

     }*/


