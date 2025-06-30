namespace Fiap.Api.Energy.ViewModel
{
    public class EquipamentoPaginacaoViewModel
    {
        public IEnumerable<EquipamentoViewModel> Equipamentos { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Equipamentos.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Equipamento?pagina={CurrentPage - 1}&amp;tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Equipamento?pagina={CurrentPage + 1}&amp;tamanho={PageSize}" : "";
    }

    public class EquipamentoPaginacaoReferenciaViewModel
    {
        public IEnumerable<EquipamentoViewModel> Equipamentos { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Equipamento?referencia={Ref}&amp;tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Equipamento?referencia={NextRef}&amp;tamanho={PageSize}" : "";
    }
}
