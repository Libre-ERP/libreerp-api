namespace Libre_ERP_API.DTO_s
{
    public class GetProductResponse
    {
        public IReadOnlyList<GetProductDTO> ProductList { get; init; } = new List<GetProductDTO>();
        public BaseResponse error { get; set; } = new BaseResponse();
    }

    public readonly record struct GetProductDTO(
        int IDProduct,
        string Name,
        int? Stock,
        decimal Price,
        int MinStock
    );
}

