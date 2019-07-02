using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaDeIdiomas.Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<Turma> Turmas { get; set; }
    }
}
