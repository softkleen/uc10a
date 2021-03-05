using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;


namespace escolauc10a.Class
{
    public class Aluno
    {
        // construtores
        public Aluno(){}
        public Aluno(string nome, string email, string senha) 
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public Aluno(int id,string nome, string email, string senha, bool ativo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
        }
        // propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        // métodos de negócio (inserir/alterar...)
        public List<Aluno> ObterAlunos()
        {
            List<Aluno> lista = new List<Aluno>();
            // recheio... 
            var cmd = Banco.Abrir();
            if (cmd.Connection.State==ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from alunos";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Aluno(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetBoolean(4)
                        )
                    );
                }
            }
            return lista;
        }//final de método obterAlunos
        public void Inserir()
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandText = "insert alunos (nome, email, senha, ativo)" +
                    " values ('"+Nome+"','"+Email+"',md5('"+Senha+"'), default)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select @@identity";
                Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            cmd.Connection.Close(); // PDO
        }// final do método inserir
        public bool Atualizar() 
        {
            bool alterado = false;
            try
            {
                var ativo = (Ativo) ? 1 : 0;
                var cmd = Banco.Abrir();
                cmd.CommandText = "update alunos set nome = '"+Nome
                +"',senha = md5('"+Senha+"'), ativo = " + ativo + 
                " where id= " + Id;
                var i = cmd.ExecuteNonQuery();
                alterado = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return alterado;
        }// final do método
        public void BuscarPorId(int id)
        {
            var cmd = Banco.Abrir();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from alunos where id = "+ id;
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {                                      
                    Nome =  dr.GetString(1);
                    Email = dr.GetString(2);
                    Ativo =  dr.GetBoolean(4);                      
                }
            }
        }
    }
}
