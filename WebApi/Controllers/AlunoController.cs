using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        public List<Alunos> Get()
        {
            Alunos aluno = new Alunos();
            return aluno.ListaAlunos();
        }

        // GET: api/Aluno/5
        public Alunos Get(int id)
        {
            Alunos aluno = new Alunos();
            return aluno.ListaAlunos().Where(x => x.id ==id).FirstOrDefault();
        }

        // POST: api/Aluno
        public List<Alunos> Post(Alunos aluno)
        {
            Alunos _aluno = new Alunos();
            _aluno.Inserir(aluno);
            return _aluno.ListaAlunos();

        }

        // PUT: api/Aluno/5
        public List<Alunos> Put(int id, Alunos aluno)
        {
            Alunos _aluno = new Alunos();
            _aluno.Atualizar(id, aluno);
            return _aluno.ListaAlunos();

        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
            Alunos _aluno = new Alunos();
            _aluno.Deletar(id);
           

        }
    }
}
