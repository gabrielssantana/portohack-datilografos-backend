namespace API.DTO
{
    public class Response
    {
        public bool Sucesso { get; set; }
        public List<string> Mensagens { get; set; } = new();
    }
    public class Response<T> : Response
    {
        public T? Dados { get; set; }
    }
}