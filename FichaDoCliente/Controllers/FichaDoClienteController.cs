using FichaDoCliente.BLL;
using FichaDoCliente.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FichaDoCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaDoClienteController : ControllerBase
    {


        FichaDoClienteBLL bll = new FichaDoClienteBLL();

        [HttpGet("{CPF}")]
        public FichaClienteDTO BuscaFichaPorCPF(String CPF)
        {


            FichaClienteDTO fichaClienteDTO = bll.retornaFichaClienteCPF(CPF);


            return fichaClienteDTO;
        }


        [HttpPost]
        public String Post(FichaClienteDTO fichaClienteDTO)
        {
            String retorno = bll.insereFichaDoCliente(fichaClienteDTO);

            return retorno;

        }

        [HttpPut]
        public String Put(FichaClienteDTO fichaClienteDTO)
        {
            String retorno = bll.alteraFichaDoCliente(fichaClienteDTO);
            return retorno;
        }


        [HttpDelete("{CPF}")]
        public String Delete(String CPF)
        {

            String retorno = bll.deletaFichaDoCliente(CPF);

            return retorno;
        }
    
}
}
