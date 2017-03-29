using System.Web.Mvc;

namespace EP.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Log de auditoria
            //Usuario,Ip,ação, etc...

            if(filterContext.Exception != null)
            {

                // Manipular a Ex
                //Injetar alguma LIB de tratamento de erro
                // -> Gravar log do erro no BD
                // -> Email para o admin
                // -> Retornar cod de erro amigavel

                //Async sempre!!!!!!

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
               
            }

            base.OnActionExecuted(filterContext);

        }

    }
}
