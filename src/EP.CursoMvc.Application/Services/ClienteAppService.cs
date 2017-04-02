using AutoMapper;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Interfaces.Services;
using EP.CursoMvc.Domain.Model;
using EP.CursoMvc.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace EP.CursoMvc.Application.Services
{
    public class ClienteAppService : AppService, IClienteAppService
    {

        private readonly IClienteRepository _clienteRepository;

        private readonly IClienteService _clienteService;



        public ClienteAppService(IClienteRepository clienteRepository ,
                                IClienteService clienteService, 
                                IUnitOfWork uow):base(uow)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {

            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);

            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);


            cliente.Enderecos.Add(endereco);

            var clienteReturn = _clienteService.Adicionar(cliente);

            //Validar ser o dominio nao reclamou de nada!
            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            clienteEnderecoViewModel.Cliente = Mapper.Map<ClienteViewModel>(clienteReturn);

            return clienteEnderecoViewModel;

        }

        public IEnumerable<ClienteViewModel> obterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {

            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            var clienteReturn = _clienteService.Atualizar(cliente);

            return Mapper.Map<ClienteViewModel>(clienteReturn);
        }

        public void Dispose()
        {

            _clienteRepository.Dispose();
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {

            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map <IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {

            _clienteService.Remover(id);

        }
    }
}
