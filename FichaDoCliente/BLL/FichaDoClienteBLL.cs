using FichaDoCliente.DAO;
using FichaDoCliente.DTO;

namespace FichaDoCliente.BLL
{
    public class FichaDoClienteBLL
    {
        FichaDoClienteDAO dao = new FichaDoClienteDAO();
        int retornoFicha = 0;

        
        public FichaClienteDTO retornaFichaClienteCPF(String CPF)
        {

            FichaClienteDTO fichaClienteDTO = dao.retornaFichaCliente(CPF);
            return fichaClienteDTO;
        }

        public String insereFichaDoCliente(FichaClienteDTO fichaClienteDTO)
        {
            retornoFicha = 0;
                 if (fichaClienteDTO != null)
            {
                retornoFicha = dao.insereFichaCliente(fichaClienteDTO);
            }
         


            return retornoFicha == 1 ? "Cadastro realizado com sucesso" : "Não foi possível cadastrar ficha";
        }



        public String deletaFichaDoCliente(String CPF)
        {
            retornoFicha = 0;


            if (CPF != null)
            {
                retornoFicha = dao.deletaFichaCliente(CPF);



            }

            return retornoFicha == 1 ? "Dados deletados com sucesso" : "Não foi possível deletar ficha";
        }

        public String alteraFichaDoCliente(FichaClienteDTO fichaClienteDTO)
        {
            retornoFicha = 0;

            retornoFicha = dao.alteraFichaCliente(fichaClienteDTO);

            return retornoFicha == 1 ? "Alteração realizada com sucesso" : "Não foi possível alterar ficha";
        }
    }
}
