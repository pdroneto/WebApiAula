using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApi.Models
{
    public class Alunos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public int ra{ get; set; }

        public List<Alunos> ListaAlunos()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaAlunos = JsonConvert.DeserializeObject<List<Alunos>>(json);

            return listaAlunos;
        }
        public bool ReescreverArquivo(List<Alunos> listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\base.json");
            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
            return true;

        }
        public Alunos Inserir(Alunos Aluno)
        {
            var ListaAlunos = this.ListaAlunos();
            var maxId = ListaAlunos.Max(aluno => aluno.id);
            Aluno.id = maxId + 1;
            ListaAlunos.Add(Aluno);
            ReescreverArquivo(ListaAlunos);
            return Aluno;

        }
        public Alunos Atualizar(int id, Alunos Aluno)
        {
            var ListaAlunos = this.ListaAlunos();
            var itemIndex = ListaAlunos.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                Aluno.id = id;
                ListaAlunos[itemIndex] = Aluno;

            }
            else
            {
                return null;
            }
            ReescreverArquivo(ListaAlunos);
            return Aluno;
        }
        public bool Deletar(int id)
        {
            var ListaAlunos = this.ListaAlunos();
            var itemIndex = ListaAlunos.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                ListaAlunos.RemoveAt(itemIndex);

            }
            else
            {
                return false;
            }
            ReescreverArquivo(ListaAlunos);
            return true;
        }
    }
}