using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRemote;
using MySql.Data.MySqlClient;

namespace Serveur
{
    class ImplBibliothecaire : MarshalByRefObject , IBibliothecaire , IEmprunteur
    {

        MySqlConnection MySqlConnection = new MySqlConnection();
        String connection_string = "server=localhost;database=poc;UserId=root";
        MySqlCommand mySqlCommand = new MySqlCommand();
        public ImplBibliothecaire()
        {
            
            MySqlConnection.ConnectionString = connection_string;
            
        }

        public bool ajouter_ouvrage(Ouvrage ouvrage)
        {
            try
            {
                string commande = String.Format("insert into ouvrage values ( '{0}' , '{1}' , '{2}' , '{3}' , '{4}' , '{5}')", ouvrage.getCode_ouvrage(), ouvrage.getTitre(), ouvrage.getAuteurs(), ouvrage.getTheme(), ouvrage.getType(), ouvrage.getMots_cle());
                mySqlCommand.Connection = MySqlConnection;
                mySqlCommand.CommandText = commande;
                MySqlConnection.Open();

                int i = mySqlCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception e)
            {
                return false;
            }
            Console.ReadLine();
            MySqlConnection.Close();
            
                
        }

        public bool authentification(Compte compte)
        {
            try
            {
                string commande = String.Format("select * from compte where user = '"+compte.getUsername()+"'");
                mySqlCommand.Connection = MySqlConnection;
                mySqlCommand.CommandText = commande;
                MySqlConnection.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while(mySqlDataReader.Read())
                {
                    if (compte.getUsername() == mySqlDataReader["user"].ToString() && compte.getMot_de_passe() == mySqlDataReader["passe"].ToString())
                    {
                        return true;
                    }
                                       
                }
                return false;
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                
            }
            Console.ReadLine();
            MySqlConnection.Close();
        }

        public ArrayList consulte()
        {
            throw new NotImplementedException();
        }

        public Ouvrage modifier_ouvrage(int id_ouvrage)
        {
            throw new NotImplementedException();
        }

        public ArrayList recherche_auteur(string auteur)
        {
            throw new NotImplementedException();
        }

        public ArrayList recherche_mot_cle(string mot_cle)
        {
            throw new NotImplementedException();
        }

        public ArrayList recherche_theme(string theme)
        {
            throw new NotImplementedException();
        }

        public ArrayList recherche_titre(string titre)
        {
            throw new NotImplementedException();
        }

        public bool supprimer_ouvrage(int id_ouvrage)
        {
            throw new NotImplementedException();
        }
    }
}
