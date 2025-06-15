using Fiap.Api.Energy.ViewModel;
using Fiap.Api.Energy.Models;
namespace Fiap.Api.Energy.ViewModel
{
    public class ClientePaginacaoViewModel
    {
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Clientes.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Cliente?pagina={CurrentPage - 1}&amp;tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Cliente?pagina={CurrentPage + 1}&amp;tamanho={PageSize}" : "";
    }
    public class ClientePaginacaoReferenciaViewModel
    {
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Cliente?referencia={Ref}&amp;tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Cliente?referencia={NextRef}&amp;tamanho={PageSize}" : "";
    }
}