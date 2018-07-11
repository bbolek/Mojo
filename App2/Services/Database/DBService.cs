using System;
using System.Collections.Generic;
using System.Data;
using App2.model;
using Npgsql;

namespace App2.Services.Database
{

    public class DBService
    {
        private static DBService _instance;
        public static DBService Instance => _instance ?? (_instance = new DBService());

        private const string CONNECTION_STRING = "Host=localhost;Username=postgres;Password=root;Database=mojo";

        public NpgsqlConnection getConnection()
        {
            return new NpgsqlConnection(CONNECTION_STRING);
        }

        public void InsertMojo(Mojo mojo)
        {
            using (var conn = new NpgsqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    var command = GenerateInsertCommand(conn, mojo);
                    command?.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
/*
        public List<Mojo> queryMojo(String query)
        {
            using (var conn = new NpgsqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    var command = GenerateInsertCommand(conn, mojo);
                    command?.ExecuteReader();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }*/
        
        private IDbCommand GenerateInsertCommand(NpgsqlConnection conn, Mojo mojo)
        {
            if (mojo == null)
            {
                return null;
            }
            IDbCommand command = conn.CreateCommand();
            var sql = "INSERT INTO public." + mojo.mojoType + "( ";
            if (mojo.attributes == null || mojo.attributes.Count <= 0) return null;
            foreach (var entry in mojo.attributes)
            {
                sql += entry.Key + ", ";
            }
            sql = sql.Remove(sql.Length -2, 1) + ") VALUES (";
                
            foreach (var entry in mojo.attributes)
            {
                sql += "@"+entry.Key + ", ";
                var parameter = command.CreateParameter();
                parameter.ParameterName = entry.Key;
                parameter.DbType = DbType.String;
                parameter.Value =  entry.Value.value;
                command.Parameters.Add(parameter);
            }
            sql = sql.Remove(sql.Length -2, 1) + ")";
            command.CommandText = sql;

            return command;
        }
    }
}