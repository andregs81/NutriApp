using Dapper;
using Microsoft.EntityFrameworkCore;
using NutriApp.Data.Interfaces;
using NutriApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriApp.Data.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public PacienteRepository(NutriAppContext context) : base(context)
        {
            
        }

        public override IEnumerable<Paciente> GetAll()
        {
            var sql = @"SELECT * FROM PACIENTE(NOLOCK)";
            return Db.Database.GetDbConnection().Query<Paciente>(sql);
        }

        public override Paciente GetById(int id)
        {
            var sql = @"SELECT * " +
                        "FROM PACIENTE P(NOLOCK) " +
                        "LEFT JOIN ENDERECO E(NOLOCK) " +
                        "ON E.IDPACIENTE = P.IDPACIENTE " +
                        "WHERE P.idPaciente = @uid ";

            var paciente = Db.Database.GetDbConnection().Query<Paciente, Endereco, Paciente>(sql,
                (p, e) =>
                {
                    if (e != null)
                        p.Endereco = e;
                    return p;
                }, new {uid = id},
                splitOn: "idPaciente");

            return paciente.FirstOrDefault();
        }
    }
}
