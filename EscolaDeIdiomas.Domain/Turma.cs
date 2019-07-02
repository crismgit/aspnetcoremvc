using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaDeIdiomas.Domain
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Idioma { get; set; }
        public string Nivel { get; set; }
        public string Periodo { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoTurma> AlunoTurmas { get; set; }
    }
}
