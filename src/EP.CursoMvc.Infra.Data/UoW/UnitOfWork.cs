using EP.CursoMvc.Infra.Data.Context;
using EP.CursoMvc.Infra.Data.Interfaces;

namespace EP.CursoMvc.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CursoMvcContext _context;


        public UnitOfWork(CursoMvcContext cursoMvcContext)
        {
            _context = cursoMvcContext;
        }

        public void Commit()
        {

            _context.SaveChanges();
        }
    }
}
