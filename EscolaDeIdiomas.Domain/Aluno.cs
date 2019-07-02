using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaDeIdiomas.Domain
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<AlunoTurma> AlunoTurmas { get; set; }
    }
}
