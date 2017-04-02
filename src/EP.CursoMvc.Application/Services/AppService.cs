using EP.CursoMvc.Infra.Data.Interfaces;

namespace EP.CursoMvc.Application.Services
{
    public abstract class AppService
    {

        private readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {

            _uow.Commit();
        }
    }
}
